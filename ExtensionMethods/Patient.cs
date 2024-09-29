using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo;
internal class Patient : IComparable<Patient>/*, IComparable*/
{
    public double HeightInCm { get; set; }
    public double WeightInKg { get; set; }

    public int CompareTo(Patient? other)
    {
        if (other is null)
            throw new ArgumentNullException();

        if (this.BMI() < other.BMI())
            return -1;

        if (this.BMI() > other.BMI())
            return 1;

        return 0;
    }

    //public int CompareTo(object? obj)
    //{
    //    Patient? other = obj as Patient;

    //    if (other is null)
    //        throw new ArgumentNullException();

    //    if (this.BMI() < other.BMI())
    //        return -1;

    //    if (this.BMI() > other.BMI())
    //        return 1;

    //    return 0;
    //}
}