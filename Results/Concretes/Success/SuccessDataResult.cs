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