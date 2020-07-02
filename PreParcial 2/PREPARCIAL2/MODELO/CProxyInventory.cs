using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;
using Npgsql;
using PREPARCIAL2.MODELO;

namespace PREPARCIAL2
{
    public class CProxy
    {
        public interface IList
        { 
            //Interface IList
            List<Inventory> getList();
        }
        
        public interface ICreateProduct
        { 
            //Interface IProduct
            void CProduct(string name, string description, double price, int stock);
        }
        
        public interface IModifyStock
        {
            //InterfaceModificar
            void MStock(int stock, string name);
        }

        public interface IDeleteProduct
        {
            //InterfaceEliminar
            void DProduct(int id);
        }

        public class ProxyList : IList
        {
            //Variable de referencia privada
            private List lista;

            public List<Inventory> getList()
            {
                if (lista == null)
                    lista = new List();

                return lista.getLista();
            }

            //Clase que protege el Proxy
            //Protege la consulta a la lista
            private class List
            {
                public List<Inventory> getLista()
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
            }
        }

        public class ProxyCProduct : ICreateProduct
            {
                private Product Producto;

                public void CProduct(string name, string description, double price, int stock)
                {
                    if(Producto == null)
                        Producto = new Product();
                    
                    Producto.CreateProduct(name,description,price,stock);
                }
                
                //Clase que protege el Proxy
                //Protege la consulta que crea el producto
                private class Product
                {
                    public void CreateProduct(string name, string description, double price, int stock)
                    {
                        string query = String.Format(
                            "INSERT INTO INVENTORY(product_name,description,price,stock) " + 
                            "VALUES('{0}','{1}','{2}','{3}')", name, description, price, stock
                        );
                        ConectionDB.ExecuteNonQuery(query);    
                    }
                }
            }   
        
        public class ProxyStock : IModifyStock
        {
            private Modify mProduct;

            public void MStock(int stock, string name)
            {
                if(mProduct == null)
                    mProduct = new Modify();
                    
                mProduct.ModifyStock(stock,name);
            }
                
            //Clase que protege el Proxy
            //Protege la consulta que modifica el stock de productos
            private class Modify
            {
                public void ModifyStock(int stock, string name)
                {
                    string query = String.Format(
                        "UPDATE INVENTORY SET stock ={0} WHERE product_name ='{1}'", stock, name
                    );
                    ConectionDB.ExecuteNonQuery(query);
                }
            }
        }   
        
        public class ProxyDelete : IDeleteProduct
        {
            private Delete dProduct;

            public void DProduct(int id)
            {
                if(dProduct == null)
                    dProduct = new Delete();
                
                dProduct.DeleteProduct(id);
                
            }
                
            //Clase que protege el Proxy
            //Protege la consulta que elimina un producto del stock
            private class Delete
            {
                public void DeleteProduct(int id)
                {
                    string query = String.Format(
                        "DELETE FROM INVENTORY WHERE id_product='{0}';", id
                    );
                    
                    ConectionDB.ExecuteNonQuery(query);        
                }
            }
        }
    }
}