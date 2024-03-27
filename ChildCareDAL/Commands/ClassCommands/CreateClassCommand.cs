using businessServicess.models.RequestModels.ChildCare;
using MediatR;

namespace ChildCareDAL.Commands.ClassCommands
{
    public class CreateClassCommand : IRequest<(bool, ClassList)>
    {
        public ClassList ClassList { get; set; }
        public CreateClassCommand( ClassList classList) 
        {
           this.ClassList = classList;  
        }
    }
}
