using AutoMapper;
using HybridWaiterDataLayer.Models;
using HybridWaiterDataLayer.Repository;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.Services
{

    public interface IFoodMenuService : IServiceBase<FOODMENU, FoodMenu>
    {
        Task<IEnumerable<FoodMenu>> GetCategories();
        Task<IEnumerable<FoodMenu>> GetByCategory(int parentId);
        Task<IEnumerable<object>> GetMenuTable();
        //Task<FoodMenu> SaveItem(FoodMenu);


    }
    public class FoodMenuService : ServiceBase<FOODMENU, FoodMenu>, IFoodMenuService
    {
        IFoodMenuRepository repository;
        IMapper mapper;
        public FoodMenuService(IFoodMenuRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<FoodMenu>> GetCategories()
        {
            IEnumerable<FOODMENU> categories = await repository.GetCategories();
            return mapper.Map<IEnumerable<FoodMenu>>(categories);
        }

        public async Task<IEnumerable<FoodMenu>> GetByCategory(int parentId)
        {
            IEnumerable<FOODMENU> menus = await repository.GetByCategory(parentId);
            return mapper.Map<IEnumerable<FoodMenu>>(menus);
        }
        public async Task<IEnumerable<object>> GetMenuTable()
        {
            return await repository.GetMenuTable();
        }
        //public async Task<FoodMenu> SaveItem(FoodMenu)
        //{
        //    return await
        //}
    }
}
