
namespace TaskHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task taskFile1 = Task.Run(() =>
            {
                string path = @"D:\Kiz_Deniel_TSvetyi_dlya_Eldjernona.txt";
                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamReader stream = new StreamReader(fileStream))
                    {
                        string text = stream.ReadToEnd();
                        int countOfSpace = text.Count(symbol => symbol == ' ');

                        Console.WriteLine($"Количество пробелов в 1 файле - {countOfSpace} в потоке {Environment.CurrentManagedThreadId}");
                    };
                };
            });

            
            Task taskFile2 = Task.Run(() =>
            {
                string path = @"D:\Tolkin_Dj__R__R__[Legendarium_Sredizemya#1]_Hobbit.txt";
                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (StreamReader stream = new StreamReader(fileStream))
                    {
                        string text = stream.ReadToEnd();
                        int countOfSpace = text.Count(symbol => symbol == ' ');

                        Console.WriteLine($"Количество пробелов в 3 файле - {countOfSpace} в потоке {Environment.CurrentManagedThreadId}");
                    };
                };
            });


            string path = @"D:\Анджей Сапковский - Ведьмак (сборник) (Сага о ведьмаке) - 2014.txt";
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamReader stream = new StreamReader(fileStream))
                {
                    string text = stream.ReadToEnd();
                    int countOfSpace = text.Count(symbol => symbol == ' ');

                    Console.WriteLine($"Количество пробелов во 2 файле - {countOfSpace} в потоке {Environment.CurrentManagedThreadId}");
                };
            };
            
            taskFile1.Wait();
            taskFile2.Wait();
        }
    }
}