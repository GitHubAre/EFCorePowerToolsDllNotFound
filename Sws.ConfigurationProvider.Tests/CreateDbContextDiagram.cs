using Microsoft.EntityFrameworkCore;
using Sws.ConfigurationProvider.Common.Helpers;
using Sws.ConfigurationProvider.Persistence.Azure;
using System.IO;
using Xunit;

namespace Sws.ConfigurationProvider.Tests
{
    public class CreateDbContextDiagram
    {
        [Fact]
        public void AzureDbContextDiagram()
        {
            using (var myContext = new AzureDbContext())
            {
                var path = DotNet.GetExecutingDirectory() + "..\\..\\..";

                System.IO.File.WriteAllText(Path.Combine(path, "AzureDbContextDiagram.dgml"),
                    myContext.AsDgml(),
                    System.Text.Encoding.UTF8);
            }
        }
    }
}
