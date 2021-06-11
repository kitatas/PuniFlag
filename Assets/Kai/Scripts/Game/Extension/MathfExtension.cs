namespace Kai.Game.Extension
{
    public static class MathfExtension
    {
        public static int RepeatIncrement(this int target, int minInclusive, int maxInclusive)
        {
            return ++target <= maxInclusive ? target : minInclusive;
        }

        public static int RepeatDecrement(this int target, int minInclusive, int maxInclusive)
        {
            return --target >= minInclusive ? target : maxInclusive;
        }
    }
}