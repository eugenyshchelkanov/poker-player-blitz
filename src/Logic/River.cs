namespace Nancy.Simple.Logic
{
    public class River
    {
        public static LogicResult Result(GameState state)
        {
            return Preflop.Result(state);
        }
    }
}