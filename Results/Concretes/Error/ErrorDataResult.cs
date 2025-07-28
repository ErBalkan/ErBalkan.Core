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