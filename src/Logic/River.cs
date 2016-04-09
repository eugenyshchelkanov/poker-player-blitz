namespace Nancy.Simple.Logic
{
    public class River
    {
        public static LogicResult Result(GameState state)
        {
            return Flop.Result(state);
        }
    }
}