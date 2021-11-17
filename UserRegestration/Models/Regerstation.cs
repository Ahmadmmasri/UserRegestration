using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegestration.Models
{
    public class Regerstation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string userName { get; set; }      
        
        [Required]
        public string userNumber { get; set; }     
        
        [Required]
        public string userEmail { get; set; }


        //init foriegn key for Course
        [Required]
        public int OfferId { get; set; }

        public Offer Offer { get; set; }

        //end of foriegn key

        //init foriegn key for Room
        [Required]

        public int ServiceId { get; set; }

        public Service Service { get; set; }

        //end of foriegn key

        public DateTime RegestrationDate { get; set; }
    }
}
