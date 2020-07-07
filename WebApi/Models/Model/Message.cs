using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Model
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DateTime RecordTime { get; set; }
        public int IsRead { get; set; }
    }

    public class MessageList : Message
    {
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Tarih { get; set; }
    }
}
