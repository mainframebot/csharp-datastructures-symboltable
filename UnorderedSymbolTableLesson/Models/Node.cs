using System;
using System.Collections.Generic;

namespace UnorderedSymbolTableLesson.Models
{
    internal class Node<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public Node<TKey, TValue> Next { get; set; }

        public Node(TKey key, TValue value, Node<TKey, TValue> next)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }
}
