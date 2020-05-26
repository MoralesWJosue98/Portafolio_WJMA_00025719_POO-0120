using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PREPARCIAL2.CONTROLADOR;
using PREPARCIAL2.MODELO;

namespace PREPARCIAL2
{
    public class OrderDAO
    {
        public static List<Orders> getLista2()
        {
            string query = "SELECT * FROM ORDERS";

            DataTable dt = ConectionDB.ExecuteQuery(query);
            
            List<Orders> list2 = new List<Orders>();
            foreach (DataRow row in dt.Rows)
            {
                Orders o = new Orders();

                o.id_order = Convert.ToInt32(row[0].ToString());
                o.user_name = row[1].ToString();
                o.product_name = row[2].ToString();
                o.quantity = Convert.ToInt32(row[3].ToString());
                o.id_user = Convert.ToInt32(row[4].ToString());
                
                list2.Add(o);
            }
            return list2;
        }

        public static void Buy(string name, string product, int quantity, int id)
        {
            string query = String.Format(
                "INSERT INTO ORDERS(user_name,product_name,quantity,id_user) " +
                "VALUES('{0}','{1}', '{2}','{3}' )", name, product, quantity,id
                );
            
            ConectionDB.ExecuteNonQuery(query);
        }
        
        
        
        public static List<Orders> getLista(string name)
        {
            string query = String.Format(
                "SELECT * FROM ORDERS WHERE user_name='{0}';", name
            );

            DataTable dt = ConectionDB.ExecuteQuery(query);
            
            List<Orders> list = new List<Orders>();
            foreach (DataRow row in dt.Rows)
            {
                Orders o = new Orders();

                o.id_order = Convert.ToInt32(row[0].ToString());
                o.user_name = row[1].ToString();
                o.product_name = row[2].ToString();
                o.quantity = Convert.ToInt32(row[3].ToString());
                o.id_user = Convert.ToInt32(row[4].ToString());
                
                list.Add(o);
            }
            return list;
        }
        
       
        
        
        
    }
}