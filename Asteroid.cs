using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace AsteroidAPI
{
    public class Asteroid
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float FurthestPoint { get; set; }
        public float NearestPoint { get; set; }
        public string ClosestDate { get; set; }
        public float Speed { get; set; }
        public float ClosestApproachEarth{get; set;}
        public string DateOfPosition { get; set; }
        public bool Hazard { get; set; }
        public Asteroid()
        {

        }

        public Asteroid(int ID)
        {

        }

        public static Asteroid[] GetAsteroidsHazard()
        {

            using (SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                string query = "SELECT * FROM Asteroids WHERE pha = 1";
                SqlCommand CMD = new SqlCommand(query, connect);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Asteroid[] AsteroidsList = new Asteroid[table.Rows.Count];
                foreach (DataRow row in table.Rows)
                {
                    Asteroid ast = new Asteroid();
                    ast.ID = int.Parse(row["ID"].ToString());
                    ast.Name = row["Name"].ToString();                    
                    ast.FurthestPoint = int.Parse(row["aphelion_distance"].ToString());
                    ast.NearestPoint = int.Parse(row["perihelion_distance"].ToString());
                    ast.Speed = int.Parse(row["semimajor_axis"].ToString());
                    ast.ClosestDate = row["perihelion_date"].ToString();
                    ast.ClosestApproachEarth = float.Parse(row["earth_moid"].ToString());
                    ast.Hazard = Convert.ToBoolean(row["pha"]);

                    AsteroidsList[table.Rows.IndexOf(row)] = ast;
                }
                return AsteroidsList;
            }

        }


        public static Asteroid[] GetAsteroids()
        {
           
            using (SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                string query = "SELECT * FROM Asteroids";
                SqlCommand CMD = new SqlCommand(query, connect);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Asteroid[] AsteroidsList = new Asteroid[table.Rows.Count];
               foreach(DataRow row in table.Rows)
               {
                    Asteroid ast = new Asteroid();
                    ast.ID = int.Parse(row["ID"].ToString());
                    ast.Name = row["Name"].ToString();                    
                    ast.FurthestPoint = float.Parse(row["aphelion_distance"].ToString());
                    ast.NearestPoint = float.Parse(row["perihelion_distance"].ToString());
                    ast.Speed = float.Parse(row["semimajor_axis"].ToString());
                    ast.ClosestDate = row["perihelion_date"].ToString();                    
                    ast.Hazard = Convert.ToBoolean(row["pha"]);

                    AsteroidsList[table.Rows.IndexOf(row)] = ast;
               }
               return AsteroidsList;                
            }            
        }


    }
}