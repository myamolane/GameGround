using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GameGround.Api
{
    public class Metadata<T>
        where T : class
    {
        public static readonly string VERSION;

        static Metadata()
        {
            VERSION = ConfigurationManager.AppSettings["version"] ?? "0.0.1";
        }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; private set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public Metadata(bool success, T data, string message)
        {
            this.Timestamp = DateTime.Now;
            this.Success = success;
            this.Version = VERSION;


            this.Data = data;
            this.Message = message;
        }

        public Metadata()
            : this(true, null, string.Empty)
        {

        }

        public Metadata(T data)
            : this(true, data, string.Empty)
        {

        }

        public Metadata(bool success, string message)
            : this(success, null, message)
        {

        }
    }

    public class Metadata : Metadata<string>
    {
        public Metadata(string data)
            : base(data)
        {

        }

        public Metadata()
            : base(string.Empty)
        {

        }
    }

    public class SearchMetadata<T> : Metadata<List<T>>
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        public SearchMetadata(List<T> data, long total)
        {
            this.Data = data;
            this.Total = total;
        }

        public SearchMetadata(List<T> data)
            : this(data, data == null ? 0 : data.Count) { }
    }
}