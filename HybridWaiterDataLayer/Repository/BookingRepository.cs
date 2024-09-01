using HybridWaiterDataLayer.Infrastructure;
using HybridWaiterDataLayer.Models;

namespace HybridWaiterDataLayer.Repository
{
    public interface IBookingRepository : IBaseRepository<BOOKING>
    {
       Task CreateBooking(BOOKING booking);
    }
    public class BookingRepository : BaseRepository<BOOKING>, IBookingRepository
    {
        public BookingRepository(HybridWaiterModel dataContext) : base(dataContext)
        {

        }

        public async Task CreateBooking(BOOKING booking)
        {
             dbContext.Bookings.Add(booking);

            await dbContext.SaveChangesAsync();
        }
    }
}
