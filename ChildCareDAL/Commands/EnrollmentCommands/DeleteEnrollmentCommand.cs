using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.EnrollmentCommands
{
    public class DeleteEnrollmentCommand : IRequest<int>
    {
        public ChildEnrollment childEntrollment { get; set; }
        public DeleteEnrollmentCommand(ChildEnrollment childEntrollment)
        {
            this.childEntrollment = childEntrollment;
        }
    }
}
