using GymWorkouts.Workout;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

var client = new TelegramBotClient("5121111549:AAEEfm8X_AisJTac3vrQ8obi1wPDE1_zU7c");

await client.DeleteWebhook();

client.StartReceiving(Update, Error);

Console.WriteLine("Бот запущен...");
Console.ReadLine();


async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
{

    if (update.Message != null)
    {
        var message = update.Message;

        if (message.Text == null)
            return;

        Console.WriteLine(
            $"{message.Chat.FirstName ?? "Anon"}: {message.Text}"
        );

        // Команда /start
        if (message.Text == "/start")
        {
            await ShowWelcome(botClient, message);
            return;
        }

        return;
    }


    if (update.CallbackQuery != null)
    {
        var callback = update.CallbackQuery;

        await botClient.AnswerCallbackQuery(callback.Id);

        var chatId = callback.Message!.Chat.Id;
        var data = callback.Data;

        if (data == "start_training")
        {
            await ShowMainMenu(botClient, chatId);
            return;
        }

        if (data == "muscle_legs")
        {
            await ShowDayMenu(
                botClient,
                chatId,
                "Сегодня у нас день ног и плеч!",
                "legs"
            );

            return;
        }

        if (data == "muscle_breast")
        {
            await ShowDayMenu(
                botClient,
                chatId,
                "Сегодня у нас день груди и трицепса!",
                "breast"
            );

            return;
        }

        if (data == "muscle_back")
        {
            await ShowDayMenu(
                botClient,
                chatId,
                "Сегодня у нас день спины и бицухи!",
                "back"
            );

            return;
        }

        if (data == "legs_day_1")
        {
            await SendLegsProgram(botClient, chatId, 1);
            return;
        }

        if (data == "legs_day_2")
        {
            await SendLegsProgram(botClient, chatId, 2);
            return;
        }

        if (data == "breast_day_1")
        {
            await SendBreastProgram(botClient, chatId, 1);
            return;
        }

        if (data == "breast_day_2")
        {
            await SendBreastProgram(botClient, chatId, 2);
            return;
        }


        if (data == "back_day_1")
        {
            await SendBackProgram(botClient, chatId, 1);
            return;
        }

        if (data == "back_day_2")
        {
            await SendBackProgram(botClient, chatId, 2);
            return;
        }
    }
}

async static Task ShowWelcome(
    ITelegramBotClient botClient,
    Message message)
{
    string name = message.From?.FirstName ?? "друг";

    var keyboard = new InlineKeyboardMarkup(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(
                "🏋️ Начать тренировку",
                "start_training"
            )
        }
    });

    await botClient.SendMessage(
        message.Chat.Id,
        $"👋 Привет, {name}!\n\n" +
        "Я бот для тренировок 💪\n\n" +
        "Помогу выбрать тренировку и покажу программу упражнений.\n\n" +
        "Чтобы начать, нажми кнопку ниже 👇",
        replyMarkup: keyboard
    );
}

async static Task ShowMainMenu(
    ITelegramBotClient botClient,
    long chatId)
{
    var keyboard = new InlineKeyboardMarkup(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(
                "🦵 Ноги",
                "muscle_legs"
            )
        },

        new[]
        {
            InlineKeyboardButton.WithCallbackData(
                "🏋️ Грудь",
                "muscle_breast"
            )
        },

        new[]
        {
            InlineKeyboardButton.WithCallbackData(
                "💪 Спина",
                "muscle_back"
            )
        }
    });

    await botClient.SendMessage(
        chatId,
        "Привет! Выбери, что ты будешь тренировать сегодня:",
        replyMarkup: keyboard
    );
}

async static Task ShowDayMenu(
    ITelegramBotClient botClient,
    long chatId,
    string text,
    string muscle)
{
    var keyboard = new InlineKeyboardMarkup(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(
                "1️⃣ Тренировка 1",
                $"{muscle}_day_1"
            )
        },

        new[]
        {
            InlineKeyboardButton.WithCallbackData(
                "2️⃣ Тренировка 2",
                $"{muscle}_day_2"
            )
        }
    });

    await botClient.SendMessage(
        chatId,
        $"{text}\n\nВыбери тренировку:",
        replyMarkup: keyboard
    );
}

async static Task SendLegsProgram(
    ITelegramBotClient botClient,
    long chatId,
    int day)
{
    Legs legs = new Legs();

    var legsProgramm = legs.TraningProgramm(day);

    await botClient.SendMessage(
        chatId,
        $"🦵 Тренировка ног №{day}"
    );

    foreach (var exercise in legsProgramm)
    {
        await botClient.SendMessage(
            chatId,
            $"{exercise.Key}  {exercise.Value}"
        );
    }
}

async static Task SendBreastProgram(
    ITelegramBotClient botClient,
    long chatId,
    int day)
{
    Breast breast = new Breast();

    var breastProgramm = breast.TraningProgramm(day);

    await botClient.SendMessage(
        chatId,
        $"🏋️ Тренировка груди №{day}"
    );

    foreach (var exercise in breastProgramm)
    {
        await botClient.SendMessage(
            chatId,
            $"{exercise.Key}  {exercise.Value}"
        );
    }
}

async static Task SendBackProgram(
    ITelegramBotClient botClient,
    long chatId,
    int day)
{
    Back back = new Back();

    var backProgramm = back.TraningProgramm(day);

    await botClient.SendMessage(
        chatId,
        $"💪 Тренировка спины №{day}"
    );

    foreach (var exercise in backProgramm)
    {
        await botClient.SendMessage(
            chatId,
            $"{exercise.Key}  {exercise.Value}"
        );
    }
}

static Task Error(
    ITelegramBotClient client,
    Exception exception,
    CancellationToken token)
{
    Console.WriteLine("Telegram error:");
    Console.WriteLine(exception);

    return Task.CompletedTask;
}