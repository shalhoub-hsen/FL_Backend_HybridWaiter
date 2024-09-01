using HybridWaiterDataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Infrastructure;

namespace HybridWaiterAPI.Controllers
{
        public abstract class BaseController<TEntity, TDTO> : ControllerBase where TEntity : BASEENTITY where TDTO : BaseDTO<TEntity>
        {
            IServiceBase<TEntity, TDTO> _ServiceBase;
        ////private readonly Lazy<Task<PermissionModel>> _permissionModelLazy;
        public BaseController(IServiceBase<TEntity, TDTO> ServiceBase)
        {
            _ServiceBase = ServiceBase;
            //_permissionModelLazy = new Lazy<Task<PermissionModel>>(LoadPermissionModelAsync);
        }

        protected int UserID => int.Parse(FindClaim("ClientId"));





        /// <summary>
        /// Get one row of TEntity data by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<ActionResult> Get(int id)
        {
            var data = await _ServiceBase.Get(id);
            return Ok(data);
        }
        
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            List<TDTO> data = (await _ServiceBase.Get()).ToList();
            List<TDTO> result = data;
            if (data.Count > 0)
            {
                result = (from element in data
                          where element.GetType().GetProperty("IsDeleted") != null ? Convert.ToBoolean(element.GetType().GetProperty("IsDeleted").GetValue(element, null)) == false : true
                          select element).ToList();
            }

            return Ok(result);
        }

        private string FindClaim(string claimName)
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(claimName);
            if (claim == null)
            {
                return null;
            }
            return claim.Value;
        }

        ///// <summary>
        ///// Save/Update Data base on the Id of the TDTO (If 0 => Add, else if >0 => Update)
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //[HttpPost("Save")]
        //public async Task<ActionResult> Save([FromBody] TDTO entity)
        //{

        //    TDTO data = entity;
        //    long Id = Convert.ToInt64(entity.GetType().GetProperty("Id").GetValue(entity, null));
        //    if (permissionModel.canEdit && Id > 0 || permissionModel.canAdd && Id == 0)
        //    {
        //        data = await _ServiceBase.Save(entity, UserID, Id == 0);
        //        return Ok(data);
        //    }
        //    else return Ok();

        //}
        [HttpPost("Save")]

        public async Task<ActionResult> Save([FromBody] TDTO entity)
        {

            TDTO data = entity;
            bool isNew = entity.Id == 0;
            await _ServiceBase.Save(entity, isNew);
            
            //if (await this.Get(data.Id) != null)
            //{
            //    data = await _ServiceBase.Save(entity, false);
            //}
            //else
            //{
            //    data = await _ServiceBase.Save(entity, true);

            //}
            return Ok();
          

        }

        ///// <summary>
        ///// Attach new instance of TDTO by id and delete it
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            bool isOk = false;
            if (id > 0)
            {
                //data = await _ServiceBase.Get(id);
                //if (data == null)
                //{
                //    return NotFound();
                //}
                isOk = await _ServiceBase.Delete(id);
            }
            if(isOk) { return Ok(); }
            return NotFound();

        }
    }
}
