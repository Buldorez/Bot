using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    class Program
    {
        static TelegramBotClient Bot;
        static void Main(string[] args)
        {
            Bot = new TelegramBotClient("2051673379:AAGbbAbFBdNcCLokBPmQsC8FYZRAu4EfBpU");

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;

            var me = Bot.GetMeAsync().Result;

            Console.WriteLine(me.FirstName);

            Bot.StartReceiving();

            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void BotOnCallbackQueryReceived(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static async void BotOnMessageReceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message;

            if ( message == null || message.Type != MessageType.TextMessage)
                return;
            string name = $"{message.From.FirstName} {message.From.LastName}";

            Console.WriteLine($"{name} отправил сообщение: '{message.Text}'");

            switch (message.Text)
            {
                case "/start":
                    string text =
                        @"Список команд:
                         /start - запуск бота
                         /inline - вывод меню
                         /keyboard - вывод клавиатуры";
                    await Bot.SendTextMessageAsync(message.From.Id, text);
                    break;
                case "/inline":
                     //var inilineKeyboard = new InlineKeyboardMarkup (new[]
                     //{
                     //    new[]
                     //    {
                     //        inilineKeyboardButton.WithUrl("VK",)
                     //    }
                     //}
                     //)
                    break;


                case  "/keyboard":
                        break;
                default:
                    break;
            }
        }
    }
}
