using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
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

    class TransferMarket
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

        //  Method
        //Change the Age
        public void ChangedAge(int nAge)
        {
            Age = nAge;
            Console.WriteLine("Neues Alter: " + Age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try {
                int tAge;
                //Init 3 Football Players
                TransferMarket Schnorcher = new TransferMarket("Sepp", "Schnorcher", 34, "FC Haudanebm", 1000);
                TransferMarket Nixnutz = new TransferMarket("Hans", "Nixnutz", 28, "FC Haudanebm", 30);
                TransferMarket Schwein = new TransferMarket("Krankes", "Schwein", 12, "SC Stall", 909921);

                //Write in the console 
                Console.WriteLine($"Bester Spieler des Saison wurde Hr. {Schwein.Name.PSecondName}");

                //Change the age of a player
                Console.WriteLine("Aendern des Alters von {0} von {1} auf:", Schnorcher.Name.PSecondName, Schnorcher.Age);
                tAge = Convert.ToInt32(Console.ReadLine());
                Schnorcher.ChangedAge(tAge);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }           
        }
    }
}
