# OpenChargeMeteringFormat

A .NET implementation of the [Open Charge Metering Format (OCMF)](https://github.com/SAFE-eV/OCMF-Open-Charge-Metering-Format).

## Installation

The package can be found on [nuget.org](https://www.nuget.org/packages/OpenChargeMeteringFormat/).
You can install the package with:

```pwsh
Install-Package OpenChargeMeteringFormat
```

## Usage

There is only one class you should interact with called `OpenChargeMeteringFormatParser`.
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
    Console.WriteLine($"Not a valid OCMF message: {parseResult.Errors.First()?.Message}");

    return;
}

Console.WriteLine($"Identification status: {parseResult.Value.Payload.IdentificationStatus}");
Console.WriteLine($"Identification type: {parseResult.Value.Payload.IdentificationType}");
Console.WriteLine($"Identification data: {parseResult.Value.Payload.IdentificationData}");
```

### Results

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

## License

This library is open-sourced software licensed under the [MIT license](LICENSE).
