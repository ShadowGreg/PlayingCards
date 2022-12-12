namespace PlayingCards;

public class Card
{
    protected static readonly Dictionary<string, string> CardCollection = new Dictionary<string, string>
                                                                          {
                                                                              ["DiamondSuit"] = "Red",
                                                                              ["HeartSuit"]        = "Red",
                                                                              ["ClubSuit"]         = "Black",
                                                                              ["SpadeSuit"]        = "Black"
                                                                          };

    protected readonly string? _suitCondition;
    protected readonly string? _colorCondition;


    public Card(int suit = 0)
    {
        switch (suit)
        {
            case 0:
                _suitCondition  = "DiamondSuit";
                _colorCondition = CardCollection["DiamondSuit"];
                break;
            case 1:
                _suitCondition  = "HeartSuit";
                _colorCondition = CardCollection["HeartSuit"];
                break;
            case 2:
                _suitCondition  = "ClubSuit";
                _colorCondition = CardCollection["ClubSuit"];
                break;
            case 3:
                _suitCondition  = "SpadeSuit";
                _colorCondition = CardCollection["SpadeSuit"];
                break;
        }
    }

    public List<string> LockCard()
    {
        if (_colorCondition != null && _suitCondition != null)
            return new List<string> { _suitCondition, _colorCondition };
        throw new InvalidOperationException("У игрока нет карт, которые можно посмотреть");
    }
}