using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.ResponseModel;
using ChildCareDAL.DBcontext;
using ChildCareDAL.Repositories.IRepositories;
using ChildCareUtility;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace ChildCareDAL.Repositories.Implementation
{
    public class EntrollmentDAL : GenericRepository<ChildEnrollment>, IEntrollmentDAL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EntrollmentDAL(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public override async Task<bool> Update(ChildEnrollment entity)
        {
            var data = _applicationDbContext.childEntrollmentTable.FirstOrDefault(x => x.Id == entity.Id);
            if (data == null)
            {
                return false;
            }
            data.UpdateBy = entity.UpdateBy;
            data.Classname = entity.Classname;
            data.Slotname = entity.Slotname;
            data.childID = entity.childID;
            data.parentId = entity.parentId;
            data.UpdateDate = entity.UpdateDate;
            data.EnrollmentEndinggDate = entity.EnrollmentEndinggDate;
            data.EnrollmentStartingDate = entity.EnrollmentStartingDate;
            data.AdmissionStatus = entity.AdmissionStatus;
            data.Admission_Approveby = entity.Admission_Approveby;
           
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<ChildProfileDTO>> ChildProfiles(Expression<Func<ChildProfileDTO, bool>> filter = null)
        {

            var data = from enmt in _applicationDbContext.childEntrollmentTable
                       join parent in _applicationDbContext.parentTable
                       on enmt.parentId equals parent.Id
                       join chd in _applicationDbContext.childTable
                       on enmt.childID equals chd.Id
                       where enmt.EnrollmentEndinggDate >= DateAndTime.Now
                       where enmt.AdmissionStatus == ConstantVariables.Approved
                       select new ChildProfileDTO
                       {
                           ChildId = chd.Id,
                           ChildFirstName = chd.FirstName,
                           ChildLastName = chd.LastName,
                           Gender = chd.Gender,
                           DOB = chd.DateOfBirth,
                           Status = enmt.AdmissionStatus,
                           ParentFirstName = parent.FirstName,
                           ParentLastName = parent.LastName,
                           Email = parent.Email,
                           PhoneNumber = parent.PhoneNumber,
                           ClassStartingDate = enmt.EnrollmentStartingDate,
                           ClassEndingDate = enmt.EnrollmentEndinggDate,
                       };

            return await (filter == null ? data.ToListAsync() : data.Where(filter).ToListAsync());

        }
    }
}
