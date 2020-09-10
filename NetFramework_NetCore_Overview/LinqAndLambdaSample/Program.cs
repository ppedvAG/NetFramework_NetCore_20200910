using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqAndLambdaSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> personenListe = new List<Person>()
            {
                new Person {Id=1, Age=50, Firstname = "Dagobert", Lastname="Duck"},
                new Person {Id=2, Age=36, Firstname = "Donald", Lastname="Duck"},
                new Person {Id=3, Age=34, Firstname = "Daisy", Lastname="Duck"},
                new Person {Id=4, Age=10, Firstname = "Trick", Lastname="Duck"},
                new Person {Id=5, Age=10, Firstname = "Tick", Lastname="Duck"},
                new Person {Id=6, Age=10, Firstname = "Truck", Lastname="Duck"},
            };

            personenListe.Add(new Person { Id = 10, Age = 33, Firstname = "Petra", Lastname = "Musterfrau" });



            //Was ist Linq

            IList<Person> ergebnisList1 = (from p in personenListe
                                          where p.Age > 30
                                          orderby p.Firstname
                                          select p).ToList();

            // Gebe mir alle Personen aus, die über 30 Jahre alt sind + Sortiert nach dem Vornamen
            foreach (Person person in ergebnisList1)
            {
                Console.WriteLine($"{person.Id} {person.Firstname} {person.Lastname} {person.Age}");
            }

            Console.WriteLine("########## Lambda Sample ###########");
            // Was ist Linq + Lambda

            IList<Person> ergebnisListe2 = personenListe
                .Where(n => n.Age > 30)
                .OrderBy(n => n.Firstname)
                .ToList();
            
            // Gebe mir alle Personen aus, die über 30 Jahre alt sind + Sortiert nach dem Vornamen
            foreach (Person person in ergebnisListe2)
            {
                Console.WriteLine($"{person.Id} {person.Firstname} {person.Lastname} {person.Age}");
            }

            Console.ReadKey();

        }
    }
}
