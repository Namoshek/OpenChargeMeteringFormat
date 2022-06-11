using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace OpenChargeMeteringFormat.Test
{
    public class ParserTest
    {
        [Fact]
        public void GivenStringWhichDoesNotStartWithOpenChargeMeteringFormatPrefix_IsValidMessage_ReturnsFalse()
        {
            Assert.False(OpenChargeMeteringFormatParser.IsValidMessage(null));
            Assert.False(OpenChargeMeteringFormatParser.IsValidMessage(""));
            Assert.False(OpenChargeMeteringFormatParser.IsValidMessage("FOO"));
            Assert.False(OpenChargeMeteringFormatParser.IsValidMessage("FOO|{}|{}"));
        }

        [Fact]
        public async Task GivenStringWhichStartsWithOpenChargeMeteringFormatPrefixButHasInvalidPayload_IsValidMessage_ReturnsFalse()
        {
            var validMessage = await File.ReadAllTextAsync("Resources/10_ocmf_message_with_invalid_payload");

            Assert.False(OpenChargeMeteringFormatParser.IsValidMessage(validMessage));
        }

        [Fact]
        public async Task GivenStringWhichStartsWithOpenChargeMeteringFormatPrefixButHasInvalidSignature_IsValidMessage_ReturnsFalse()
        {
            var validMessage = await File.ReadAllTextAsync("Resources/11_ocmf_message_with_invalid_signature");

            Assert.False(OpenChargeMeteringFormatParser.IsValidMessage(validMessage));
        }

        [Fact]
        public async Task GivenCompactValidOpenChargingMeteringFormatMessage_ParserParsesInputCorrectly()
        {
            var validMessage = await File.ReadAllTextAsync("Resources/01_valid_ocmf_message_compact");

            Assert.True(OpenChargeMeteringFormatParser.IsValidMessage(validMessage));

            var message = OpenChargeMeteringFormatParser.ParseMessage(validMessage);

            Assert.NotNull(message);
            Assert.NotNull(message.Payload);
            Assert.NotNull(message.Signature);

            Assert.Equal("1.0", message.Payload.MeterFirmwareVersion);
            Assert.Equal("ABL SBC-301", message.Payload.GatewayIdentification);
            Assert.Equal("808829900001", message.Payload.GatewaySerialNumber);
            Assert.Equal("1.4p3", message.Payload.GatewayVersion);
            Assert.Equal("T12345", message.Payload.Pagination);
            Assert.Equal("Phoenix Contact", message.Payload.MeterVendor);
            Assert.Equal("EEM-350-D-MCB", message.Payload.MeterModel);
            Assert.Equal("BQ27400330016", message.Payload.MeterSerialNumber);
            Assert.Equal("1.0", message.Payload.MeterFirmwareVersion);
            Assert.True(message.Payload.IdentificationStatus);
            Assert.Equal(Types.EIdentificationLevel.Verified, message.Payload.IdentificationLevel);
            Assert.Equal(2, message.Payload.IdentificationFlags.Length);
            Assert.Contains(Types.EIdentificationFlag.RFID_Plain, message.Payload.IdentificationFlags);
            Assert.Contains(Types.EIdentificationFlag.OCPP_RemoteStartWithTls, message.Payload.IdentificationFlags);
            Assert.Equal(Types.EIdentificationType.ISO14443, message.Payload.IdentificationType);
            Assert.Equal("1F2D3A4F5506C7", message.Payload.IdentificationData);

            Assert.Single(message.Payload.Readings);
            Assert.Equal(new DateTimeOffset(2018, 7, 24, 13, 22, 4, TimeSpan.FromHours(2)), message.Payload.Readings[0].Time.Timestamp);
            Assert.Equal(Types.ETimeSynchronizationState.Synchronized, message.Payload.Readings[0].Time.SynchronizationState);
            Assert.Equal(Types.ETransactionReadingReason.BeginOfTransaction, message.Payload.Readings[0].TransactionReadingReason);
            Assert.Equal(2935.6M, message.Payload.Readings[0].ReadingValue);
            Assert.Equal("1-b:1.8.0", message.Payload.Readings[0].ReadingIdentification);
            Assert.Equal(Types.EReadingUnit.KiloWatthour, message.Payload.Readings[0].ReadingUnit);
            Assert.Equal(Types.EReadingCurrentType.AC, message.Payload.Readings[0].ReadingCurrentType);
            Assert.Empty(message.Payload.Readings[0].ErrorFlags);
            Assert.Equal(Types.EReadStatus.Ok, message.Payload.Readings[0].ReadStatus);

            Assert.Equal(Types.ESignatureAlgorithm.ECDSA_secp256r1_SHA256, message.Signature.Algorithm);
            Assert.Equal(Types.ESignatureEncoding.Hex, message.Signature.Encoding);
            Assert.Equal(Types.ESignatureMimeType.ASN_1, message.Signature.MimeType);
            Assert.Equal("887FABF407AC82782EEFFF2220C2F856AEB0BC22364BBCC6B55761911ED651D1A922BADA88818C9671AFEE7094D7F536", message.Signature.Data);
        }

        [Fact]
        public async Task GivenFormattedValidOpenChargingMeteringFormatMessage_ParserParsesInputCorrectly()
        {
            var validMessage = await File.ReadAllTextAsync("Resources/02_valid_ocmf_message_formatted");

            Assert.True(OpenChargeMeteringFormatParser.IsValidMessage(validMessage));

            var message = OpenChargeMeteringFormatParser.ParseMessage(validMessage);

            Assert.NotNull(message);
            Assert.NotNull(message.Payload);
            Assert.NotNull(message.Signature);

            Assert.Equal("1.0", message.Payload.MeterFirmwareVersion);
            Assert.Equal("ABL SBC-301", message.Payload.GatewayIdentification);
            Assert.Equal("808829900001", message.Payload.GatewaySerialNumber);
            Assert.Equal("1.4p3", message.Payload.GatewayVersion);
            Assert.Equal("T12345", message.Payload.Pagination);
            Assert.Equal("Phoenix Contact", message.Payload.MeterVendor);
            Assert.Equal("EEM-350-D-MCB", message.Payload.MeterModel);
            Assert.Equal("BQ27400330016", message.Payload.MeterSerialNumber);
            Assert.Equal("1.0", message.Payload.MeterFirmwareVersion);
            Assert.True(message.Payload.IdentificationStatus);
            Assert.Equal(Types.EIdentificationLevel.Verified, message.Payload.IdentificationLevel);
            Assert.Equal(2, message.Payload.IdentificationFlags.Length);
            Assert.Contains(Types.EIdentificationFlag.RFID_Plain, message.Payload.IdentificationFlags);
            Assert.Contains(Types.EIdentificationFlag.OCPP_RemoteStartWithTls, message.Payload.IdentificationFlags);
            Assert.Equal(Types.EIdentificationType.ISO14443, message.Payload.IdentificationType);
            Assert.Equal("1F2D3A4F5506C7", message.Payload.IdentificationData);

            Assert.Single(message.Payload.Readings);
            Assert.Equal(new DateTimeOffset(2018, 7, 24, 13, 22, 4, TimeSpan.FromHours(2)), message.Payload.Readings[0].Time.Timestamp);
            Assert.Equal(Types.ETimeSynchronizationState.Synchronized, message.Payload.Readings[0].Time.SynchronizationState);
            Assert.Equal(Types.ETransactionReadingReason.BeginOfTransaction, message.Payload.Readings[0].TransactionReadingReason);
            Assert.Equal(2935.6M, message.Payload.Readings[0].ReadingValue);
            Assert.Equal("1-b:1.8.0", message.Payload.Readings[0].ReadingIdentification);
            Assert.Equal(Types.EReadingUnit.KiloWatthour, message.Payload.Readings[0].ReadingUnit);
            Assert.Equal(Types.EReadingCurrentType.AC, message.Payload.Readings[0].ReadingCurrentType);
            Assert.Empty(message.Payload.Readings[0].ErrorFlags);
            Assert.Equal(Types.EReadStatus.Ok, message.Payload.Readings[0].ReadStatus);

            Assert.Equal(Types.ESignatureAlgorithm.ECDSA_secp256r1_SHA256, message.Signature.Algorithm);
            Assert.Equal(Types.ESignatureEncoding.Hex, message.Signature.Encoding);
            Assert.Equal(Types.ESignatureMimeType.ASN_1, message.Signature.MimeType);
            Assert.Equal("887FABF407AC82782EEFFF2220C2F856AEB0BC22364BBCC6B55761911ED651D1A922BADA88818C9671AFEE7094D7F536", message.Signature.Data);
        }
    }
}