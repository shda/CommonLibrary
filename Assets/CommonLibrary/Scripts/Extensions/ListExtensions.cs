using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonSouzM.SouzMCore.Common.Lib.Extensions
{
    public static class ListExtensions
    {
        public static bool Empty<T>(this IEnumerable<T> enumerator)
        {
            if (enumerator == null)
                return true;
            return !enumerator.Any();
        }

        public static void Foreach<T>(this IEnumerable<T> enumerable , Action<T> action)
        {
            if (enumerable != null)
            {
                foreach (var val in enumerable)
                {
                    action?.Invoke(val);
                }
            }
        }
        
        public static T GetNextElement<T>(this IList<T> array, T current)
        {
            if (array != null &&
                current != null &&
                array.Count > 0)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    if (Equals(array[i], current))
                    {
                        int nextIndex = 0;
                        nextIndex = i + 1;

                        if (nextIndex >= array.Count)
                        {
                            return array[0];
                        }

                        return array[nextIndex];

                    }
                }
            }

            return current;
        }

        public static T GetPreviousElement<T>(this IList<T> array, T current)
        {
            if (array != null &&
                current != null &&
                array.Count > 0)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    if (Equals(array[i], current))
                    {
                        int nextIndex = 0;
                        nextIndex = i - 1;

                        if (nextIndex < 0)
                        {
                            return array[array.Count - 1];
                        }

                        return array[nextIndex];
                    }
                }
            }

            return current;
        }
    }
}