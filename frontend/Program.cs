﻿using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TGBotNVK;

class Program
{
    private static ITelegramBotClient _botClient;
    private static ReceiverOptions _receiverOptions;

    public static bool isBusy;

    public static Dictionary<long, Driver> DriversDataBase = new();
    private static CancellationTokenSource cts;

    static async Task Main()
    {
        //_botClient = new TelegramBotClient("7664250365:AAFEp8JUtd_6xb5PzTWPriBHXJlTO7J_KjI");
        _botClient = new TelegramBotClient("7664250365:AAFEp8JUtd_6xb5PzTWPriBHXJlTO7J_KjI");
        _receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = new[]
            {
                UpdateType.Message,
                UpdateType.CallbackQuery
            },
            DropPendingUpdates = true
        };

        cts = new CancellationTokenSource();

        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);

        await Task.Delay(-1);
    }

    public static async void StartBotWithAnotherUpdateHandler(
        Func<ITelegramBotClient, Update, CancellationToken, Task> newUpdateHandler)
    {
        cts.Cancel();

        cts = new();
        _botClient.StartReceiving(newUpdateHandler, ErrorHandler, _receiverOptions, cts.Token);
        await Task.Delay(-1);
    }

    public static async void StartWithStandardUpdateHandler()
    {
        cts.Cancel();

        cts = new();

        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);
        await Task.Delay(-1);
    }

    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        try
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        MessageHandler.ProcessMessage(msg: update.Message, botClient);
                        return;
                    }
                case UpdateType.CallbackQuery:
                    {
                        MessageHandler.CheckStartChoice(botClient, update);
                        return;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
    {
        var ErrorMessage = error switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => error.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}
