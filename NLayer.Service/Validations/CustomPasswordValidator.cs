﻿using Microsoft.AspNetCore.Identity;
using NLayer.Core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class CustomPasswordValidator : IPasswordValidator<UserApp>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<UserApp> manager, UserApp user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                if (!user.Email.Contains(user.UserName))
                {
                    errors.Add(new IdentityError() { Code = "PasswordContainsUserName", Description = "şifre alanı kullanıcı adı içeremez" });
                }
            }
            if (password.ToLower().Contains(user.Email.ToLower()))
            {
                errors.Add(new IdentityError() { Code = "PasswordContainsEmail", Description = "şifre alanı email adresiniz içeremez" });
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
