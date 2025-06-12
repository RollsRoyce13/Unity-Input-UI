using UnityEngine;

namespace Utils
{
	public static class NullChecker
	{
		public static bool IsNull<T>(this T obj)
		{
			if (obj == null)
			{
				Debug.LogWarning($"Object is null");
				return true;
			}

			return false;
		}
	}
}