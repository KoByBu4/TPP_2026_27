using System;
class Program {
    public static string PrintBalance(int balance, string currency)
    {
       return $"{balance}{currency}";
    }
    public static int PrintSum(int balance,int sum, List<string> history)
    {
        if (sum > 0)
        {
            string message = $"Пополнение счета на {sum}₽";
            history.Add(message);
            return balance + sum;
        }
        return balance;
    }
    public static int PrintCash(int balance,int sumReturn, List<string> history)
    {
        if(sumReturn > 0 && sumReturn < balance)
        {
            string message = $"Снятие со счета {sumReturn}₽";
            history.Add(message);
            return balance - sumReturn;
        }
        return balance;
    }
    public static void PrintHistory(List<string> history)
    {
        Console.WriteLine($"История операций:");
        if(history.Count == 0) Console.WriteLine("Вы еще не совершили ни одной операции");
        else foreach(string operation in history)
        {
            Console.WriteLine($"\t{operation}");
        }
        
    }
    static void Main()
    {
        Console.WriteLine("Введите начальный баланс:");
        int balance = int.Parse(Console.ReadLine());
        bool alwaysTrue = true;
        List<string> history = new List<string>();
        string currency = "₽";
        Console.WriteLine("1. Показать баланс\n2. Пополнить счёт\n3. Снять деньги\n4. Показать историю операций\n5. Выйти");
        while (alwaysTrue)
        {
            int number = int.Parse(Console.ReadLine());
            switch (number)
                {
                    case 1: Console.WriteLine($"Ваш баланс: {PrintBalance(balance, currency)}");break;
                    case 2: Console.WriteLine("Введите сумму для пополнения:"); int sum = int.Parse(Console.ReadLine());balance = PrintSum(balance, sum, history); break;
                    case 3: Console.WriteLine("Введите сумму для вывода:"); int sumReturn = int.Parse(Console.ReadLine());balance = PrintCash(balance, sumReturn, history); break;
                    case 4: PrintHistory(history); break;
                    case 5: alwaysTrue = false; break;
                    default: Console.WriteLine("Неверная цифра, попробуйте еще раз"); break;
                }
        }
    }
}