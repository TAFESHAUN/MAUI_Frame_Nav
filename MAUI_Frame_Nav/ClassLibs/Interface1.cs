// IAlertService.cs
using System.Threading.Tasks;

namespace MAUI_Frame_Nav.ClassLibs
{
    public interface IAlertService
    {
        Task ShowAlert(string title, string message, string cancel);
    }
}
