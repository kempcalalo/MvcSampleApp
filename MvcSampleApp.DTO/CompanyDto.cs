using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSampleApp.DTO
{
    public class CompanyDto : BaseDto
    {
        [DisplayName("Company Name:")]
        public string CompanyName { get; set; }
        public byte[] CompanyLogo { get; set; }
        [DisplayName("Conception Date:")]
        public DateTime? ConceptionDate { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
