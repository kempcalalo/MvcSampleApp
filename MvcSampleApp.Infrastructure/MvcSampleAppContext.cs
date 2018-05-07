using MvcSampleApp.Core;
using System.Data.Entity;


namespace MvcSampleApp.Infrastructure
{
    public class MvcSampleAppContext : DbContext
    {
        public MvcSampleAppContext()
            : base("name=MvcAppContextConnectionString")
        {
            var a = Database.Connection.ConnectionString;
        }
    }
}
