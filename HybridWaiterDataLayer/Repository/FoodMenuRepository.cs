using HybridWaiterDataLayer.Infrastructure;
using HybridWaiterDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer.Repository
{
    public interface IFoodMenuRepository : IBaseRepository<FOODMENU>
    {
        Task<IEnumerable<FOODMENU>> GetByCategory(int parentId);
        Task<IEnumerable<FOODMENU>> GetCategories();
        Task<IEnumerable<object>> GetMenuTable();
        //Task<bool> SaveItem(FOODMENU item);
    }
    public class FoodMenuRepository : BaseRepository<FOODMENU>, IFoodMenuRepository
    {
        public FoodMenuRepository(HybridWaiterModel dataContext) : base(dataContext)
        {

        }
        public async Task<IEnumerable<FOODMENU>> GetByCategory(int parentId)
        {
            IEnumerable<FOODMENU> foodMenus = await this.dbContext.FoodMenus.Where(x => (x.IsDeleted == null || x.IsDeleted == false) &&
            x.ParentId == parentId).ToListAsync();
            return foodMenus;
        }

        public async Task<IEnumerable<FOODMENU>> GetCategories()
        {
            IEnumerable<FOODMENU> categories = await this.dbContext.FoodMenus.Where(x => (x.IsDeleted == null || x.IsDeleted == false) &&
            x.ParentId == null).ToListAsync();
            return categories;
        }
        public async Task<IEnumerable<object>> GetMenuTable()
        {
            var menuTable = await (from f1 in dbContext.FoodMenus
                                                     join f2 in dbContext.FoodMenus on f1.ParentId equals f2.Id
                                                     select new 
                                                     {
                                                         Id = f1.Id,
                                                         ParentId = f1.ParentId,
                                                         Category = f2.Name,
                                                         Name = f1.Name,
                                                         Price = f1.Price,
                                                         ImageURL = f1.ImageURL
                                                     }).ToListAsync();
            return menuTable;
        }
        //public async Task<bool> SaveItem(FOODMENU item)
        //{

        //    return true;
        //}
    }
}
