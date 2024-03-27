using AutoMapper;
using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.ResponseModel;
using ChildCareBAL.Iservicess;
using ChildCareDAL.Commands.ParentCommands;
using ChildCareDAL.Querys.QueryParent;
using ChildCareUtility;
using MediatR;

#nullable disable

namespace ChildCareBAL.Implimentation
{
    public class ParentBAL : IParentBAL
    {
        private readonly IMediator _mediator; private readonly IMapper _mapper;
        public ParentBAL(IMediator mediator, IMapper mapper) { _mediator = mediator; _mapper = mapper; }
        private ResponseParentDTO _response = new ResponseParentDTO(); private Response _ResponseParent = new Response();
        public async Task<Response> Add(Parent model)
        {
            var data = await _mediator.Send(new CreateParentCommand(model));

            if (data.Item2 == null) { _ResponseParent.id = null; }
            else { _ResponseParent.id = data.Item2.Id.ToString(); }

            if (data.Item1)
            {
                _ResponseParent.Results = FinalResult.StatusPass(_ResponseParent.Results, ResultSet.registration_successfull.ToString());

                MailSender.ParentRegistrationConfirmationEmail(data.Item2);
            }

            else
            {
                _ResponseParent.Results = FinalResult.StatusFail(_ResponseParent.Results, ResultSet.registration_un_successfull.ToString());
            }

            return _ResponseParent;
        }
        public async Task<ResponseParentDTO> GetParent(int id)
        {
            _response.parent = await _mediator.Send(new GetParentByIdQuery { Id = id });

            if (_response.parent != null) { _response.Results = FinalResult.StatusPass(_response.Results, ConstantVariables.Success); }

            else { _response.Results = FinalResult.StatusFail(_response.Results, ResultSet.IdNotFound.ToString()); }

            return _response;
        }
        public async Task<ResponseParentListDTO> GetParentList(string request)
        {
            ResponseParentListDTO listofparent = new ResponseParentListDTO();

            listofparent.parent = await _mediator.Send(new GetParentListQuery { request = request });

            if (listofparent.parent != null) { listofparent.Results = FinalResult.StatusPass(listofparent.Results, ConstantVariables.Success); }

            else { listofparent.Results = FinalResult.StatusFail(listofparent.Results, ConstantVariables.Faill); }

            return listofparent;
        }
        public async Task<Response> Update(Parent entity)
        {
            var data = await _mediator.Send(new UpdateParentCammand(entity));

            if (data)
            { _ResponseParent.Results = FinalResult.StatusPass(_ResponseParent.Results, ResultSet.Updated_Successfull.ToString()); }

            else { _ResponseParent.Results = FinalResult.StatusFail(_ResponseParent.Results, ResultSet.IdNotFound.ToString() + " " + ResultSet.Updated_Un_Successfull.ToString()); }

            return _ResponseParent;
        }
        public async Task<Response> DeleteParent(int id)
        {
            var toDelete = await _mediator.Send(new GetParentByIdQuery { Id = id });

            if (toDelete != null)
            {
                await _mediator.Send(new DeleteParentCommand(toDelete));
                _ResponseParent.Results = FinalResult.StatusPass(_ResponseParent.Results, ResultSet.Delete_Successfull.ToString());
                return _ResponseParent;
            }
            else
            {
                _ResponseParent.Results = FinalResult.StatusFail(_ResponseParent.Results, ResultSet.IdNotFound.ToString());
                return _ResponseParent;
            }
        }
        public async Task<ParentChildDetailResponseDTO> GetParentChildRelationship(int id)
        {
            ParentChildDetailResponseDTO parentchilddetailResponse = new ParentChildDetailResponseDTO();

            parentchilddetailResponse.ParentChildData = new ParentChildDetailDTO();

            parentchilddetailResponse.ParentChildData = await _mediator.Send(new GetparenrtchildByIdQuery { Id = id });
            if (parentchilddetailResponse.ParentChildData.Parent != null)
            {
                parentchilddetailResponse.Results = FinalResult.StatusPass(parentchilddetailResponse.Results, "Success");
            }
            else
            {
                parentchilddetailResponse.Results = FinalResult.StatusFail(parentchilddetailResponse.Results, ResultSet.IdNotFound.ToString());
            }
            return parentchilddetailResponse;
        }
        public async Task<Responseparent> GetParentProfile(string UserName)
        {

            Responseparent profileResponse = new Responseparent();

            var data = await _mediator.Send(new GetParentListQuery());

            var result = data.Where(x => x.loginname == UserName).LastOrDefault();

            if (result != null) { profileResponse.parent = result; profileResponse.Results = FinalResult.StatusPass(profileResponse.Results, ConstantVariables.Success); }

            else { profileResponse.parent = result; profileResponse.Results = FinalResult.StatusFail(profileResponse.Results, ConstantVariables.UserNotFound); }

            return profileResponse;
        }
    }
}
