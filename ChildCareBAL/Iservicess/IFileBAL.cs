using businessServicess.models.RequestModels.ChildCare;

namespace ChildCareBAL.Iservicess
{
    public interface IFileBAL
    {
        Task<bool> PostFileAsync(FileUploadModel fileDetails);
        Task<(Stream, string)> DownloadFileById(int Id);

    }
}
