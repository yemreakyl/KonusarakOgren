
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.EntityModels
{
    public class UserApp : IdentityUser
    {
        //İstek yapan kullanıcıların verilerinin kontrolü için oluşturduğum model
        public string City { get; set; }
        public virtual List<Comment> Comments { get; set; }// Kullanıcının yaptığı yorumlar
      

    }
}
