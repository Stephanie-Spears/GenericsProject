using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericsProject
{
    internal static class EnumerableCompositor
    {
        //EcCreate() factory method takes an array of collections and then passes that array of collections to the constructor of an EnumerableComposite<T> to create a new instance and then return it.
        public static EnumerableCompositor<T> EcCreate<T>(params IEnumerable<T>[] collections)
        {
            return new EnumerableCompositor<T>(collections);
        }
    }

    internal class EnumerableCompositor<T> : IEnumerable<T>
    {
        private List<IEnumerable<T>> _collections;

        public EnumerableCompositor()
        {
            _collections = new List<IEnumerable<T>>();
        }

        public EnumerableCompositor(IEnumerable<IEnumerable<T>> collections)
        {
            _collections = collections.ToList();
        }

        public void Add(IEnumerable<T> collection)
        {
            _collections.Add(collection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var collection in _collections)
            {
                foreach (var item in collection)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}