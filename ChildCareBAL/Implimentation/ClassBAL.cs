using businessServicess.models.RequestModels.auth;
using businessServicess.models.RequestModels.ChildCare;
using ChildCareBAL.Iservicess;
using ChildCareDAL.Commands.ClassCommands;
using ChildCareDAL.Querys.QueryClass;
using ChildCareUtility;
using MediatR;

namespace ChildCareBAL.Implimentation
{
    public class ClassBAL : IClassBAL
    {
        private readonly IMediator _mediator; private Response _response = new Response();
        public ClassBAL(IMediator mediator) { _mediator = mediator;}
        public async Task<Response> CreateClass(ClassList classList)
        {
             var  Data = await _mediator.Send(new CreateClassCommand(classList));
            if(Data.Item1)
            {
                _response.Status = ConstantVariables.CareatMessage;
                _response.Data = Data;
            }

            return _response;
        }  
        public async Task<List<ClassList>> GetClassList()
        {
            return await _mediator.Send(new GetClassListQuery { });
        }
    }
}
