using PlayingCards.View;

namespace PlayingCards.Controllers;

public class GameController
{
    private readonly GameDeck   _gameDeck   = new GameDeck();
    private readonly Player     _player     = new Player();
    private const    string     GameMessage = "OK";
    private const    ConsoleKey ExitKey     = ConsoleKey.Q;

    private readonly List<ConsoleKey> _chooseKeys = new List<ConsoleKey>()
                                                   {
                                                       ConsoleKey.Z,
                                                       ConsoleKey.X,
                                                       ConsoleKey.C
                                                   };

    private const int TheeCardsKey   = 0;
    private const int CardsAmountKey = 1;
    private const int LookCardsKey   = 2;

    public string GamePlay()
    {
        ConsoleKeyInfo cki;
        do
        {
            ViewGame.LookDeckAmount(_gameDeck.CardCounter);

            ChooseTheAction(_chooseKeys);

            cki = ExitKeyInfo();
        } while (cki.Key != ExitKey);

        return GameMessage;
    }
    private static ConsoleKeyInfo ExitKeyInfo()
    {
        ViewGame.ExitMessage(ExitKey);
        ConsoleKeyInfo cki = Console.ReadKey();
        return cki;
    }

    private void ChooseTheAction(List<ConsoleKey> chooseKey)
    {
        ConsoleKeyInfo chosenKey = ViewGame.GetChooseActionKey(chooseKey);
        if (Equals(chosenKey.Key, chooseKey[LookCardsKey]))
        {
            ViewGame.WatchCardsInHand(_player.ViewPlayerCards());
        }
        if (Equals(chosenKey.Key, chooseKey[TheeCardsKey]))
        {
            const int cardCount = 3;
            _player.TakeSomeCards(
                _gameDeck.HandOverCards(GetCardsIndex(cardCount, _gameDeck.CardCounter))
            );
        }
        if (Equals(chosenKey.Key, chooseKey[CardsAmountKey]))
        {
            int cardCount = ViewGame.InputCardCount();
            _player.TakeSomeCards(
                _gameDeck.HandOverCards(GetCardsIndex(cardCount, _gameDeck.CardCounter))
            );
        }
    }
    private List<int> GetCardsIndex(int inputAmount, int gameDeckCardCounter)
    {
        List<int> outputArray = new List<int>();
        if (inputAmount <= gameDeckCardCounter)
        {
            for (int i = 0; i < inputAmount ; i++)
            {
                outputArray.Add(new Random().Next(gameDeckCardCounter - i));
            }
        }
        else
        {
            ViewGame.CardAmountException();
            ChooseTheAction(_chooseKeys);
        }

        return outputArray;
    }
}