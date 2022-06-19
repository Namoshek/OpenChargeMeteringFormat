# OpenChargeMeteringFormat [![Nuget](https://img.shields.io/nuget/v/OpenChargeMeteringFormat?style=flat-square)](https://nuget.org/packages/OpenChargeMeteringFormat)

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Namoshek_OpenChargeMeteringFormat&metric=coverage)](https://sonarcloud.io/summary/new_code?id=Namoshek_OpenChargeMeteringFormat)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Namoshek_OpenChargeMeteringFormat&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Namoshek_OpenChargeMeteringFormat)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=Namoshek_OpenChargeMeteringFormat&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=Namoshek_OpenChargeMeteringFormat)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=Namoshek_OpenChargeMeteringFormat&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=Namoshek_OpenChargeMeteringFormat)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=Namoshek_OpenChargeMeteringFormat&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=Namoshek_OpenChargeMeteringFormat)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=Namoshek_OpenChargeMeteringFormat&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=Namoshek_OpenChargeMeteringFormat)

A .NET implementation of the [Open Charge Metering Format (OCMF)](https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format).

## Installation

The package can be found on [nuget.org](https://www.nuget.org/packages/OpenChargeMeteringFormat/).
You can install the package with:

```pwsh
Install-Package OpenChargeMeteringFormat
```

## Usage

### Parse OCMF

To parse an OCMF message, use the `OpenChargeMeteringFormatParser`.
It provides you with two methods to validate and parse OCMF messages:

```csharp
var message = "OCMF|{...}|{...}";

// Optional: validate messages before usage
if (!OpenChargeMeteringFormatParser.IsValidMessage(message))
{
    Console.WriteLine("Not a valid OCMF message.");

    return;
}

// Mandatory: parse messages with implicit validation
var parseResult = OpenChargeMeteringFormatParser.ParseMessage(message);
if (parseResult.IsFailed)
{
    if (parseResult.HasError<InputIsNotAnOpenChargeMeteringFormatMessage>())
    {
        Console.WriteLine("The given string is not a valid OCMF message according to the specification.");
    }
    else if (parseResult.HasError<PayloadHasAnInvalidFormat>())
    {
        Console.WriteLine("The given OCMF message contains an invalid payload.");
    }
    else
    {
        Console.WriteLine($"Not a valid OCMF message: {parseResult.Errors.First().Message}");
    }

    return;
}

Console.WriteLine($"Identification status: {parseResult.Value.Payload.IdentificationStatus}");
Console.WriteLine($"Identification type: {parseResult.Value.Payload.IdentificationType}");
Console.WriteLine($"Identification data: {parseResult.Value.Payload.IdentificationData}");
```

`IsValidMessage(message)` will only perform structural tests, no actual verification of the signature.

### Verify OCMF signature

To verify the signature of a parsed OCMF message, use the `OpenChargeMeteringFormatVerifier`.
It provides a `Verify(OpenChargeMeteringFormatMessage message, string publicKey)` method,
where you have to pass the output of `OpenChargeMeteringFormatParser.ParseMessage(message)`
as well as the public key of the charge point meter.

```csharp
var message = "OCMF|{...}|{...}";
var publicKey = "A0B1C2...";

var parseResult = OpenChargeMeteringFormatParser.ParseMessage(message);
if (parseResult.IsFailed)
{
    return;
}

var verificationResult = OpenChargeMeteringFormatVerifier.Verify(parseResult.Value, publicKey);
if (verificationResult.IsFailed)
{
    Console.WriteLine("The OCMF message has an invalid signature or the provided public key is invalid.");
}
```

### Method results

This library makes use of [`FluentResults`](https://github.com/altmann/FluentResults),
which allows returning a `Result<OpenChargeMeteringFormatMessage>` covering both,
the success and the error scenario.

To check for success, use `Result<OpenChargeMeteringFormatMessage>.IsSuccess`.
A success result will also contain a valid `Result<OpenChargeMeteringFormatMessage>.Value`
with the parsed OCMF message as content.

To check for failure, use `Result<OpenChargeMeteringFormatMessage>.IsFailed`.
In case of failure, the result _may_ contains errors which can be retrieved using
`Result<OpenChargeMeteringFormatMessage>.Errors`. To check for presence of errors,
use `Result<OpenChargeMeteringFormatMessage>.Errors.Any()`.

`IsSuccess` and `IsFailed` are mutually exclusive, i.e. when one is `true`, the other is `false`.

## License

This library is open-sourced software licensed under the [MIT license](LICENSE).
