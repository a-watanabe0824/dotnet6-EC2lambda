using System.Text;
using System.Text.Json;
using CLib;
namespace C_DotNetCore_Launch_EC2.Functions
{
    internal class Slack
    {

        private static string WebHook_Url = Property.WebHook_Url;

        //指定したslackチャンネルに投稿
        public static async Task PostToSlackChannel(List<string> postData, string actiontyp, string group)
        {
            var data = JsonSerializer.Serialize(new
            {
                text = "EC2 Action" + ":" + actiontyp + "\n" +
                "EC2 Group" + ":" + group + "\n" +
                postData.Count.ToString() + "件" + "\n" +
                T01.ConvListToString(postData)
            });
            var content = new StringContent(data, Encoding.UTF8, @"application/json");
            var result = await Httpclient.httpClient.PostAsync(WebHook_Url, content);
            Console.WriteLine("Slack送信結果");
            Console.WriteLine(result.ToString());
        }

        public static async Task PostSlackErrorAsync(string actiontyp, string group, string errorstr)
        {
            var data = JsonSerializer.Serialize(new
            {
                text = "EC2 Action" + ":" + actiontyp + "Error" + "\n" +
                "EC2 Group" + ":" + group + "\n" +
                "detail" + ":" + errorstr + "\n"
            });
            var content = new StringContent(data, Encoding.UTF8, @"application/json");
            var result = await Httpclient.httpClient.PostAsync(WebHook_Url, content);
            Console.WriteLine("Slack送信結果");
            Console.WriteLine(result.ToString());
        }
    }

    public class Httpclient
    {
        public static readonly HttpClient httpClient;
        static Httpclient()
        {
            httpClient = new HttpClient();
        }
    }
}
