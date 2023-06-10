using System;

namespace ConsoleApp1
{
    class Program
    {
        class Sensor
        {
            private int value1;

            //Auto Implemented property
            public int Value2 { get; set; } = 2;

            //Constructor
            public Sensor(int arg)
            {
                this.value1 = arg;
            }

            public void PrintValue()
            {
                Console.WriteLine(this.value1);
            }
        }

        static void Main(string[] args)
        {
            Sensor sensor = new Sensor(1);
            sensor.PrintValue();

            sensor.Value2 = 3;
            Console.WriteLine(sensor.Value2);
        }
    }
}
