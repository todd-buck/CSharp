using System;
using System.Text;
using Microsoft.Data.Sqlite;

namespace BankingApp
{
    class ClientDatabaseConnection
    {

        //private database connection that is created in constructor. set to private to prevent SQL injection attacks
        private static SqliteConnection sqlite_conn;

        //constructor, creates connection to clientDb. If Client Data table does not exist, it creates the Client Data Table.
        public ClientDatabaseConnection()
        {
            //creates connection to 'clientDb.db'. If 'clientDb.db does not exist, it creates it.
            sqlite_conn = CreateConnection();

            //verifies that table exists. If not, creates table and fills with dummy values
            CreateTable();
        }

        //helper function for constructor
        static SqliteConnection CreateConnection()
        {
            // Create a new database connection:
            SqliteConnection sqlite_conn = new("Data Source=clientDb.db");

            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error: Unable to create connection to database.");
            }

            return sqlite_conn;
        }

        //helper function for constructor
        static void CreateTable()
        {

            //creates SQL query for client data table
            SqliteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE ClientData (FirstName NVARCHAR(50), LastName NVARCHAR(50), CardNum NVARCHAR(16), Pin CHAR(4), Balance DECIMAL(10,2))";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;

            // Runs SQL query to create client table
            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error: Trying to create table that already exists.");
                return;
            }

            DummyFill();

        }

        //helper function for constructor
        static void DummyFill()
        {
            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO ClientData VALUES('Todd', 'Buck', '1234567890987654', '1104', '12.25'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO ClientData VALUES('Breelyn', 'Buck', '1111222233334444', '0206', '50.01'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO ClientData VALUES('Braxton', 'Buck', '0001000200030004', '0303', '1.22'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO ClientData VALUES('Gina', 'Buck', '1111111111111111', '0911', '900.51'); ";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO ClientData VALUES('Ben', 'Buck', '9876543212345678', '0821', 100.27); ";
            sqlite_cmd.ExecuteNonQuery();

        }

        public User ValidateUser(User PotentialUser)
        {
            SqliteDataReader sqlite_datareader;
            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT * FROM ClientData WHERE CardNum = '{PotentialUser.CardNum}' AND Pin = '{PotentialUser.Pin}'; ";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            if (sqlite_datareader.HasRows)
            {
                sqlite_datareader.Read();

                PotentialUser.FirstName = sqlite_datareader.GetString(0);
                PotentialUser.LastName = sqlite_datareader.GetString(1);
                PotentialUser.CardNum = sqlite_datareader.GetString(2);
                PotentialUser.Pin = sqlite_datareader.GetString(3);
                PotentialUser.Balance = sqlite_datareader.GetString(4);
                PotentialUser.IsValidUser = true;

            }

            return PotentialUser;
        }

        //TODO
        //public, will be called by UI to update session changes in the client database at the end of a session
        public static void UpdateClientDatabase(User User)
        {
            //write SQL query that will update DB based on matching CardNum

            //set user fields to empty ("") and IsValidUser to false (should be picked up by garbage collector

            //go back to login screen
        }


        //public, will be called by UI to create new user
        public User InsertNewUser(User PotentialNewUser)
        {
            //get a card number for the new user
            User NewUser = GenerateRandomCardNum(PotentialNewUser);

            //set new user's balance to zero
            NewUser.Balance = "0.00";

            //put user in client database
            SqliteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO ClientData VALUES('" + NewUser.FirstName + "', '" + NewUser.LastName + "', '" + NewUser.CardNum + "', '" + NewUser.Pin + "', '" + NewUser.Balance + "'); ";
            sqlite_cmd.ExecuteNonQuery();

            //new user is now a valid user, mark before return so that they can get to the account home successfully
            NewUser.IsValidUser = true;

            Console.WriteLine("FirstName: " + PotentialNewUser.FirstName);
            Console.WriteLine("LastName: " + PotentialNewUser.LastName);
            Console.WriteLine("CardNum: " + PotentialNewUser.CardNum);
            Console.WriteLine("Pin: " + PotentialNewUser.Pin);
            Console.WriteLine("Balance: " + PotentialNewUser.Balance);

            //send the new user back with their updated data, because they're about to get sent to the account homepage
            return NewUser;

        }

        //local function to create unique card number for new users
        static User GenerateRandomCardNum(User PotentialNewUser)
        {
            String PotentialCardNum;
            object? result;

            //generate random card number, and check if it is already in use. If so, repeat
            do
            {
                PotentialCardNum = GenerateRandomNumber();

                SqliteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT COUNT(*) FROM ClientData WHERE CardNum = " + PotentialCardNum + ";";
                result = sqlite_cmd.ExecuteScalar();

            } while (result.ToString() != "0");

            //found a good card number, give it to the new user and return
            PotentialNewUser.CardNum = PotentialCardNum;

            return PotentialNewUser;
        }

        //helper for GenerateRandomCardNum()
        static String GenerateRandomNumber()
        {
            Random RandomNumberGenerator = new Random();
            StringBuilder builder = new StringBuilder();

            while (builder.Length < 16)
            {
                builder.Append(RandomNumberGenerator.Next(0, 10).ToString());
            }

            return builder.ToString();
        }



        //DEV TOOLBOX
        // dev testing, local main to ensure functionality
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Entering");
        //    Console.ReadLine();
        //    sqlite_conn = CreateConnection();
        //    CreateTable();
        //    ReadData();
        //    Console.WriteLine("Exiting");
        //    Console.ReadLine();
        //}

        //dev testing, prints table
        //static void PrintTable()
        //{
        //    SqliteDataReader sqlite_datareader;
        //    SqliteCommand sqlite_cmd;
        //    sqlite_cmd = sqlite_conn.CreateCommand();
        //    sqlite_cmd.CommandText = "SELECT FirstName, LastName, CardNum, Pin, Balance FROM ClientData";

        //    sqlite_datareader = sqlite_cmd.ExecuteReader();
        //    while (sqlite_datareader.Read())
        //    {

        //        for (int ordinal = 0; ordinal < sqlite_datareader.FieldCount; ordinal++)
        //        {
        //            string myreader = sqlite_datareader.GetString(ordinal);
        //            Console.Write(myreader + " ");
        //        }

        //        Console.WriteLine();
        //    }
        //}

        //dev testing, displays client data for user validation
        //public void testQuery(User PotentialUser)
        //{
        //    SqliteDataReader sqlite_datareader;
        //    SqliteCommand sqlite_cmd;
        //    sqlite_cmd = sqlite_conn.CreateCommand();
        //    sqlite_cmd.CommandText = $"SELECT * FROM ClientData WHERE CardNum = {PotentialUser.CardNum} AND Pin = {PotentialUser.Pin}";

        //    Console.WriteLine("Test: (" + sqlite_cmd.CommandText + ")");

        //    sqlite_datareader = sqlite_cmd.ExecuteReader();

        //    sqlite_datareader.Read();

        //    Console.WriteLine("FirstName: " + sqlite_datareader.GetString(0));
        //    Console.WriteLine("LastName: " + sqlite_datareader.GetString(1));
        //    Console.WriteLine("CardNum: " + sqlite_datareader.GetString(2));
        //    Console.WriteLine("Pin: " + sqlite_datareader.GetString(3));
        //    Console.WriteLine("Balance: " + sqlite_datareader.GetString(4));
        //}
    }
}

