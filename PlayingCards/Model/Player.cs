namespace PlayingCards;

public class Player
{
    private       List<Card> PlayerCards;
    private const string     OkMessage = "Всё хорошо";
    
    public Player()
    {
        PlayerCards = new List<Card>();
    }

    public string TakeSomeCards(List<Card> cards)
    {
        foreach (var card in cards)
        {
            PlayerCards.Add(card);
        }

        return OkMessage;
    }

    public List<Card> ViewPlayerCards()
    {
        return PlayerCards;
    }

}