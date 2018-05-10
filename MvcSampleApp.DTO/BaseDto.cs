using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSampleApp.DTO
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }
    }
}
