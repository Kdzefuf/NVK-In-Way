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
public class TripInfo
{
    public string PlaceStartEnd;
    public string TimeStartEnd;
    public double Price;
    public int Free;

    public TripInfo(string place, string time, double price, int free)
    {
        PlaceStartEnd = place;
        TimeStartEnd = time;
        Price = price;
        Free = free;
    }
}

public class ActiveTrip
{
    private Dictionary<int, Trip> TripDictionary = new();
    public static List<Trip> trips; 

    public static async void ViewActiveTrip(ITelegramBotClient botClient, Chat chat)
    {
        trips = new List<Trip>();
        if (Program.DriversDataBase.Keys.Count == 0)
        {
            await botClient.SendTextMessageAsync(chat.Id, "�� ������ ������ ��� ��������� �������");
        }
        var counter = 0;
        foreach (long index in Program.DriversDataBase.Keys)
        {
            var curList = Program.DriversDataBase[index].trips;
            for (int i = 0; i < curList.Count; i++)
            {
                counter++;
                trips.Add(curList[i]);
                var inlineKeyboard = new InlineKeyboardMarkup(
                new List<InlineKeyboardButton[]>()
                {
                    new InlineKeyboardButton[]
                    {
                        InlineKeyboardButton.WithCallbackData("���������", $"moreInf_{counter}"), 
                    },
                });
                await botClient.SendTextMessageAsync(chat.Id, 
                $"\b�������� �������: {counter}\n������ - ����: {curList[i].From} - {curList[i].To}\n�����: {curList[i].ToPair}\n����: {curList[i].Cost}\n����������� ��������� ����: {curList[i].NumberOfAvailableSeats}", 
                 replyMarkup: inlineKeyboard);
            }
        }
    }

    public static async void ViewTrip(ITelegramBotClient botClient, Chat chat, Trip trip)
    {
        var inlineKeyboard = new InlineKeyboardMarkup(
        new List<InlineKeyboardButton[]>()
        {
            new InlineKeyboardButton[]
            {
                InlineKeyboardButton.WithCallbackData("�����", "takeIt"), 
            },
        });
        await botClient.SendTextMessageAsync(chat.Id, 
        $"����������\n������ - ����: {trip.From} - {trip.To}\n�����: {trip.ToPair}\n����: {trip.Cost}\n����������� ��������� ����: {trip.NumberOfAvailableSeats}\n����� �������: {trip.CarPosition}\n �����-����-����� ����: {trip.driver.car.Name}-{trip.driver.car.Color}-{trip.driver.car.Number}", 
        replyMarkup: inlineKeyboard);
    }
}