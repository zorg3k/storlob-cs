using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace storlob
{
    public partial class Form2 : Form
    {
        public string nom, publie;
        public int id, currRow;
        public DataGridView dsource;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            produit.Text = nom;

            if (publie == "Publié")
                checkBox1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mise à jour publication si modifiée
            if ((checkBox1.Checked && publie == "Dépublié") || (!checkBox1.Checked && publie == "Publié"))
            {
                Cursor.Current = Cursors.WaitCursor;
                char publish = (checkBox1.Checked ? 'Y' : 'N');
                // Mise à jour dans la database ( update )
                string req;
                if( (string)dsource.Tag == "Produits" )
                    req = "update jos_vm_product set product_publish = '" + publish + "' where product_id = " + Convert.ToString(id);
                else
                    req = "update jos_smart_properties set published = '" + publish + "' where id = " + Convert.ToString(id);
                int numRowsUpdated;
                using (MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.myConnectionStringOK))
                {
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand(req, cn);
                    numRowsUpdated = cmd.ExecuteNonQuery(); 
                }
                if (numRowsUpdated != 0)
                {
                    int pubindex = 3;
                    if (dsource.Tag == "Encas")
                        pubindex = 4;
                    // Mise à jour dans le DGV
                    if (checkBox1.Checked)
                        dsource.Rows[currRow].Cells[pubindex].Value = "Publié";
                    else
                        dsource.Rows[currRow].Cells[pubindex].Value = "Dépublié";
                    dsource.Update();
                    dsource.Refresh();
                }
            }
            Cursor.Current = Cursors.Default;
            this.Close();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
