using ChildCareDAL.Commands.EnrollmentCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerEnrollment
{
    public class DeleteEnrollmentHandler : IRequestHandler<DeleteEnrollmentCommand, int>
    {
        private readonly IEntrollmentDAL entrollmentDAL;
        public DeleteEnrollmentHandler(IEntrollmentDAL entrollmentDAL)
        {
            this.entrollmentDAL = entrollmentDAL;
        }

        public Task<int> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            return entrollmentDAL.Delete(request.childEntrollment);
        }
    }
}
