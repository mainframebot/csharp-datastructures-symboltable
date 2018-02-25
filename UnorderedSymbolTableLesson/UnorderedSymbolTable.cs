using System;
using System.Collections;
using System.Collections.Generic;
using UnorderedSymbolTableLesson.Models;

namespace UnorderedSymbolTableLesson
{
    public class UnorderedSymbolTable<TKey, TValue> : IEnumerable<TKey>
        where TKey : IEquatable<TKey>
    {
        private int _count;

        private Node<TKey, TValue> _root;

        public bool Contains(TKey key)
        {
            try
            {
                Search(key);
                return true;
            }
            catch(KeyNotFoundException ex)
            {
                return false;
            }
        }

        public TValue Search(TKey key)
        {
            if (IsEmpty())
                throw new Exception();

            if (key == null)
                throw new ArgumentNullException();

            for (var node = _root; node != null; node = node.Next)
            {
                if (node.Key.Equals(key))
                    return node.Value;
            }

            throw new KeyNotFoundException();
        }

        public void Insert(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException();

            for (var node = _root; node != null; node = node.Next)
            {
                if (key.Equals(node.Key))
                {
                    node.Value = value;
                    return;
                }
            }

            _root = new Node<TKey,TValue>(key, value, _root);
            _count++;
        }

        public void Delete(TKey key)
        {
            if (IsEmpty())
                throw new Exception();

            if (key == null)
                throw new ArgumentNullException();

            _root = Delete(_root, key);
        }

        private Node<TKey, TValue> Delete(Node<TKey, TValue> node, TKey key)
        {
            if (node == null)
                return null;

            if (key.Equals(node.Key))
            {
                _count--;
                return node;
            }

            node.Next = Delete(node.Next, key);
            return node;
        } 

        public int Size()
        {
            return _count;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            for (var node = _root; node != null; node = node.Next)
                yield return node.Key;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
