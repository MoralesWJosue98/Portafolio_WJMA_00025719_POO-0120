namespace PREPARCIAL2
{
    public class Inventory
    {
    
        public string product_name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
        
        public Inventory(){}

        public Inventory( string pProductName, string dDescription, double pPrice, int sStock)
        {
          
            product_name = pProductName;
            description = dDescription;
            price = pPrice;
            stock = sStock;
        }
    }
    
    
    
    
}