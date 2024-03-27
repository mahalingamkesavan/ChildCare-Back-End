
#nullable disable
using businessServicess.models.RequestModels.ChildCare;
using Microsoft.EntityFrameworkCore;

namespace ChildCareDAL.DBcontext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<ChildEnrollment> childEntrollmentTable { get; set; }
        public DbSet<Parent> parentTable { get; set; }
        public DbSet<Child> childTable { get; set; }
        public DbSet<ClassList> classListTable { get; set; }
        public DbSet<SlotList> slotListTable { get; set; }
        public DbSet<FileDetails> FileDetails { get; set; }


    }
}
