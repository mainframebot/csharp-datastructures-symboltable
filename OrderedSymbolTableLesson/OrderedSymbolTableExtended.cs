using System;
using System.Collections.Generic;

namespace OrderedSymbolTableLesson
{
    public class OrderedSymbolTableExtended<TKey, TValue> : OrderedSymbolTable<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        public OrderedSymbolTableExtended() : base()
        {
        }

        public OrderedSymbolTableExtended(int capacity) : base(capacity)
        {
        }

        public TKey Min()
        {
            if (IsEmpty())
                throw new KeyNotFoundException();

            return _keys[0];
        }

        public TKey Max()
        {
            if (IsEmpty())
                throw new KeyNotFoundException();

            return _keys[_count - 1];
        }

        public void DeleteMin()
        {
            if (IsEmpty())
                throw new KeyNotFoundException();

            Delete(Min());
        }

        public void DeleteMax()
        {
            if (IsEmpty())
                throw new KeyNotFoundException();

            Delete(Max());
        }

        public TKey Select(int position)
        {
            if(position < 0 || position >= _count)
                throw new KeyNotFoundException();

            return _keys[position];
        }

        public TKey Floor(TKey key)
        {
            if(key == null)
                throw new ArgumentNullException();

            var position = Rank(key);

            if (position < _count && key.CompareTo(_keys[position]) == 0)
                return _keys[position];

            if (position == 0)
                throw new KeyNotFoundException();

            return _keys[position - 1];
        }

        public TKey Ceiling(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();

            var position = Rank(key);

            if(position == _count)
                throw new KeyNotFoundException();

            return _keys[position];
        }

        public int Size(TKey lo, TKey hi)
        {
            if(lo == null || hi == null)
                throw new Exception();

            if (lo.CompareTo(hi) > 0)
                return 0;

            if (Contains(hi))
                return Rank(hi) - Rank(lo) + 1;

            return Rank(hi) - Rank(lo);
        }

        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            if (lo == null || hi == null)
                throw new Exception();

            var queue = new Queue<TKey>();

            if (lo.CompareTo(hi) > 0)
                return null;

            for(var i = Rank(lo); i < Rank(hi); i++)
                queue.Enqueue(_keys[i]);

            if(Contains(hi))
                queue.Enqueue(_keys[Rank(hi)]);

            return queue;
        } 
    }
}
