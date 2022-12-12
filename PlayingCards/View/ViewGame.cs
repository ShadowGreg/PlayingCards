using System.Runtime.InteropServices;

namespace PlayingCards.View;

public class ViewGame
{
    private static ConsoleKeyInfo cki = default;

    public static void ExitMessage(ConsoleKey inputKey)
    {
        Console.WriteLine("----------");
        Console.WriteLine($"Если хотите выйти нажмите {inputKey.ToString()}");
    }
    public static ConsoleKeyInfo GetChooseActionKey(List<ConsoleKey> controlKeys)
    {
        Console.WriteLine("----------");
        Console.WriteLine($"Если хотите взять 3 карты нажмите {controlKeys[0].ToString()}");
        Console.WriteLine($"Если хотите выбрать количество карт нажмите {controlKeys[1].ToString()}");
        Console.WriteLine($"Если хотите посмотреть карты на руках нажмите {controlKeys[2].ToString()}");
        Console.WriteLine("----------");
        Console.Write("Ваш выбор > ");
        cki = Console.ReadKey();
        Console.WriteLine();
        return cki;
    }
    public static void LookDeckAmount(int inputAmount)
    {
        Console.WriteLine($"В колоде {inputAmount} шт. карт.");
        Console.WriteLine();
    }

    public static void WatchCardsInHand(List<Card> playersCards)
    {
        try
        {
            if (playersCards.Count > 0)
            {
                for (int i = 0; i < playersCards.Count; i++)
                {
                    const int Suit = 0;
                    const int Color = 1;
                    Console.WriteLine("----------");
                    Console.WriteLine(
                        $"{i+1} карта {playersCards[i].LockCard()[Suit]} - масти," +
                        $" {playersCards[i].LockCard()[Color]} - цвета");
                }
            }
            else
            {
                Console.WriteLine("У вас нет карт на руках");
            }
        }
        catch
        {
            throw new InvalidOperationException("Ошибка в методе WatchCardsInHand класса ViewGame");
        }
    }
    public static int InputCardCount()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("----------");
        Console.Write("Введите количество карт > ");
        Console.ResetColor();
        string strValue = Console.ReadLine() ?? "0";
        bool isNumber = int.TryParse(strValue, out int value);
        if (isNumber)
        {
            return value;
        }

        throw new Exception("Данное значение не возможно преобразовать в число");
    }


    public static void CardAmountException()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("----------");
        Console.Write("Введите количество карт > ");
        Console.WriteLine();
        Console.ResetColor();
    }
}