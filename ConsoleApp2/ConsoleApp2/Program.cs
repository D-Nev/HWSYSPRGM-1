using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp2;

class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите приложение для запуска:");
            Console.WriteLine("1. Блокнот");
            Console.WriteLine("2. Калькулятор");
            Console.WriteLine("3. Paint");
            Console.WriteLine("4. Steam");
            Console.WriteLine("5. Выход");
            Console.Write("> ");

            switch (Console.ReadLine())
            {
                case "1":
                    Process.Start("notepad.exe");
                    break;
                case "2":
                    Process.Start("calc.exe");
                    break;
                case "3":
                    Process.Start("mspaint.exe");
                    break;
                case "4":
                    Process.Start("\"C:\\Program Files (x86)\\Steam\\steam.exe\"");
                    break;
                case "5":
                    return;
                default:
                    MessageBox(IntPtr.Zero, "!", "Ошибка", 0);
                    break;
            }
        }
    }
}
