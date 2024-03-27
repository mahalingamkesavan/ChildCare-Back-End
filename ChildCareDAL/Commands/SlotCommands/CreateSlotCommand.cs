using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.SlotCommands
{
    public class CreateSlotCommand : IRequest<(bool, SlotList)>
    {
        public SlotList SlotList;
        public CreateSlotCommand(SlotList slotList)
        {
            this.SlotList = slotList;
        }
    }
}
