using businessServicess.models.RequestModels.ChildCare;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildCareDAL.Querys.QueryClass
{
    public class GetClassListQuery :IRequest<List<ClassList>>
    {

    }
}
