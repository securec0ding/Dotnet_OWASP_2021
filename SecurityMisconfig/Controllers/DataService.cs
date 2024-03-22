// DataService.cs
namespace SecurityMisconfig.Controllers
{
    public class DataService : IDataService
    {
        public string GetSensitiveData()
        {
            return "This is sensitive data accessible only to admin.";
        }
    }
}
