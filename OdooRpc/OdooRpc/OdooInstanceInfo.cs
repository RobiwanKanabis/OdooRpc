namespace OdooRpc.Client
{
    public class OdooInstanceInfo
    {
        public string Host { get; protected set; }
        public string Database { get; protected set; }
        public int Port { get; protected set; }

        /// <summary>
        /// Creates a new instance of OdooInstanceInfo
        /// </summary>
        /// <param name="host">The Odoo instance url</param>
        /// <param name="database">The Odoo instance databse</param>
        /// <param name="port">The Odoo instance port</param>
        public OdooInstanceInfo(string host, string database, int port)
        {
            this.Host = host;
            this.Database = database;
            this.Port = port;
        }
    }
}
