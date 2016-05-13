using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace Uno.Services
{
    public class ServiceManager
    {
        public Uri restURI { get; set; }

        public ServiceManager(Uri serviceURI)
        {
            restURI = serviceURI;
        }

        public T CallService<T>()
        {
            try
            {
                WebRequest request = WebRequest.Create(restURI);
                request.ContentType = "application/json; charset=utf-8";
                var response = request.GetResponse();

                string responseFromServer = string.Empty;

                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                }

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(responseFromServer));

                T dataObject = (T)serializer.ReadObject(ms);

                return dataObject;
            } catch (Exception ex) {
                return default(T);
            }
        }
    }
}
