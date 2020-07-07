using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Model;

namespace WebApi.Models.Repositories
{
    public class MessageRepository
    {
        private readonly DB _db;
        public MessageRepository(DB context)
        {
            _db = context;
        }

        public Tuple<int, int> GetMessageInfo(int UserId)
        {
            try
            {
                int totalMessages = _db.Messages.Where(x => x.To == UserId).Count();
                int unreadMessage = _db.Messages.Where(x => x.To == UserId && x.IsRead == 0).Count();
                return  Tuple.Create(totalMessages, unreadMessage);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<MessageList> Messages(int refUser,int take,int skip)
        {
            try
            {
                var messages = _db.Messages.Join(_db.Users,
                        message=>message.From,
                        user=>user.Id,
                        (message,user)=>new MessageList()
                        {
                          Id = message.Id,
                          FromName = user.Name+" "+user.Surname,
                          Subject = message.Subject,
                          Content = message.Content,
                          Tarih = message.RecordTime.ToString("dd.MM.yyyy"),
                          IsRead=message.IsRead,
                          To=message.To,
                          RecordTime = message.RecordTime
                        }                        
                        ).Where(x => x.To == refUser).Skip(skip * take).Take(take).OrderByDescending(x=>x.RecordTime).ToList();
                return messages;
            }
            catch (Exception e)
            {
               return  new List<MessageList>();
            }
        }

        public Message MessageRead(int MessageId)
        {
            try
            {
                var message = _db.Messages.Where(x => x.Id == MessageId).FirstOrDefault();
                if (message!=null)
                {
                    message.IsRead = 1;
                    _db.SaveChanges();
                    return message;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

       
    }
}
