using System;
using System.Collections.Generic;

namespace GenericsProject
{
    public static class Utils
    {
        public static IEnumerable<T> Take<T>(IEnumerable<T> source, int n)
        {
            int i = 0;

            foreach (var item in source)
            {
                yield return item;

                //signal end of collection with yield break statement
                if (++i == n)
                {
                    yield break;
                }
            }
        }

        //To constrain what T can be, we add a where statement. This says T must implement the IComparable interface.
        public static T Min<T>(T item1, T item2) where T : IComparable<T>
        {
            return (item1.CompareTo(item2) > 0) ? item1 : item2;
        }
    }
}