using System;
namespace BankingApp
{
    public class User
    {

        internal bool IsValidUser = false;
        internal String FirstName = "";
        internal String LastName = "";
        internal String CardNum = "";
        internal String Pin = "";
        internal String Balance = "";

        //public, used when passing User Session data to Account Home
        public User(String NewFirstName, String NewLastName, String NewCardNum, String NewPin, String NewBalance, int? NewIsValidUser)
        {
            this.FirstName = NewFirstName;
            this.LastName = NewLastName;
            this.CardNum = NewCardNum;
            this.Pin = NewPin;
            this.Balance = NewBalance;
            if(NewIsValidUser == 1) this.IsValidUser = true;

        }

        //public, used by UI when creating a new client
        public User(String NewFirstName, String NewLastName, String NewPin)
        {
            //only changed by validate (located in Database.cs)
            this.IsValidUser = false;
            this.CardNum = "";
            this.Balance = "";

            //passed to constructor
            this.FirstName = NewFirstName;
            this.LastName = NewLastName;
            this.Pin = NewPin;
        }

        //public, used by UI when handling account login
        public User(String PotentialCardNum, String PotentialPin)
        {
            //only changed by validate (located in Database.cs)
            this.IsValidUser = false;
            this.FirstName = "";
            this.LastName = "";
            this.Balance = "";

            //passed to constructor
            this.CardNum = PotentialCardNum;
            this.Pin = PotentialPin;

        }
    }
}

