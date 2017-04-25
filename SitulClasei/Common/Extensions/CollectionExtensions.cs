using System.Collections.Generic;

namespace SitulClasei.Common.Extensions
{
	//TODO: check this Preserver
	[Foundation.Preserve(AllMembers = true)]
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IList<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static void RemoveRange<T>(this ICollection<T> collection, IList<T> items)
        {
            foreach (var item in items)
            {
                collection.Remove(item);
            }
        }
    }
}