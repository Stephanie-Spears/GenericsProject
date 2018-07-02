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
    }
}