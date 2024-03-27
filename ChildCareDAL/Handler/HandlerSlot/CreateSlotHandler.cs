using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Commands.SlotCommands;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Handler.HandlerSlot
{
    public class CreateSlotHandler : IRequestHandler<CreateSlotCommand, (bool, SlotList)>
    {
        private readonly ISlotDAL _slotDAL;
        public CreateSlotHandler(ISlotDAL slotDAL) { _slotDAL = slotDAL; }

        public async Task<(bool, SlotList)> Handle(CreateSlotCommand request, CancellationToken cancellationToken)
        {
            return await _slotDAL.Add(request.SlotList);
        }
    }
}
