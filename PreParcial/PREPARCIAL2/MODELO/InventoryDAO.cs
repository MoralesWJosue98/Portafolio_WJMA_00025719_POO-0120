using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PREPARCIAL2.CONTROLADOR;
using PREPARCIAL2.MODELO;


namespace PREPARCIAL2
{
    public static class InventoryDAO
    {
        public static List<Inventory> getLista()
        {
            string query = "SELECT * FROM INVENTORY";

            DataTable dt = ConectionDB.ExecuteQuery(query);

            List<Inventory> list = new List<Inventory>();
            foreach (DataRow row in dt.Rows)
            {
                Inventory i = new Inventory();
                i.id_product = Convert.ToInt32(row[0].ToString());
                i.product_name = row[1].ToString();
                i.description = row[2].ToString();
                i.price = Convert.ToDouble(row[3].ToString());
                i.stock = Convert.ToInt32(row[4].ToString());

                list.Add(i);
            }

            return list;
        }
       

        public static void CreateProduct(string name, string description, double price, int stock)
        {
            string query = String.Format(
                "INSERT INTO INVENTORY(product_name,description,price,stock) " + 
                "VALUES('{0}','{1}','{2}','{3}')", name, description, price, stock
                );
            
            ConectionDB.ExecuteNonQuery(query);    
        }

        public static void ModifyStock(int stock, string name)
        {
            string query = String.Format(
                "UPDATE INVENTORY SET stock ={0} WHERE product_name ='{1}'", stock, name
                );
            ConectionDB.ExecuteNonQuery(query);
        }
        
        public static void Delete(int id)
        {
            string query = String.Format(
                "DELETE FROM INVENTORY WHERE id_product='{0}';", id
            );
                    
            ConectionDB.ExecuteNonQuery(query);        
        }

       
      
        
        
        

    }
}