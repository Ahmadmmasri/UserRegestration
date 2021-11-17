using UserRegestration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegestration.Reposotries
{
   public interface IRegRepo
    {
        public List<Offer> GetAllOffer();
        public List<Service> GetAllService();

        public void Create(Regerstation regerstation);

        public void SendEmail(string usermail, string usernumber, string name, string offer, string service);
    }
}
