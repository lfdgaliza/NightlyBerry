using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;

namespace NB.Shared.Configuration.Stages
{
    public class ConfigurationDevelopment : ConfigurationChainBase
    {
        public ConfigurationDevelopment() : base(StageOption.Development) { }

        protected override async Task<string> GetConnectionString()
        {
            var client = new AmazonS3Client(RegionEndpoint.USEast1);
            var request = new GetObjectRequest()
            {
                BucketName = "nightlyberry",
                Key = "configuration/db_conStr_dev"
            };

            using (GetObjectResponse response = await client.GetObjectAsync(request))
            using (Stream responseStream = response.ResponseStream)
            using (StreamReader reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
