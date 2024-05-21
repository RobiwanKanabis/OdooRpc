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
                odooRpcClient.Authenticate();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}