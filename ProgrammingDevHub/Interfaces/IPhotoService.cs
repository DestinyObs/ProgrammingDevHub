using CloudinaryDotNet.Actions;

namespace ProgrammingDevHub.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string PublicId);

    }
}
