
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Serilog;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {            
            Calculator calculator = new Calculator();

            decimal zahl1 = 1345.234m;
            decimal zahl2 = 83.87823m;

            decimal summe = calculator.Addition(zahl1, zahl2);
            decimal resultSubtraktion = calculator.Subtraktion(zahl1, zahl2);

            //Console.WriteLine("Additionsergebnis: " + summe.ToString()); //So bitte nicht -> Performanceverlust
            //Console.WriteLine("Formel: {0} + {1} = {2}", zahl1, zahl2, summe); //printf nachbei ala C
            Console.WriteLine($"Formel: {zahl1} + {zahl2} = {summe}"); // ab C# 7.0 Neues Feature

            //string myString = $"Hier baue ein String für mich zusammen {zahl1} weitere Variable {summe}";
            Console.ReadKey();

        }
    }
}
