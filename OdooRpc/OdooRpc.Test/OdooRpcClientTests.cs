using Microsoft.VisualStudio.Threading;
using Nethereum.JsonRpc.Client;
using OdooRpc.Client;

namespace OdooRpc.Test
{
    [TestClass]
    public class OdooRpcClientTests
    {
        [TestMethod]
        public void TestAuthentication()
        {
            try
            {
                var odooRpcClient = new OdooRpcClient();
                odooRpcClient.TestDatabase();
                //odooRpcClient.Authenticate();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private async Task Test()
        {
            var httpClient = new HttpClient();
            var client = new RpcClient(new Uri("https://demo.odoo.com/start"), httpClient);
            await client.SendRequestAsync("start", null, new { });
        }
    }
}