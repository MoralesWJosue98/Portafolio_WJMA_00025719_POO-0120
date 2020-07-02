using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PREPARCIAL2.CONTROLADOR;

namespace PREPARCIAL2.MODELO
{
    public static class UserDAO
    {
        public static List<User> getLista()
        {
            string query = "SELECT * FROM USERS";

            DataTable dt = ConectionDB.ExecuteQuery(query);
            
            List<User> list = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                User u = new User();
                u.id_user = Convert.ToInt32(row[0].ToString());
                u.user_name = row[1].ToString();
                u.user_admin = Convert.ToBoolean(row[2].ToString());
                u.user_password = row[3].ToString();

                list.Add(u);
            }
            return list;
        }

        public static void CreateUser(string user)
        {
            string query = String.Format(
                "INSERT INTO USERS(user_name,user_admin,user_password) " +
                "VALUES('{0}',false,'{1}');", user, Encriptador.CrearMD5(user));

            ConectionDB.ExecuteNonQuery(query);
        }


        public static void RefresPermission(string user, bool admin)
        {
            string query = String.Format(
                "UPDATE USERS SET user_admin={0} WHERE user_name='{1}';", admin ? "true" : "false", user);
            
            ConectionDB.ExecuteNonQuery(query);
        }

        public static void newPassword(string user, string newPass)
        {
            string query = String.Format(
                    "UPDATE USERS SET user_password='{0}' WHERE user_name='{1}';", newPass, user
                );
                
            ConectionDB.ExecuteNonQuery(query);    
                
        }

        public static void Delete(string user)
        {
            string query = String.Format(
                    "DELETE FROM USERS WHERE user_name='{0}';", user
                    );
                    
            ConectionDB.ExecuteNonQuery(query);        
        }
        
        
        



    }
    
}