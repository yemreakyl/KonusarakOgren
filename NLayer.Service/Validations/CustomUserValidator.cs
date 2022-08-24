using Microsoft.AspNetCore.Identity;
using NLayer.Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
   
    
        public class CustomUserValidator : IUserValidator<UserApp>
        {
            public Task<IdentityResult> ValidateAsync(UserManager<UserApp> manager, UserApp user)
            {
                List<IdentityError> errors = new List<IdentityError>();

                string[] Digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                foreach (var item in Digits)
                {
                    if (user.UserName[0].ToString() == item)
                    {
                        errors.Add(new IdentityError() { Code = "UserNameContainsFirstLetterDigitContains", Description = "Kullanıcı adının ilk karakteri sayısal karakter içeremez" });
                    }
                }

                if (errors.Count == 0)
                {
                    return Task.FromResult(IdentityResult.Success);
                }
                else
                {
                    return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
                }
            }
        }
    
}
