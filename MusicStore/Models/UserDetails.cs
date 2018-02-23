using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class UserDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Maximum Length of First Name should be 10")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Maximum Length of Middle Name should be 5")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Maximum Length of Last Name should be 10")]
        public string SurName { get; set; }
        public string DOB { get; set; }
        public string type { get; set; }

        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string EmailId { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile No")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string PhoneNo { get; set; }
        public string fprice { get; set; }
        public int CardFee { get; set; }
        public string customerIp { get; set; }

        [Required]
        [RegularExpression("[^0-9]", ErrorMessage = "Card Number must be 16 numeric numbers.")]
        public string CardNo { get; set; }
        [Required]
        [RegularExpression("[^0-9]", ErrorMessage = "CCV must be 3 numeric numbers.")]
        public string CardCCVNo { get; set; }
       // public List<SelectListItem> CardExpiryMonth { get; set; }
//public List<SelectListItem> CardExpiryYear { get; set; }
        public string SelectedCardExpiryMonth { get; set; }
        public string SelectedCardExpiryYear { get; set; }
    }
}