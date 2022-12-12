using PlayingCards;

namespace PlayingCardsTest;

public class CardTest: Card
{
    [Fact]
    public void Create_Cards_Test()
    {
        var testCard = new Card();

        List<string> actualCard = testCard.LockCard();
        List<string> expectedCard = new List<string>()
                                    {
                                        "DiamondSuit",
                                        "Red"
                                    };


        Assert.Equal(expectedCard, actualCard);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void All_Cards_Suit_Test(int inputSuitNumber)
    {
        var testCard = new Card(inputSuitNumber);

        List<List<string>> expectedCardSuits = new List<List<string>>()
                                               {
                                                   new List<string>() { "DiamondSuit", "Red", },
                                                   new List<string>() { "HeartSuit", "Red" },
                                                   new List<string>() { "ClubSuit", "Black" },
                                                   new List<string>() { "SpadeSuit", "Black", }
                                               };
        List<string> actualCard = testCard.LockCard();

        Assert.Equal(expectedCardSuits[inputSuitNumber], actualCard);
    }
}