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