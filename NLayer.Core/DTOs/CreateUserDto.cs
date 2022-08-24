using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CreateUserDto
    {
        [Required(ErrorMessage ="Kullanıcı adı ismi gereklidir")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email adresi  gereklidir")]
        [Display(Name = "Email Adresi")]
        [EmailAddress(ErrorMessage ="Doğru formatta bir email adresi giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
