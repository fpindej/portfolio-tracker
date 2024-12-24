using System.ComponentModel.DataAnnotations;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PortfolioTracker.CsvParser.Models;
using PortfolioTracker.CsvParser.Services;
using PortfolioTracker.Domain;

namespace PortfolioTracker.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
public class TestController : ControllerBase
{
    private readonly CsvParsingService _csvParsingService;

    public TestController(CsvParsingService csvParsingService)
    {
        _csvParsingService = csvParsingService ?? throw new ArgumentNullException(nameof(csvParsingService));
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadCsv([FromForm] UploadCsvFormModel? formModel)
    {
        if (formModel?.File.Length is 0)
        {
            return BadRequest("No file uploaded.");
        }

        var file = formModel!.File;

        try
        {
            await using var stream = file.OpenReadStream();

            var dtos = _csvParsingService.FromCsv<BitcoinTransactionCsv>(stream);

            var transactions = dtos.Select(ToBitcoinTransaction).ToList();

            return Ok(transactions);
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to process the CSV file: {ex.Message}");
        }
    }

    private static BitcoinTransaction ToBitcoinTransaction(BitcoinTransactionCsv dto)
    {
        return new BitcoinTransaction
        {
            Id = dto.TransactionId,
            TransactionDateTime = CombineDateAndTime(dto.Date, dto.Time),
            BtcAmount = dto.BtcAmount,
            BtcCurrency = dto.BtcCurrency,
            FiatPrice = dto.FiatPrice,
            FiatFee = dto.FiatFee,
            FiatCurrency = dto.FiatCurrency,
            Notes = dto.Notes
        };
    }
    
    private static DateTime CombineDateAndTime(DateTime date, TimeSpan time)
    {
        var combinedDateTime = date.Date + time;

        return DateTime.SpecifyKind(combinedDateTime, DateTimeKind.Utc);
    }
}

public class UploadCsvFormModel
{
    [Required]
    public IFormFile File { get; set; } = null!;
}