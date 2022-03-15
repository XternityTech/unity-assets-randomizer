using System;

namespace Xternity.Extension
{
    public static class EnumExtensions
    {
        private static readonly Random Random = new Random ();
        
        public static T GetRandom<T>() where T : Enum
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("Random enum variable is not an enum");
            }

            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(Random.Next(values.Length));
        }
    }
}