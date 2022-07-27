
using System.ComponentModel.DataAnnotations;


namespace SameDayAuth.Models
{
    public class Tickets
    {


            [Required]

            public string OrderId { get; set; }

            [Required]

            public string Subject { get; set; }

            [RegularExpression("^[0-9]*$")]
            public string MobileNo { get; set; }

            [Required]

            public string Discription { get; set; }


            public string IsActive { get; set; }

    }
}