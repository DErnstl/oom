using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface IAge
    {
        void ChangeAge(int nAge);
        void PrintAge();
    }
    //Secure class, controll if the name fields are empty
    class FName
    {
        //Private Fields
        private string FirstName;
        private string SecondName;

        public string PFirstName
        {
            set
            {
                if (value == null || value == "") throw new Exception("FirstName is Empty!");
                else FirstName = value;
            }
            get
            {
                return FirstName;
            }
        }

        public string PSecondName
        {
            set
            {
                if (value == null || value == "") throw new Exception("SecondName is Empty!");
                else SecondName = value;
            }
            get
            {
                return SecondName;
            }
        }
    }

    class TransferMarket : IAge
    {
        public int Age;
        public string Club;
        public decimal MarketValue;

        public FName Name = new FName();

        //Init
        public TransferMarket(string nFirstName, string nSecondName, int nAge, string nClub, decimal nMarketValue)
        {
            Age = nAge;
            Club = nClub;
            MarketValue = nMarketValue;
            Name.PFirstName = nFirstName;
            Name.PSecondName = nSecondName;
        }

        //Interface Methods
        //Change the Age
        public void ChangeAge(int nAge)
        {
            Age = nAge;
        }

        public void PrintAge()
        {
            Console.WriteLine($"Spieler {Name.PSecondName} ist {Age} Jahre alt");
        }
    }

    class Student : IAge
    {
        public FName Name = new FName();
        public int Age;

        //Init
        public Student(string nFirstName, string nSecondName, int nAge)
        {
            Age = nAge;
            Name.PFirstName = nFirstName;
            Name.PSecondName = nSecondName;
        }

        public void ChangeAge(int nAge)
        {
            Age = nAge;
        }

        public void PrintAge()
        {
            Console.WriteLine($"Der Schüler {Name.PSecondName} ist {Age} Jahre alt");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int tAge;
                //Init 3 Football Players
                TransferMarket Schnorcher = new TransferMarket("Sepp", "Schnorcher", 34, "FC Haudanebm", 1000);
                TransferMarket Nixnutz = new TransferMarket("Hans", "Nixnutz", 28, "FC Haudanebm", 30);
                TransferMarket Schwein = new TransferMarket("Krankes", "Schwein", 12, "SC Stall", 909921);

                //Init 1 Football Player and 1 Student with the Interface IAge
                IAge Seppl = new TransferMarket("Seppl", "Dergroße", 50, "FC Haudanebm", 0815);
                IAge DerNeueSchueler = new Student("Muster", "Schueler", 11);

                //Array of Interface IAge
                var ArrIAge = new IAge[]{
                     new TransferMarket("Sepp", "Schnorcher", 34, "FC Haudanebm", 1000),
                     new TransferMarket("Zweiter", "Irgendwas", 24, "CF LangAtem", 4),
                     new Student("Dritter", "Streber", 6),
                     new Student("Vierter", "StreberVier", 7),
                     new Student("Fuenfter", "Fauler", 89)
                };

                //Write in the console 
                Console.WriteLine($"Bester Spieler des Saison wurde Hr. {Schwein.Name.PSecondName}");

                //Change the age of a player
                Console.WriteLine("Aendern des Alters von {0} von {1} auf:", Schnorcher.Name.PSecondName, Schnorcher.Age);
                tAge = Convert.ToInt32(Console.ReadLine());

                Seppl.ChangeAge(tAge);
                Seppl.PrintAge();

                //Print the age of the Student
                DerNeueSchueler.PrintAge();

                Console.WriteLine("----------------------");

                //Printing Loop for the Interface
                foreach (var i in ArrIAge)
                {
                    i.PrintAge();
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
