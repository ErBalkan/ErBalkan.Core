namespace ErBalkan.Core.Base;

// Bu sınıf tüm Entity sınıflarının temelidir.
// Yani veritabanına kaydedilecek her şey (örneğin kullanıcı, ürün, kategori) bu sınıftan kalıtım alır.

// 'abstract' demek: Bu sınıftan doğrudan nesne (örnek) oluşturulamaz.
// Ama bu sınıf başka sınıflar tarafından kalıtım alınabilir.
public abstract class BaseEntity
    {
        // Her nesnenin (örneğin her kullanıcı, her ürün) benzersiz bir kimliği olmalı.
        // 'Guid', sistemin otomatik olarak oluşturduğu rastgele ve benzersiz bir kimliktir.
        public Guid Id { get; set; }

        // Nesne ilk oluşturulduğunda sistemin kaydettiği tarih.
        // UTC zamanı kullanılır çünkü dünya genelinde saat farkı olabilir.
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Eğer nesne güncellenirse, buraya o güncelleme tarihi yazılır.
        // '?' işareti, bu alanın boş geçilebileceği (nullable) anlamına gelir.
        public DateTime? UpdatedDate { get; set; }
    }