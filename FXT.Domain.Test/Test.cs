using System;
using FXT.Domain.Entities;
using Xunit;

public class CurrencyRateAdvancedTests
{
    [Fact]
    public void Can_Create_Valid_CurrencyRate()
    {
        // Arrange
        var id = Guid.NewGuid();
        var date = DateTime.UtcNow;
        var currencyPair = "USD/EUR";
        var rate = 1.1234m;

        // Act
        var currencyRate = new CurrencyRate
        {
            Id = id,
            Date = date,
            CurrencyPair = currencyPair,
            Rate = rate
        };

        // Assert
        Assert.Equal(id, currencyRate.Id);
        Assert.Equal(date, currencyRate.Date);
        Assert.Equal(currencyPair, currencyRate.CurrencyPair);
        Assert.Equal(rate, currencyRate.Rate);
    }

    [Fact]
    public void Cannot_Set_Invalid_Rate()
    {
        // Arrange
        var currencyRate = new CurrencyRate();

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => currencyRate.Rate = -1m);
    }

    [Fact]
    public void Can_Update_CurrencyRate()
    {
        // Arrange
        var currencyRate = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/EUR",
            Rate = 1.1234m
        };

        // Act
        currencyRate.Rate = 1.2345m;

        // Assert
        Assert.Equal(1.2345m, currencyRate.Rate);
    }

    [Fact]
    public void Can_Compare_Two_CurrencyRates_By_Rate()
    {
        // Arrange
        var rate1 = new CurrencyRate { Rate = 1.1234m };
        var rate2 = new CurrencyRate { Rate = 1.2345m };

        // Act
        var comparison = rate1.Rate < rate2.Rate;

        // Assert
        Assert.True(comparison, "Expected rate1 to be less than rate2.");
    }
}
