using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl
{
	public static class Utils
	{
		public static string JoinEnumerable<T>(this IEnumerable<T> enumerable, string separator) =>
			string.Join(separator, enumerable);
		public static string JoinEnumerable<T>(this IEnumerable<T> enumerable, char separator) =>
			string.Join(separator, enumerable);

		public static void Each<T>(this IEnumerable<T> arr, Action<T> act)
		{
            foreach (var item in arr)
                act(item);
        }
	}
}
