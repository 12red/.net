using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1
{
    public class datas
    {

        public void Insert(Register register)
        {
            try
            {
                string con = "datasource=localhost;port=3306;username=root;password=1234qwer";
                string query = $"insert into login.registeration(username,email,password,repassword)values('{register.username}','{register.email}','{register.password}','{register.repassword}');";
                MySqlConnection myconn = new MySqlConnection(con);
                MySqlCommand mycomm = new MySqlCommand(query, myconn);
                MySqlDataReader reader;
                myconn.Open();
                reader = mycomm.ExecuteReader();

                while (reader.Read())
                {


                }
                myconn.Close();


            }
            catch (Exception exo)
            {
                Console.Write("no connection with database");
            }




        }
        public int userlogin(Logins logins)
        {
            string input1 = logins.username;
            string input2 = logins.password;
            string con = "datasource=localhost;port=3306;username=root;password=1234qwer";
            string query = $"select id from login.registeration where username= @username and password= @password;";
            MySqlConnection myconn = new MySqlConnection(con);
            MySqlCommand mycomm = new MySqlCommand(query, myconn);



            mycomm.Parameters.Add(new MySqlParameter("@username", logins.username));

            mycomm.Parameters.Add(new MySqlParameter("@password", logins.password));
            myconn.Open();
            return Convert.ToInt32(mycomm.ExecuteScalar());

        }

        public void story(Venting vent)
        {

            try
            {
                string con = "datasource=localhost;port=3306;username=root;password=1234qwer";
                string query = $"insert into login.secrets(title,secret)values('{vent.title}','{vent.secret}');";
                MySqlConnection myconn = new MySqlConnection(con);
                MySqlCommand mycomm = new MySqlCommand(query, myconn);
                MySqlDataReader reader;
                myconn.Open();
                reader = mycomm.ExecuteReader();

                while (reader.Read())
                {


                }
                myconn.Close();


            }
            catch (Exception exo)
            {
                Console.Write("no connection with database");
            }
        }

        public IEnumerable<Venting> list()
        {
            List<Venting> lst = new List<Venting>();
            string con = "datasource=localhost;port=3306;username=root;password=1234qwer";
            string query = $"select * from login.secrets order by id";
            using (MySqlConnection myconn = new MySqlConnection(con))
            {

                MySqlCommand mycomm = new MySqlCommand(query, myconn);


                myconn.Open();
                MySqlDataReader reader = mycomm.ExecuteReader();
                while (reader.Read())
                {
                    Venting div = new Venting();
                    div.id = Convert.ToInt32(reader["id"]);

                    div.title = reader["title"].ToString();
                    div.secret = reader["secret"].ToString();
                    lst.Add(div);

                }
                myconn.Close();

            }
            return lst;




        }
        public Venting GetDiary(int? id)
        {
            Venting div = new Venting();
            string con = "datasource=localhost;port=3306;username=root;password=1234qwer";
            using (MySqlConnection myconn = new MySqlConnection(con))
            {
                string query = $"select * from login.secrets where id =" + id;


                MySqlCommand mycomm = new MySqlCommand(query, myconn);
                myconn.Open();
                MySqlDataReader reader = mycomm.ExecuteReader();
                while (reader.Read())
                {

                    div.id = Convert.ToInt32(reader["id"]);

                    div.title = reader["title"].ToString();
                    div.secret = reader["secret"].ToString();
                }

            }
            return div;

        }
        public void updateDiary(Venting venting)
        {
             string con = "datasource=localhost;port=3306;username=root;password=1234qwer";
            using (MySqlConnection myconn = new MySqlConnection(con))
            {
                string query = $"update login.secrets set secret=@secret where id = @id";




                MySqlCommand mycomm = new MySqlCommand(query, myconn);
                mycomm.Parameters.AddWithValue("@id", venting.id);

           

                mycomm.Parameters.AddWithValue("@secret",venting.secret);

                myconn.Open();
                mycomm.ExecuteNonQuery();
                myconn.Close();
            } 
                

        }
        public void DeleteDiary(int? id)
        {

            string con = "datasource=localhost;port=3306;username=root;password=1234qwer";
            using (MySqlConnection myconn = new MySqlConnection(con))
            {
                string query = $"delete from login.secrets where id=@id";
                MySqlCommand mycomm = new MySqlCommand(query, myconn);
                mycomm.Parameters.AddWithValue("@id", id);
                myconn.Open();
                mycomm.ExecuteNonQuery();
                myconn.Close();


            }
        }

        }
}





