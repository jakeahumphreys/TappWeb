using System.Security.Cryptography;

namespace TappWeb.Common.Security;

public static class PasswordHelper
{
    public static byte[] GenerateSalt()
    {
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }

    public static byte[] HashPassword(string password, byte[] salt)
    {
        using (var pbdkf2 = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            return pbdkf2.GetBytes(32);
        }
    }

    public static bool VerifyPassword(string password, byte[] salt, byte[] hash)
    {
        var computedHash = HashPassword(password, salt);
        return SlowEquals(hash, computedHash);
    }
    
    private static bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }
        return diff == 0;
    }
}