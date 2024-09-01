using AutoMapper;
using HybridWaiterDataLayer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace HybridWaiterServiceLayer.Infrastructure
{

    public interface  IServiceBase<TEntity, TDTO> where TDTO : class
    {
        Task<TDTO> Get(int id);
        Task<IEnumerable<TDTO>> Get();
        Task<TDTO> Save(TDTO obj, bool isNew);
        Task<bool> Delete(int id);
    }
        public abstract class ServiceBase<TEntity, TDTO> where TEntity : class
    {
        protected IBaseRepository<TEntity> Repository;
        IMapper mapper;
        protected ServiceBase(IBaseRepository<TEntity> _Repository, IMapper mapper)
        {
            this.Repository = _Repository;
            this.mapper = mapper;
        }
        public async Task<TDTO> Get(int id)
        {
            TEntity obj = await Repository.Get(id);
            return mapper.Map<TDTO>(obj);
        }
        public async Task<IEnumerable<TDTO>> Get()
        {
            IEnumerable<TEntity> lst = await Repository.Get();
            return mapper.Map <IEnumerable<TDTO>>(lst);
        }

        public  async Task<TDTO> Save(TDTO obj, bool isNew)
        {
            TEntity data = mapper.Map<TEntity>(obj);
            await Repository.Save(data, isNew);
            return mapper.Map<TDTO>(data);
        }
        public async Task<bool> Delete(int id)
        {
            //TEntity data = mapper.Map<TEntity>(obj);
             return await Repository.Delete(id);
        }

    }
}
