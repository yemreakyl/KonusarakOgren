namespace NLayer.Core.DTOs
{
    //DTO demek Client lara tüm entity dönmek yerine görmeleri gereken kısımları görmeleri için ara entity maksadıyla oluşturduğum classlardır
    public abstract class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
