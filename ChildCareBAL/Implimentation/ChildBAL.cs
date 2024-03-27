using AutoMapper;
using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.ResponseModel;
using ChildCareBAL.Iservicess;
using ChildCareDAL.Commands.ChildCommands;
using ChildCareDAL.Querys.QueryChild;
using ChildCareDAL.Querys.QueryParent;
using ChildCareUtility;
using MediatR;

namespace ChildCareBAL.Implimentation
{
    public class ChildBAL : IChildBAL
    {
        private readonly IMediator _mediator; private readonly IMapper _mapper; private Response _responsechild = new Response();
        public ChildBAL(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<Response> Add(ChildRequest model)
        {
            var childdto = _mapper.Map<Child>(model);

            var Cheakparent = await _mediator.Send(new GetParentByIdQuery { Id = model.parentID });

            if (Cheakparent != null)
            {
                var IsFlag = await _mediator.Send(new CreateChildCommand(childdto));

                if (IsFlag.Item2 == null) { _responsechild.id = null; }

                else { _responsechild.id = IsFlag.Item2.Id.ToString(); }

                if (IsFlag.Item1) _responsechild.Results = FinalResult.StatusPass(_responsechild.Results, ResultSet.registration_successfull.ToString());

                else _responsechild.Results = FinalResult.StatusFail(_responsechild.Results, ResultSet.registration_un_successfull.ToString());
            }
            else { _responsechild.Results = FinalResult.StatusFail(_responsechild.Results, ResultSet.registration_un_successfull.ToString() + " , " + " Parent " + ConstantVariables.UserNotFound); }

            return _responsechild;
        }
        public async Task<ResponseChildDTO> GetChild(int id)
        {
            ResponseChildDTO childDTO = new ResponseChildDTO();

            childDTO.child = await _mediator.Send(new GetChildByIdQuery { Id = id });

            if (childDTO.child != null) { childDTO.Results = FinalResult.StatusPass(childDTO.Results, ConstantVariables.Success); }

            else { childDTO.Results = FinalResult.StatusFail(childDTO.Results, ConstantVariables.UserNotFound); }

            return childDTO;
        }
        public async Task<ResponceChildListDTO> GetChildList(string requestItem)
        {
            var Listofchild = new ResponceChildListDTO();

            Listofchild.ChildList = await _mediator.Send(new GetChildListQuery { request = requestItem });

            if (Listofchild.ChildList.Count == 0)
            {
                Listofchild.Results = FinalResult.StatusFail(Listofchild.Results, ConstantVariables.Faill);
            }
            Listofchild.Results = FinalResult.StatusPass(Listofchild.Results, ConstantVariables.Success);
            return Listofchild;
        }
        public async Task<Response> Update(Child entity)
        {
            bool IsFlag = await _mediator.Send(new UpdateChildCommand(entity));

            if (IsFlag) { _responsechild.Results = FinalResult.StatusPass(_responsechild.Results, ResultSet.Updated_Successfull.ToString()); }

            else { _responsechild.Results = FinalResult.StatusFail(_responsechild.Results, ResultSet.IdNotFound.ToString()); }

            return _responsechild;
        }
        public async Task<Response> DeleteChild(int id)
        {
            var GetChild = await _mediator.Send(new GetChildByIdQuery { Id = id });

            if (GetChild != null)
            {
                await _mediator.Send(new DeleteChildCommand(GetChild));
                _responsechild.Results = FinalResult.StatusPass(_responsechild.Results, ResultSet.Delete_Successfull.ToString());
            }
            else
            {
                _responsechild.Results = FinalResult.StatusPass(_responsechild.Results, ResultSet.IdNotFound.ToString());
            }
            return _responsechild;
        }


    }
}
