using System.Data;
using Erp.Custom.Framework;

namespace Erp.Custom.Session.Models
{
    public class CustomSession
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string PlantId { get; set; }

        public string PlantName { get; set; }

        public string Company { get; set; }

        public string CompanyName { get; set; }

        public string SessionId { get; set; }

        public string Client { get; set; }

        public string AppServer { get; set; }


    }
}