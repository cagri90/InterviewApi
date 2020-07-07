using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Model
{
    public class MessageRequest
    {
        public  int UserId { get; set; }
        public  int MessageId { get; set; }
        public  int Take { get; set; }
        public  int Skip { get; set; }
    }
}
