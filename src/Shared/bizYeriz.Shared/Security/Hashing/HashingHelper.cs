using System.Security.Cryptography;
using System.Text;

namespace bizYeriz.Shared.Security.Hashing;

public static class HashingHelper
{
    /// <summary>
    /// Create a password hash via HMACSHA512 without using salt.
    /// </summary>
    public static void CreatePasswordHash(string password, out string passwordHash)
    {
        using HMACSHA512 hmac = new();

        // Sadece şifreyi hash'liyoruz, salt kullanmıyoruz
        passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));  // Hash'i Base64 string olarak sakla
    }

    /// <summary>
    /// Verify a password hash via HMACSHA512.
    /// </summary>
    public static bool VerifyPasswordHash(string password, string passwordHash)
    {
        using HMACSHA512 hmac = new();

        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(computedHash) == passwordHash;  // Hash'i karşılaştır
    }
}

