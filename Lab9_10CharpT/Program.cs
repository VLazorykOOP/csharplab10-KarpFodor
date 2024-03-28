
using HorseLifeSimulation;

namespace Lab9_10CharpT
{
    class Program
    {
        public static void RecursiveMethod()
        {
            RecursiveMethod(); 
        }
        static void HandleBirth(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"Обробка подiї народження нового коня {e.Name}.");
        }

        static void HandleDeath(object sender, HorseEventArgs e)
        {
            Console.WriteLine($"Обробка подiї смертi коня {e.Name} у вiцi {e.Age} рокiв.");
        }
        static void Main()
        {
            int n = 0;
            Console.WriteLine("Виберiть яку помилку:\n Власний Exeption - 1\n ArrayTypeMismatchException - 2\n DivideByZeroException - 3\n IndexOutOfRangeException - 4\n InvalidCastException - 5 \n OutOfMemoryException - 6\n OverflowException - 7\n StackOverflowException - 8");
            Console.WriteLine("Життя коня - 0");
            n = int.Parse(Console.ReadLine());
            ReverseCheck reverseCheck;
            switch (n)
            {
                case 0:
                    Console.WriteLine("Симуляцiя життя коня...");

                    List<Horse> horses = new List<Horse>();
                    Horse horse = new Horse("Пегас");
                    horse.Birth += HandleBirth;
                    horse.Death += HandleDeath;
                    horse.Live();
                    horses.Add(horse);

                    while (horses.Count > 0)
                    {
                        for (int i = horses.Count - 1; i >= 0; i--)
                        {
                            if (!horses[i].getIsAlive())
                            {
                                horses.RemoveAt(i);
                            }
                        }

                        Thread.Sleep(1000);
                    }

                    Console.WriteLine("Кiнець симуляцiї.");
                    break;
                case 1:
                    {
                        reverseCheck = new ReverseCheck();
                        reverseCheck.Run();
                    }
                    break;
                case 2:
                    try
                    {
                        object[] array = new string[4];
                        array[0] = 12345; // ArrayTypeMismatchException
                    }
                    catch (ArrayTypeMismatchException ex)
                    {
                        Console.WriteLine($"ArrayTypeMismatchException: {ex.Message}");
                    }
                    break;
                case 3:
                    try
                    {
                        int y = 0;
                        int result = 10 / y; // DivideByZeroException
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"DivideByZeroException: {ex.Message}");
                    }
                    break;
                case 4:
                    try
                    {
                        int[] array = new int[3];
                        int value = array[4]; // IndexOutOfRangeException
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"IndexOutOfRangeException: {ex.Message}");
                    }
                    break;
                case 5:
                    try
                    {
                        object obj = "Hello";
                        int num = (int)obj; // InvalidCastException
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine($"InvalidCastException: {ex.Message}");
                    }
                    break;
                case 6:
                    try
                    {
                        List<byte[]> list = new List<byte[]>();
                        while (true)
                        {
                            byte[] array = new byte[1000000];
                            list.Add(array);
                        }
                    }
                    catch (OutOfMemoryException ex)
                    {
                        Console.WriteLine($"OutOfMemoryException: {ex.Message}");
                    }
                    break;
                case 7:
                    try
                    {
                        {
                            int maxInt = int.MaxValue;
                            maxInt++; // OverflowException
                        }
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine($"OverflowException: {ex.Message}");
                    }
                    break;
                case 8:
                    try
                    {
                        RecursiveMethod();
                    }
                    catch (StackOverflowException ex)
                    {
                        Console.WriteLine($"StackOverflowException: {ex.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Не вiрно");
                    break;
            }
        }
    }

}