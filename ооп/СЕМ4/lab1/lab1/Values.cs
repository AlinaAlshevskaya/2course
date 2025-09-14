using System;

namespace lab1
{
    static class Values
    {
        public static string[] types = { "Weight", "Lenght", "Square", "Volume", "Speed", "Time", "Temperature" };
        public static string[][] sizes = new string[7][];
        public static double[][] diff = new double[7][];

        static Values()
        {
            add();
        }

        private static void add()
        {
            sizes[0] = new string[] { "Microgram", "Milligram", "Gram", "Kilogram", "Center", "Tons" };
            sizes[1] = new string[] { "Micrometer", "Millimeter", "Centimeter", "Decimeter", "Meter", "Kilometer", "Foot", "Yard", "Mile", "Inch" };
            sizes[2] = new string[] { "Square millimeter", "Square centimeter", "Square decimeter", "Square meter", "Square Kilometer", "Hectare" };
            sizes[3] = new string[] { "Cubic millimeters", "Cubic centimeters", "Cubic decimeters", "Cubic meters", "Cubic kilometers", "Liters", "Milliliters" };
            sizes[4] = new string[] { "Meter per second", "Kilometer per hour", "Miles per hour", "Foot per second", "Miles per second", "Kilometer per second", "Meter per minute" };
            sizes[5] = new string[] { "Millisecond", "Second", "Minute", "Hour", "Day", "Week", "Month", "Year", "Century" };
            sizes[6] = new string[] { "Degree Celsius", "Degree Fahrenheit", "Kelvin" };

            diff[0] = new double[] { 0.000001, 0.001, 1, 1000, 100000, 1000000 };
            diff[1] = new double[] { 0.000001, 0.001, 0.01, 0.1, 1, 1000, 0.3048, 0.9144, 1609.3, 0.00013, 0254 };
            diff[2] = new double[] { 0.0000001, 0.00001, 0.01, 1, 1000000, 10000 };
            diff[3] = new double[] { 0.000000001, 0.000001, 0.001, 1, 1000000000, 0.001, 0.000001 };
            diff[4] = new double[] { 1, 3.6, 2.237, 3.281, 0.000621, 0.001, 60 };
            diff[5] = new double[] { 1000, 1, 0.01667, 0.0002778, 0.00001157, 0.000001653, 0.0000003803, 0.00000003169, 0.0000000003169 };
            diff[6] = new double[] { 1, 33.8, 274.1 };

        }
        




    }
}
