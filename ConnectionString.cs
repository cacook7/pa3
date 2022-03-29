namespace PA3
{
    public class ConnectionString
    {
        public string cs{get; set;}

        public ConnectionString()
        {
            string server = "eanl4i1omny740jw.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "skz2znkwczaxt80m";
            string port = "3306";
            string userName = "micx7e7zun4s2c4r";
            string password = "nfco7mfcslo5om4n";

            cs = $@"server = {server};user={userName};database={database};port={port};password={password};";
        }
    }
}