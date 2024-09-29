/*
 * Please see the comments in the ExtensionMethods class.
 */

using System.Dynamic;

namespace ExtensionMethodsDemo;

internal class Program
{
    static void Main(string[] args)
    {
        //DemoPerCentChance(); // Demonstrates the PerCentChance extension method.
        //DemoBMI(); // Demonstrates the BMI extension method.
        //TestExtensionMethodsAsArguments(); // Demonstrates the syntactic advantage of extension methods.
        //DemoInterface(); // Demonstrates that an interface type can be an extension method argument.
        DemoPrint();
    }

    private static void DemoPerCentChance()
    {
        double lucky = 0, unlucky = 0;
        int randomAttempts = 100;

        for (int i = 0; i < randomAttempts; i++)
        {
            if (/*ExtensionMethods.PerCentChance(25)*/ 25.PerCentChance())
                lucky++;
            else
                unlucky++;
        }

        Console.WriteLine($"Lucky {Math.Round(lucky / randomAttempts * 100.0, 0)} per cent of the time.");
        Console.WriteLine($"Unlucky {Math.Round(unlucky / randomAttempts * 100.0, 0)} per cent of the time.");
    }

    private static void DemoBMI()
    {
        Patient patient = new Patient { WeightInKg = 96.7, HeightInCm = 182.5 };
        double bmi = patient.BMI(); // ExtensionMethods.BMI(patient);
        Console.WriteLine($"BMI: {Math.Round(bmi, 0)}");
    }

    private static void TestExtensionMethodsAsArguments()
    {
        int number = 10;

        // Calling on the methods in the conventional way using several statements.
        int square = ExtensionMethods.Square(number);
        int squarePlus10 = ExtensionMethods.Plus10(square);
        int squarePlus10DividedBy2 = ExtensionMethods.DividedBy2(squarePlus10);

        // Calling on the methods in the conventional way using a single statement ("one liner").
        squarePlus10DividedBy2 =
            ExtensionMethods.DividedBy2(ExtensionMethods.Plus10(ExtensionMethods.Square(number)));

        // Calling on the methods using extension method syntax.
        squarePlus10DividedBy2 = number
            .Square()
            .Plus10()
            .DividedBy2();
    }

    private static void DemoInterface()
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
    private static void DemoPrint()
    {
        int[] ints = [1962, 1976, 1959, 2009, 1939, 1937, 2006];
        //ExtensionMethods.Print(ints);
        ints.Print();
        ints.Print(i => $"This year you will be {DateTime.Now.Year - i} years old.");

        List<Patient> patients = new List<Patient>()
        {
            new Patient { HeightInCm = 157.5, WeightInKg = 59.5 },
            new Patient { HeightInCm = 182.5, WeightInKg = 96.7 },
            new Patient { HeightInCm = 195.5, WeightInKg = 75.1 },
        };

        patients.Print();
        patients.Print(p => $"The BMI of the patient is {p.BMI()}");
    }
}