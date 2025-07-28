namespace ErBalkan.Core.Results.Concretes.Success;

// Bu sınıf işlemin başarılı olduğunu otomatik olarak belirtir.
public class SuccessResult : Result
    {
        // Sadece mesaj alır, success değeri her zaman true olur.
        public SuccessResult(string message) : base(true, message)
        {
        }
    }