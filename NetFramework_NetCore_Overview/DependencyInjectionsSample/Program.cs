using System;

namespace DependencyInjectionsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new DummyCarService();




            Console.ReadKey();
        }
    }


    #region Bad CodeSample



    //Programmierer A Arbeitzeit für BadCar 8 Tage  

    // + BadCar liegt in einer DLL
    public class BadCar
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public DateTime ConstructionYear { get; set; }
        public bool Klimaanlage { get; set; }



        //Old School Variante

        private int räderAnzahl;

        public int RäderAnzahl
        {
            get
            {
                return this.räderAnzahl;
            }

            set
            {
                if (value < 0)
                    räderAnzahl = 0;

                räderAnzahl = value;
            }
        }
    }

    // Programmierer B Arbeitzeit 3 Tagen
    // Anwendung -> 
    public class BadCarService
    {

        /// <summary>
        /// Auto wird repariert
        /// </summary>
        /// <param name="badCar"></param>
        /// <returns>Reperatur Dauer</returns>
        public int RepairCar(BadCar badCar)
        {
            if (badCar.Brand == "BMW")
                return 4;

            if (badCar.Brand == "Alfa Romeo")
                return 12;

            return 5;
        }
    }



    #endregion


    #region Best Solution

    public interface ICar
    {
        string Brand { get; set; }
        string Type { get; set; }
        DateTime? ConstructionYear { get; set; }
        bool Klimaanlage { get; set; }

        int? AnzahlRäder { get; set; }
    }


    //Programmierer A -> 8 Tage arbeit 
    public class Car : ICar
    {

        public string Brand { get; set; }
        public string Type { get; set; }
        public DateTime ConstructionYear { get; set; }
        public bool Klimaanlage { get; set; }
        public int? AnzahlRäder { get; set; }
        DateTime? ICar.ConstructionYear { get; set; }
    }

    public class DummyCarService : ICarService
    {
        public int RepairCar(ICar car)
        {
            if (string.IsNullOrEmpty(car.Brand))
                throw new ArgumentException();

            if (string.IsNullOrEmpty(car.Type))
                throw new ArgumentException();

            if (car.ConstructionYear.Value.Year == 0)
                throw new ArgumentException();

            

            return 1;
        }
    }
    //-------------------- Grenze des Arbeitsbereiches ----------------------------


    public interface ICarService
    {
        int RepairCar(ICar car);
    }

    //Programmierer B -> 2 Tage
    public class CarService : ICarService
    {
        public int RepairCar(ICar car)
        {
            
            if (car.Brand == "BMW")
            {


                //Verwendung von Nullable Datentypen
                if (!car.AnzahlRäder.HasValue)
                    return 6;
                else
                    Console.WriteLine($"Anzahl der Räder {car.AnzahlRäder.Value}");


                return 4;
            }
                

            if (car.Brand == "Alfa Romeo")
                return 12;

            return 5;
        }


        
    }

    public class DummyCar : ICar
    {
        public string Brand { get; set; } = "BMW"; //Setze Defaultwerte
        public string Type { get; set; } = "Z8";
        public DateTime ConstructionYear { get; set; } = DateTime.Now;
        public bool Klimaanlage { get; set; } = true;
        public int? AnzahlRäder { get; set; } = null;
        DateTime? ICar.ConstructionYear { get; set; }
    }
    #endregion
}
