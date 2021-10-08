using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubicServer.Models
{
    public class SMS
    {
        public int Id { get; set; }
        public int SendId { get; set; }
        public string Text { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
