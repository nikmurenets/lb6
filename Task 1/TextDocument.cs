using System;
using System.IO;

namespace Task_1
{
    class TextDocument : AbstractHandler
    {
        public virtual string Extension
        {
            get
            {
                return ".txt";
            }
        }

        public override void Open()
        {
            Console.Write("Введіть шлях до файлу(без кавичок): ");
            string path = Console.ReadLine();

            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }
        }
        public override void Create()
        {
            string path;

            Console.Write("Введіть назву файлу: ");
            string name = Console.ReadLine();

            Console.WriteLine("Де зберегти:");
            Console.WriteLine("1 - Робочий стіл");
            Console.WriteLine("2 - Ввести самостійно");
            Console.WriteLine();
            Console.Write("Відповідь: ");
            int ansPath = int.Parse(Console.ReadLine());

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            switch (ansPath)
            {
                case (1):
                    path = desktop + "/" + name + Extension;
                    break;
                case (2):
                    Console.WriteLine();
                    Console.Write("Введіть шлях збереження: ");
                    string savePlace = Console.ReadLine();
                    try
                    {
                        path = savePlace + "/" + name;
                    }
                    catch (Exception ex)
                    {

                        throw new Exception("Щось було введено неправильно");
                    }
                    break;
                default:
                    throw new Exception("Неправильний вибір");
            }

            string text = "";

            Console.WriteLine();
            Console.WriteLine("Бажаєте добавити текст у файл:");
            Console.WriteLine("1 - Так"); ;
            Console.WriteLine("2 - Ні");
            Console.WriteLine();
            Console.Write("Відповідь: ");
            int ansText = int.Parse(Console.ReadLine());

            switch (ansText)
            {
                case (1):
                    Console.Write("Введіть текст:");
                    text = Console.ReadLine();
                    break;
                case (2):
                    break;
                default:
                    throw new Exception("Неправильний вибір");
            }

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }

            Console.WriteLine("Файл створено у:" + path);
        }
        public override void Edit()
        {
            Console.WriteLine("1 - Замінити весь текст");
            Console.WriteLine("2 - Замінити окрему частину тексту");
            Console.WriteLine("3 - Додати свій текст в кінець");
            Console.Write("Відповідь:");
            int ansEdit = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введіть шлях до файлу(без кавичок):");
            string path = Console.ReadLine();

            string text;

            switch (ansEdit)
            {
                case (1):
                    Console.Write("Введіть новий текст: ");
                    text = Console.ReadLine();
                    File.WriteAllText(path, text);
                    break;
                case (2):
                    Console.WriteLine("Текст у файлі:");
                    string[] readText = File.ReadAllLines(path);
                    foreach (string s in readText)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Введіть текст який потрібно замінити:");
                    string repText = Console.ReadLine();
                    Console.Write("Новий текст: ");
                    string newText = Console.ReadLine();

                    text = File.ReadAllText(path);
                    text = text.Replace(repText, newText);
                    File.WriteAllText(path, text);
                    break;
                case (3):
                    Console.WriteLine("Який текст хочете дописати: ");
                    text = Console.ReadLine();
                    File.AppendAllText(path, text);
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
