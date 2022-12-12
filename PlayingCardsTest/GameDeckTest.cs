using PlayingCards;

namespace PlayingCardsTest;

public class GameDeckTest
{
    [Fact]
    public void Create_GameDeck_Test()
    {
        var testGameDeck = new GameDeck();

        Assert.NotNull(testGameDeck);
    }
    [Theory]
    [InlineData(1,0)]
    [InlineData(9,1)]
    [InlineData(17,2)]
    [InlineData(25,3)]
    public void HandOverCards_Test(int cardNumberInDeck, int expectedCardSuit)
    {
        var testGameDeck = new GameDeck();
        List<int> testCardIndexes = new List<int>()
                                    {
                                        cardNumberInDeck
                                    };
        List<Card> expectedCards = new List<Card>()
                                   {
                                       new Card(expectedCardSuit)
                                   };
        const int listIndex =0;

        var actualCards = testGameDeck.HandOverCards(testCardIndexes);

        Assert.Equal(expectedCards[listIndex].LockCard(),actualCards[listIndex].LockCard());
    }
    [Fact]
    public void CardCounter_Test()
    {
        var testGameDeck = new GameDeck();
        int expectedCardCounter = 32;
        var actualCardCounter = testGameDeck.CardCounter;

        Assert.Equal(expectedCardCounter,actualCardCounter);
    }
}