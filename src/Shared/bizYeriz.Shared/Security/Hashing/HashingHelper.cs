using System.Security.Cryptography;
using System.Text;
namespace bizYeriz.Shared.Security.Hashing;
public static class HashingHelper
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("Gq0oiyFRkbnww6OhLlM89XvJKAioQePnuojIh0g-NQo=codi"); // Sabit bir key tanımlayın

    /// <summary>
    /// Sabit bir key kullanarak password hash oluşturur.
    /// </summary>
    public static void CreatePasswordHash(string password, out string passwordHash)
    {
        using HMACSHA512 hmac = new(Key); // Sabit key kullanılıyor
        passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }

    /// <summary>
    /// Sabit bir key kullanarak password hash doğrulaması yapar.
    /// </summary>
    public static bool VerifyPasswordHash(string password, string passwordHash)
    {
        using HMACSHA512 hmac = new(Key); // Sabit key kullanılıyor
        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(computedHash) == passwordHash;
    }
}