/*
 * Please see the comments in the ExtensionMethods class.
 */

namespace ExtensionMethodsDemo;

internal class Program
{
    static void Main(string[] args)
    {
        TestPerCentChance();
        TestBMI();
        TestInterface();
        TestExtensionMethodAsArgument();
    }

    private static void TestPerCentChance()
    {
        double lucky = 0, unlucky = 0;
        int randomAttempts = 100;

        for (int i = 0; i < randomAttempts; i++)
        {
            if (/*ExtensionMethods.PerCentChance(1)*/ 25.PerCentChance())
                lucky++;
            else
                unlucky++;
        }

        Console.WriteLine($"Lucky {Math.Round(lucky / randomAttempts * 100.0, 0)} per cent of the time.");
        Console.WriteLine($"Unlucky {Math.Round(unlucky / randomAttempts * 100.0, 0)} per cent of the time.");
    }

    private static void TestBMI()
    {
        Patient patient = new Patient { WeightInKg = 95.0, HeightInCm = 182.5 };
        double BMI = patient.BMI(); // ExtensionMethods.BMI(patient);
        Console.WriteLine($"BMI: {Math.Round(BMI, 0)}");
    }

    private static void TestInterface()
    {
        // --- Example using int ---
        int x = 10;
        int y = 12;

        //if (ExtensionMethods.IsLessThan(x, y))
        if (x.IsLessThan(y))
            Console.WriteLine($"{x} is less than {y}");

        // --- Example using DateTime ---
        DateTime start = new DateTime(2024, 09, 29);
        DateTime stop = new DateTime(2024, 09, 30);

        //if (ExtensionMethods.IsLessThan(start, stop))
        if (start.IsLessThan(stop))
            Console.WriteLine($"{start.ToShortDateString()} is less than {stop.ToShortDateString()}");

        // --- Example using Patient ---
        Patient a = new Patient { WeightInKg = 60.0, HeightInCm = 157.5 };
        Patient b = new Patient { WeightInKg = 96.7, HeightInCm = 182.5 };

        //if (ExtensionMethods.IsLessThan(a, b))
        if (a.IsLessThan(b))
            Console.WriteLine($"{a.BMI()} is less than {b.BMI()}");
    }

    private static void TestExtensionMethodAsArgument()
    {
        int number = 10;

        int square = ExtensionMethods.Square(number);
        int added10 = ExtensionMethods.Plus10(square);
        int result = ExtensionMethods.DividedBy2(added10);

        result = ExtensionMethods.DividedBy2(ExtensionMethods.Plus10(ExtensionMethods.Square(number)));

        result = number
            .Square()
            .Plus10()
            .DividedBy2();
    }
}