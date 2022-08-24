using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.EntityModels
{
    public class Comment:BaseEntity
    {
       
        public string Content { get; set; }
        public int  ProductId { get; set; } // Hangi ürüne yorum yapmış olduğu
       
        [ForeignKey("UserId")]
        public string UserName { get; set; }
    }
}
