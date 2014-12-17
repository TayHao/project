using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GeneralClasses;

namespace ServerV1
{
    public class DBConnection
    {
        private string ConnectionString;
        private MySqlConnection Connection;

        public DBConnection()
        {
            ConnectionString = "server=localhost;userid=root;password=root;database=project";
        }
        ~DBConnection()
        {
            if (Connection != null)
                Connection.Close();
        }
        private int AddAccount(Account Acc)
        {
            try
            {
                Connection = new MySqlConnection(ConnectionString);
                Connection.Open();
                MySqlCommand CmdRead = new MySqlCommand(
                    "select count(id) from accounts where username = '" + Acc.getLoginData().getLogin() + "'", Connection);
                int Count = Convert.ToInt32(CmdRead.ExecuteScalar().ToString());
                if (Count != 0)
                {
                    throw new FormatException();
                }
                MySqlCommand CmdWrite = new MySqlCommand(
                    "insert into accounts (username, password, user_type, firstname, lastname, phone, adress, email)" +
                    "values(@Name, @Password, @AccType, @Firstname, @Lastname, @Phone, @Address, @Email)", Connection);
                CmdWrite.Parameters.AddWithValue("@Name", Acc.getLoginData().getLogin());
                CmdWrite.Parameters.AddWithValue("@Password", Acc.getLoginData().getPassword());
                CmdWrite.Parameters.AddWithValue("@AccType", Acc.getAccType());
                CmdWrite.Parameters.AddWithValue("@Firstname", Acc.getName());
                CmdWrite.Parameters.AddWithValue("@Lastname", Acc.getSurname());
                CmdWrite.Parameters.AddWithValue("@Phone", Acc.getPhoneNumber());
                CmdWrite.Parameters.AddWithValue("@Address", Acc.getAddress());
                CmdWrite.Parameters.AddWithValue("@Email", Acc.getEmail());
                CmdWrite.ExecuteNonQuery();
                Console.WriteLine("User " + Acc.getLoginData().getLogin() + " added to database");
                MySqlCommand CmdRead1 = new MySqlCommand(
                    "select id from accounts where username = '" + Acc.getLoginData().getLogin() + "'", Connection);
                int id = Convert.ToInt32(CmdRead1.ExecuteScalar().ToString());
                Connection.Close();
                return id;
            }

            catch (Exception ex)
            {
                Connection.Close();
                return 0;
            }
        }
        public int InsertInstructor(InstructorAccount Inst)
        {
            try
            {
                Inst.setAccType(AccountType.INSTRUCTOR);
                int id = AddAccount(Inst);
                if (id == 0)
                {
                    throw new Exception("Username already taken");
                }
                Connection = new MySqlConnection(ConnectionString);
                Connection.Open();
                Inst.setId(id);
                MySqlCommand CmdWrite = new MySqlCommand(
                    "insert into instructors (user_id, position, `academic status`, academic_level, work_place)" +
                    "values (@UserID, @Pos, @AcSt, @AcLv, @Wplace)", Connection);
                CmdWrite.Parameters.AddWithValue("@UserID", id);
                CmdWrite.Parameters.AddWithValue("@Pos", Inst.getPosition());
                CmdWrite.Parameters.AddWithValue("@AcSt", Inst.getAcademicStatus());
                CmdWrite.Parameters.AddWithValue("@AcLv", Inst.getAcademicLevel());
                CmdWrite.Parameters.AddWithValue("@Wplace", Inst.getWorkPlace());
                CmdWrite.ExecuteNonQuery();
                Console.WriteLine("Instructor " + Inst.getName() + " " + Inst.getSurname() + " added to database");
                Connection.Close();
                return id;
            }
            catch (Exception ex)
            {
                Connection.Close();
                Console.WriteLine("Error: ", ex.ToString());
                return 0;
            }
        }
        public bool CheckPass(string Login, string Pass)
        {
            try
            {
                Connection = new MySqlConnection(ConnectionString);
                Connection.Open();
                MySqlCommand CmdRead = new MySqlCommand(       // TODO: case sensitive password
                    "select count(id) from accounts where username = '" + Login + "' and password = '" + Pass + "'", Connection);
                string Count = CmdRead.ExecuteScalar().ToString();
                if (Count == "0")
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.ToString());
                return false;
            }
        }
        public void DisplayDatabase()
        {
            MySqlDataReader Reader = null;
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
            MySqlCommand CmdRead = new MySqlCommand("select * from accounts", Connection);
            Reader = CmdRead.ExecuteReader();
            Console.WriteLine("Database:");
            while (Reader.Read())
            {
                Console.WriteLine("Name: " + Reader.GetString(1) + "    Password: " + Reader.GetString(2) + "   Firstname: " + Reader.GetString(4));
            }
            Reader.Close();
            Connection.Close();
        }
    }
}
