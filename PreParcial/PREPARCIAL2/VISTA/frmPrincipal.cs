using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PREPARCIAL2.MODELO;
using PREPARCIAL2.CONTROLADOR;
using System.Windows.Forms.VisualStyles;
using LiveCharts;
using LiveCharts.Wpf;
using CartesianChart = LiveCharts.WinForms.CartesianChart;




namespace PREPARCIAL2
{
    public partial class frmPrincipal : Form
    {
        private User user;  
        private CartesianChart graficoProductos;
        public frmPrincipal(User pUser)
        {
            InitializeComponent();
            user = pUser;
            graficoProductos = new CartesianChart();
            this.Controls.Add(graficoProductos);
            graficoProductos.Parent = tabControl1.TabPages[4];
        }
        
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Bienvenido " + user.user_name + "ID: " + user.id_user + " [" + (user.user_admin ? "Administrador" : "Usuario") +
                              "]";
            
            
            
            
            

            if (user.user_admin)
            {
                tabControl1.TabPages[5].Parent = null;
                tabControl1.TabPages[5].Parent = null;
                configurarGrafico();
                RefreshControl();
                RefreshControl2();
                poblarGrafico();
               
            }
            else
            { 
            
               tabControl1.TabPages[1].Parent = null;
               tabControl1.TabPages[1].Parent = null;
               tabControl1.TabPages[1].Parent = null;
               tabControl1.TabPages[1].Parent = null;
               
               RefreshControl2();
               
            
               

            }
        }
        
        
        
        private void RefreshControl()
        {
            List<User> list = UserDAO.getLista();

            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = list;
            cmbEmployee.DataSource = null;
            cmbEmployee.ValueMember = "user_password";
            cmbEmployee.DisplayMember = "user_name";
            cmbEmployee.DataSource = list;

            cmbDelete.DataSource = null;
            cmbDelete.ValueMember = "user_password";
            cmbDelete.DisplayMember = "user_name";
            cmbDelete.DataSource = list;
            
            
        }
        
        

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro que deseas salir, " + user.user_name + "?", "DISTRIBUIDORA 'LA SULTANA'",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    e.Cancel = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha sucedido un error, intente dentro de un minuto!", "DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }  
        }


        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btnCreateUser_Click(object sender, EventArgs e)
        {  
            
            try
            {
                if (txtEmployee.Text.Length >= 5)
                {
                    UserDAO.CreateUser(txtEmployee.Text);

                    MessageBox.Show("USUARIO CREADO EXITOSAMENTE!" +
                                    "Values: Password igual nombre, no admin", "DISTRIBUIDORA 'LA SULTANA'",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtEmployee.Clear();
                    RefreshControl();
                }
                else
                    MessageBox.Show("ERROR!, ingrese un usuario con más de cinco caracteres.",
                        "DISTRIBUIDORA 'LA SULTANA'", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
           catch(Exception)
            {
                MessageBox.Show("El usuario digitado no se encuentra disponible!", "DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUserRefresh_Click(object sender, EventArgs e)
        {
            RefreshControl();
        }


        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            User u = (User) cmbEmployee.SelectedItem;

            if (u.user_admin)
                radAdmin.Checked = true;
            else
                radUsuario.Checked = true;

        }
        
        private void saveChanges_Click(object sender, EventArgs e)
        {
            UserDAO.RefresPermission(cmbEmployee.Text, radAdmin.Checked);
            
            MessageBox.Show("Usuario actualizado!","DISTRIBUIDORA 'LA SULTANA'", MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
            
            RefreshControl();    
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            bool Actual = Encriptador.CompararMD5(txtPassword.Text, cmbEmployee.SelectedValue.ToString());
            bool New = txtNewPass.Text.Equals(txtConfirm.Text);
            bool Valid = txtNewPass.Text.Length > 0;

            if (Actual && New && Valid)
            {
                try
                {
                    UserDAO.newPassword(cmbEmployee.Text, Encriptador.CrearMD5(txtNewPass.Text));

                    MessageBox.Show("Se cambio la password exitosamente!", "DISTRIBUIDORA 'LA SULTANA'",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtPassword.Clear();
                    txtConfirm.Clear();
                    txtNewPass.Clear();

                }
                catch (Exception)
                {
                    MessageBox.Show("Password no actualizada!, intentelo más tarde", "DISTRIBUIDORA 'LA SULTANA'",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Verifique que los datos sean correctos!", "DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Estas seguro de querer eliminar al usuario " + cmbDelete.Text + " ?",
                            "DISTRIBUIDORA 'LA SULTANA'", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            UserDAO.Delete(cmbDelete.Text); 
                            MessageBox.Show("Usuario eliminado correctamente!","DISTRIBUIDORA 'LA SULTANA'",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    
                             RefreshControl();    
                             
                        }
        }
        
        private void RefreshControl2()
        {
            List<Inventory> list = InventoryDAO.getLista();
            
          
     

            dgvInventory.DataSource = null;
            dgvInventory.DataSource = list;
            
            cmbProduct.DataSource = null;
            cmbProduct.ValueMember = "price";
            cmbProduct.DisplayMember = "product_name";
            cmbProduct.DataSource = list;

            dgvStock.DataSource = null;
            dgvStock.DataSource = list;
            
            cmbDeleteProducts.DataSource = null;
            cmbDeleteProducts.ValueMember = "price";
            cmbDeleteProducts.DisplayMember = "product_name";
            cmbDeleteProducts.DataSource = list;

            cmbBuyProduct.DataSource = null;
            cmbBuyProduct.ValueMember = "price";
            cmbBuyProduct.DisplayMember = "product_name";
            cmbBuyProduct.DataSource = list;
            

        } 
        
        
       

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProduct.Text.Length >= 5 && txtDescription.Text.Length >= 10 && Convert.ToDouble(txtPrice.Text) > 0 && 
                    Convert.ToInt32(txtStock.Text) > 0 && Convert.ToInt32(txtStock.Text) < 500
                    )
                {
                    InventoryDAO.CreateProduct(txtProduct.Text, txtDescription.Text, Convert.ToDouble(txtPrice.Text),Convert.ToInt32(txtStock.Text));
                    
                    MessageBox.Show("Se agrego el producto correctamente!","DISTRIBUIDORA 'LA SULTANA'",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    txtProduct.Clear();
                    txtDescription.Clear();
                    txtPrice.Clear();
                    txtStock.Clear();
                    RefreshControl2();

                }
                else
                {
                    MessageBox.Show("Se han ingresado mal los datos, intentelo otra vez!",
                        "DISTRIBUIDORA 'LA SULTANA'", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puedo agregar el producto, intentelo más tarde!", "DISTRIBUIDORA 'LA SULTANA'",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRefreshI_Click(object sender, EventArgs e)
        {
            RefreshControl2();
        }


        private void btnApplyStock_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNewStock.Text) > 0 && Convert.ToInt32(txtNewStock.Text) < 600)
            {
                InventoryDAO.ModifyStock(Convert.ToInt32(txtNewStock.Text), cmbProduct.Text);

                MessageBox.Show("Se cambio el stock con exito!", "DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNewStock.Clear();
                RefreshControl2();
            }
            else
                MessageBox.Show("Error al cambiar el stock, intentelo más tarde!, No pueden haber más de 600 productos en stock!", "DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de querer eliminar el producto " + cmbDeleteProducts.Text + " ?",
                "DISTRIBUIDORA 'LA SULTANA'", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InventoryDAO.Delete(cmbDeleteProducts.Text);
                                
                MessageBox.Show("Producto eliminado correctamente!","DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    
                RefreshControl2();    
                             
            }
        }


        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (MessageBox.Show("Estas seguro de querer realizar esta compra?", "DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OrderDAO.Buy(user.user_name, cmbBuyProduct.Text, Convert.ToInt32(nudQuantity.Value),user.id_user);

                    MessageBox.Show("Se compro el producto con exito!" + "\n" + "Usuario: " + user.user_name + "\n" +
                                    "Producto: " + cmbBuyProduct.Text + "\n" + "Cantidad: " + Convert.ToInt32(nudQuantity.Value),
                        "DISTRIBUIDORA 'LA SULTANA'", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshControl2();
                }
                else
                {
                    MessageBox.Show("Compra no realizada!, error, intentelo más tarde", "DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puedo comprar el producto!, intentelo más tarde", "DISTRIBUIDORA 'LA SULTANA'",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        private void RefreshControl3()
        {
           
            List<Orders> list = OrderDAO.getLista(user.user_name);
            label15.Text = "HISTORIAL DEL USUARIO " + user.user_name + ".";
            
            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = list;
            

        }

        private void RefreshControl4()
        {
            List<Orders> list2 = OrderDAO.getLista2();
            label16.Text = "HISTORIAL DE COMPRAS";

            dgvHistoryAdmin.DataSource = null;
            dgvHistoryAdmin.DataSource = list2;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RefreshControl3();
         
        }


        
        
        private void configurarGrafico()
        {
            graficoProductos.Top = 5;
            graficoProductos.Left = 5;
            graficoProductos.Width = graficoProductos.Parent.Width ;
            graficoProductos.Height = graficoProductos.Parent.Height;

            graficoProductos.Series = new SeriesCollection
            {
                new ColumnSeries{Title = "Stock de productos en existencia", Values = new ChartValues<int>(), DataLabels = true}
            };
            graficoProductos.AxisX.Add(new Axis{Labels = new List<string>()});
            graficoProductos.AxisX[0].Separator = new Separator() {Step = 1, IsEnabled = false};
            graficoProductos.LegendLocation = LegendLocation.Top;
        }
        
        private void poblarGrafico()
        {
            
            graficoProductos.Series[0].Values.Clear();
            graficoProductos.AxisX[0].Labels.Clear();
            
            foreach (Inventory i in InventoryDAO.getLista())
            {
                graficoProductos.Series[0].Values.Add(i.stock);
                graficoProductos.AxisX[0].Labels.Add(i.product_name);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            RefreshControl4();
        }
    }
}