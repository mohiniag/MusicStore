using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Core.Models
{
    public class CustomerDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        public string FirstName { get; set; }

        
        [Required(ErrorMessage = "Please enter the Last Name")]
        public string LastName { get; set; }
       
        public string type { get; set; }

        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string EmailId { get; set; }
     
        public string PhoneNo { get; set; }
        public string payableAmount { get; set; }
        public int CardFee { get; set; }
        public string customerIp { get; set; }

        [Required]
        [RegularExpression("[^0-9]", ErrorMessage = "Card Number must be 16 numeric numbers.")]
        public string CardNo { get; set; }
        [Required]
        [RegularExpression("[^0-9]", ErrorMessage = "CCV must be 3 numeric numbers.")]
        public string CardCCVNo { get; set; }
        public List<SelectListItem> CardExpiryMonth { get; set; }
        public List<SelectListItem> CardExpiryYear { get; set; }
        public string SelectedCardExpiryMonth { get; set; }
        public string SelectedCardExpiryYear { get; set; }

    }
}
