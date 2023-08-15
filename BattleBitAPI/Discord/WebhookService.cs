using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace CommunityServerAPI.BattleBitAPI.Discord
{
    public class Discord
    {
        class HTTPService
        {
            public static byte[] PostRequest(string url, NameValueCollection pairs)
            {
                return new WebClient().UploadValues(url, pairs);
            }
        }
        public static void sendWebhookMessage(string content, string webHookUrl)
        {
            Task.Run(() =>
            {
                HTTPService.PostRequest(webHookUrl, new NameValueCollection() { { "content", content }, });
            });
        }
        public static void sendWebhookMessage(string content, string webHookUrl, string username)
        {
            Task.Run(() =>
            {
                HTTPService.PostRequest(webHookUrl, new NameValueCollection() { { "content", content }, { "username", username } });
            });
        }
        public static void sendWebhookMessage(string content, string webHookUrl, string username, string avatarUrl)
        {
            Task.Run(() =>
            {
                HTTPService.PostRequest(webHookUrl, new NameValueCollection() { { "content", content }, { "username", username }, { "avatarURL", avatarUrl } });
            });
        }
    }
}

