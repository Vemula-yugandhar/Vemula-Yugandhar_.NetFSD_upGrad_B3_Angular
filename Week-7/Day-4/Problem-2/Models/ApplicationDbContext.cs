namespace Entity_FrameWork_Contact_Management_Repository_service_pattern.Models
{
    public class ApplicationDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One Company → Many Contacts
            modelBuilder.Entity<ContactInfo>()
                        .HasOne(c => c.Company)
                        .WithMany(cmp => cmp.Contacts)
                        .HasForeignKey(c => c.CompanyId)
                        .OnDelete(DeleteBehavior.Restrict);

            // One Department → Many Contacts
            modelBuilder.Entity<ContactInfo>()
                        .HasOne(c => c.Department)
                        .WithMany(d => d.Contacts)
                        .HasForeignKey(c => c.DepartmentId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
