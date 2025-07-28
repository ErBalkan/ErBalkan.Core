# ✅ ADIM 2: Result Yapısı

CRUD (Create, Read, Update, Delete) işlemleri yaparken genelde bu soruları sorarız:

- İşlem başarılı mı?

- Hata varsa mesaj ne?

- Veri dönecekse, hangi veri döndü?

Tüm bu sorulara cevap verebilecek ortak dönüş modellerine ihtiyacımız var.
Bu yüzden `Result Pattern` denilen yapıyı kuracağız.

## 💡 Gerçek Dünya Benzetmesi

Bankadan bir işlem yaptığında SMS gelir:
“✅ Para transferiniz başarıyla gerçekleşti.”
İşte bu mesaj Result.
Paranın kaç lira olduğu ise DataResult.

## IResult.cs

```csharp
namespace ErBalkan.Core.Results.Abstracts;

// Bu arayüz, her işlemin sonucunun başarılı mı yoksa hatalı mı olduğunu belirtmek için kullanılır.
public interface IResult
    {
        // İşlem başarılıysa true, başarısızsa false olur.
        bool Success { get; }

        // Kullanıcıya ya da log sistemine gösterilecek mesajdır.
        string Message { get; }
    }
```

## IDataResult.cs

```csharp
namespace ErBalkan.Core.Results.Abstracts;

// Bu arayüz, bir işlem sonucunda veri döndürülmesi gerekiyorsa kullanılır.
// IResult'u genişletir, yani hem 'Success' hem 'Message' hem de 'Data' içerir.
public interface IDataResult<T> : IResult
    {
        // Generic T türünde veri taşır (örneğin User, Product, vs.).
        T Data { get; }
    }
```

## Result.cs

```csharp
using ErBalkan.Core.Results.Abstracts;

namespace ErBalkan.Core.Results.Concretes;

// Bu sınıf, işlemin başarılı mı değil mi olduğunu ve mesajını döndürmek için kullanılır.
// Örneğin: "Kayıt silindi." veya "Böyle bir kullanıcı yok."

public class Result : IResult
    {
        // 'get' ile sadece okunabilir yapılardır.
        public bool Success { get; }

        public string Message { get; }

        // Constructor: Bu sınıf new'lendiğinde Success ve Message atanır.
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
```

## DataResult.cs

```csharp
using ErBalkan.Core.Results.Abstracts;

namespace ErBalkan.Core.Results.Concretes;

// Bu sınıf, hem işlem sonucu (başarılı mı?) hem mesaj hem de veri döndürür.

public class DataResult<T> : Result, IDataResult<T>
    {
        // 'Data' isimli property, döndürülmek istenen veriyi tutar.
        public T Data { get; }

        // Constructor: Hem veri hem işlem sonucu hem de mesaj alınır.
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
    }
```

## ErrorResult.cs

```csharp
namespace ErBalkan.Core.Results.Concretes.Error;

// Bu sınıf işlemin başarısız olduğunu otomatik olarak belirtir.
public class ErrorResult : Result
    {
        // Sadece mesaj alır, success değeri her zaman false olur.
        public ErrorResult(string message) : base(false, message)
        {
        }
    }
```

## ErrorDataResult.cs

```csharp
namespace ErBalkan.Core.Results.Concretes.Error;

// Veri dönen işlemlerde kullanılır. Başarısız olduğu varsayılır.
public class ErrorDataResult<T> : DataResult<T>
    {
        // Hem veri hem mesaj alır, success false olur.
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        // Sadece veri alır, mesaj boş geçilir.
        public ErrorDataResult(T data) : base(data, false, string.Empty)
        {
        }
    }
```

## SuccessResult.cs

```csharp
namespace ErBalkan.Core.Results.Concretes.Success;

// Bu sınıf işlemin başarılı olduğunu otomatik olarak belirtir.
public class SuccessResult : Result
    {
        // Sadece mesaj alır, success değeri her zaman true olur.
        public SuccessResult(string message) : base(true, message)
        {
        }
    }
```

## SuccessDataResult.cs

```csharp
namespace ErBalkan.Core.Results.Concretes.Success;

// Veri dönen işlemlerde kullanılır. Başarılı olduğu varsayılır.
public class SuccessDataResult<T> : DataResult<T>
    {
        // Hem veri hem mesaj alır, success true olur.
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }

        // Sadece veri alır, mesaj boş geçilir.
        public SuccessDataResult(T data) : base(data, true, string.Empty)
        {
        }
    }
```

## 🧠 Bu Sınıflar Ne İşe Yarar?

| Sınıf                  | Ne İşe Yarar                                  |
| ---------------------- | --------------------------------------------- |
| `SuccessResult`        | Başarılı ama veri dönmeyen işlemler için      |
| `ErrorResult`          | Hatalı ama veri dönmeyen işlemler için        |
| `SuccessDataResult<T>` | Başarılı ve veri dönen işlemler için          |
| `ErrorDataResult<T>`   | Hatalı ama veri dönmesi gereken işlemler için |

## 🔁 Kullanım Örnekleri

```csharp
// Kayıt başarılı
return new SuccessResult("Kayıt başarıyla oluşturuldu");

// Kullanıcı bulundu
return new SuccessDataResult<UserDto>(userDto, "Kullanıcı bulundu");

// Kullanıcı yok
return new ErrorResult("Kullanıcı bulunamadı");

// Kullanıcı null döndü ama hata mesajı göstermek istiyoruz
return new ErrorDataResult<UserDto>(null, "Kullanıcı bulunamadı");
```

## 💡 Ekstra Bilgi: Generic Neden Var?

`DataResult<T>` ve onun çocukları (SuccessDataResult, ErrorDataResult) içinde `<T>` ifadesi var çünkü her veri tipi için kullanılabilir olmasını istiyoruz:

UserDto, ProductDto, CategoryDto gibi tüm tiplerle kullanılabilir.

Tek bir sınıf yazıp tüm veri türlerini taşıyabilmek için Generic yazı kullanıyoruz.
