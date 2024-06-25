using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuantumStock.Shared.Models;

namespace QuantumStock.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CartPayment> CartPayments { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CompanyDetail> CompanyDetails { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpensesCategory> ExpensesCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TransferProduct> TransferProducts { get; set; }
        public DbSet<SalesList> SalesLists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentItemList> PaymentItemLists { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<TaxDiscount> TaxDiscounts { get; set; }
    }
}