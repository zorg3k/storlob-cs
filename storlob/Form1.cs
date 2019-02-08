using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;
using System.IO;


namespace storlob
{
    public partial class Form1 : Form
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString = Properties.Settings.Default.myConnectionStringOK;
        DataGridViewButtonColumn editButton;
        DataTable dtCommandes;
        static int orders_today = 0;

        SoundPlayer sp;


        // Dictionnaire coorespondance colonnes DGV <-> Datasource pour les produits
        Dictionary<string, List<string>> dprod = new Dictionary<string, List<string>>()
	    {
	      {"product_id", new List<string>{"Id", "System.Int32"} },
	      {"product_name", new List<string>{"Nom", "System.String"}},
	      {"product_publish", new List<string>{"Publication", "System.String"}},
	      {"product_available_date", new List<string>{"D'aujourd'hui","System.String"}},
          {"product_height", new List<string>{"N°Plat","System.String"}}
	    };

        // Dictionnaire coorespondance colonnes DGV <-> Datasource pour les commandes
        Dictionary<string, List<string>> dorders = new Dictionary<string, List<string>>()
	    {
	      {"order_id", new List<string>{"Numéro", "System.Int32"} },
	      {"order_total", new List<string>{"Total", "System.Decimal"}},
	      {"order_status", new List<string>{"Etat", "System.String"}},
	      {"company", new List<string>{"Société","System.String"}},
          {"first_name", new List<string>{"Prénom","System.String"}},
          {"last_name", new List<string>{"Nom","System.String"}},
          {"user_email", new List<string>{"Email","System.String"}},
          {"address_1", new List<string>{"Adresse 1","System.String"}},
          {"address_2", new List<string>{"Adresse 2","System.String"}},
          {"zip", new List<string>{"Code Postal","System.String"}},
          {"city", new List<string>{"Ville","System.String"}},
          {"phone_1", new List<string>{"Tel.1","System.String"}},
          {"phone_2", new List<string>{"Tel.2","System.String"}},
          {"customer_note", new List<string>{"Note client","System.String"}}
	    };

        // Timer pour le scan des nouvelles commandes

        System.Timers.Timer tOrders;

        public Form1()
        {
            InitializeComponent();

            sp = new SoundPlayer();
            sp.Stream = Properties.Resources.trumpet_x;
            SplashForm sc = new SplashForm();
            sc.Show();

            // Creation dynamique des tabs des catégories
            using (MySqlConnection c = new MySqlConnection(myConnectionString))
            {
                
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    
                    c.Open();
                    string query = "SELECT category_id, category_name FROM jos_vm_category WHERE category_publish='Y'";
                    MySqlCommand cmd = new MySqlCommand(query, c);
                
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            TabPage p = new TabPage();
                            p.Text = (string)r["category_name"];
                            p.Name = "tab" + Convert.ToString(r["category_id"]);
                            p.Tag = Convert.ToString(r["category_id"]);
                            tabControl2.TabPages.Add(p);
                        }
                    }
                    c.Close();
                    
                    
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Erreur de connection à la base : " + e.Message);
                    sc.Close();
                }
            }
            
            foreach (TabPage p in tabControl2.TabPages)
            {
                string category = (string)p.Tag;
                using (MySqlConnection c = new MySqlConnection(myConnectionString))
                {
                    c.Open();
                    //string req = "SELECT a.product_name FROM `jos_vm_product as a, jos_vm_product_category_xref as b where a.product_id = b.product_id and b.category_id='" + category + "'";
                    string req = "SELECT * FROM jos_vm_product inner join jos_vm_product_category_xref on jos_vm_product.product_id = jos_vm_product_category_xref.product_id and jos_vm_product_category_xref.category_id='" + category + "' ORDER BY product_available_date DESC";
                    //MySqlDataAdapter mda = new MySqlDataAdapter(req, conn);
                    MySqlCommand cmd = new MySqlCommand(req, c);
                    //DataSet ds = new DataSet();
                    //mda.Fill(ds);

                    using (MySqlDataReader msr = cmd.ExecuteReader())
                    {
                        // DataTable et colonnes pour le DataGridView
                        DataTable dt = new DataTable();
                        // Ajout des colonnes avec le dictionnaire produits
                        foreach (string s in dprod.Keys)
                        {
                            List<string> l = dprod[s];
                            DataColumn col = new DataColumn();
                            col.ColumnName = l[0];
                            col.DataType = System.Type.GetType(l[1]);
                            dt.Columns.Add(col.ColumnName, col.DataType);
                        }
                        
                        bool pdj = false;
                        while (msr.Read())
                        {
                            DataRow row = dt.NewRow();
                            row[dt.Columns[0]] = msr["product_id"];
                            row[dt.Columns[1]] = msr["product_name"];
                            if ((string)msr["product_publish"] == "Y")
                                row[dt.Columns[2]] = "Publié";
                            else
                                row[dt.Columns[2]] = "Dépublié";
                            DateTime d = UnixTimeStampToDateTime(Convert.ToDouble(msr["product_available_date"])).Date;
                            if (d.Equals(DateTime.Now.Date))
                            {
                                row[dt.Columns[3]] = "Oui";
                                pdj = true;
                            }
                            row[dt.Columns[4]] = Convert.ToString(msr["product_height"]).Substring(0, 1);
                            dt.Rows.Add(row);
                        }

                        // Initialisation du DataGridView
                        DataGridView dg = new DataGridView();
                        dg.Tag = (string)"Produits";
                        dg.Width = 600;
                        dg.Height = 500;
                        dg.ReadOnly = true;
                        dg.DataSource = null;
                        dg.AllowUserToAddRows = false;
                        dg.Name = "DataGrid" + (string)this.Tag;
                        dg.AutoGenerateColumns = true;
                        //dg.Columns.Clear();

                        BindingSource bs = new BindingSource();
                        string[] colnames = (from dc in dt.Columns.Cast<DataColumn>()
                        select dc.ColumnName).ToArray();
                        foreach( string s in colnames)
                        {
                            DataGridViewColumn col = new DataGridViewTextBoxColumn();
                            col.DataPropertyName = s;
                            col.HeaderText = s;
                            col.Name = s;
                            dg.Columns.Add(col);
                        }
                        
                        bs.DataSource = dt;
                        dg.DataSource = bs;

                        //if (dg.Columns.Count != 0)
                        //    dg.Columns[1].Visible = false;

                        editButton = new DataGridViewButtonColumn();
                        editButton.HeaderText = "Modifier";
                        editButton.Text = "Modifier";
                        editButton.Name = "Modifier";
                        editButton.UseColumnTextForButtonValue = true;
                        editButton.Width = 80;
                        dg.Columns.Add(editButton);
                        
                        dg.CellContentClick += new DataGridViewCellEventHandler(DataGrid_CellContentClick);
                        dg.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGrid_CellFormatting);
                        
                        // Ajour du controle à l'onglet
                        p.Controls.Add(dg);
                        // Affichage des colonnes spécifique PDJ ( aujourd'hui + n° )
                        dg.Columns["D'aujourd'hui"].Visible = pdj;
                        dg.Columns["N°Plat"].Visible = pdj;
                    }
                }
            }

            // Ingrédients et encas
            using (MySqlConnection c = new MySqlConnection(myConnectionString))
            {
                c.Open();
                string req = "SELECT * FROM jos_smart_properties WHERE is_product = 'N' and active = 'Y';";
                MySqlCommand cmd = new MySqlCommand(req, c);

                using (MySqlDataReader msr = cmd.ExecuteReader())
                {
                    // DataTable et colonnes pour le DataGridView
                        DataTable dt = new DataTable();
                        DataColumn col_id = new DataColumn();
                        col_id.DataType = System.Type.GetType("System.Int32");

                        col_id.ColumnName = "Id";
                        col_id.Caption = "Id";
                        dt.Columns.Add(col_id.ColumnName, col_id.DataType);

                        DataColumn col_name = new DataColumn();
                        col_name.DataType = System.Type.GetType("System.String");
                        col_name.ColumnName = "Nom";
                        col_name.Caption = "Nom";
                        dt.Columns.Add(col_name.ColumnName, col_name.DataType);

                        DataColumn col_cat = new DataColumn();
                        col_cat.DataType = System.Type.GetType("System.String");
                        col_cat.ColumnName = "Catégorie";
                        col_cat.Caption = "Catégorie";
                        dt.Columns.Add(col_cat.ColumnName, col_cat.DataType);

                        DataColumn col_pub = new DataColumn();
                        col_pub.DataType = System.Type.GetType("System.String");
                        col_pub.ColumnName = "Publication";
                        col_pub.Caption = "Publication";
                        dt.Columns.Add(col_pub.ColumnName, col_pub.DataType);
                        
                        while (msr.Read())
                        {
                            DataRow row = dt.NewRow();
                            row[col_id.ColumnName] = msr["id"];
                            string test = Convert.ToString(row[col_id.ColumnName]);
                            row[col_name.ColumnName] = msr["name"];
                            row[col_cat.ColumnName] = msr["category"];
                            if ((string)msr["published"] == "Y")
                                row[col_pub.ColumnName] = "Publié";
                            else
                                row[col_pub.ColumnName] = "Dépublié";
                            dt.Rows.Add(row);
                        }
                        dataGridView2.Tag = (string)"Encas";
                        dataGridView2.Width = 600;
                        dataGridView2.ReadOnly = true;
                        dataGridView2.DataSource = null;
                        dataGridView2.AllowUserToAddRows = false;
                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = dt;
                        editButton = new DataGridViewButtonColumn();
                        editButton.HeaderText = "Modifier";
                        editButton.Text = "Modifier";
                        editButton.Name = "Modifier";
                        editButton.UseColumnTextForButtonValue = true;
                        editButton.Width = 80;
                        dataGridView2.Columns.Add(editButton);
                        dataGridView2.CellContentClick += new DataGridViewCellEventHandler(DataGrid_CellContentClick);
                        dataGridView2.CellFormatting += new DataGridViewCellFormattingEventHandler(DataGrid_CellFormatting);
                }

                // DataGridView Commandes
                dataGridView1.Tag = (string)"Commandes";
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = null;
                dataGridView1.AllowUserToAddRows = false;

                // DataTable et colonnes pour le DataGridView Commandes
                dtCommandes = new DataTable();
                // Ajout des colonnes avec dictionnary commandes
                foreach (string s in dorders.Keys)
                {
                    List<string> l = dorders[s];
                    DataColumn col = new DataColumn();
                    col.ColumnName = l[0];
                    col.DataType = System.Type.GetType(l[1]);
                    dtCommandes.Columns.Add(col.ColumnName, col.DataType);
                }

                getOrders(DateTime.Now);

                dataGridView1.DataSource = dtCommandes;
                dataGridView1.Refresh();
                orders_today = dtCommandes.Rows.Count;
                monthCalendar1.MaxDate = DateTime.Now.Date;

                // Paramétrage du timer commandes
                tOrders = new System.Timers.Timer();
                tOrders.SynchronizingObject = this;
                tOrders.AutoReset = true;       // Se redéclenche en fin de période
                tOrders.Interval = 60000;       // Toutes les 60 secondes
                tOrders.Elapsed +=new ElapsedEventHandler(tOrders_Elapsed);
                tOrders.Start();
                Cursor.Current = Cursors.Default;
                
            }
            sc.Close();
            // Commandes
            
        }

        private void tOrders_Elapsed(Object sender, ElapsedEventArgs e)
        {
            monthCalendar1.SetDate(DateTime.Now.Date);
            getOrders(DateTime.Now.Date);
            lb_updated.Text = DateTime.Now.ToString();
            int count = dtCommandes.Rows.Count;
            if (count > orders_today)
            {
                sp.Play();
                orders_today = count;
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            getOrders( e.Start );
            if (e.Start.Equals(DateTime.Now.Date))
                bt_update.Enabled = true;
            else
                bt_update.Enabled = false;
        }
        

        private void getOrders(DateTime d)
        {
            string orders_request = "SELECT a.order_id, a.order_total, a.order_subtotal, a.order_tax, a.order_status, from_unixtime(a.cdate), from_unixtime(a.mdate),a.customer_note,"
                                  + "b.company, b.first_name, b.last_name, b.phone_1, b.phone_2, b.address_1, b.address_2,b.city,b.zip,b.user_email "
                                  + "FROM jos_vm_orders as a "
                                  + "inner join jos_vm_order_user_info as b on a.order_id = b.order_id "
                                  + "where DATE( from_unixtime(a.cdate) ) = DATE ('"+  d.Date.ToString("yyyy-MM-dd") + "')";
            dtCommandes.Clear();
            Cursor.Current = Cursors.WaitCursor;
            using (MySqlConnection c = new MySqlConnection(myConnectionString))
            {
                c.Open();
                MySqlCommand cmd = new MySqlCommand(orders_request, c);
                using (MySqlDataReader msr = cmd.ExecuteReader())
                {
                    while (msr.Read())
                    {
                        DataRow row = dtCommandes.NewRow();
                        row[dtCommandes.Columns[0]] = msr["order_id"];
                        //row[0] = Convert.ToString(msr["order_id"]);
                        //row[1] = msr["order_total"].ToString();
                        row[dtCommandes.Columns[1]] =  Math.Round( (decimal)msr["order_total"],2);
                        switch ( msr["order_status"].ToString())
                        {
                            case "P":
                                row[dtCommandes.Columns[2]] = "Nouvelle";
                                break;
                            case "C":
                                row[dtCommandes.Columns[2]] = "En cours de traitement";
                                break;
                            case "S":
                                row[dtCommandes.Columns[2]] = "Expédiée";
                                break;
                            case "X":
                                row[dtCommandes.Columns[2]] = "Annulée";
                                break;
                            case "R":
                                row[dtCommandes.Columns[2]] = "Remboursée";
                                break;
                        }
                        row[dtCommandes.Columns[3]] = msr["company"].ToString();
                        row[dtCommandes.Columns[4]] = msr["first_name"].ToString();
                        row[dtCommandes.Columns[5]] = msr["last_name"].ToString();
                        row[dtCommandes.Columns[6]] = msr["user_email"].ToString();
                        row[dtCommandes.Columns[7]] = msr["address_1"].ToString();
                        row[dtCommandes.Columns[8]] = msr["address_2"].ToString();
                        row[dtCommandes.Columns[9]] = msr["city"].ToString();
                        row[dtCommandes.Columns[10]] = msr["zip"].ToString();
                        row[dtCommandes.Columns[11]] = msr["phone_1"].ToString();
                        row[dtCommandes.Columns[12]] = msr["phone_2"].ToString();
                        row[dtCommandes.Columns[13]] = ReplaceBRWithNewline( msr["customer_note"].ToString() );
                        dtCommandes.Rows.Add(row);
                    }
                }
            }
            label3.Text = dtCommandes.Rows.Count.ToString();
            dataGridView1.DataSource = dtCommandes;
            dataGridView1.Refresh();
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = true;
                button4.Enabled = true;
            }
            else
                button4.Enabled = false;
            Cursor.Current = Cursors.Default;
        }

        // Affichage lignes produits avec couleur ( publié:vert, dépublié:rose )
        private void DataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView d = (DataGridView)sender;

            int currentRow = int.Parse(e.RowIndex.ToString());
            if (currentRow < d.Rows.Count)
            {
                int colindex;
                if( d.Tag.ToString().Equals("Encas" ))
                    colindex = 4;
                else
                    colindex= 3;
                if (!String.IsNullOrEmpty(d[colindex, currentRow].Value.ToString()))
                    if (d[colindex, currentRow].Value.ToString().Equals("Publié"))
                        d.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.GreenYellow };
                    else
                        d.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.Pink };
            }

        }

        // Affiche le détail de la commande dans Form3
        private void button4_Click(object sender, EventArgs e)
        {
            int currentRow = dataGridView1.SelectedRows[0].Index;

            Form3 f3 = new Form3();
            string c= Convert.ToString(dataGridView1.Rows[currentRow].Cells[0].Value);
            string etat = Convert.ToString(dataGridView1.Rows[currentRow].Cells[2].Value);
            f3.commande = c;
            f3.etat = etat;
            f3.societe = dataGridView1.Rows[currentRow].Cells[3].Value.ToString();
            f3.email = dataGridView1.Rows[currentRow].Cells[6].Value.ToString();
            f3.nom = dataGridView1.Rows[currentRow].Cells[5].Value.ToString();
            f3.prenom = dataGridView1.Rows[currentRow].Cells[4].Value.ToString();
            f3.adr1 = dataGridView1.Rows[currentRow].Cells[7].Value.ToString();
            f3.adr2 = dataGridView1.Rows[currentRow].Cells[8].Value.ToString();
            f3.cp = dataGridView1.Rows[currentRow].Cells[9].Value.ToString();
            f3.ville = dataGridView1.Rows[currentRow].Cells[10].Value.ToString();
            f3.tel1 = dataGridView1.Rows[currentRow].Cells[11].Value.ToString();
            f3.tel2 = dataGridView1.Rows[currentRow].Cells[12].Value.ToString();
            f3.note = dataGridView1.Rows[currentRow].Cells[13].Value.ToString();
            f3.dgCommandes = dataGridView1;
            string orders_request = "select order_item_name,product_quantity,round( product_item_price,2),product_final_price,product_attribute "
                                  + "from jos_vm_order_item where order_id = " + c + " order by order_id;";

            using (MySqlConnection cn = new MySqlConnection(myConnectionString))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(orders_request, cn);
                using (MySqlDataReader msr = cmd.ExecuteReader())
                {
                    decimal ht = 0, ttc = 0;
                    List<string> lines = new List<string>();

                    while (msr.Read())
                    {
                        
                        decimal ht_produit = 0;
                        ht_produit = (Convert.ToDecimal(msr[3]) - Convert.ToDecimal(msr[2])) * Convert.ToDecimal(msr[1]);
                        ht += ht_produit;
                        ttc += Convert.ToDecimal(msr[3]) * Convert.ToDecimal(msr[1]);
                        lines.Add( msr[0] + "\t" + msr[1] + "\t" + Convert.ToString(ht_produit) + "\t" + msr[2] + "\t" + msr[3]);
                        string attr = msr[4].ToString();
                        if (!String.IsNullOrEmpty(attr))
                        {
                               
                            string[] attributes = ReplaceBRWithNewline(attr).Split('\n');
                            foreach (string s in attributes)
                                lines.Add(s);
                        }
                    }
                    f3.lignes = lines;
                    f3.ht = ht;
                    f3.ttc = ttc;
                }
            }
            f3.ShowDialog(this);   // Affiche la fenêtre de modification commande en mode modal
            //f3.Show();
        }

        // Selection d'une ligne
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //int r = e.RowIndex;
            //if (r != 0)
            //    button4.Enabled = true;
            //else
            //    button4.Enabled = false;
        }

        // Affichage des lignes commandes colorées
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int currentRow = int.Parse(e.RowIndex.ToString());
            switch (dataGridView1[2, currentRow].Value.ToString())
            {
                case "Nouvelle":
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.Pink };
                    break;
                case "En cours de traitement":
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.Yellow };
                    break;
                case "Expédiée":
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.Green };
                    break;
                case "Annulée":
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = new DataGridViewCellStyle { BackColor = Color.LightGray };
                    break;
            }
        }

        // Click dans contenu des commandes
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = int.Parse(e.RowIndex.ToString());
            dataGridView1.Rows[currentRow].Selected = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = int.Parse(e.RowIndex.ToString());
            dataGridView1.Rows[currentRow].Selected = true;
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView d = (DataGridView)sender;
            int currentRow = int.Parse(e.RowIndex.ToString());
            string n = d.Columns[e.ColumnIndex].Name.ToString();
            if (d.Columns[e.ColumnIndex].Name.ToString() == "Modifier")
            {
                int id = Convert.ToInt32(d[1,currentRow].Value);
                string nom = d[2, currentRow].Value.ToString();
                string publie;
                if( (string)d.Tag == "Produits" )
                    publie = d[3, currentRow].Value.ToString();
                else
                    publie = d[4, currentRow].Value.ToString();
                Form2 f2 = new Form2();
                f2.nom = nom;
                f2.id = id;
                f2.publie = publie;
                f2.dsource = d;
                f2.currRow = currentRow;
                f2.Show();
            }
        }
        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private string ReplaceBRWithNewline(string text)
        {
            string newText = "";

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            // Create regular expressions
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");

            // Replace new line with <br/> tag
            newText = regex.Replace(text, "\n");

            // Result
            return newText;
        }

        private void openConn()
        {// Ouverture connexion base MySql

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            getOrders(DateTime.Now.Date);
            lb_updated.Text = DateTime.Now.ToString();
            int count = dtCommandes.Rows.Count;
            if (count > orders_today)
            {
                sp.Play();
                orders_today = count;
            }
        }
    }
}
