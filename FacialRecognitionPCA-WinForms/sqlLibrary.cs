using MySql.Data.MySqlClient;
using System;

namespace FacialRecognitionPCA_WinForms
{
    public class sqlLibrary
    {
        private MySqlConnection connection;
        private String server = "localhost";
        private String database = "dbattendance";
        private String uid = "root";
        private String password = "";
        private String connectionString;

        public void initializeDatabase()
        {
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        public String testConnection()
        {
            String rMessage = null;
            try
            {
                connection.Open();
                connection.Close();
                rMessage = "Database Connection Success!";
            }
            catch (Exception)
            {
                rMessage = "Database Connection Failed!";
            }

            return rMessage;
        }

        public bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void insertNewEmployee(String employeeID, String employeeName, String employeeDOB, String employeeGender, String employeeImageLocation, String employeePhone, String employeePriority)
        {
            String query = "INSERT INTO tb_employee (employee_id, employee_name, employee_dob, employee_gender, employee_image_location, employee_phone, employee_priority) VALUES('" +
                employeeID + "','" + employeeName + "','" + employeeDOB + "','" + employeeGender + "','" + employeeImageLocation + "','" + employeePhone + "','" + employeePriority + 
                "')";

            if (this.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.ExecuteNonQuery();
                this.closeConnection();
            }
        }

        public String getEmployeePriority(String employeeID)
        {
            String query = "SELECT employee_priority FROM tb_employee WHERE employee_id='" + employeeID + "'";
            String _sPriority = null;

            if (this.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    _sPriority = dataReader["employee_priority"] + "";
                }

                dataReader.Close();
                this.closeConnection();

                return _sPriority;
            }
            else
            {
                return _sPriority;
            }
        }
    }
}
