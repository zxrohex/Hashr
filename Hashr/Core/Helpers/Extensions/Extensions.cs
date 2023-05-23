using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hashr.Data.Models;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

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
}
