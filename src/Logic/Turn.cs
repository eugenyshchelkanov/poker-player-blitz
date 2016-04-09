namespace Nancy.Simple.Logic
{
    public class Turn
    {
        public static LogicResult Result(GameState state)
        {
            return Flop.Result(state);
        }
    }
}