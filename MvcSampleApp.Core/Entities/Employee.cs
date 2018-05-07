using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSampleApp.Core.Entities
{
    public class Employee : BaseEntity
    {

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string NationalIdNo { get; set; }
        public byte[] Image { get; set; }
        public Nullable<Guid> CompanyId { get; set; }

        public virtual Company Company { get; set; }

    }
}
