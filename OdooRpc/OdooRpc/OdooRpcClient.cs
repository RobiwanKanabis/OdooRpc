using System.Text.Json;

namespace OdooRpc.Client
{
    public class OdooRpcClient : IOdooRpcClient
    {
        protected OdooInstanceInfo _odooInstanceInfo;
        protected OdooAuthenticationInfo _odooAuthenticationInfo;

        protected bool isAuthenticated;
        protected string userId;

        protected HttpClient _httpClient;

        public OdooRpcClient()
        {
            this._httpClient = new HttpClient();
            //For local : 6627bbc6f9c4ce5fa40c58ad3bb805adfd62084d
            this._odooAuthenticationInfo = new OdooAuthenticationInfo("Micthell Admin", "6627bbc6f9c4ce5fa40c58ad3bb805adfd62084d");
            this._odooInstanceInfo = new OdooInstanceInfo("http://localhost", "test", 8069);
        }

        public void Authenticate()
        {
            //For next try, see : https://www.odoo.com/documentation/17.0/developer/reference/external_api.html#test-database
            using (var httpClient = new HttpClient())
            {
                var guid = Guid.NewGuid();
                var requestObject = new
                {
                    jsonrpc = "2.0",
                    method = "call",
                    @params = new
                    {
                        service = "common",
                        method = "authenticate",
                        args = new object[]
                        {
                            this._odooInstanceInfo.Database,
                            this._odooAuthenticationInfo.UserName,
                            this._odooAuthenticationInfo.ApiKey,
                        }
                    },
                    id = guid // Request ID, can be any unique identifier
                };
                var jsonRequest = JsonSerializer.Serialize(requestObject);

                // Send HTTP POST request to JSON-RPC server
                var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json-rpc");
                HttpResponseMessage response = httpClient.PostAsync($"{this._odooInstanceInfo.Host}:{this._odooInstanceInfo.Port}", content).Result;

                // Check if request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read response content as string
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

                    // Handle response
                    Console.WriteLine("JSON-RPC call successful. Response:");
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    throw new ApplicationException("Authentication failed");
                }
            }
        }
    }
}
