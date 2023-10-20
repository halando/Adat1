using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Adatbazis1
{
    internal class Program
    {
        static SqlConnection k;
        static void Main(string[] args)
        {
            /*SqlConnection kapcsolat = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tanar\source\repos\Adatbazis1\Adatbazis1\Database1.mdf;Integrated Security=True");
            kapcsolat.Open();
            int vsz = (new Random()).Next(100, 1000);
            string nev = "Gipsz Jakab";
            DateTime datum = DateTime.Today;
            string d = "";
            d += datum.Year;
            d += "-";
            d += datum.Month;
            d += "-";
            d += datum.Day;
            //SqlCommand parancs = new SqlCommand($"INSERT INTO Alapadatok VALUES({vsz},'{nev}','{d}');", kapcsolat);
            SqlCommand parancs = new SqlCommand("INSERT INTO Alapadatok VALUES(@vsz,@nev,@datum);", kapcsolat);
            parancs.Parameters.AddWithValue("@vsz", vsz);
            parancs.Parameters.AddWithValue("@nev", nev);
            parancs.Parameters.AddWithValue("@datum", datum);
            parancs.ExecuteNonQuery();
            kapcsolat.Close();*/
            //(new Program()).FileFeldolgozas("zenek.txt");
            k= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tanar\source\repos\Adatbazis1\Adatbazis1\Database1.mdf;Integrated Security=True");
            k.Open();
            Tablak();
            RadioAdok();
            FileFeldolgozas("zenek.txt");
        }
        static void FileFeldolgozas(string filename)
        {
            StreamReader sr = new StreamReader(filename);
        }
        static void RadioAdok()
        {
            string utasitas = "CREATE TABLE radiok(kod INT PRIMARY KEY,nev NVARCHAR(20));";
            SqlCommand p = new SqlCommand(utasitas, k);
            try
            {
                p.ExecuteNonQuery();
                utasitas = "INSERT INTO radiok VALUES(1,'Retro Rádió');";
                p = new SqlCommand(utasitas, k);
                p.ExecuteNonQuery();
                utasitas = "INSERT INTO radiok VALUES(2,'RÁDIÓ 1');";
                p = new SqlCommand(utasitas, k);
                p.ExecuteNonQuery();
                utasitas = "INSERT INTO radiok VALUES(3,'Rock FM');";
                p = new SqlCommand(utasitas, k);
                p.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
        static void Tablak()
        {
            //string u = "SHOW TABLES;"; //MySQL
            string u = "SELECT * FROM SYSOBJECTS WHERE xtype='U';";
            SqlCommand p = new SqlCommand(u, k);
            SqlDataReader r = p.ExecuteReader();
            while (r.Read())
            {
                //Console.WriteLine(r[0].ToString());
                for(int i=0;i<r.FieldCount;i++)
                {
                    Console.WriteLine(r["name"]);
                }
            }
            Console.ReadLine();
        }
    }
}
