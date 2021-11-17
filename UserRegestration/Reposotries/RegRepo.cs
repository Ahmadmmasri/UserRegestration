using UserRegestration.Context;
using UserRegestration.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegestration.Reposotries
{
    public class RegRepo : IRegRepo
    {
        private readonly MyDbContext _dbContext;

        public RegRepo(MyDbContext dbContext)
        {
           this._dbContext = dbContext;
        }

        public void Create(Regerstation regerstation)
        {
            _dbContext.regerstation.Add(regerstation);
            _dbContext.SaveChanges();
        }

        public List<Offer> GetAllOffer()
        {
           var AllOfers= _dbContext.offer.ToList();
            return AllOfers;
        }

        public List<Service> GetAllService()
        {
           var AllServices= _dbContext.service.ToList();
            return AllServices;
        }

        public void SendEmail(string usermail, string userNumber, string name, string offer, string service)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Assement", "TestAssegment25@gmail.com"));
            message.To.Add(new MailboxAddress("naren", usermail));

            var query =
               from rege in _dbContext.regerstation
               join Offer in _dbContext.offer on rege.OfferId equals Convert.ToInt32(offer) 
               join Service in _dbContext.service on rege.ServiceId equals Convert.ToInt32(service) 
               select new { offerName = Offer.OfferName, ServiceName = Service.seviceName };

            foreach(var item in query)
            {
                message.Subject = "Hello " + name + " the offer you are intressts in is " + item.offerName.ToLower() + 
                    " and services is " + item.ServiceName.ToLower() +" we will contact you on "+userNumber+" as soon as possible";
                break;
            }

            message.Body = new TextPart("plain") { Text = "hello mail" };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("TestAssegment25@gmail.com", "Test12345678");
                client.Send(message);
                client.Disconnect(true);
            };

        }
    }
}
