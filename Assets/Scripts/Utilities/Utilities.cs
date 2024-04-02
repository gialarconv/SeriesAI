using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SeriesAI.Utilities
{
    public static class Utilities
    {
        private static System.Random rng = new System.Random();

        //generic shuffle
        public static void Shuffle<T>(IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
        //shuffle for lists
        public static List<T> ShuffleList<T>(List<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = UnityEngine.Random.Range(0, n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }

            return list;
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
        
        public static T RemoveAndGet<T>(this IList<T> list, int index)
        {
            lock (list)
            {
                T value = list[index];
                list.RemoveAt(index);
                return value;
            }
        }

        /// <summary>
        /// Show or hide a CanvasGroup
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="state"></param>
        public static void CanvasGroupBehaviour(CanvasGroup canvasGroup, bool state)
        {
            canvasGroup.alpha = state ? 1f : 0f;
            canvasGroup.interactable = state;
            canvasGroup.blocksRaycasts = state;
        }
        
        /// <summary>
        /// Returns true if the two lists are equal, regardless of order.
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool ListsAreEqual<T>(List<T> list1, List<T> list2)
        {
            if (list1.Count != list2.Count)
                return false;
            

            var sortedList1 = list1.OrderBy(item => item);
            var sortedList2 = list2.OrderBy(item => item);

            return sortedList1.SequenceEqual(sortedList2);
        }
        
        /// <summary>
        /// Converts a dictionary to a json string
        /// </summary>
        /// <param name="dict"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static string DictionaryToJson<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            var entries = dict.Select(d => $"Key: \"{d.Key}\" -> Value: \"{d.Value}\"");
            string result = "{\n" + string.Join(",\n", entries) + "\n}";
            return result;
        }
    }
}