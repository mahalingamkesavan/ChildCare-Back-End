using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.EnrollmentCommands
{
    public class UpdateEnrollmentCommand : IRequest<bool>
    {
        public ChildEnrollment entrollment { get; set; }
        public UpdateEnrollmentCommand(ChildEnrollment entrollment)
        {
            this.entrollment = entrollment;
        }
    }
}
