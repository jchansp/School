using System.Configuration;

namespace Repositories
{
    public class Repository
    {
        protected static string ConnectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
    }
}