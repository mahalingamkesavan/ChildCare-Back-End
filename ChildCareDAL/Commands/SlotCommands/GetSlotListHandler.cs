using businessServicess.models.RequestModels.ChildCare;
using ChildCareDAL.Querys.QuerySlot;
using ChildCareDAL.Repositories.IRepositories;
using MediatR;

namespace ChildCareDAL.Commands.SlotCommands
{
    public class GetSlotListHandler : IRequestHandler<GetSlotListQuery, List<SlotList>>
    {
        private readonly ISlotDAL slotDAL;

        public GetSlotListHandler(ISlotDAL slotDAL) { this.slotDAL = slotDAL; }
        public async Task<List<SlotList>> Handle(GetSlotListQuery request, CancellationToken cancellationToken)
        {
            return await slotDAL.GetList();
        }
    }
}
