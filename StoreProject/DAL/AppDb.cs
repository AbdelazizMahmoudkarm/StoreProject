using StoreProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace StoreProject.DAL
{
    /// <summary>
    /// The first class which responsable for any thing related to database
    /// </summary>
    public class AppDb: IdentityDbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }
        /// <summary>
        /// Use to add some important data to our database about the classes entity
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bill>().HasKey(c => new { c.BillId });
            builder.Entity<Customer>().HasKey(c => new { c.CustomerId });
            builder.Entity<BillItem>().HasKey(c => new { c.BillItemId});
            builder.Entity<Category>().HasKey(c => new { c.CategoryId });
            builder.Entity<Store>().HasKey(c => new { c.StoreId });
            builder.Entity<Measure>().HasKey(c => new { c.MeasureId});
            builder.Entity<Payment>().HasKey(c => new { c.PaymentId});
            builder.Entity<Item>().HasKey(c => new {c.ItemId});
            builder.Entity<Color>().HasKey(c => new { c.ColorId });
            builder.Entity<Expense>().HasKey(c => new { c.Id });
            builder.Entity<Brand>().HasKey(c => new { c.BrandId});
            builder.Entity<BrandImage>().HasKey(c => new { c.Id });
            builder.Entity<Expense>().HasKey(c => new { c.Id });
            builder.Entity<ItemQuantity>().HasKey(c => new { c.ItemQuantityId });

            builder.Entity<Item>().HasMany(e => e.ItemQuantities)
            .WithOne(e => e.Item)
            .HasForeignKey(e => e.ItemId)
            .HasPrincipalKey(e => e.ItemId);

            base.OnModelCreating(builder);
        }
        /// <summary>
        /// Use to deal with all things about buy or sale
        /// </summary>
        public virtual DbSet<Bill> Bills { set; get; }
        /// <summary>
        /// Define the customer detail
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }
        /// <summary>
        ///  Represent the data in the store
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Deatils of catrgory which define the measure, color and quantity
        /// </summary>
        public virtual DbSet<Measure> Measures { get; set; }
        /// <summary>
        /// Represnt the store of program
        /// </summary>
        public virtual DbSet<Store>Stores { get; set; }
        /// <summary>
        /// Use to insert, retrive, update and delete the bill details 
        /// </summary>
        public virtual DbSet<BillItem> BillItems { get; set; }
        /// <summary>
        /// Deatils of catrgory which define the measure, color and quantity
        /// </summary>
        public virtual DbSet<Item> Items { get; set; }
        /// <summary>
        ///  Customer payment details
        /// </summary>
        public virtual DbSet<Payment> Payments { get; set; }
        /// <summary>
        ///  define the color of program
        /// </summary>
        public virtual DbSet<Color> Colors { get; set; }
        //public DbSet<Masroufat> Masroufats { get; set; }
        /// <summary>
        /// Has some information about the store which use this prgram
        /// </summary>
        public virtual DbSet<Brand> Brands { get; set; }
        /// <summary>
        /// Use to manipulate date which use to define the store it self
        /// </summary>
        public virtual DbSet<BrandImage> BrandImages{ get; set; }
        /// <summary>
        /// Represent the item details which has price and quantity
        /// </summary>
        public virtual DbSet<ItemQuantity> ItemQantities { set; get; }
        /// <summary>
        ///  Represent the money which spends in store work
        /// </summary>
        public virtual DbSet<Expense>Expenses { set; get; }
    }
}
