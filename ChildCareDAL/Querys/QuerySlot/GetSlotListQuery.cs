using businessServicess.models.RequestModels.ChildCare;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCareDAL.Querys.QuerySlot
{
    public class GetSlotListQuery :IRequest<List<SlotList>>
    {

    }
}
