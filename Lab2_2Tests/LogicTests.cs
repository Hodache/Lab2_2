using Lab2_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2_2.Tests
{
    [TestClass()]
    public class LogicTests
    {
        // Все буквы совпадают в одинаковых словах
        [TestMethod()]
        public void GotIdenticalWords()
        {
            string firstWord = "привет";
            string secondWord = "привет";

            string message = Logic.CompareWords(firstWord, secondWord);

            Assert.AreEqual("да да да да да да ", message);
        }

        // Все буквы совпадают в одинаковых словах с разнымм регистрами
        [TestMethod()]
        public void GotIdenticalWordsDiffCases()
        {
            string firstWord = "привет";
            string secondWord = "Привет";

            string message = Logic.CompareWords(firstWord, secondWord);

            Assert.AreEqual("да да да да да да ", message);
        }

        // Правильность ответа в разных словах одинаковой длины
        [TestMethod()]
        public void GotDifferentWords()
        {
            string firstWord = "Иркутск";
            string secondWord = "Гамбург";

            string message = Logic.CompareWords(firstWord, secondWord);

            Assert.AreEqual("нет да нет да нет нет ", message);
        }

        // Тест правильности ответа, если первое слово больше второго
        [TestMethod()]
        public void GotLongFirstWord()
        {
            string firstWord = "лошадь";
            string secondWord = "конь";

            string message = Logic.CompareWords(firstWord, secondWord);

            Assert.AreEqual("нет да нет нет нет да ", message);
        }

        // Тест правильности ответа, если второе слово больше первого
        [TestMethod()]
        public void GotLongSecondWord()
        {
            string firstWord = "конь";
            string secondWord = "лошадь";

            string message = Logic.CompareWords(firstWord, secondWord);

            Assert.AreEqual("нет да нет да ", message);
        }

        // Тест правильности ответа со словом с повторяющимися буквами
        [TestMethod()]
        public void GotWordWithSameSymbols()
        {
            string firstWord = "Россия";
            string secondWord = "Село";

            string message = Logic.CompareWords(firstWord, secondWord);

            Assert.AreEqual("нет да да нет нет ", message);
        }

        // Тест из примера
        [TestMethod()]
        public void GotExampleTest()
        {
            string firstWord = "процессор";
            string secondWord = "информация";

            string message = Logic.CompareWords(firstWord, secondWord);

            Assert.AreEqual("нет да да да нет нет ", message);
        }
    }
}