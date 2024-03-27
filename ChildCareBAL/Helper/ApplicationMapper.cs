using AutoMapper;
using businessServicess.models.RequestModels.ChildCare;

namespace ChildCareBAL.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ParentDTO, Parent>();

            CreateMap<ChildRequest, Child>();
        }
    }
}
