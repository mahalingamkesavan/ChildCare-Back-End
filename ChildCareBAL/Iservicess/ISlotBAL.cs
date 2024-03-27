using businessServicess.models.RequestModels.auth;
using businessServicess.models.RequestModels.ChildCare;

namespace ChildCareBAL.Iservicess
{
    public interface ISlotBAL 
    {
        public Task<List<SlotList>> GetSlatList();
        public Task<Response> CreateSlot(SlotList createslot);
    }
}
