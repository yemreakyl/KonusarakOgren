# KonusarakOgren
*İstenildiği şekilde solid prensiplerine uygun, katmanlı mimari, Repository Design Pattern ve Entity Framework
Core(Code first) kullanalarak projeyi gerçekleştirmeye çalıştım. 
*Core katmanında interface,entitymodel,dto nesneleri gibi proje genelinde kullandığım model ve abstract nesneleri tutmaya çalıştım.
*Data katmanında istenildiği üzere seed ve configurasyon dosyaları oluşturarak proje ayağa kaldırıldığında otomatik olarak tabloları fake data ile doldurdum.
*AppSetting.json içerisinde yer alan connection string değiştirilerek ayağa uygulama migration yapabilirsiniz.
*Proje de istenildiği şekilde email ve şifre ile doğrulama login olan kullanıcılar direkt olarak ürünleri listelediğim sayfaya yönlendiriliyor.
*İdentity role konusunda eksiklerim olduğu için istenilen rol atamalarını yapamadım ve o ksıımda projem eksik kalmış oldu.
*Üye ol sayfası üzerinde email,username ve şifre bigileri için validation class ları yazdım ve uygun şekilde veri girilmediği takdirde uyarı mesajları döndüm.
*Programın genelinde çağırılmasa da Service katmanında bazı business kodları yazdım .
*Veri tabanı savechanges işlemlerini yönetebilmek için UnitOfWork patterni kullandım.
*Proje de dto ve entity modeller arasında yapılan dönüşümler için auto  mapper kütüphanesinden faydalandım.
*User tabloları ve authorization için identity kütüphanesinden faydalandım.
*Kısıtlı zamanda elimden geldiğince en iyisini yapmaya çalıştım tabiki eksiklerim ve hatalarım vardır bu konu da da görüş ve eleştirilerinizi merakla bekliyorum.
Şimdiden teşekkür ederim iyi çalışmalar dilerim.

