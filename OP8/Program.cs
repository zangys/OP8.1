using System;

public class Rational
{
    private int numerator;   // числитель
    private int denominator; // знаменатель

    // Конструктор
    public Rational(int num, int denom)
    {
        if (denom == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен нулю.", nameof(denom));
        }

        numerator = num;
        denominator = denom;
        Reduce();
    }

    // Метод для нахождения наибольшего общего делителя (НОД)
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Метод для сокращения дроби
    private void Reduce()
    {
        int common_divisor = GCD(numerator, denominator);
        numerator /= common_divisor;
        denominator /= common_divisor;
    }

    // Метод для сложения дробей
    public Rational Add(Rational other)
    {
        int new_numerator = numerator * other.denominator + other.numerator * denominator;
        int new_denominator = denominator * other.denominator;
        return new Rational(new_numerator, new_denominator);
    }

    // Метод для вычитания дробей
    public Rational Subtract(Rational other)
    {
        int new_numerator = numerator * other.denominator - other.numerator * denominator;
        int new_denominator = denominator * other.denominator;
        return new Rational(new_numerator, new_denominator);
    }

    // Метод для умножения дробей
    public Rational Multiply(Rational other)
    {
        int new_numerator = numerator * other.numerator;
        int new_denominator = denominator * other.denominator;
        return new Rational(new_numerator, new_denominator);
    }

    // Метод для деления дробей
    public Rational Divide(Rational other)
    {
        if (other.numerator == 0)
        {
            throw new ArgumentException("Деление на ноль невозможно.", nameof(other));
        }

        int new_numerator = numerator * other.denominator;
        int new_denominator = denominator * other.numerator;
        return new Rational(new_numerator, new_denominator);
    }

    // Метод для сравнения дробей
    public int Compare(Rational other)
    {
        int lhs = numerator * other.denominator;
        int rhs = other.numerator * denominator;
        if (lhs < rhs)
            return -1;
        else if (lhs > rhs)
            return 1;
        else
            return 0;
    }

    // Метод для вывода дроби
    public void Print()
    {
        Console.WriteLine($"{numerator}/{denominator}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        int num1, denom1, num2, denom2;

        // Ввод данных 
        try
        {
            Console.Write("Введите числитель первой дроби: ");
            num1 = int.Parse(Console.ReadLine());

            Console.Write("Введите знаменатель первой дроби: ");
            denom1 = int.Parse(Console.ReadLine());

            Console.Write("Введите числитель второй дроби: ");
            num2 = int.Parse(Console.ReadLine());

            Console.Write("Введите знаменатель второй дроби: ");
            denom2 = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Некорректный формат ввода.");
            return;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return;
        }

        // Создание объектов рациональных чисел
        Rational rational1, rational2;

        try
        {
            rational1 = new Rational(num1, denom1);
            rational2 = new Rational(num2, denom2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка при создании рационального числа: {ex.Message}");
            return;
        }

        Rational sum = rational1.Add(rational2);
        Rational difference = rational1.Subtract(rational2);
        Rational product = rational1.Multiply(rational2);
        Rational quotient;
        try
        {
            quotient = rational1.Divide(rational2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка при делении: {ex.Message}");
            return;
        }

        // Вывод результатов
        Console.Write("Сумма: ");
        sum.Print();

        Console.Write("Разность: ");
        difference.Print();

        Console.Write("Произведение: ");
        product.Print();

        Console.Write("Частное: ");
        quotient.Print();

        int comparison_result = rational1.Compare(rational2);
        if (comparison_result < 0)
            Console.WriteLine("Первая дробь меньше второй.");
        else if (comparison_result > 0)
            Console.WriteLine("Первая дробь больше второй.");
        else
            Console.WriteLine("Дроби равны.");
    }
}
