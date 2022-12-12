namespace PlayingCards;

public class GameDeck
{
    private       List<Card> _cadrdsBanc = new List<Card>();
    private const int        CardsCount  = 8;
    private const int        SuitCount   = 4;
    public int CardCounter { get; private set; }

    public GameDeck()
    {
        try
        {
            for (int suit = 0; suit < SuitCount; suit++)
            {
                for (int j = 0; j < CardsCount; j++)
                {
                    _cadrdsBanc.Add(new Card(suit));
                    CardCounter += 1;
                }
            }
        }
        catch
        {
            throw new InvalidOperationException("Ошибка в конструкторе класса GameDeck");
        }
    }

    public List<Card> HandOverCards(List<int> inputNumbers)
    {
        List<Card> outList = new List<Card>();
        try
        {
            foreach (int item in inputNumbers)
            {
                outList.Add(_cadrdsBanc[item]);
                CardCounter -= 1;
            }

            foreach (int item in inputNumbers)
            {
                _cadrdsBanc.RemoveAt(item);
            }

            return outList;
        }
        catch
        {
            throw new InvalidOperationException("Ошибка в методе HandOverCards класса GameDeck");
        }
    }
}