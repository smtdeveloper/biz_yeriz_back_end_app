using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Domain.Entities.CustomerEntities;
using bizYeriz.Domain.Entities.FoodEntities;
using System.Reflection;

namespace bizYeriz.Persistence.Context
{
    public class AppDbContext : DbContext
    {

        protected IConfiguration Configuration { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission>  Permissions { get; set; }
        public DbSet<RolePermission>  RolePermissions { get; set; }
        public DbSet<RefreshToken>  RefreshTokens { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<UserAddress> CustomerAddresses { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CuisineCategory> KitchenCategories { get; set; }
        public DbSet<CuisineCategoryAndFood> CuisineCategoryAndFoods { get; set; }
        public DbSet<CompanyWorkingHour> CompanyWorkingHours { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodCategoryAndFood> FoodCategoryAndFoods { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CompanyComment> CompanyComments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<CompanyPaymentType> CompanyPaymentTypes { get; set; }              
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions, IConfiguration configuration)
               : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.HasPostgresExtension("postgis");
        }

    }

}