
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Sm.Crm.Infrastructure.Persistence
{
    static class Configiration
    {
        static public string ConnectingString
        {
            get
            {

                ConfigurationManager configirationManger = new();
                configirationManger.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), ""));
                configirationManger.AddJsonFile("appsettings.json");
                return configirationManger.GetConnectionString("Default");
            }
        }

    }
}
