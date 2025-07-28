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