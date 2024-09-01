using HybridWaiterDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridWaiterDataLayer
{
    public class HybridWaiterModel : DbContext
    {

        public HybridWaiterModel(DbContextOptions<HybridWaiterModel> options) : base(options) 
        { 
        }

        public HybridWaiterModel()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //builder.UseSqlServer("data source=DESKTOP-FFKBJTO\\SQLEXPRESS;initial catalog=HybridWaiter;user id=shalhoub;password=P@ssw0rd;Trusted_Connection=True;Encrypt=False; MultipleActiveResultSets=true;");
                builder.UseSqlServer("data source=DESKTOP-FFKBJTO\\SQLEXPRESS;initial catalog=HybridWaiterSample;Integrated Security=True;TrustServerCertificate=True;Trusted_Connection=True;Encrypt=False;");
            }
        }


        public DbSet<CLIENT> CLients { get; set; }
        public DbSet<FEEDBACK> FeedBacks { get; set; }
        public DbSet<FOODMENU> FoodMenus { get; set; }
        public DbSet<POSITION> Positions { get; set; }
        public DbSet<SERVICELIST> ServiceLists { get; set; }
        public DbSet<TEAMMEMBER> TeamMembers { get; set; }
        public DbSet<LOOKUP_VALUE> LookupValues { get; set; }
        public DbSet<BANK> Banks { get; set; }
        public DbSet<ORDER> Orders { get; set; }
        public DbSet<ORDER_DETAIL> OrderDetails{ get; set; }
        public DbSet<BOOKING> Bookings { get; set; }




        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);

            #region Deletion Behavior

            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType? e in b.Model.GetEntityTypes())
            {
                // See: https://www.red-gate.com/simple-talk/blogs/change-delete-behavior-and-more-on-ef-core/
                e.GetForeignKeys().Where(key => !key.IsOwnership && key.DeleteBehavior == DeleteBehavior.Cascade).ToList().ForEach(key => key.DeleteBehavior = DeleteBehavior.NoAction);
            }

            #endregion Deletion Behavior
        }

    }//Ends Class
}
