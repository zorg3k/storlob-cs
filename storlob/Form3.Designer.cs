namespace storlob
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lb_commande = new System.Windows.Forms.Label();
            this.b_print = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfos = new System.Windows.Forms.TabPage();
            this.lb_email = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_note = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_tel2 = new System.Windows.Forms.Label();
            this.lb_tel1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_ville = new System.Windows.Forms.Label();
            this.lb_cp = new System.Windows.Forms.Label();
            this.lb_adr2 = new System.Windows.Forms.Label();
            this.lb_adr1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_societe = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_prenom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_nom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.lb_tot_ttc = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_tot_ht = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lv_oder = new System.Windows.Forms.ListView();
            this.designation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_taxe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pu_ht = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pu_tcc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cb_etat = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chk_notify = new System.Windows.Forms.CheckBox();
            this.chk_comment = new System.Windows.Forms.CheckBox();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabInfos.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° Commande :";
            // 
            // lb_commande
            // 
            this.lb_commande.AutoSize = true;
            this.lb_commande.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_commande.Location = new System.Drawing.Point(100, 12);
            this.lb_commande.Name = "lb_commande";
            this.lb_commande.Size = new System.Drawing.Size(0, 13);
            this.lb_commande.TabIndex = 1;
            // 
            // b_print
            // 
            this.b_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_print.Location = new System.Drawing.Point(16, 362);
            this.b_print.Name = "b_print";
            this.b_print.Size = new System.Drawing.Size(148, 60);
            this.b_print.TabIndex = 2;
            this.b_print.Text = "Imprimer le ticket";
            this.b_print.UseVisualStyleBackColor = true;
            this.b_print.Click += new System.EventHandler(this.b_print_Clicked);
            // 
            // b_exit
            // 
            this.b_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_exit.Location = new System.Drawing.Point(272, 363);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(201, 59);
            this.b_exit.TabIndex = 3;
            this.b_exit.Text = "Quitter";
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInfos);
            this.tabControl1.Controls.Add(this.tabDetail);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(16, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(457, 223);
            this.tabControl1.TabIndex = 4;
            // 
            // tabInfos
            // 
            this.tabInfos.Controls.Add(this.lb_email);
            this.tabInfos.Controls.Add(this.label11);
            this.tabInfos.Controls.Add(this.tb_note);
            this.tabInfos.Controls.Add(this.label10);
            this.tabInfos.Controls.Add(this.lb_tel2);
            this.tabInfos.Controls.Add(this.lb_tel1);
            this.tabInfos.Controls.Add(this.label6);
            this.tabInfos.Controls.Add(this.lb_ville);
            this.tabInfos.Controls.Add(this.lb_cp);
            this.tabInfos.Controls.Add(this.lb_adr2);
            this.tabInfos.Controls.Add(this.lb_adr1);
            this.tabInfos.Controls.Add(this.label5);
            this.tabInfos.Controls.Add(this.lb_societe);
            this.tabInfos.Controls.Add(this.label4);
            this.tabInfos.Controls.Add(this.lb_prenom);
            this.tabInfos.Controls.Add(this.label3);
            this.tabInfos.Controls.Add(this.lb_nom);
            this.tabInfos.Controls.Add(this.label2);
            this.tabInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInfos.Location = new System.Drawing.Point(4, 22);
            this.tabInfos.Name = "tabInfos";
            this.tabInfos.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfos.Size = new System.Drawing.Size(449, 197);
            this.tabInfos.TabIndex = 0;
            this.tabInfos.Text = "Informations Cleint";
            this.tabInfos.UseVisualStyleBackColor = true;
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.Location = new System.Drawing.Point(254, 33);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(0, 13);
            this.lb_email.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Email :";
            // 
            // tb_note
            // 
            this.tb_note.Location = new System.Drawing.Point(9, 146);
            this.tb_note.Multiline = true;
            this.tb_note.Name = "tb_note";
            this.tb_note.ReadOnly = true;
            this.tb_note.Size = new System.Drawing.Size(434, 45);
            this.tb_note.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Remarque client";
            // 
            // lb_tel2
            // 
            this.lb_tel2.AutoSize = true;
            this.lb_tel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tel2.Location = new System.Drawing.Point(180, 105);
            this.lb_tel2.Name = "lb_tel2";
            this.lb_tel2.Size = new System.Drawing.Size(0, 13);
            this.lb_tel2.TabIndex = 13;
            // 
            // lb_tel1
            // 
            this.lb_tel1.AutoSize = true;
            this.lb_tel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tel1.Location = new System.Drawing.Point(74, 105);
            this.lb_tel1.Name = "lb_tel1";
            this.lb_tel1.Size = new System.Drawing.Size(0, 13);
            this.lb_tel1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Téléphone";
            // 
            // lb_ville
            // 
            this.lb_ville.AutoSize = true;
            this.lb_ville.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ville.Location = new System.Drawing.Point(180, 85);
            this.lb_ville.Name = "lb_ville";
            this.lb_ville.Size = new System.Drawing.Size(0, 13);
            this.lb_ville.TabIndex = 10;
            // 
            // lb_cp
            // 
            this.lb_cp.AutoSize = true;
            this.lb_cp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cp.Location = new System.Drawing.Point(66, 85);
            this.lb_cp.Name = "lb_cp";
            this.lb_cp.Size = new System.Drawing.Size(0, 13);
            this.lb_cp.TabIndex = 9;
            // 
            // lb_adr2
            // 
            this.lb_adr2.AutoSize = true;
            this.lb_adr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_adr2.Location = new System.Drawing.Point(63, 66);
            this.lb_adr2.Name = "lb_adr2";
            this.lb_adr2.Size = new System.Drawing.Size(0, 13);
            this.lb_adr2.TabIndex = 8;
            // 
            // lb_adr1
            // 
            this.lb_adr1.AutoSize = true;
            this.lb_adr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_adr1.Location = new System.Drawing.Point(62, 49);
            this.lb_adr1.Name = "lb_adr1";
            this.lb_adr1.Size = new System.Drawing.Size(0, 13);
            this.lb_adr1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Adresse :";
            // 
            // lb_societe
            // 
            this.lb_societe.AutoSize = true;
            this.lb_societe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_societe.Location = new System.Drawing.Point(60, 33);
            this.lb_societe.Name = "lb_societe";
            this.lb_societe.Size = new System.Drawing.Size(0, 13);
            this.lb_societe.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Société :";
            // 
            // lb_prenom
            // 
            this.lb_prenom.AutoSize = true;
            this.lb_prenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_prenom.Location = new System.Drawing.Point(254, 6);
            this.lb_prenom.Name = "lb_prenom";
            this.lb_prenom.Size = new System.Drawing.Size(0, 13);
            this.lb_prenom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(191, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prénom :";
            // 
            // lb_nom
            // 
            this.lb_nom.AutoSize = true;
            this.lb_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nom.Location = new System.Drawing.Point(43, 6);
            this.lb_nom.Name = "lb_nom";
            this.lb_nom.Size = new System.Drawing.Size(0, 13);
            this.lb_nom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom :";
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.lb_tot_ttc);
            this.tabDetail.Controls.Add(this.label9);
            this.tabDetail.Controls.Add(this.lb_tot_ht);
            this.tabDetail.Controls.Add(this.label8);
            this.tabDetail.Controls.Add(this.lv_oder);
            this.tabDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDetail.Location = new System.Drawing.Point(4, 22);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetail.Size = new System.Drawing.Size(449, 197);
            this.tabDetail.TabIndex = 1;
            this.tabDetail.Text = "Détails de la commande";
            this.tabDetail.UseVisualStyleBackColor = true;
            // 
            // lb_tot_ttc
            // 
            this.lb_tot_ttc.AutoSize = true;
            this.lb_tot_ttc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tot_ttc.Location = new System.Drawing.Point(382, 181);
            this.lb_tot_ttc.Name = "lb_tot_ttc";
            this.lb_tot_ttc.Size = new System.Drawing.Size(0, 13);
            this.lb_tot_ttc.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(275, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Total TTC";
            // 
            // lb_tot_ht
            // 
            this.lb_tot_ht.AutoSize = true;
            this.lb_tot_ht.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tot_ht.Location = new System.Drawing.Point(382, 164);
            this.lb_tot_ht.Name = "lb_tot_ht";
            this.lb_tot_ht.Size = new System.Drawing.Size(0, 13);
            this.lb_tot_ht.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(275, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Total TVA";
            // 
            // lv_oder
            // 
            this.lv_oder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.designation,
            this.quantite,
            this.h_taxe,
            this.pu_ht,
            this.pu_tcc});
            this.lv_oder.Location = new System.Drawing.Point(7, 7);
            this.lv_oder.Name = "lv_oder";
            this.lv_oder.Size = new System.Drawing.Size(436, 150);
            this.lv_oder.TabIndex = 0;
            this.lv_oder.UseCompatibleStateImageBehavior = false;
            // 
            // designation
            // 
            this.designation.Text = "Désignation";
            // 
            // quantite
            // 
            this.quantite.Text = "Quantité";
            // 
            // h_taxe
            // 
            this.h_taxe.Text = "TVA";
            // 
            // pu_ht
            // 
            this.pu_ht.Text = "P.U. HT";
            // 
            // pu_tcc
            // 
            this.pu_tcc.Text = "P.U. TTC";
            // 
            // cb_etat
            // 
            this.cb_etat.FormattingEnabled = true;
            this.cb_etat.Items.AddRange(new object[] {
            "Nouvelle",
            "En cours de traitement",
            "Expédiée",
            "Annulée",
            "Remboursée"});
            this.cb_etat.Location = new System.Drawing.Point(109, 39);
            this.cb_etat.Name = "cb_etat";
            this.cb_etat.Size = new System.Drawing.Size(354, 21);
            this.cb_etat.TabIndex = 5;
            this.cb_etat.SelectedIndexChanged += new System.EventHandler(this.cb_etat_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Etat commande :";
            // 
            // chk_notify
            // 
            this.chk_notify.AutoSize = true;
            this.chk_notify.Checked = true;
            this.chk_notify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_notify.Enabled = false;
            this.chk_notify.Location = new System.Drawing.Point(368, 11);
            this.chk_notify.Name = "chk_notify";
            this.chk_notify.Size = new System.Drawing.Size(95, 17);
            this.chk_notify.TabIndex = 7;
            this.chk_notify.Text = "Avertir le client";
            this.chk_notify.UseVisualStyleBackColor = true;
            // 
            // chk_comment
            // 
            this.chk_comment.AutoSize = true;
            this.chk_comment.Location = new System.Drawing.Point(20, 296);
            this.chk_comment.Name = "chk_comment";
            this.chk_comment.Size = new System.Drawing.Size(87, 17);
            this.chk_comment.TabIndex = 8;
            this.chk_comment.Text = "Commentaire";
            this.chk_comment.UseVisualStyleBackColor = true;
            this.chk_comment.Visible = false;
            this.chk_comment.CheckedChanged += new System.EventHandler(this.chk_comment_CheckedChanged);
            // 
            // txt_comment
            // 
            this.txt_comment.Location = new System.Drawing.Point(114, 296);
            this.txt_comment.Multiline = true;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(349, 60);
            this.txt_comment.TabIndex = 9;
            this.txt_comment.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 434);
            this.ControlBox = false;
            this.Controls.Add(this.txt_comment);
            this.Controls.Add(this.chk_comment);
            this.Controls.Add(this.chk_notify);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_etat);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.b_exit);
            this.Controls.Add(this.b_print);
            this.Controls.Add(this.lb_commande);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3";
            this.Text = "Détail de la commande";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabInfos.ResumeLayout(false);
            this.tabInfos.PerformLayout();
            this.tabDetail.ResumeLayout(false);
            this.tabDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_commande;
        private System.Windows.Forms.Button b_print;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfos;
        private System.Windows.Forms.Label lb_tel2;
        private System.Windows.Forms.Label lb_tel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_ville;
        private System.Windows.Forms.Label lb_cp;
        private System.Windows.Forms.Label lb_adr2;
        private System.Windows.Forms.Label lb_adr1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_societe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_prenom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_nom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabDetail;
        private System.Windows.Forms.ComboBox cb_etat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_note;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_email;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView lv_oder;
        private System.Windows.Forms.ColumnHeader designation;
        private System.Windows.Forms.ColumnHeader quantite;
        private System.Windows.Forms.ColumnHeader h_taxe;
        private System.Windows.Forms.ColumnHeader pu_ht;
        private System.Windows.Forms.Label lb_tot_ht;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_tot_ttc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader pu_tcc;
        private System.Windows.Forms.CheckBox chk_notify;
        private System.Windows.Forms.CheckBox chk_comment;
        private System.Windows.Forms.TextBox txt_comment;
    }
}