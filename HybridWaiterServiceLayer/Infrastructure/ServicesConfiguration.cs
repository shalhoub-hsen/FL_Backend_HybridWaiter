using HybridWaiterServiceLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterServiceLayer.Infrastructure
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IFeedBackService, FeedBackService>();
            services.AddTransient<IFoodMenuService, FoodMenuService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IServiceListService, ServiceListService>();
            services.AddTransient<ITeamMemberService, TeamMemberService>();
            services.AddTransient<ILookupValueService, LookupValueService>();
            services.AddTransient<IBankService, BankService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IBookingService, BookingService>();



        }
    }
}
