using System;
using System.Collections.Generic;

namespace Xternity.Extension
{
    public static class ArrayExtensions
    {
        private static Random Rand = new Random();
        
        public static T GetRandom<T>(this T[] items)
        {
            return items[Rand.Next(0, items.Length)];
        }

        public static T GetRandom<T>(this List<T> items)
        {
            return items[Rand.Next(0, items.Count)];
        }
    }
}