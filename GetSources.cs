using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class GetSources
    {
        public void getSources()
        {
            string urlAddress = "http://google.com";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                string data = readStream.ReadToEnd();
                if (!File.Exists(@"C:\Ứng dụng\Project\source.txt")) 
                    File.Create(@"C:\Ứng dụng\Project\source.txt").Close();
                File.WriteAllText(@"C:\Ứng dụng\Project\source.txt", data);

                response.Close();
                readStream.Close();
            }
        }
    }
}
