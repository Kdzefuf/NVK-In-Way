using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBotNVK;
public class Passenger
{
    public int TripCount { get; set; }
    public double Rating { get; set; }
    public string Profile { get; set; }

    public Passenger () { }
    public Passenger(int count, double rating, string prof)
    {
        TripCount = count;
        Rating = rating;
        Profile = prof;
    }
}

public static class PassengerInfo
{
    public static async void ShowPassangerCard(ITelegramBotClient botClient, Chat chat, Update update)
    {
        var passenger = new Passenger(0, 0, update.CallbackQuery.From.Username);
        var inlineKeyboard = new InlineKeyboardMarkup(
            new List<InlineKeyboardButton[]>()
            {
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData($"������� ��: {passenger.Profile}", "profile"),
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData($"�������: {passenger.Rating}"),
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData($"����� ����������� �������: {passenger.TripCount}"),
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData($"�����", "pas_button"),
                },
            });
        await botClient.SendTextMessageAsync(chat.Id, "�������� ������������", replyMarkup: inlineKeyboard);
    }
}
