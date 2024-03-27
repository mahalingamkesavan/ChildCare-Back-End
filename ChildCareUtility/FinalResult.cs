using businessServicess.models.ResponseModel;

namespace ChildCareUtility
{
    public static class FinalResult
    {
        public static ResultDetailDTO StatusPass(ResultDetailDTO result, string Message)
        {
            result = new ResultDetailDTO();
            result.Status = (int)ResultSet.success;
            result.Message = Message;
            return result;
        }
        public static ResultDetailDTO StatusFail(ResultDetailDTO result, string Message)
        {
            result = new ResultDetailDTO();
            result.Status = (int)ResultSet.Bad_Request;
            result.Message = Message;
            return result;
        }
    }
}