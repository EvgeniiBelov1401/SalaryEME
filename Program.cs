internal class Program
{
    private static void Main(string[] args)
    {
        const decimal oklad = 70000;
        const decimal okladDeclare = 230000;
        decimal prize;
        while (true)
        {
            Console.Write("Введите кол-во рабочих дней: ");
            try
            {
                if (int.TryParse(Console.ReadLine(),out int dayCounStandart))
                {
                    var hourCountStandart = dayCounStandart * 8;
                    var hourlyBetStandart = oklad / hourCountStandart;
                    var hourlyBetDeclare = okladDeclare / hourCountStandart;

                    Console.Write("Введите кол-во декларированных часов: ");
                    if (decimal.TryParse(Console.ReadLine(),out decimal hourCountDeclare))
                    {
                        prize = hourCountDeclare * hourlyBetDeclare - (hourlyBetStandart*hourCountDeclare);
                    }
                    else
                    {
                        throw new FormatException();
                    }


                    ShowReport(dayCounStandart,hourCountStandart,hourlyBetStandart,hourlyBetDeclare, hourCountDeclare, oklad, prize);
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите корректные данные...");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Введите корректные данные...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
    static void ShowReport(int dayCountSt,int hourCountSt,decimal hourlyBetSt,decimal hourlyBetDec, decimal hourCountDec,decimal oklad, decimal prize)
    {
        Console.WriteLine($"\nКоличество рабочих дней: {dayCountSt}\n" +
            $"\tКоличество стандартных рабочих часов: {hourCountSt-hourCountDec} ч.\n" +
            $"\t\tЕжечасовая стандартная ставка: {hourlyBetSt.ToString("F2")} руб/час\n"+
            $"\tКоличество декларированных рабочих часов: {hourCountDec} ч.\n" +
            $"\t\tЕжечасовая декларированная ставка: {hourlyBetDec.ToString("F2")} руб/час\n" +
            $"ИТОГО:\n" +
            $"\tОклад: {oklad} руб\n" +
            $"\tПремия: {prize.ToString("F2")} руб");
    }
}
