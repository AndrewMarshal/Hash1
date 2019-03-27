using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable.Tests1
{
    [TestClass]
    public class TestsHashTable
    {
        [TestMethod]
        public void SearshAndPut3ElementsTest() // Добавление трёх элементов, поиск трёх элементов 
        {
            var pair = new HashTable(3);
            for (int i = 0; i < 3; i++)
            {
                pair.PutPair(i.GetHashCode(), i);
            }
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(j, pair.GetValueByKey(j.GetHashCode()));
            }
        }

        [TestMethod]
        public void Add2KeysTest() //  Добавление одного и того же ключа дважды с разными значениями сохраняет последнее добавленное значение
        {
            var pair = new HashTable(2);
            string title1 = "Crysis";
            string title2 = "Metro";
            pair.PutPair(0, title1);
            pair.PutPair(0, title2);
            Assert.AreEqual(title2, pair.GetValueByKey(0));
        }

        [TestMethod]
        public void Add10000ElementsAnd1SearchTest() //  Добавление 10000 элементов в структуру и поиск одного из них
        {
            var pair = new HashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                pair.PutPair(i, i * 100);
            }
            Assert.AreEqual(700, pair.GetValueByKey(7));
        }

        [TestMethod]
        public void Add10000ElementsAndSearch1000NotAddTest() // Добавление 10000 элементов в структуру и поиск 1000 недобавленных ключей, поиск которых должен вернуть null
        {
            var pair = new HashTable(10000);
            for (int i = 0; i < 10000; i++)
            {
                pair.PutPair(i, i);
            }
            for (int j = 10000; j < 10000 + 1000; j++)
            {
                Assert.AreEqual(pair.GetValueByKey(j), null);
            }
        }
    }
}
