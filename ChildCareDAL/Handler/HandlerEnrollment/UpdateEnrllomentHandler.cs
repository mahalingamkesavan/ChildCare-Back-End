using ChildCareDAL.Commands.EnrollmentCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerEnrollment
{
    public class UpdateEnrllomentHandler : IRequestHandler<UpdateEnrollmentCommand, bool>
    {
        private readonly IEntrollmentDAL entrollment;
        public UpdateEnrllomentHandler(IEntrollmentDAL entrollment)
        {
            this.entrollment = entrollment;
        }

        public Task<bool> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            return entrollment.Update(request.entrollment);
        }
    }
}
