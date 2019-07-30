using System;
using System.Collections.Generic;
using System.Text;

namespace SlidEnglish.Shared
{
    public class ArrayUtils
    {
        public static string JoinToString(System.Collections.IEnumerable array, string separator)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (separator == null)
                throw new ArgumentNullException(nameof(separator));

            var result = new StringBuilder();

            System.Collections.IEnumerator enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (result.Length != 0)
                    result.Append(separator);

                result.Append(enumerator.Current.ToString());
            };

            return result.ToString();
        }
    }
}
