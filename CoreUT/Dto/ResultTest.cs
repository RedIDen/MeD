using Core.Dto;

namespace CoreUT.Dto;

public class ResultTest
{
    [TestCase]
    public void IsSuccessful_NoError()
    {
        var result = new Result();
        Assert.That(result.IsSuccessful, Is.True);
    }

    [TestCase]
    public void IsSuccessful_Error()
    {
        var result = new Result() { Error = "Error" };
        Assert.That(result.IsSuccessful, Is.False);
    }
}
