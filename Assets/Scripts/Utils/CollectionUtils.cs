using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
	public static class CollectionUtils
	{
		public static bool IsEmpty<T>(this IEnumerable<T> collection)
		{
			if (collection == null || !collection.Any())
			{
				Debug.LogWarning($"{nameof(collection)} is empty");
				return true;
			}

			return false;
		}
        
		public static bool IsIndexWithinRange<T>(this IList<T> collection, int index)
		{
			if (collection != null && index >= 0 && index < collection.Count)
			{
				return true;
			}

			Debug.LogWarning($"{nameof(index)} is out of range");
			return false;
		}
		
		public static bool IsCountWithinRange<T>(this IList<T> collection, int count)
		{
			if (collection != null && count >= 0 && count <= collection.Count)
			{
				return true;
			}

			Debug.LogWarning($"{nameof(count)} is out of range");
			return false;
		}
	}
}