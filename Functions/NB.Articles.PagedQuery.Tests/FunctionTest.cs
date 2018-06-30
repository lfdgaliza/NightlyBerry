using Amazon.Lambda.TestUtilities;
using NB.Shared.BasicClasses.Enum;
using System;
using Xunit;

namespace NB.Articles.PagedQuery.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {
            Environment.SetEnvironmentVariable("Stage", "Development");
            var function = new Function();
            var context = new TestLambdaContext
            {
                ClientContext = new TestClientContext()
            };

            var result = function.FunctionHandler(new Filter
            {
                DocumentType = DocumentType.Article,
                Language = Language.En,
                PageIndex = 1,
                PageSize = 10
            }, context);

            result.Wait();

            result = function.FunctionHandler(new Filter
            {
                DocumentType = DocumentType.Article,
                Language = Language.En,
                PageIndex = 1,
                PageSize = 10
            }, context);

            var awaitedResult = result.Result;

            Assert.True(awaitedResult.Items.Count == 3);
        }
    }
}
