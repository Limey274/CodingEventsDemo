using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventsViewModel
    {
        [Required(ErrorMessage ="Please Enter Your Event Name")]
        [StringLength(50, MinimumLength =2)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Describe Your Event")]
        [StringLength(500, ErrorMessage ="Description too long")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Please Update The Event Location")]

        public string Location { get; set; }

        [Required(ErrorMessage = "How Many Will Be Attending")]
        [Range(1,100000)]
        public int Attending { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }
    }
}
