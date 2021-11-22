using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding =
                    Console.OutputEncoding =
                        System.Text.Encoding.Unicode;

            Console.WriteLine("З яким типом текстових файлів хочете працювати:");
            Console.WriteLine("1 - txt");
            Console.WriteLine("2 - MsWORD");
            Console.WriteLine("3 - PDF");
            Console.WriteLine("4 - html");
            Console.Write("Відповідь: ");
            int ans = int.Parse(Console.ReadLine());

            TextDocument document;

            switch (ans)
            {
                case (1):
                    document = new TextDocument();
                    break;
                case (2):
                    document = new WordDocument();
                    break;
                case (3):
                    document = new PdfDucument();
                    break;
                case (4):
                    document = new HtmlDocument();
                    break;
                default:
                    throw new Exception("Неправильний вибір");
            }

            Console.WriteLine();
            Console.WriteLine("Що зробити з документом: ");
            Console.WriteLine("1 - Відкрити");
            Console.WriteLine("2 - Створити");
            Console.WriteLine("3 - Редагувати");
            Console.Write("Відповідь: ");
            int actAns = int.Parse(Console.ReadLine());

            switch (actAns)
            {
                case (1):
                    document.Open();
                    break;
                case (2):
                    document.Create();
                    break;
                case (3):
                    document.Edit();
                    break;
                default:
                    throw new Exception("Неправильний вибір");
            }
        }
    }
}
