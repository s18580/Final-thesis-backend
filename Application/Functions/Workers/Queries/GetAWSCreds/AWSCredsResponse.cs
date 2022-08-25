namespace Application.Functions.Workers.Queries.GetAWSCreds
{
    public class AWSCredsResponse
    {
        public string AccessKeyAWS { get; set; }
        public string SecretKeyAWS { get; set; }

        public AWSCredsResponse(string access, string secret)
        {
            AccessKeyAWS = access;
            SecretKeyAWS = secret;
        }
    }
}
