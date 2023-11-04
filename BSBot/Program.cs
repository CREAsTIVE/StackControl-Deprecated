using BeautifulSymbols;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Web;
using VkNet;

var httpClient = new HttpClient();
var AccessToken = File.ReadAllText("token.txt");
var api = new VkApi();
api.Authorize(new()
{
    AccessToken = AccessToken,
});

var lpRaw = httpClient.GetAsync($"https://api.vk.com/method/messages.getLongPollServer?access_token={AccessToken}&v=5.131").Result.Content.ReadAsStringAsync().Result;
var lpData = JObject.Parse(lpRaw)["response"];

var compiler = new Compilator();

while (true)
{
    var urlStr = $"https://{lpData?["server"]}?act=a_check&key={lpData?["key"]}&ts={lpData?["ts"]}&wait=25";
    var responseObject = httpClient.GetAsync(urlStr).Result.Content.ReadAsStringAsync().Result;
    var json = JObject.Parse(responseObject);
    lpData["ts"] = json["ts"];

    foreach (var update in json?["updates"] ?? new JArray())
    {
        var type = (int?)update?[0] ?? 0;
        if (type == 4)
        {
            var peerId = (int?)update?[3] ?? 0;
            var message = HttpUtility.HtmlDecode((string?)update?[6] ?? "");

            

            if (message.StartsWith("$"))
            {
                var env = new BeautifulSymbols.RuntimeEnvironment();
                var tokens = Compilator.SepOnTokens(message[1..]);
                compiler.UnpuckAliases(tokens);
                try
                {
                    Compilator.Run(compiler.GenerateCommands(tokens), env);
                } catch (Exception e)
                {
                    api.Messages.Send(new()
                    {
                        PeerId = peerId,
                        RandomId = 0,
                        Message = $"ERROR: {e.Message}",
                    });
                }
                api.Messages.Send(new()
                {
                    PeerId = peerId,
                    RandomId = 0,
                    Message = $"{string.Join(" ", tokens)}\n----------\n{string.Join("\n", env.Stack.Select(e => e.StackView()))}",
                });
            }
        }
    }
}
