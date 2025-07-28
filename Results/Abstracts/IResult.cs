namespace ErBalkan.Core.Results.Abstracts;

// Bu arayüz, her işlemin sonucunun başarılı mı yoksa hatalı mı olduğunu belirtmek için kullanılır.
public interface IResult
    {
        // İşlem başarılıysa true, başarısızsa false olur.
        bool Success { get; }

        // Kullanıcıya ya da log sistemine gösterilecek mesajdır.
        string Message { get; }
    }