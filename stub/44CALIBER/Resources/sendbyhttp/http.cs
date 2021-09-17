using System.Net;
using System.IO;

namespace youknowcaliber.Resources.sendbyhttp
{
    public class http
    {
        public static void post(string filepath, string msg)
        {
            using (WebClient client = new WebClient())
            {
                client.QueryString.Add("message", msg);
                client.UploadFile("http://localhost:5264", filepath);
            }

            return;
        }
    }
}