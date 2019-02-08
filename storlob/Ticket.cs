using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace storlob
{
    public class Ticket
    {
        PrintDocument pdoc = null;
        int ticketNo;
        DateTime TicketDate;
        String nom, prenom, societe,adr1,adr2,cp,ville;
        float total_ht,total_ttc;
        Image bcImage;  // Le barcode
        ListView lvSource;  // la listview détails commande


        // Listview détails commande
        public ListView LvSource
        {
            set { this.lvSource = value; }
        }
        // Image du barcode
        public Image BcImage
        {
            set { this.bcImage = value; }
        }


        public int TicketNo
        {
            //set the person name
            set { this.ticketNo = value; }
            //get the person name 
            get { return this.ticketNo; }
        }
        public DateTime ticketDate
        {
            //set the person name
            set { this.TicketDate = value; }
            //get the person name 
            get { return this.TicketDate; }
        }

        public String Nom
        {
            set { this.nom = value; }
        }
        public String Prenom
        {
            set { this.prenom = value; }
        }
        public String Societe
        {
            set { this.societe = value; }
        }

        public String Adr1
        {
            set { this.adr1 = value; }
        }
        public String Adr2
        {
            set { this.adr2 = value; }
        }
        public String Cp
        {
            set { this.cp = value; }
        }
        public String Ville
        {
            set { this.ville = value; }
        }
        public float Total_HT
        {
            set { this.total_ht = value; }
        }
        public float Total_TTC
        {
            set { this.total_ttc = value; }
        }

        public Ticket()
        {

        }
        public Ticket(int ticketNo, DateTime TicketDate, String Source, String Destination, float Amount, String DrawnBy)
        {
            this.ticketNo = ticketNo;
            this.TicketDate = TicketDate;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Cp = cp;
            this.Ville = ville;
        }
        public void print()
        {
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);


            PaperSize psize = new PaperSize("Custom", 100, 200);
            //ps.DefaultPageSettings.PaperSize = psize;



            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height =320;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;

            pdoc.DefaultPageSettings.PaperSize.Width = 283;

            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
                result = pp.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pdoc.Print();
                }
            }

        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image logo = Properties.Resources.logo_ticket;
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 90;
            int Offset = 40;
            graphics.DrawImage(bcImage, new Rectangle(0, 0, bcImage.Width, bcImage.Height));
            graphics.DrawImage(logo, new Rectangle(20, 60, logo.Width, logo.Height));

            graphics.DrawString("16,Av. de St Antoine", new Font("Courier New", 9), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("13015 Marseille", new Font("Courier New", 9), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("www.resto-boulot.fr", new Font("Courier New", 9), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("0491465306 - 0952522689", new Font("Courier New", 9), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            String underLine = "------------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Commande N° " + this.ticketNo, new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            graphics.DrawString(this.nom + " " + this.prenom, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(this.societe, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            graphics.DrawString(this.adr1, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(this.adr2, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(this.cp + " " + this.ville, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            underLine = "------------------------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 9,FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;

            int[] positions = { 0, 140, 166, 200, 235 }; // Positions de colonnes désignation, qté ...
            graphics.DrawString("Article", new Font("Courier New", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX + positions[0], startY + Offset);
            graphics.DrawString("Qté", new Font("Courier New", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX + positions[1], startY + Offset);
            graphics.DrawString("TVA", new Font("Courier New", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX + positions[2], startY + Offset);
            graphics.DrawString("HT", new Font("Courier New", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX + positions[3], startY + Offset);
            graphics.DrawString("TTC", new Font("Courier New", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX + positions[4], startY + Offset);

            Offset = Offset + 20;
            for (int i = 0; i < lvSource.Items.Count; i++)
            {
                string ligne = "";
                for (int j = 0; j < lvSource.Items[i].SubItems.Count; j++)
                {
                    ligne = lvSource.Items[i].SubItems[j].Text.TrimStart(' ');
                    if (ligne.Length > 20)
                        ligne = ligne.Substring(0, 17) + "...";
                    graphics.DrawString(ligne, new Font("Courier New", 8), new SolidBrush(Color.Black), startX + positions[j], startY + Offset);
                }
                //graphics.DrawString(ligne, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
            }
            Offset = Offset + 40;
            graphics.DrawString("Total TVA    " + String.Format("{0:0.00}", this.total_ht), new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX + 105, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString("Total TTC    " + String.Format("{0:0.00}", this.total_ttc), new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX + 105, startY + Offset);
            Offset = Offset + 20;
        }
    }

}
