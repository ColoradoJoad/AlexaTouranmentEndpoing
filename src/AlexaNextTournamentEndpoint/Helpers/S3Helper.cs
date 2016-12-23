using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AlexaNextTournamentEndpoint.Helpers
{
    public static class S3Helper
    {
        public static RegionEndpoint GetRegionEndpoint(string _region)
        {
            string region = _region.ToLower();

            switch (region)
            {
                case "useast1":
                    return RegionEndpoint.USEast1;
                case "useast2":
                    return RegionEndpoint.USEast2;
                case "uswest1":
                    return RegionEndpoint.USWest1;
                case "uswest2":
                    return RegionEndpoint.USWest2;
            }

            throw new NotImplementedException("Region not currently implemented in S3Helper.  Add requested region");
        }

        public static async Task<string> ReadDocument(string _bucket, string _key, string _regionName)
        {
            AmazonS3Client client = new AmazonS3Client(GetRegionEndpoint(_regionName));
            GetObjectRequest request = new GetObjectRequest()
            {
                BucketName = _bucket,
                Key = _key
            };

            var result = await client.GetObjectAsync(request);
            string json = result.ResponseStream.ReadAsString();
            return json;
        }
    }
}
