using PlayingCards;

namespace PlayingCardsTest;

public class PlayerTest
{
    [Fact]
    public void Create_Player_Test()
    {
        var testPlayer = new Player();

        Assert.NotNull(testPlayer);
    }
    [Fact]
    public void TakeSomeCards_Test()
    {
        var testPlayer = new Player();
        var expectedCards = new List<Card>()
                    {
                        new Card(),
                        new Card(1),
                    };


        testPlayer.TakeSomeCards(expectedCards);

        List<Card> actualCards = testPlayer.ViewPlayerCards();

        Assert.Equal(expectedCards,actualCards);
    }
    
    [Fact]
    public void TakeSomeCards_OkMessage_Test()
    {
        var testPlayer = new Player();
        List<Card> cards = new List<Card>()
                           {
                               new Card(),
                               new Card(1),
                           };
        const string     expectedMessage = "Всё хорошо";


        string actualMessage = testPlayer.TakeSomeCards(cards);

        Assert.Equal(expectedMessage,actualMessage);
    }
}