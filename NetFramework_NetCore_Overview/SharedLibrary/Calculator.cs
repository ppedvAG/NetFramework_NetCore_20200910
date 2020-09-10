using System;

namespace SharedLibrary
{
    /// <summary>
    /// Calculator für Subtraktion und Addition
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Hier werden zwei Zahlen addiert
        /// </summary>
        /// <param name="zahl1">summand1</param>
        /// <param name="zahl2">summand2</param>
        /// <returns>Summe</returns>
        public decimal Addition (decimal zahl1, decimal zahl2)
        {
            return (zahl1 + zahl2);
        }

        /// <summary>
        /// Hier wird subtrahiert
        /// </summary>
        /// <param name="zahl1"></param>
        /// <param name="zahl2"></param>
        /// <returns></returns>
        public decimal Subtraktion(decimal zahl1, decimal zahl2)
        {
            return (zahl1 - zahl2);
        }
    }

}


