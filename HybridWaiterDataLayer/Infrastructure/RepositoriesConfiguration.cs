using HybridWaiterDataLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer.Infrastructure
{
    public static class RepositoriesConfiguration
    {
        public static void AddCustomRepositories(this IServiceCollection repositories)
        {
            repositories.AddTransient<IClientRepository, ClientRepository>();
            repositories.AddTransient<IFeedBackRepository, FeedBackRepository>();
            repositories.AddTransient<IFoodMenuRepository, FoodMenuRepository>();
            repositories.AddTransient<IPositionRepository, PositionRepository>();
            repositories.AddTransient<IServiceListRepository, ServiceListRepository>();
            repositories.AddTransient<ITeamMemberRepository, TeamMemberRepository>();
            repositories.AddTransient<ILookupValueRepository, LookupValueRepository>();
            repositories.AddTransient<IBankRepository, BankRepository>();
            repositories.AddTransient<IOrderRepository, OrderRepository>();
            repositories.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            repositories.AddTransient<IBookingRepository, BookingRepository>();



        }
    }
}
