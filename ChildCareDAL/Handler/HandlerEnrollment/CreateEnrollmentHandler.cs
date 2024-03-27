using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Commands.EnrollmentCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerEnrollment
{
    public class CreateEnrollmentHandler : IRequestHandler<CreateEnrollmentCommand, (bool, ChildEnrollment)>
    {
        private readonly IEntrollmentDAL entrollment;
        public CreateEnrollmentHandler(IEntrollmentDAL entrollment)
        {
            this.entrollment = entrollment;
        }

        public async Task<(bool, ChildEnrollment)> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            return await entrollment.Add(request.Entrollment);
        }
    }
}
