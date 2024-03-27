using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.EnrollmentCommands
{
    public class CreateEnrollmentCommand : IRequest<(bool, ChildEnrollment)>
    {
        public ChildEnrollment Entrollment;
        public CreateEnrollmentCommand(ChildEnrollment entrollment)
        {
            Entrollment = entrollment;
        }
    }
}
