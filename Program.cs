using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrammBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("1166680475:AAHD_i06-XZMgDLMJs-0l1FI5Jacpyx3kFA");
            botClient.StartReceiving(Update, Error, null);
            

            Console.ReadLine();

        }

        async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            Message? massage = update.Message;
            if(massage.Text != null)
            {
                if(massage.Text == "Привет")
                {
                    Random rnd = new Random();
                    rnd.Next(10);
                    await client.SendTextMessageAsync(massage.Chat.Id, $"{rnd.Next(10)} Здорова ебаный мальчишка", cancellationToken: token);
                    return;
                }
                if(massage.Text == "здарова")
                {
                    await client.SendPhotoAsync(massage.Chat.Id, "https://i.ytimg.com/vi/2p404ZV5VQM/maxresdefault.jpg", cancellationToken: token);
                    return;
                }
                if (massage.Text == "стикер")
                {
                    await client.SendStickerAsync(massage.Chat.Id, "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp", cancellationToken: token);
                    return;
                }

            }
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
