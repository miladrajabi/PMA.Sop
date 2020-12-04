using System.Threading.Tasks;

namespace PMA.Sop.ApplicationServices.Interfaces
{
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64);
    }
}