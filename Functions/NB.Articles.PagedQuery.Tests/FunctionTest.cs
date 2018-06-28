using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using NB.Articles.PagedQuery;
using NB.Shared.BasicClasses.Enum;

namespace NB.Articles.PagedQuery.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {
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

            Assert.True(result.Items.Count == 3);
        }
    }
}
