using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FluentResults;
using OpenChargeMeteringFormat.Errors;
using OpenChargeMeteringFormat.Types;
using OpenChargeMeteringFormat.Util;

namespace OpenChargeMeteringFormat
{
    /// <summary>
    /// A signature verifier for the <see href="https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format">OCMF protocol</see>.
    /// </summary>
    public static class OpenChargeMeteringFormatVerifier
    {
        /// <summary>
        /// Verifies the integrity of the given <paramref name="message"/> using the given <paramref name="publicKey"/>.
        /// The <paramref name="publicKey"/> is expected to be a string in HEX format (upper or lower case)
        /// and only basic normalization (e.g. removal of spaces) is performed on it.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="publicKey"></param>
        public static Result Verify(OpenChargeMeteringFormatMessage message, string publicKey)
        {
            // Validate and normalize the public key.
            byte[] publicKeyBytes;
            try
            {
                if (string.IsNullOrWhiteSpace(publicKey))
                {
                    return Result.Fail(new InvalidPublicKey("The public key may not be null or white space only."));
                }

                publicKey = publicKey.Replace(" ", "");

                if (publicKey.Length % 2 != 0)
                {
                    return Result.Fail(new InvalidPublicKey("The public key has an unexpected length (odd number of characters)."));
                }

                if (!publicKey.IsHex())
                {
                    return Result.Fail(new InvalidPublicKey("The public key is not in HEX format."));
                }

                publicKeyBytes = publicKey.ToByteArray();

                PublicKey.CreateFromSubjectPublicKeyInfo(publicKeyBytes, out var publicKeyBytesRead);

                if (publicKeyBytesRead != publicKeyBytes.Length)
                {
                    return Result.Fail(new InvalidPublicKey("The public key is invalid. It must be in ASN.1 format."));
                }
            }
            catch (Exception ex)
            {
                return Result.Fail(new InvalidPublicKey("The public key is invalid. It could not loaded.").CausedBy(ex));
            }


            // Perform the actual verification of the signature.
            // Note: currently, only EDCSA is supported; this code needs refactoring if other algorithms are added to the OCMF protocol.
            try
            {
                var internalCurveName = MapAlgorithmToCurveName(message.Signature.Algorithm);
                var ecdsa = ECDsa.Create(ECCurve.CreateFromFriendlyName(internalCurveName));

                ecdsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out var _);

                var verificationResult = ecdsa.VerifyData(
                    data: Encoding.UTF8.GetBytes(message.RawPayload),
                    signature: message.Signature.Data.ToByteArray(),
                    hashAlgorithm: HashAlgorithmName.SHA256,
                    signatureFormat: DSASignatureFormat.Rfc3279DerSequence);

                return verificationResult
                    ? Result.Ok()
                    : Result.Fail(new InvalidSignature());
            }
            catch (Exception ex)
            {
                return Result.Fail(new SignatureVerificationFailed().CausedBy(ex));
            }
        }

        /// <summary>
        /// Maps the given <paramref name="algorithm"/> to a curve name understood by the <see cref="ECDsa"/> class.
        /// </summary>
        /// <param name="algorithm"></param>
        /// <exception cref="NotSupportedException"></exception>
        private static string MapAlgorithmToCurveName(ESignatureAlgorithm algorithm)
        {
            return algorithm switch
            {
                ESignatureAlgorithm.ECDSA_brainpool256r1_SHA256 => "brainpoolP256r1",
                ESignatureAlgorithm.ECDSA_brainpool384r1_SHA256 => "brainpoolP384r1",
                ESignatureAlgorithm.ECDSA_secp192k1_SHA256 => "secp192k1",
                ESignatureAlgorithm.ECDSA_secp256k1_SHA256 => "secp256k1",
                ESignatureAlgorithm.ECDSA_secp192r1_SHA256 => "secp192r1",
                ESignatureAlgorithm.ECDSA_secp256r1_SHA256 => "secp256r1",
                ESignatureAlgorithm.ECDSA_secp384r1_SHA256 => "secp384r1",
              
                _ => throw new NotSupportedException($"The signature algorithm {algorithm} is not supported by the verifier."),
            };
        }
    }
}
