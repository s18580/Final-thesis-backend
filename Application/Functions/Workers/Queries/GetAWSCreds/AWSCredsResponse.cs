namespace Application.Functions.Workers.Queries.GetAWSCreds
{
    public class AWSCredsResponse
    {
        public string BucketName { get; set; }
        public string Region { get; set; }
        public string AccessKeyAWS { get; set; }
        public string SecretKeyAWS { get; set; }

        public AWSCredsResponse(string access, string secret)
        {
            BucketName = "";
            Region = "";
            AccessKeyAWS = access;
            SecretKeyAWS = secret;
        }
    }
}
