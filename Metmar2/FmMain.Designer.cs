namespace Metmar2
{
    partial class FmMain
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTelefon = new System.Windows.Forms.Label();
            this.lbNazwisko = new System.Windows.Forms.Label();
            this.lbImie = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.klientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelStawkaGdzinowa = new System.Windows.Forms.Label();
            this.buttonUsun = new System.Windows.Forms.Button();
            this.labelStawkaDzien = new System.Windows.Forms.Label();
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.radioButtonStawkaGodzinowa = new System.Windows.Forms.RadioButton();
            this.lbStawkaDbWidok = new System.Windows.Forms.Label();
            this.radioButtonStawkaDobowa = new System.Windows.Forms.RadioButton();
            this.lbStawkaGdWidok = new System.Windows.Forms.Label();
            this.lbCenaWidok = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbCenaStawka = new System.Windows.Forms.Label();
            this.comboboxItem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIlosc = new System.Windows.Forms.TextBox();
            this.textBoxKaucja = new System.Windows.Forms.TextBox();
            this.buttonGeneruj = new System.Windows.Forms.Button();
            this.tbiloscCzas = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxKat = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBoxSuma = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Metmar2.Properties.Resources.logo;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(634, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.Location = new System.Drawing.Point(89, 107);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(124, 24);
            this.textBoxPesel.TabIndex = 115;
            this.textBoxPesel.Leave += new System.EventHandler(this.textBoxPesel_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 112;
            this.label4.Text = "Telefon:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 111;
            this.label3.Text = "Pesel:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 110;
            this.label2.Text = "Nazwisko:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 109;
            this.label1.Text = "Imie:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTelefon);
            this.groupBox1.Controls.Add(this.lbNazwisko);
            this.groupBox1.Controls.Add(this.lbImie);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxPesel);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 186);
            this.groupBox1.TabIndex = 120;
            this.groupBox1.TabStop = false;
            // 
            // lbTelefon
            // 
            this.lbTelefon.AutoSize = true;
            this.lbTelefon.Location = new System.Drawing.Point(313, 158);
            this.lbTelefon.Name = "lbTelefon";
            this.lbTelefon.Size = new System.Drawing.Size(0, 18);
            this.lbTelefon.TabIndex = 123;
            // 
            // lbNazwisko
            // 
            this.lbNazwisko.AutoSize = true;
            this.lbNazwisko.Location = new System.Drawing.Point(313, 134);
            this.lbNazwisko.Name = "lbNazwisko";
            this.lbNazwisko.Size = new System.Drawing.Size(0, 18);
            this.lbNazwisko.TabIndex = 122;
            // 
            // lbImie
            // 
            this.lbImie.AutoSize = true;
            this.lbImie.Location = new System.Drawing.Point(314, 107);
            this.lbImie.Name = "lbImie";
            this.lbImie.Size = new System.Drawing.Size(0, 18);
            this.lbImie.TabIndex = 121;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klientToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 20);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 28);
            this.menuStrip1.TabIndex = 120;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // klientToolStripMenuItem
            // 
            this.klientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edycjaToolStripMenuItem});
            this.klientToolStripMenuItem.Name = "klientToolStripMenuItem";
            this.klientToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.klientToolStripMenuItem.Text = "Klient";
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.edycjaToolStripMenuItem.Text = "Edycja";
            this.edycjaToolStripMenuItem.Click += new System.EventHandler(this.edycjaToolStripMenuItem_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(317, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 18);
            this.label9.TabIndex = 97;
            this.label9.Text = "Kaucja:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(261, 179);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 18);
            this.label11.TabIndex = 95;
            this.label11.Text = "Ilość:";
            // 
            // labelStawkaGdzinowa
            // 
            this.labelStawkaGdzinowa.AutoSize = true;
            this.labelStawkaGdzinowa.Location = new System.Drawing.Point(350, 114);
            this.labelStawkaGdzinowa.Name = "labelStawkaGdzinowa";
            this.labelStawkaGdzinowa.Size = new System.Drawing.Size(54, 18);
            this.labelStawkaGdzinowa.TabIndex = 94;
            this.labelStawkaGdzinowa.Text = "label10";
            // 
            // buttonUsun
            // 
            this.buttonUsun.Location = new System.Drawing.Point(522, 193);
            this.buttonUsun.Name = "buttonUsun";
            this.buttonUsun.Size = new System.Drawing.Size(75, 31);
            this.buttonUsun.TabIndex = 100;
            this.buttonUsun.Text = "Usuń";
            this.buttonUsun.UseVisualStyleBackColor = true;
            this.buttonUsun.Click += new System.EventHandler(this.buttonUsun_Click);
            // 
            // labelStawkaDzien
            // 
            this.labelStawkaDzien.AutoSize = true;
            this.labelStawkaDzien.Location = new System.Drawing.Point(134, 114);
            this.labelStawkaDzien.Name = "labelStawkaDzien";
            this.labelStawkaDzien.Size = new System.Drawing.Size(51, 18);
            this.labelStawkaDzien.TabIndex = 93;
            this.labelStawkaDzien.Text = "Label9";
            // 
            // buttonDodaj
            // 
            this.buttonDodaj.Location = new System.Drawing.Point(441, 194);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(75, 30);
            this.buttonDodaj.TabIndex = 101;
            this.buttonDodaj.Text = "Dodaj";
            this.buttonDodaj.UseVisualStyleBackColor = true;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            // 
            // radioButtonStawkaGodzinowa
            // 
            this.radioButtonStawkaGodzinowa.AutoSize = true;
            this.radioButtonStawkaGodzinowa.Location = new System.Drawing.Point(11, 203);
            this.radioButtonStawkaGodzinowa.Name = "radioButtonStawkaGodzinowa";
            this.radioButtonStawkaGodzinowa.Size = new System.Drawing.Size(158, 22);
            this.radioButtonStawkaGodzinowa.TabIndex = 92;
            this.radioButtonStawkaGodzinowa.Text = "Stawka Godzinowa";
            this.radioButtonStawkaGodzinowa.UseVisualStyleBackColor = true;
            // 
            // lbStawkaDbWidok
            // 
            this.lbStawkaDbWidok.AutoSize = true;
            this.lbStawkaDbWidok.Location = new System.Drawing.Point(10, 114);
            this.lbStawkaDbWidok.Name = "lbStawkaDbWidok";
            this.lbStawkaDbWidok.Size = new System.Drawing.Size(118, 18);
            this.lbStawkaDbWidok.TabIndex = 103;
            this.lbStawkaDbWidok.Text = "Stawka dobowa:";
            // 
            // radioButtonStawkaDobowa
            // 
            this.radioButtonStawkaDobowa.AutoSize = true;
            this.radioButtonStawkaDobowa.Checked = true;
            this.radioButtonStawkaDobowa.Location = new System.Drawing.Point(11, 175);
            this.radioButtonStawkaDobowa.Name = "radioButtonStawkaDobowa";
            this.radioButtonStawkaDobowa.Size = new System.Drawing.Size(138, 22);
            this.radioButtonStawkaDobowa.TabIndex = 91;
            this.radioButtonStawkaDobowa.TabStop = true;
            this.radioButtonStawkaDobowa.Text = "Stawka Dobowa";
            this.radioButtonStawkaDobowa.UseVisualStyleBackColor = true;
            // 
            // lbStawkaGdWidok
            // 
            this.lbStawkaGdWidok.AutoSize = true;
            this.lbStawkaGdWidok.Location = new System.Drawing.Point(203, 114);
            this.lbStawkaGdWidok.Name = "lbStawkaGdWidok";
            this.lbStawkaGdWidok.Size = new System.Drawing.Size(141, 18);
            this.lbStawkaGdWidok.TabIndex = 104;
            this.lbStawkaGdWidok.Text = "Stawka Godzinowa:";
            // 
            // lbCenaWidok
            // 
            this.lbCenaWidok.AutoSize = true;
            this.lbCenaWidok.Location = new System.Drawing.Point(6, 114);
            this.lbCenaWidok.Name = "lbCenaWidok";
            this.lbCenaWidok.Size = new System.Drawing.Size(47, 18);
            this.lbCenaWidok.TabIndex = 105;
            this.lbCenaWidok.Text = "Cena:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 18);
            this.label8.TabIndex = 88;
            this.label8.Text = "Nazwa Sprzętu";
            // 
            // lbCenaStawka
            // 
            this.lbCenaStawka.AutoSize = true;
            this.lbCenaStawka.Location = new System.Drawing.Point(63, 114);
            this.lbCenaStawka.Name = "lbCenaStawka";
            this.lbCenaStawka.Size = new System.Drawing.Size(54, 18);
            this.lbCenaStawka.TabIndex = 106;
            this.lbCenaStawka.Text = "label12";
            // 
            // comboboxItem
            // 
            this.comboboxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxItem.FormattingEnabled = true;
            this.comboboxItem.Location = new System.Drawing.Point(13, 85);
            this.comboboxItem.Name = "comboboxItem";
            this.comboboxItem.Size = new System.Drawing.Size(615, 26);
            this.comboboxItem.TabIndex = 90;
            this.comboboxItem.SelectedIndexChanged += new System.EventHandler(this.comboboxItem_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 108;
            this.label5.Text = "Godz./Dni:";
            // 
            // textBoxIlosc
            // 
            this.textBoxIlosc.Location = new System.Drawing.Point(264, 200);
            this.textBoxIlosc.Name = "textBoxIlosc";
            this.textBoxIlosc.Size = new System.Drawing.Size(50, 24);
            this.textBoxIlosc.TabIndex = 96;
            // 
            // textBoxKaucja
            // 
            this.textBoxKaucja.Location = new System.Drawing.Point(320, 200);
            this.textBoxKaucja.Name = "textBoxKaucja";
            this.textBoxKaucja.Size = new System.Drawing.Size(83, 24);
            this.textBoxKaucja.TabIndex = 98;
            // 
            // buttonGeneruj
            // 
            this.buttonGeneruj.Location = new System.Drawing.Point(500, 119);
            this.buttonGeneruj.Name = "buttonGeneruj";
            this.buttonGeneruj.Size = new System.Drawing.Size(125, 36);
            this.buttonGeneruj.TabIndex = 117;
            this.buttonGeneruj.Text = "Generuj Umowę";
            this.buttonGeneruj.UseVisualStyleBackColor = true;
            this.buttonGeneruj.Click += new System.EventHandler(this.buttonGeneruj_Click);
            // 
            // tbiloscCzas
            // 
            this.tbiloscCzas.Location = new System.Drawing.Point(185, 200);
            this.tbiloscCzas.Name = "tbiloscCzas";
            this.tbiloscCzas.Size = new System.Drawing.Size(73, 24);
            this.tbiloscCzas.TabIndex = 107;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(23, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(602, 94);
            this.listBox1.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 18);
            this.label6.TabIndex = 87;
            this.label6.Text = "Kategoria Sprzętu";
            // 
            // comboBoxKat
            // 
            this.comboBoxKat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKat.FormattingEnabled = true;
            this.comboBoxKat.Location = new System.Drawing.Point(13, 35);
            this.comboBoxKat.Name = "comboBoxKat";
            this.comboBoxKat.Size = new System.Drawing.Size(322, 26);
            this.comboBoxKat.TabIndex = 89;
            this.comboBoxKat.SelectedIndexChanged += new System.EventHandler(this.comboBoxKat_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.comboBoxKat);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbiloscCzas);
            this.groupBox2.Controls.Add(this.textBoxKaucja);
            this.groupBox2.Controls.Add(this.textBoxIlosc);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboboxItem);
            this.groupBox2.Controls.Add(this.lbCenaStawka);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbCenaWidok);
            this.groupBox2.Controls.Add(this.lbStawkaGdWidok);
            this.groupBox2.Controls.Add(this.radioButtonStawkaDobowa);
            this.groupBox2.Controls.Add(this.lbStawkaDbWidok);
            this.groupBox2.Controls.Add(this.radioButtonStawkaGodzinowa);
            this.groupBox2.Controls.Add(this.buttonDodaj);
            this.groupBox2.Controls.Add(this.labelStawkaDzien);
            this.groupBox2.Controls.Add(this.buttonUsun);
            this.groupBox2.Controls.Add(this.labelStawkaGdzinowa);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(640, 399);
            this.groupBox2.TabIndex = 121;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBoxSuma);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.buttonGeneruj);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(634, 161);
            this.groupBox3.TabIndex = 118;
            this.groupBox3.TabStop = false;
            // 
            // txtBoxSuma
            // 
            this.txtBoxSuma.Enabled = false;
            this.txtBoxSuma.Location = new System.Drawing.Point(75, 121);
            this.txtBoxSuma.Name = "txtBoxSuma";
            this.txtBoxSuma.Size = new System.Drawing.Size(100, 24);
            this.txtBoxSuma.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 18);
            this.label7.TabIndex = 118;
            this.label7.Text = "Suma: ";
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 577);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Metmar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxPesel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelStawkaGdzinowa;
        private System.Windows.Forms.Button buttonUsun;
        private System.Windows.Forms.Label labelStawkaDzien;
        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.RadioButton radioButtonStawkaGodzinowa;
        private System.Windows.Forms.Label lbStawkaDbWidok;
        private System.Windows.Forms.RadioButton radioButtonStawkaDobowa;
        private System.Windows.Forms.Label lbStawkaGdWidok;
        private System.Windows.Forms.Label lbCenaWidok;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbCenaStawka;
        private System.Windows.Forms.ComboBox comboboxItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIlosc;
        private System.Windows.Forms.TextBox textBoxKaucja;
        private System.Windows.Forms.Button buttonGeneruj;
        private System.Windows.Forms.TextBox tbiloscCzas;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxKat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lbTelefon;
        private System.Windows.Forms.Label lbNazwisko;
        private System.Windows.Forms.Label lbImie;
        private System.Windows.Forms.ToolStripMenuItem klientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.TextBox txtBoxSuma;
        private System.Windows.Forms.Label label7;
    }
}

