using UserRegestration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegestration.Models.ViewModels
{
    public class modeslLIst
    {
      public List<Regerstation> regerstation { get; set; }
      public List<Offer> offer { get; set; }
      public List<Service> service { get; set; }

    }
}
