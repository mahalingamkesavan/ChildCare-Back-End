using businessServicess.models.RequestModels.ChildCare;
using ChildCareBAL.Iservicess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChildCareAPI.Controllers
{
    [Authorize]
    public class SlotController : HomeController
    {
        private readonly ISlotBAL slotBAL;

        public SlotController(ISlotBAL slotBAL)
        {
            this.slotBAL = slotBAL;
        }
        [HttpGet]
        [Route("GetslotList")]
        public async Task<IActionResult> GetSlotName()
        {
            return Ok(await slotBAL.GetSlatList());
        }

        [HttpPost]
        [Route("Create-Slat")]
        public async Task<IActionResult> CreateSlot([FromBody] SlotList createslot)
        {
            return Ok(await slotBAL.CreateSlot(createslot));
        }
    }
}
