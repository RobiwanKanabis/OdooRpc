namespace OdooRpc.Client
{
    public class OdooAuthenticationInfo
    {
        public string UserName { get; protected set; }
        public string ApiKey { get; protected set; }

        public OdooAuthenticationInfo(string username, string apiKey)
        {
            this.UserName = username;
            this.ApiKey = apiKey;
        }
    }
}
