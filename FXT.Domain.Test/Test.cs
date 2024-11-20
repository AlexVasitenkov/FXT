using System;
using FXT.Domain.Entities;
using Xunit;

public class CurrencyRateAdvancedTests
{
    [Fact]
    public void Can_Create_Valid_CurrencyRate()
    {
        var id = Guid.NewGuid();
        var date = DateTime.UtcNow;
        var currencyPair = "USD/EUR";
        var rate = 1.1234m;

        var currencyRate = new CurrencyRate
        {
            Id = id,
            Date = date,
            CurrencyPair = currencyPair,
            Rate = rate
        };

        Assert.Equal(id, currencyRate.Id);
        Assert.Equal(date, currencyRate.Date);
        Assert.Equal(currencyPair, currencyRate.CurrencyPair);
        Assert.Equal(rate, currencyRate.Rate);
    }

    [Fact]
    public void Cannot_Set_Invalid_Rate()
    {
        var currencyRate = new CurrencyRate();

        Assert.Throws<ArgumentOutOfRangeException>(() => currencyRate.Rate = -1m);
    }

    [Fact]
    public void Can_Update_CurrencyRate()
    {
        var currencyRate = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/EUR",
            Rate = 1.1234m
        };

        currencyRate.Rate = 1.2345m;

        Assert.Equal(1.2345m, currencyRate.Rate);
    }

    [Fact]
    public void Can_Compare_Two_CurrencyRates_By_Rate()
    {
        var rate1 = new CurrencyRate { Rate = 1.1234m };
        var rate2 = new CurrencyRate { Rate = 1.2345m };

        var comparison = rate1.Rate < rate2.Rate;

        Assert.True(comparison, "Expected rate1 to be less than rate2.");
    }
}
