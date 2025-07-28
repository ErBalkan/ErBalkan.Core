namespace ErBalkan.Core.Results.Concretes.Error;

// Bu sınıf işlemin başarısız olduğunu otomatik olarak belirtir.
public class ErrorResult : Result
    {
        // Sadece mesaj alır, success değeri her zaman false olur.
        public ErrorResult(string message) : base(false, message)
        {
        }
    }