using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SpacenditureAuthentication.Services
{
  public class ComputeSha256Hash
  {

    public string hashedString { get; }

    public ComputeSha256Hash(string password, byte[] salt)
    {
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(salt);
      }
      string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
          password: password,
          salt: salt,
          prf: KeyDerivationPrf.HMACSHA256,
          iterationCount: 10000,
          numBytesRequested: 256 / 8));
      hashedString = hashed + "." + Convert.ToBase64String(salt);
    }
  }
}
