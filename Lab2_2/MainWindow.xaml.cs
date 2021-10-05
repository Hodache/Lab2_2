using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Реакция на нажатия Enter
        private void FirstWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SecondWord.Focus();
            }
        }

        private void SecondWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CompareBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        // Очистка полей
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            FirstWord.Text = "";
            SecondWord.Text = "";
        }

        // Нажатие кнопки сравнения
        private void CompareBtn_Click(object sender, RoutedEventArgs e)
        {
            // Удаляем незаметные случайно введенные пробелы
            FirstWord.Text = FirstWord.Text.Trim();
            SecondWord.Text = SecondWord.Text.Trim();

            string firstWord = FirstWord.Text;
            string secondWord = SecondWord.Text;

            if (firstWord == "" || secondWord == "" || !(Logic.CheckWord(firstWord) && Logic.CheckWord(secondWord)))
            {
                MessageBox.Show("Поля должны содержать слова!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                answerTextBox.Text = "Ответ: " + Logic.CompareWords(firstWord, secondWord);
            }
        }

        private void taskBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Даны два слова. Для каждой буквы первого слова определить, " +
                "входит ли она во второе слово. " +
                "Повторяющиеся буквы первого слова не рассматривать. " +
                "Например, если заданные слова процессор и информация, " +
                "то для букв первого из них ответом должно быть: нет да да да нет нет.", "Задание");
        }
    }

    // Класс логики
    public static class Logic
    {
        // Метод сравнения символов слов
        public static string CompareWords(string firstWord, string secondWord)
        {
            // Перевод в нижний регистр (может не понадобиться)
            string word1 = firstWord.ToLower();
            string word2 = secondWord.ToLower();

            char ch; // Символ, который ищем
            string answer = ""; // Строка-ответ

            for (int i = 0; i < word1.Length; i++)
            {
                ch = word1[i];

                // Если первое вхождение символа было раньше
                if (word1.IndexOf(ch) < i)
                {
                    continue;
                }

                // Если во втором слове не нашлось буквы, пишем "нет"
                if (word2.IndexOf(ch) == -1)
                {
                    answer += "нет ";
                }
                else // Иначе "да"
                {
                    answer += "да ";
                }
            }

            return answer;
        }

        // Метод, проверяющий является ли текст словом
        public static bool CheckWord(string word)
        {
            bool isWord = true; 

            foreach (char ch in word)
            {
                if (!Char.IsLetter(ch))
                {
                    isWord = false;
                }
            }

            return isWord;
        }
    }
}
