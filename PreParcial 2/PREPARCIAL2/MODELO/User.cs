namespace PREPARCIAL2.MODELO
{
    public class User
    {
        public int id_user { get; set;}
        public string user_name { get; set;}
        public string user_password { get; set; }
        public bool user_admin { get; set; }

        public User()
        {
        
        }

        public User(int iIdUser, string uUserName, string uUserPassword, bool uUserAdmin)
        {
            id_user = iIdUser;
            user_name = uUserName;
            user_password = uUserPassword;
            user_admin = uUserAdmin;
        }
        
        
    }
}