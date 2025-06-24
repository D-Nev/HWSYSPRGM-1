using System.Runtime.InteropServices;

namespace ConsoleApp1;
class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            PlayGame();
            playAgain = AskForReplay();
        }
        Console.WriteLine("Спасибо за игру!");
    }

    static void PlayGame()
    {
        Console.WriteLine("Загадайте число от 0 до 100.");
        Console.WriteLine("Компьютер будет пытаться его угадать.");

        int min = 0;
        int max = 100;
        int guess;
        string userInput;

        while (true)
        {
            guess = (min + max) / 2;
            Console.WriteLine($"Компьютер предполагает, что ваше число: {guess}");
            Console.WriteLine("Введите '+' если компьютер угадал, '-' если ваше число меньше, или '+' если ваше число больше.");
            userInput = Console.ReadLine();

            if (userInput == "+")
            {
                MessageBox(IntPtr.Zero, $"Компьютер угадал ваше число! Оно равно {guess}.", "Угаданное число", 0);
                break;
            }
            else if (userInput == "-")
            {
                max = guess - 1;
            }
            else if (userInput == "+") 
            {
                min = guess + 1;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
            }
        } 
    }
    static bool AskForReplay()
    {
        Console.WriteLine("Хотите сыграть еще раз? (да/нет)");
        string response = Console.ReadLine();

        return response.ToLower() == "да";
    }
}

