using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani.ViewModel.UserViewModels
{
    public class UserCreateVM
    {
        [Display(Name = "Ad", Prompt = "firstname")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, ErrorMessage = "max 100 character", MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Display(Name = "Soyad", Prompt = "lastname")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(100, ErrorMessage = "max 100 character", MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Display(Name = "Email Address", Prompt = "e-mail address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} exception")]
        [StringLength(100, ErrorMessage = "max 100 character", MinimumLength = 10)]
        [Required(ErrorMessage = "{0} is Required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "max 100 character", MinimumLength = 5)]
        [Required(ErrorMessage = "{0} is Required")]
        public string Password { get; set; }
        [Display(Name = "Phone Number", Prompt = "phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
