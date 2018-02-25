using System;
using System.Collections;
using System.Collections.Generic;

namespace OrderedSymbolTableLesson
{
    public class OrderedSymbolTable<TKey, TValue> : IEnumerable<TKey>
        where TKey : IComparable<TKey>
    {
        internal TKey[] _keys;

        internal TValue[] _values;

        internal int _count;

        public OrderedSymbolTable() : this(2)
        {
        }

        public OrderedSymbolTable(int capacity)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];

            _count = 0;
        }

        public bool Contains(TKey key)
        {
            try
            {
                Search(key);
                return true;
            }
            catch (KeyNotFoundException ex)
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

            var position = Rank(key);

            if (position < _count && _keys[position].CompareTo(key) == 0)
                return _values[position];

            throw new KeyNotFoundException();
        }

        public void Insert(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException();

            var position = Rank(key);

            if (position < _count && _keys[position].CompareTo(key) == 0)
            {
                _values[position] = value;
                return;
            }

            if(_count == _keys.Length)
                Resize(2*_keys.Length);

            for (var i = _count; i > position; i--)
            {
                _keys[i] = _keys[i - 1];
                _values[i] = _values[i - 1];
            }

            _keys[position] = key;
            _values[position] = value;

            _count++;
        }

        public void Delete(TKey key)
        {
            if (IsEmpty())
                throw new Exception();

            if (key == null)
                throw new ArgumentNullException();

            var position = Rank(key);

            if (position == _count || _keys[position].CompareTo(key) != 0)
                return;

            for (var i = position; i < _count - 1; i++)
            {
                _keys[i] = _keys[i + 1];
                _values[i] = _values[i + 1];
            }

            _count--;

            if(_count > 0 && _count == _keys.Length/4)
                Resize(_keys.Length/2);
        }

        public int Rank(TKey key)
        {
            if(key == null)
                throw new ArgumentNullException();

            var lo = 0;
            var hi = _count - 1;

            while (lo <= hi)
            {
                var mid = lo + (hi - lo)/2;

                var result = key.CompareTo(_keys[mid]);

                if (result < 0)
                {
                    hi = mid - 1;
                } 
                else if (result > 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return lo;
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
            foreach (var key in _keys)
                yield return key;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Resize(int capacity)
        {
            if(capacity < _count)
                throw new Exception();

            var resizedKeys = new TKey[capacity];
            var resizedValues = new TValue[capacity];

            for (var i = 0; i < _count; i++)
            {
                resizedKeys[i] = _keys[i];
                resizedValues[i] = _values[i];
            }

            _keys = resizedKeys;
            _values = resizedValues;
        }
    }
}
