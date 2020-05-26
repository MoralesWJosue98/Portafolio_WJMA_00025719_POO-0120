namespace PREPARCIAL2
{
    public class Orders
    {
        public int id_order { get; set;}
        
        public int id_user { get; set;  }
        public string user_name { get; set; }
        public string product_name { get; set; }
      
        public int quantity { get; set; }
        
        public Orders(){}

        public Orders(int iIdOrder, int iIdUser, string uUserName, string pProductName, int qQuantity)
        {
            id_order = iIdOrder;
            id_user = iIdUser;
            user_name = uUserName;
            product_name = pProductName;
            quantity = qQuantity;
        }
       
    }
}