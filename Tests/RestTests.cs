using System.Collections.Generic;
using QuoteFetcher.Services.Rest;
using Xunit;

namespace Tests;

public class RestTests
{   
    [Fact]
    public async void GetTransactions_Success()
    {
        Dictionary<int, double> res = await CustomerTransaction.GetTransactions("debit");
        Assert.Equal(97285.55, res[1]);
    }
    
    [Fact]
    public async void FilterRecordsIdsByAgeAndBp_Success()
    {
        List<int> res = await MedicalRecords.FilterRecordsIdsByAgeAndBp(28, 31, 13);
        Assert.Equal(4, res[0]);
    }
    
    [Fact]
    public async void QuoteService_Success()
    {
        Dictionary<string, List<string>> res = await QuoteService.FetchQuotes(10);
        Assert.True(res.Count <= 10);
    }
    
    [Fact]
    public async void GetMostViewedArticles_Success()
    {
        List<string> res = await TopArticles.GetMostViewedArticles(2);
        Assert.Equal("F.C.C. Repeals Net Neutrality Rules", res[0]);
    }
    
    [Fact]
    public async void CollateAffordableOutlets_Success()
    {
        List<string> res = await  RelevantFoodOutlet.CollateAffordableOutlets("Seattle", 135);
        Assert.Equal("Vanilla Sky", res[0]);
    }
    
    [Fact]
    public async void CountDevices_Success()
    {
        int res = await RootThreshold.CountDevices(45, "STOPPED", "03-2019");
        Assert.Equal(2, res);
    }
    
    
    
}
