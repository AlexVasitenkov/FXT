using System;
using System.Linq;
using System.Threading.Tasks;
using FXT.Domain.Entities;
using FXT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class CurrencyRateRepositoryTests
{
    private CurrencyRateRepository GetRepository()
    {
        var options = new DbContextOptionsBuilder<FXTimeSeriesDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Изолированная база для каждого теста
            .Options;

        var context = new FXTimeSeriesDbContext(options);
        return new CurrencyRateRepository(context);
    }

    [Fact]
    public async Task Can_Add_And_Retrieve_CurrencyRate()
    {
        var repository = GetRepository();
        var rate = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/EUR",
            Rate = 1.1234m
        };

        await repository.AddCurrencyRateAsync(rate);
        var retrievedRates = await repository.GetAllCurrencyRatesAsync();

        Assert.Single(retrievedRates);
        Assert.Equal("USD/EUR", retrievedRates.First().CurrencyPair);
    }

    [Fact]
    public async Task Can_Filter_CurrencyRates_By_CurrencyPair()
    {
        var repository = GetRepository();
        var rate1 = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/EUR",
            Rate = 1.1234m
        };
        var rate2 = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/JPY",
            Rate = 110.567m
        };

        await repository.AddCurrencyRateAsync(rate1);
        await repository.AddCurrencyRateAsync(rate2);

        var filteredRates = await repository.GetRatesByCurrencyPairAsync("USD/EUR");

        Assert.Single(filteredRates);
        Assert.Equal("USD/EUR", filteredRates.First().CurrencyPair);
    }

    [Fact]
    public async Task Can_Update_CurrencyRate()
    {
        var options = new DbContextOptionsBuilder<FXTimeSeriesDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new FXTimeSeriesDbContext(options);
        var repository = new CurrencyRateRepository(context);

        var rate = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/EUR",
            Rate = 1.1234m
        };

        await repository.AddCurrencyRateAsync(rate);

        rate.Rate = 1.2345m;
        await repository.UpdateCurrencyRateAsync(rate);

        var updatedRate = (await repository.GetAllCurrencyRatesAsync()).First();

        Assert.Equal(1.2345m, updatedRate.Rate);
    }
    [Fact]
    public async Task Can_Delete_CurrencyRate()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<FXTimeSeriesDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new FXTimeSeriesDbContext(options);
        var repository = new CurrencyRateRepository(context);

        var rate = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/EUR",
            Rate = 1.1234m
        };

        await repository.AddCurrencyRateAsync(rate);

        context.CurrencyRates.Remove(rate);
        await context.SaveChangesAsync();

        var remainingRates = await repository.GetAllCurrencyRatesAsync();

        Assert.Empty(remainingRates);
    }


    [Fact]
    public async Task Can_Handle_Failed_Operation_Simulation()
    {
        var options = new DbContextOptionsBuilder<FXTimeSeriesDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        using var context = new FXTimeSeriesDbContext(options);
        var repository = new CurrencyRateRepository(context);

        var rate1 = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/EUR",
            Rate = 1.1234m
        };

        var rate2 = new CurrencyRate
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            CurrencyPair = "USD/JPY",
            Rate = 110.567m
        };

        try
        {
            await repository.AddCurrencyRateAsync(rate1);
            await repository.AddCurrencyRateAsync(rate2);

            // Симуляция ошибки
            throw new Exception("Simulated failure");
        }
        catch
        {
           
        }

        var rates = await repository.GetAllCurrencyRatesAsync();

        Assert.Equal(2, rates.Count());
    }

}
