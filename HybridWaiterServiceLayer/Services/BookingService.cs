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
    public interface IBookingService : IServiceBase<BOOKING, DTO.Booking>
    {
        Task CreateBooking(Booking booking);
    }
    public class BookingService : ServiceBase<BOOKING, DTO.Booking>, IBookingService
    {
        IBookingRepository repository;
        IMapper mapper;
        public BookingService(IBookingRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task CreateBooking(Booking booking)
        {
            await repository.CreateBooking(mapper.Map<BOOKING>(booking));
        }


    }
}

