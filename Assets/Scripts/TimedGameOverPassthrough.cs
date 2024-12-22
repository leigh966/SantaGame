public class TimedGameOverpassthrough : GameOverPassthrough
{

    public override void EndGame()
    {
        game.EndGame(new TimedLeaderboardInterface());
    }

}
