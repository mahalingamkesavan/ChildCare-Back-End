using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Commands.ChildCommands;
using ChildCareDAL.Commands.ClassCommands;
using ChildCareDAL.Repositories.Implementation;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCareDAL.Handler.HandlerClass
{
    public class CreateClassHandler :IRequestHandler<CreateClassCommand,(bool,ClassList)>
    {
        private readonly IClassDAL classDAL;
        public CreateClassHandler(IClassDAL classDAL) { this.classDAL = classDAL; }
        public  async Task<(bool, ClassList)> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            return await classDAL.Add(request.ClassList);
        }

    }
}
