using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
        // Unit of Work ün amacı şudur normalde repository katmanımda veri tabanına yapacağım işlemleri belirttiğim classın içindeki her methotta save changes komutunu eklemem gerekiyor ki EF core veri tabanına işlemleri kaydetsin.Ama birden çok işlem yaptığımı düşündüğümde bazıları başarılı bazıları başarısız olabilir ve bu durumda kontrol zorlaşır.Ben sava changes kısmını tek elden yönetiyorum ki her hang bir işlem başarısız olursa diğer diğer işlemler de veri tabanına kayıt edilmesin.Bunu bu class tan yöneteceğim.

    }
}
