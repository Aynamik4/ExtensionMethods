/* 
 * Extension methods are static methods written in a static class where the
 * first parameter is prefixed by the keyword this.
 */

namespace ExtensionMethodsDemo;

internal static class ExtensionMethods
{
    internal static bool PerCentChance(this int percent)
    {
        //if (percent < 0 || percent > 100)
        //    throw new ArgumentOutOfRangeException();

        int randomNumber = Random.Shared.Next(1, 100 + 1);
        return  randomNumber <= percent;
    }

    internal static double BMI(this Patient patient)
    {
        return patient.WeightInKg / ((patient.HeightInCm / 100) * (patient.HeightInCm / 100));
    }

    internal static bool IsLessThan<T>(/*No this*/ this IComparable<T> first, T second)
    {
        return first.CompareTo(second) == -1;
    }

    internal static int Square(this int i)
    {
        return i * i;
    }

    internal static int Plus10(this int i)
    {
        return i + 10;
    }

    internal static int DividedBy2(this int i)
    {
        return i / 2;
    }

    internal static void Print<T>(this IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Console.WriteLine(item.ToString());
        }
    }

    internal static void Print<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> func)
    {
        foreach (T item in collection)
        {
            Console.WriteLine(func(item));
        }
    }
}