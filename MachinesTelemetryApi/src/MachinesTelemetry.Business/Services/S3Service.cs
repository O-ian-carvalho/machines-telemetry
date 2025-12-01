using Amazon.S3;
using Amazon.S3.Model;
using MachinesTelemetry.Business.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace MachinesTelemetry.Business.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;

        public S3Service(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var bucketName = Environment.GetEnvironmentVariable("S3__BucketName");
            var region = Environment.GetEnvironmentVariable("S3__Region");

            var key = $"{Guid.NewGuid()}-{file.FileName}";

            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = key,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            await _s3Client.PutObjectAsync(request);

            return $"https://{bucketName}.s3.{region}.amazonaws.com/{key}";
        }

    }
}
