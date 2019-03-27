using System;
using System.Collections.Generic;

namespace HashTable
{
    public class Pair
    {
        public object Key { get; private set; }

        public object Value { get; private set; }

        public Pair AttachedPair;

        public Pair(object key, object value)
        {
            Key = key;
            Value = value;
            if (Key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (Value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public void TransformValue(object value)
        {
            Value = value;
        }
    }

    public class HashTable
    {
        public Pair[] array;
        readonly int size;
        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэш-таблицы
        public HashTable(int size)
        {
            this.size = size;
            array = new Pair[size];
        }

        ///
        /// Метод складывающий пару ключь-значение в таблицу
        ///
        /// key">
        /// value">
        public void PutPair(object key, object value) // Метод складывающий пару ключь-значение в таблицу
        {
            var hash = key.GetHashCode();
            hash = Math.Abs(hash) % size;
            var str = new Pair(key, value);
            var oldStr = array[hash];
            if (oldStr is null)
            {
                array[hash] = str;
            }
            else
            {
                while (true)
                {
                    if (oldStr.Key.Equals(key))
                    {
                        oldStr.TransformValue(value);
                        break;
                    }
                    if (oldStr.AttachedPair is null)
                    {
                        oldStr.AttachedPair = str;
                        break;
                    }
                    else
                    {
                        oldStr = oldStr.AttachedPair;
                    }
                }
            }
        }

        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключь
        /// <returns>Значение, null если ключ отсутствует <returns>
        public object GetValueByKey(object key) // 
        {
            foreach (var e in array)
            {
                if (e.Key.Equals(key))
                    return e.Value;
            }
            return null;
        }
    }
}
