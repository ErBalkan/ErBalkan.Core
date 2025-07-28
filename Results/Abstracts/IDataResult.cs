namespace ErBalkan.Core.Results.Abstracts;

// Bu arayüz, bir işlem sonucunda veri döndürülmesi gerekiyorsa kullanılır.
// IResult'u genişletir, yani hem 'Success' hem 'Message' hem de 'Data' içerir.
public interface IDataResult<T> : IResult
    {
        // Generic T türünde veri taşır (örneğin User, Product, vs.).
        T Data { get; }
    }