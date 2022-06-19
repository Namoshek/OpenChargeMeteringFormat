using OpenChargeMeteringFormat.Errors;
using System.IO;
using Xunit;

namespace OpenChargeMeteringFormat.Test
{
    public class VerifierTest
    {
        [Fact]
        public void GivenAnOpenChargeMeteringFormatMessage_AndThePublicKeyOfTheMeter_VerificationReturnsTrue()
        {
            // Private key: 3077020101042048F11DC78903B9B5B42164F6A9F4B24770F3E338320AAC425704CD2AEC88A533A00A06082A8648CE3D030107A14403420004FDF1692847E151B2FBCDBE4CE7C0F79AD838987205B34DE419CFDF3490AB94D8C4B1AE5D9D997B669D05029D79D9711F393D732789BECBA741B51663D68A6342
            // Public key: 3059301306072A8648CE3D020106082A8648CE3D03010703420004FDF1692847E151B2FBCDBE4CE7C0F79AD838987205B34DE419CFDF3490AB94D8C4B1AE5D9D997B669D05029D79D9711F393D732789BECBA741B51663D68A6342
            // Signature: 30460221008690B1B3C2DFC5342FE663DF94CC9D7176832349E74A88A433CBF53889428F37022100829555A660C77E2DE94B0E078ECC420CCD815B84D17B8C53F7BD3CEFC99FB818

            var publicKey = "3059301306072A8648CE3D020106082A8648CE3D03010703420004FDF1692847E151B2FBCDBE4CE7C0F79AD838987205B34DE419CFDF3490AB94D8C4B1AE5D9D997B669D05029D79D9711F393D732789BECBA741B51663D68A6342";
            var signature = File.ReadAllText("Resources/20_valid_ocmf_message_for_verification");

            var ocmf = OpenChargeMeteringFormatParser.ParseMessage(signature);

            Assert.True(ocmf.IsSuccess);

            var verificationResult = OpenChargeMeteringFormatVerifier.Verify(ocmf.Value, publicKey);

            Assert.True(verificationResult.IsSuccess);
        }

        [Fact]
        public void GivenAnOpenChargeMeteringFormatMessage_AndTheWrongPublicKey_VerificationReturnsFalse()
        {
            var publicKey = "3059301306072A8648CE3D020106082A8648CE3D03010703420004873461318BAC67A8A5481D3C11CCAB63887517E0348EA912BCD99D84FDDD723302E589B843B7BD33FC93EFFFD01E40A7CBBBE70F5BB97DB462F221842DA1401C";
            var signature = File.ReadAllText("Resources/20_valid_ocmf_message_for_verification");

            var ocmf = OpenChargeMeteringFormatParser.ParseMessage(signature);

            Assert.True(ocmf.IsSuccess);

            var verificationResult = OpenChargeMeteringFormatVerifier.Verify(ocmf.Value, publicKey);

            Assert.True(verificationResult.IsFailed);
            Assert.True(verificationResult.HasError<InvalidSignature>());
        }

        [Fact]
        public void GivenAnOpenChargeMeteringFormatMessage_AndAnInvalidPublicKey_VerificationReturnsFalse()
        {
            var publicKey = "C1041AD248122F264BD79BB5F07EBBBC7A04E10DFFFE39CF33DB7B348B985E203327DDDF48D99DCB219AE8430E71578836BACC11C3D1845A8A76CAB81316437840002430701030D3EC8468A280601020D3EC8468A2706031039503";
            var signature = File.ReadAllText("Resources/20_valid_ocmf_message_for_verification");

            var ocmf = OpenChargeMeteringFormatParser.ParseMessage(signature);

            Assert.True(ocmf.IsSuccess);

            var verificationResult = OpenChargeMeteringFormatVerifier.Verify(ocmf.Value, publicKey);

            Assert.True(verificationResult.IsFailed);
            Assert.True(verificationResult.HasError<InvalidPublicKey>());
        }
    }
}
