using System;
using System.Collections.Generic;
using System.Linq;

namespace MonsterQuest
{
    public static class StringHelper
    {
        public static string JoinWithAnd(IEnumerable<Character> items, bool useSerialComma = false)
        {
            if (items.Count() == 0)
            {
                return "";
            }
            else if (items.Count() == 1)
            {
                return items.ElementAt(0).displayName;
            }
            else if (items.Count() == 2)
            {
                return $"{items.ElementAt(0).displayName} and {items.ElementAt(1).displayName}";
            }
            else
            {
                var itemsCopy = new List<string>();

                foreach (var item in items)
                {
                    itemsCopy.Add(item.displayName);
                }

                if (useSerialComma)
                {
                    itemsCopy[itemsCopy.Count - 1] = $"and {itemsCopy[itemsCopy.Count - 1]}";
                }
                else
                {
                    int lastItemIndex = itemsCopy.Count - 1;
                    string lastItem = itemsCopy[lastItemIndex];

                    int secondToLastItemIndex = itemsCopy.Count - 2;
                    string secondToLastItem = itemsCopy[secondToLastItemIndex];

                    itemsCopy[secondToLastItemIndex] = $"{secondToLastItem} and {lastItem}";
                    itemsCopy.RemoveAt(lastItemIndex);
                }
                return String.Join(", ", itemsCopy);
            }
        }
    }
}
