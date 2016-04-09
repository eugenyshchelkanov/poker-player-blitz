namespace Nancy.Simple.Logic
{
    public class Flop
    {
        public static LogicResult Result(GameState state)
        {
            return Preflop.Result(state);
        }
    }
}