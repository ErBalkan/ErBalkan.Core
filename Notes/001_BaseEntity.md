# ✅ ADIM 1: BaseEntity.cs Dosyasını Oluşturmak

## 📄 Core/Base/BaseEntity.cs

```csharp
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
```

### 🧠 Ne İşe Yarar Bu Kod?

Bu BaseEntity sınıfı, tüm veritabanı varlıklarının (entity’lerin) kalıtım alacağı temel bir yapıdır.
Yani ileride bir User veya Product sınıfı yazarsan, bu sınıftan kalıtım alacak ve bu ortak özelliklere (Id, CreatedDate vs.) sahip olacak.

❗ Bu sayede her entity sınıfına ayrı ayrı Id, CreatedDate, UpdatedDate yazmak zorunda kalmazsın. Tek bir yerden yönetilir.
Buna DRY (Don't Repeat Yourself) prensibi denir.

### 🔁 Kısaca Hatırlarsak:

| Özellik          | Anlamı                                                          |
| ---------------- | --------------------------------------------------------------- |
| `Guid Id`        | Her kaydın benzersiz kimliği (rastgele oluşturulan veri)        |
| `CreatedDate`    | O nesnenin ilk oluşturulduğu zaman                              |
| `UpdatedDate`    | O nesne güncellenirse, son güncelleme zamanı (yoksa null kalır) |
| `abstract class` | Doğrudan kullanılmaz, başka sınıflar bu sınıfı kalıtım alır     |


### 🧪 Örnek Kullanım (ileride)

```csharp
public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
}
```
User sınıfı, BaseEntity'den kalıtım alır ve artık otomatik olarak Id, CreatedDate, UpdatedDate özelliklerine sahiptir.

### 💡 Gerçek dünya benzetmesi:

BaseEntity, bir kimlik kartı gibi.
Hangi kuruma gidersen git (kullanıcı, ürün, sipariş), herkesin bir kimliği (Id), doğum tarihi (CreatedDate) ve belki değişiklik tarihi (UpdatedDate) olur. Bu temel bilgileri tek bir sınıfa koyduk.
