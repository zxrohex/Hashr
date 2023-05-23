using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hashr.Data.Models;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

using Spectre.Console;

namespace Hashr.Core.Helpers.Extensions
{
    public static class ModelExtensions
    {
        public static IDigest GetDigest(this HashAlgorithm algorithm)
        {
            return algorithm switch
            {
                HashAlgorithm.MD4 => new MD4Digest(),
                HashAlgorithm.MD5 => new MD5Digest(),
                HashAlgorithm.SHA1 => new Sha1Digest(),
                HashAlgorithm.SHA224 => new Sha224Digest(),
                HashAlgorithm.SHA256 => new Sha256Digest(),
                HashAlgorithm.SHA384 => new Sha384Digest(),
                HashAlgorithm.SHA512 => new Sha512Digest(),
                HashAlgorithm.SHA3224 => new Sha3Digest(224),
                HashAlgorithm.SHA3256 => new Sha3Digest(256),
                HashAlgorithm.SHA3384 => new Sha3Digest(384),
                HashAlgorithm.SHA3512 => new Sha3Digest(512),
                HashAlgorithm.RIPEMD128 => new RipeMD128Digest(),
                HashAlgorithm.RIPEMD160 => new RipeMD160Digest(),
                HashAlgorithm.RIPEMD256 => new RipeMD256Digest(),
                HashAlgorithm.RIPEMD320 => new RipeMD320Digest(),
                HashAlgorithm.Whirlpool => new WhirlpoolDigest()
            };
        }
    }

    public static class CryptoExtensions
    {
        public static byte[] GetHashBuffer(this IDigest digest)
        {
            byte[] hashBuffer = new byte[digest.GetDigestSize()];

            return hashBuffer;
        }

        public static string GetHash(this IDigest digest)
        {
            byte[] hashBuffer = digest.GetHashBuffer();

            digest.DoFinal(hashBuffer, 0);

            return hashBuffer.ToReadableString();
        }
    }

    public static class ArrayExtensions
    {
        public static string ToReadableString(this byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", string.Empty).ToLowerInvariant();
        }
    }

    public static class SpectreConsoleExtensions
    {
        
    }
}
