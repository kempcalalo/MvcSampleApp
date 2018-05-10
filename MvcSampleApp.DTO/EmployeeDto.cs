using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSampleApp.DTO
{
    public class EmployeeDto : BaseDto
    {
        [DisplayName("First Name:")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name:")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name:")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [DisplayName("Date of Birth:")]
        public DateTime? DateOfBirth { get; set; }
        [DisplayName("Marital Status:")]
        public string MaritalStatus { get; set; }
        [DisplayName("ID No:")]
        public string NationalIdNo { get; set; }
        public byte[] Image { get; set; }
        public Guid? CompanyId { get; set; }
        public CompanyDto Company { get; set; }

    }
}
