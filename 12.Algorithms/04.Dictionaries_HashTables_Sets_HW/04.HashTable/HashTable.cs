using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HashTable
{
    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int InitialValuesSize = 16;

        private LinkedList<KeyValuePair<K, V>>[] values;

        public HashTable()
        {
            this.values = new LinkedList<KeyValuePair<K, V>>[InitialValuesSize];
        }

        public int Count
        {
            get;
            private set;
        }

        public int Capacity
        {
            get
            {
                return this.values.Length;
            }
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                var hash = this.HashKey(key);
                if (this.values[hash] == null)
                {
                    throw new ArgumentException("Key not found!");
                }
                else
                {
                    bool elementFound = false;
                    var next = this.values[hash].First;
                    while (next != null)
                    {
                        if (next.Value.Key.Equals(key))
                        {
                            var node = new LinkedListNode<KeyValuePair<K, V>>(new KeyValuePair<K, V>(key, value));
                            this.values[hash].AddAfter(next, node);
                            this.values[hash].Remove(next);
                            elementFound = true;
                            break;
                        }
                        next = next.Next;
                    }
                    if (elementFound == false)
                    {
                        throw new ArgumentException("There is no element with this key");
                    }
                }
            }
        }

        public void Add(K key, V value)
        {
            var hash = this.HashKey(key);

            if (this.values[hash] == null)
            {
                this.values[hash] = new LinkedList<KeyValuePair<K, V>>();
            }

            var alreadyHasKey = this.values[hash].Any(p => p.Key.Equals(key));

            if (alreadyHasKey)
            {
                throw new ArgumentException("Key already exists");
            }

            var pair = new KeyValuePair<K, V>(key, value);
            this.values[hash].AddLast(pair);
            this.Count++;

            if (this.Count >= 0.75 * this.Capacity)
            {
                this.Resize();
            }
        }

        public bool ContainsKey(K key)
        {
            var hash = HashKey(key);

            if (this.values[hash] == null)
            {
                return false;
            }

            var pairs = this.values[hash];

            return pairs.Any(pair => pair.Key.Equals(key));
        }

        public V Find(K key)
        {
            var hash = HashKey(key);

            if (this.values[hash] == null)
            {
                throw new ArgumentException("Key not found");
            }
            var pairs = this.values[hash];
            var val = this.values[hash].First;
            return val.Value.Value;
        }

        private int HashKey(K key)
        {
            var hash = key.GetHashCode();
            hash %= this.Capacity;
            hash = Math.Abs(hash);
            return hash;
        }

        public void Remove(K key)
        {
            var hash = HashKey(key);

            if (this.values[hash] == null)
            {
                throw new ArgumentException("Key not found");
            }

            bool elementFound = false;
            var next = this.values[hash].First;
            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    this.values[hash].Remove(next);
                    elementFound = true;
                    this.Count -= 1;
                }
                next = next.Next;
            }
            if (elementFound == false)
            {
                throw new ArgumentException("There is no element with this key");
            }
        }

        private void Resize()
        {
            //cache old values
            var cachedValues = this.values;
            //resize
            this.values = new LinkedList<KeyValuePair<K, V>>[2 * this.Capacity];

            //add values
            this.Count = 0;
            foreach (var valueCollection in cachedValues)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var valueCollection in this.values)
            {
                if (valueCollection != null)
                {
                    foreach (var value in valueCollection)
                    {
                        yield return value;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}