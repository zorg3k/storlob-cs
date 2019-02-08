using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//using System.Net.Mail;        // Envoi e-mail pour changement d'état commande

namespace storlob
{
    public partial class Form3 : Form
    {
        public string commande, nom, prenom, societe, adr1, adr2, cp, ville, tel1, tel2;
        public string etat,email,note;
        public List<string> lignes;
        public decimal ht, ttc;
        public DataGridView dgCommandes;

        // Code barre
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        // Dictionnaire coorespondance pour les états de commande
        Dictionary<string, string> dstatus_code = new Dictionary<string, string>()   // Libellé -> Etat
	    {
	      {"A traiter", "P" },
	      {"En cours de traitement", "C" },
	      {"Annulée", "X" },
	      {"Remboursée", "R" },
          {"Expédiée", "S" }
	    };
        Dictionary<string, string> dstatus_text = new Dictionary<string, string>()  // Etat -> Libellé
	    {
	      {"P","A traiter"},
	      {"C","En cours de traitement"},
	      {"X","Annulée"},
	      {"R","Remboursée"},
          {"S","Expédiée"}
	    };

        static bool bchanged = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lb_commande.Text = commande;
            lb_nom.Text = nom;
            lb_prenom.Text = prenom;
            lb_societe.Text = societe;
            lb_adr1.Text = adr1;
            lb_adr1.Text = adr2;
            lb_cp.Text = cp;
            lb_ville.Text = ville;
            lb_tel1.Text = tel1;
            lb_tel2.Text = tel2;
            lb_tot_ht.Text = Convert.ToString(ht);
            lb_tot_ttc.Text = Convert.ToString(ttc);
            tb_note.Text = note;
            lb_email.Text = email;

            lv_oder.AllowColumnReorder = false;
            lv_oder.FullRowSelect = true;
            lv_oder.GridLines = true;
            lv_oder.View = View.Details;
            lv_oder.Sorting = SortOrder.None;
            lv_oder.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            int i = 0;
            foreach (string ligne in lignes)
            {
                if (ligne.Contains("\t"))  // ligne de produit + prix
                {
                    string[] items = ligne.Split('\t');
                    ListViewItem item = new ListViewItem(items[0], 0);
                    for (int j = 1; j < items.Length; j++)
                        item.SubItems.Add(items[j]);
                    lv_oder.Items.Add(item);
                }
                else  // Ligne d'attributs ( ingrédients )
                {
                    Regex r = new Regex(@"(Ingr[eé]dient Big [0-9]: |Ingrédient Must ou Big [0-9]: |Douceur sucrée offerte: |Boisson: |Dessert: |Choix pates: |Choix sauce: )");

                    string[] items = r.Replace(StripHTML(ligne), "").Split('\n');
                    ListViewItem item = new ListViewItem(items);
                    item.ForeColor = Color.DarkRed;
                    lv_oder.Items.Add(item);
                }
            }
            foreach (ColumnHeader column in lv_oder.Columns)
            {
                if( column.Name.Equals("Désignation"))
                    column.Width = -1;
                else
                    column.Width = -2;
            }
            cb_etat.SelectedIndex = cb_etat.FindStringExact(etat);
        }

        private void cb_etat_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string selitem = cb_etat.SelectedItem.ToString();
            if (selitem.Equals(etat))
                bchanged = false;
            else
                bchanged = true;
            chk_notify.Enabled = bchanged;
            chk_comment.Visible = bchanged;
        }

        private void chk_comment_CheckedChanged(Object sender, EventArgs e)
        {
            txt_comment.Visible = chk_comment.Checked;
        }

        private string StripHTML (string inputString)
        {
            const string HTML_TAG_PATTERN = "<.*?>";

             return Regex.Replace 
            (inputString, HTML_TAG_PATTERN, string.Empty);
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            int numRowsUpdated = 0;

            if (bchanged) // demande confirmation du changement état commande
            {
                DialogResult dr = MessageBox.Show("Changer l'état commande en " + cb_etat.SelectedItem + " ?", "Données modifiées", MessageBoxButtons.YesNoCancel);
                if (dr != DialogResult.Cancel)
                {
                    if (dr != DialogResult.No) // Validation du changement d'état
                    {
                        // Ajout du nouvel état commande
                        
                        string req = "insert into jos_vm_order_history (order_id,order_status_code, date_added,customer_notified, comments) "
                                    + "values(" + commande + ",'" + dstatus_code[cb_etat.SelectedItem.ToString()] 
                                    + "', CURRENT_TIMESTAMP()," + (chk_notify.Checked ? "1" : "0") 
                                    + ",'" + (chk_comment.Checked ? txt_comment.Text : "NULL" ) + "');";
                        try
                        {
                            using (MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.myConnectionStringOK))
                            {
                                cn.Open();
                                MySqlCommand cmd = new MySqlCommand(req, cn);
                                numRowsUpdated = cmd.ExecuteNonQuery();
                                cn.Close();
                            }
                        }
                        catch (MySqlException se)
                        {
                            MessageBox.Show("Une erreur s'est produite lors de la modification d'historique de la commande : \n" + se.Message);
                        }
                        if (numRowsUpdated > 0)
                        {
                            // Mets à jour l'état de la commande 
                            req = "update jos_vm_orders set order_status = '" + dstatus_code[cb_etat.SelectedItem.ToString()] + "' where order_id =" + commande + ";";
                            try
                            {
                                using (MySqlConnection cn = new MySqlConnection(Properties.Settings.Default.myConnectionStringOK))
                                {
                                    cn.Open();
                                    MySqlCommand cmd = new MySqlCommand(req, cn);
                                    numRowsUpdated = cmd.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            catch (MySqlException se)
                            {
                                MessageBox.Show("Une erreur s'est produite lors de l'enregistrement du changement d'état de la commande : \n" + se.Message);
                            }
                        }
                        int currentRow = dgCommandes.SelectedRows[0].Index;
                        dgCommandes.Rows[currentRow].Cells[2].Value = cb_etat.SelectedItem.ToString();
                        dgCommandes.Update();
                        this.Close();
                    }
                    else
                        this.Close();
                }
            }
            else
                this.Close();
        }

        private void b_print_Clicked(Object sender, EventArgs e)
        {
            Image temp;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            b.EncodedType = BarcodeLib.TYPE.UPCA;
            b.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
            b.IncludeLabel = false;
            b.Width = 250;
            b.Height = 50;

            string encValue = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.ToString("yy") + "0" + commande;
            temp = b.Encode(BarcodeLib.TYPE.UPCA, encValue);
            Ticket t = new Ticket();
            t.LvSource = lv_oder;
            t.BcImage = temp;
            t.TicketNo = Int16.Parse( commande );
            t.ticketDate = DateTime.Now.Date;
            t.Nom = nom;
            t.Prenom = prenom;
            t.Societe = lb_societe.Text;
            t.Adr1 = lb_adr1.Text;
            t.Adr1 = lb_adr2.Text;
            t.Cp = lb_cp.Text;
            t.Ville = lb_ville.Text;
            t.Total_HT = float.Parse(lb_tot_ht.Text);
            t.Total_TTC = float.Parse(lb_tot_ttc.Text);
            t.print();

        }
    }
}
