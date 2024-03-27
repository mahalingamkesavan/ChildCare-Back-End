using businessServicess.models.RequestModels.auth;
using businessServicess.models.RequestModels.ChildCare;
using ChildCareBAL.Iservicess;
using ChildCareDAL.Commands.SlotCommands;
using ChildCareDAL.Querys.QuerySlot;
using ChildCareUtility;
using MediatR;

namespace ChildCareBAL.Implimentation
{
    public class SlotBAL : ISlotBAL
    {
        private readonly IMediator _mediator; private Response _response = new Response();
        public SlotBAL(IMediator mediator) { _mediator= mediator; }
        public async Task<Response> CreateSlot(SlotList createslot)
        {
            var  Data = await _mediator.Send(new CreateSlotCommand(createslot));

            if (Data.Item1)
            {
                _response.Status = ConstantVariables.CareatMessage;
                _response.Data = Data;
            }

            return _response;
        }
        public async Task<List<SlotList>> GetSlatList()
        {
            return await _mediator.Send(new GetSlotListQuery());
        }
    }
}
