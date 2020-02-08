using System;
using System.Linq;
using System.Text;

namespace ChatApp.Core
{
    /// <summary>
    /// Exstension for easier sorting <see cref="string[]"/>
    /// </summary>
    public static class SortStringWordsExstensions
    {
        public static string[] SortByOrder(this string[] words)
        {
            return words.OrderBy(o => o).ToArray();
        }
    }
}
