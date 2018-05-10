using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSampleApp.Core.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public byte[] CompanyLogo { get; set; }
        public DateTimeOffset? ConceptionDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
