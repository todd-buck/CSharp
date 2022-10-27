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

            //TODO
            //pass to insert, then send to account home page upon successful return (IsValidUser == true)
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

            //TODO
            //pass to validate (in Database.cs)
            //check if user is valid. if so, send to account home page. if else, send back to login page/run prompt again

        }


    }
}

