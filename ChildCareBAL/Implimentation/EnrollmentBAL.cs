using businessServicess.models.RequestModels.ChildCare;
using businessServicess.models.RequestModels.ChildCare.pagination;
using businessServicess.models.ResponseModel;
using ChildCareBAL.Iservicess;
using ChildCareDAL.Commands.ChildCommands;
using ChildCareDAL.Commands.EnrollmentCommands;
using ChildCareDAL.Querys.QueryChild;
using ChildCareDAL.Querys.QueryEnrollment;
using ChildCareDAL.Querys.QueryParent;
using ChildCareUtility;
using MediatR;
using Microsoft.VisualBasic;

#nullable disable

namespace ChildCareBAL.Implimentation
{
    public class EnrollmentBAL : IEnrollmentBAL
    {
        private readonly IMediator _mediator; private Response _Response = new Response();
        public EnrollmentBAL(IMediator mediator) { _mediator = mediator; }
        public async Task<Response> Add(EnrollmentRequest entrollment)
        {
            var Enrollment = new ChildEnrollment
            {
                parentId = entrollment.parentId,
                childID = entrollment.childID,
                EnrollmentStartingDate = entrollment.EnrollmentStartingDate,
                EnrollmentEndinggDate = entrollment.EnrollmentEndinggDate,
                Classname = entrollment.Classname,
                Slotname = entrollment.Slotname,
                CreateBy = entrollment.CreateBy,
                CreateDate = DateAndTime.Now.ToString(),
                UpdateBy = null,
                UpdateDate = null
            };

            var ParentData = await _mediator.Send(new GetParentByIdQuery { Id = entrollment.parentId });

            var childDta = await _mediator.Send(new GetChildByIdQuery { Id = entrollment.childID });

            if (ParentData != null && childDta != null)
            {
                var ivalid = await _mediator.Send(new CreateEnrollmentCommand(Enrollment));

                if (ivalid.Item2 == null) { _Response.id = null; }

                else { _Response.id = ivalid.Item2.Id.ToString(); }

                if (ivalid.Item1)
                {
                    _Response.Results = FinalResult.StatusPass(_Response.Results, ResultSet.registration_successfull.ToString());
                }
                else
                {
                    _Response.Results = FinalResult.StatusFail(_Response.Results, ResultSet.registration_un_successfull.ToString() + ConstantVariables.inputError);
                }
            }

            else { _Response.Results = FinalResult.StatusFail(_Response.Results, ResultSet.registration_un_successfull.ToString() + ConstantVariables.inputError); }

            return _Response;
        }
        public async Task<Response> Delete(int id)
        {
            var Enrollmentdata = await _mediator.Send(new GetEnrollmentByIdQuery { Id = id });
            if (Enrollmentdata != null)
            {
                await _mediator.Send(new DeleteEnrollmentCommand(Enrollmentdata));
                _Response.Results = _Response.Results = FinalResult.StatusPass(_Response.Results, ResultSet.Delete_Successfull.ToString());
            }
            else { _Response.Results = _Response.Results = FinalResult.StatusFail(_Response.Results, ResultSet.IdNotFound.ToString()); }

            return _Response;
        }
        public async Task<GetChildEnrollment> Get(int id)
        {
            GetChildEnrollment entrollment = new GetChildEnrollment();

            var data = await _mediator.Send(new GetEnrollmentByIdQuery { Id = id });

            if (data == null)
            {
                entrollment.Results = FinalResult.StatusFail(_Response.Results, ResultSet.IdNotFound.ToString());
                return entrollment;
            }
            entrollment.childEntrollment = data;
            entrollment.Results = FinalResult.StatusPass(_Response.Results, ConstantVariables.Success);
            return entrollment;
        }
        public async Task<GetEnrollmentList> GetList(string request)
        {
            GetEnrollmentList entrollmentList = new GetEnrollmentList();
            entrollmentList.entrollmentslist = await _mediator.Send(new GetEnrollmentListQuery { request = request });
            entrollmentList.Results = FinalResult.StatusPass(_Response.Results, ConstantVariables.Success);
            return entrollmentList;
        }
        public async Task<Response> Update(EnrollmentRequest entrollment)
        {
            var Enrolldata = new ChildEnrollment
            {
                Id = entrollment.Id,
                parentId = entrollment.parentId,
                childID = entrollment.childID,
                EnrollmentStartingDate = entrollment.EnrollmentStartingDate,
                EnrollmentEndinggDate = entrollment.EnrollmentEndinggDate,
                Classname = entrollment.Classname,
                Slotname = entrollment.Slotname,
                UpdateBy = entrollment.CreateBy,
                UpdateDate = DateAndTime.Now.ToString(),
                AdmissionStatus = entrollment.AdmissionStatus,

            };

            var ParentData = await _mediator.Send(new GetParentByIdQuery { Id = entrollment.parentId });

            var childDta = await _mediator.Send(new GetChildByIdQuery { Id = entrollment.childID });

            if (ParentData != null && childDta != null)
            {
                var isValid = await _mediator.Send(new UpdateEnrollmentCommand(Enrolldata));

                if (isValid) _Response.Results = FinalResult.StatusPass(_Response.Results, ResultSet.Updated_Successfull.ToString());

                else _Response.Results = FinalResult.StatusFail(_Response.Results, ResultSet.registration_un_successfull.ToString() + ConstantVariables.inputError);
            }

            else
                _Response.Results = FinalResult.StatusFail(_Response.Results, ResultSet.registration_un_successfull.ToString() + ConstantVariables.inputError);

            return _Response;
        }
        public async Task<List<ChildEnrollment>> AdmissionApprovalpending()
        {
            var data = await _mediator.Send(new GetEnrollmentListQuery { request = ConstantVariables.AdmissionApprovalpending });
            return data;
        }
        public async Task<List<ChildEnrollment>> AdmissionApprovallList()
        {
            var data = await _mediator.Send(new GetEnrollmentListQuery { request = ConstantVariables.Approved });
            return data;
        }
        public async Task<List<ChildEnrollment>> AdmissionRejectedlList()
        {
            var data = await _mediator.Send(new GetEnrollmentListQuery { request = ConstantVariables.Rejected });
            return data;
        }
        public async Task<Response> AddmissionApproval(EnrollmentApprovedRequest entrollment)
        {
            var Enrolldata = new ChildEnrollment
            {
                Id = entrollment.Id,
                parentId = entrollment.parentId,
                childID = entrollment.childID,
                EnrollmentStartingDate = entrollment.EnrollmentStartingDate,
                EnrollmentEndinggDate = entrollment.EnrollmentEndinggDate,
                Classname = entrollment.Classname,
                Slotname = entrollment.Slotname,
                UpdateBy = entrollment.CreateBy,
                UpdateDate = DateAndTime.Now.ToString(),
                AdmissionStatus = entrollment.AdmissionStatus,
                Admission_Approveby = entrollment.Admission_Approveby,
            };

            var isValid = await _mediator.Send(new UpdateEnrollmentCommand(Enrolldata));

            if (isValid)
            {
                if (entrollment.AdmissionStatus == ConstantVariables.Approved)
                {
                    var ParentData = await _mediator.Send(new GetParentByIdQuery { Id = entrollment.parentId });
                    MailSender.SendMail(ParentData, entrollment);
                    _Response.Results = FinalResult.StatusPass(_Response.Results, ResultSet.Updated_Successfull.ToString());
                }
                else
                    _Response.Results = FinalResult.StatusPass(_Response.Results, ResultSet.Updated_Successfull.ToString());
            }
            else
                _Response.Results = FinalResult.StatusFail(_Response.Results, ResultSet.registration_un_successfull.ToString());

            return _Response;
        }
        public async Task<List<ChildEnrollment>> GetActiveChild(string request)
        {
            var data = await AdmissionApprovallList();

            List<ChildEnrollment> Activechilds = new List<ChildEnrollment>();

            foreach (var item in data)
            {
                if (item.EnrollmentEndinggDate >= DateAndTime.Now) Activechilds.Add(item);

                else
                {
                    var Getchildata = await _mediator.Send(new GetChildByIdQuery { Id = item.childID });

                    var childUpdate = new Child()
                    {
                        Id = Getchildata.Id,
                        parentID = Getchildata.parentID,
                        Status = ConstantVariables.InActive,
                        DateOfBirth = Getchildata.DateOfBirth,
                        Gender = Getchildata.Gender,
                        FirstName = Getchildata.FirstName,
                        LastName = Getchildata.LastName,
                    };

                    await _mediator.Send(new UpdateChildCommand(childUpdate));
                }
            }
            return Activechilds;
        }
        public async Task<ChildProfileResponceDTO> GetChildren(Paginationparameter paginationparameter)
        {
            ChildProfileResponceDTO childProfile = new ChildProfileResponceDTO();

            childProfile.ChildProfiles = await _mediator.Send(new GetCHildProfileQuery(paginationparameter));

            return childProfile;
        }
        public async Task<int> GetActiveChildCount()
        {
            var count = await _mediator.Send(new Getactivechildcountquery());

            return count;

        }


    }
}



