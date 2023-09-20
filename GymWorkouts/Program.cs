using GymWorkouts.Workout;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

var client = new TelegramBotClient("5121111549:AAEEfm8X_AisJTac3vrQ8obi1wPDE1_zU7c");
client.StartReceiving(Update, Error);

async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
{
    var massage = update.Message;

    await botClient.SendTextMessageAsync(massage.Chat.Id, "Привет! Выбери что ты будешь тренировать сегодня");
    await botClient.SendTextMessageAsync(massage.Chat.Id, "Ноги, грудь или спина");

    if (massage.Text != null)
    {
        Console.WriteLine($"{massage.Chat.FirstName ?? "Anon"} write:    |    {massage.Text}");

        if (massage.Text.ToLower().Contains("ноги"))
        {
            Legs legs = new Legs();
            int day;
            await botClient.SendTextMessageAsync(massage.Chat.Id, "Сегодня у нас день ног и плеч!");
            await botClient.SendTextMessageAsync(massage.Chat.Id, "1 или 2 тренировка?");

            if(massage.Text.Contains('1')) { day = 1; }
            else { day = 2; }

            var legsProgramm = legs.TraningProgramm(day);

            foreach (var exercise in legsProgramm)
            {
                await botClient.SendTextMessageAsync(massage.Chat.Id, $"{exercise.Key}  {exercise.Value}");
            }

            return;
        }
        if (massage.Text.ToLower().Contains("грудь"))
        {
            Breast breast = new Breast();
            int day;

            await botClient.SendTextMessageAsync(massage.Chat.Id, "Сегодня у нас день груди и трицепса!");
            await botClient.SendTextMessageAsync(massage.Chat.Id, "1 или 2 тренировка?");

            if (massage.Text.Contains('1')) { day = 1; }
            else { day = 2; }

            var breastProgramm = breast.TraningProgramm(day);

            foreach (var exercise in breastProgramm)
            {
                await botClient.SendTextMessageAsync(massage.Chat.Id, $"{exercise.Key}  {exercise.Value}");
            }

            return;
        }
        if (massage.Text.ToLower().Contains("спина"))
        {
            Back back = new Back();
            int day;

            await botClient.SendTextMessageAsync(massage.Chat.Id, "Сегодня у нас день спины и бицухи!");
            await botClient.SendTextMessageAsync(massage.Chat.Id, "1 или 2 тренировка?");

            if (massage.Text.Contains('1')) { day = 1; }
            else { day = 2; }

            var backProgramm = back.TraningProgramm(day);

            foreach (var exercise in backProgramm)
            {
                await botClient.SendTextMessageAsync(massage.Chat.Id, $"{exercise.Key}  {exercise.Value}");
            }

            return;
        }
    }
    if(massage.Photo != null)
    {
        await botClient.SendTextMessageAsync(massage.Chat.Id, "Please, send a document!");
        return;
    }
}

Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
{
    throw new NotImplementedException();
}

Console.ReadLine();