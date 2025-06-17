namespace yazlab1deneme2
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKategoriFiltre = new System.Windows.Forms.ComboBox();
            this.cmbHazirlamaSuresiFiltre = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbSiralamaSec = new System.Windows.Forms.ComboBox();
            this.btnFiltreleyerekAra = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTarifAdi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHazirlamaSuresi = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTalimatlar = new System.Windows.Forms.TextBox();
            this.btnTarifEkle = new System.Windows.Forms.Button();
            this.btnTarifSil = new System.Windows.Forms.Button();
            this.btnTarifGuncelle = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbMevcutMalzemeSec = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbMevcutMalzemeBirimi = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMevcutMalzemeMiktar = new System.Windows.Forms.TextBox();
            this.btnMevcutMalzemeEkle = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtYeniMalzemeAdi = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtYeniMalzemeBirimFiyat = new System.Windows.Forms.TextBox();
            this.btnYeniMalzemeEkle = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.dataGridViewDetay = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label25 = new System.Windows.Forms.Label();
            this.dataGridViewMalzemeler = new System.Windows.Forms.DataGridView();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbYeniMalzemeBirimi = new System.Windows.Forms.ComboBox();
            this.TarifAdinaGoreAra = new System.Windows.Forms.Button();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.cmbMalzemelerSec = new System.Windows.Forms.CheckedListBox();
            this.MalzemeyeGoreAra = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.numMaliyetAraligiMin = new System.Windows.Forms.NumericUpDown();
            this.numMaliyetAraligiMax = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewTarifOner = new System.Windows.Forms.DataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbTarifOnerMalzemeSec = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbTarifOnerMalzemeBirimi = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTarifOnerMalzemeMiktar = new System.Windows.Forms.TextBox();
            this.btnTarifOnerMalzemeEkle = new System.Windows.Forms.Button();
            this.btnTarifOnerMalzemeReset = new System.Windows.Forms.Button();
            this.btnTarifOner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMalzemeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaliyetAraligiMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaliyetAraligiMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarifOner)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarif Adi:";
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(91, 37);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(236, 22);
            this.txtArama.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kategori Filtreleme:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hazirlanma Süresi Filtreleme:";
            // 
            // cmbKategoriFiltre
            // 
            this.cmbKategoriFiltre.FormattingEnabled = true;
            this.cmbKategoriFiltre.Location = new System.Drawing.Point(228, 206);
            this.cmbKategoriFiltre.Name = "cmbKategoriFiltre";
            this.cmbKategoriFiltre.Size = new System.Drawing.Size(110, 24);
            this.cmbKategoriFiltre.TabIndex = 4;
            // 
            // cmbHazirlamaSuresiFiltre
            // 
            this.cmbHazirlamaSuresiFiltre.FormattingEnabled = true;
            this.cmbHazirlamaSuresiFiltre.Location = new System.Drawing.Point(228, 243);
            this.cmbHazirlamaSuresiFiltre.Name = "cmbHazirlamaSuresiFiltre";
            this.cmbHazirlamaSuresiFiltre.Size = new System.Drawing.Size(110, 24);
            this.cmbHazirlamaSuresiFiltre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maliyet Aralığı Filtreleme: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(190, 342);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "min";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(186, 314);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "max";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 281);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 16);
            this.label19.TabIndex = 44;
            this.label19.Text = "Sıralama Seçimi";
            // 
            // cmbSiralamaSec
            // 
            this.cmbSiralamaSec.FormattingEnabled = true;
            this.cmbSiralamaSec.Location = new System.Drawing.Point(228, 278);
            this.cmbSiralamaSec.Name = "cmbSiralamaSec";
            this.cmbSiralamaSec.Size = new System.Drawing.Size(112, 24);
            this.cmbSiralamaSec.TabIndex = 45;
            // 
            // btnFiltreleyerekAra
            // 
            this.btnFiltreleyerekAra.Location = new System.Drawing.Point(365, 265);
            this.btnFiltreleyerekAra.Name = "btnFiltreleyerekAra";
            this.btnFiltreleyerekAra.Size = new System.Drawing.Size(134, 48);
            this.btnFiltreleyerekAra.TabIndex = 46;
            this.btnFiltreleyerekAra.Text = "Filtreleyerek Ara";
            this.btnFiltreleyerekAra.UseVisualStyleBackColor = true;
            this.btnFiltreleyerekAra.Click += new System.EventHandler(this.btnFiltreleyerekAra_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(513, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "----------------------------------------Tarif Arama ve Filtreleme Bölümü---------" +
    "----------------------------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(521, 16);
            this.label6.TabIndex = 48;
            this.label6.Text = "-----------------------------------------Tarif Öneri Bölümü----------------------" +
    "--------------------------------------";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(640, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(713, 16);
            this.label7.TabIndex = 50;
            this.label7.Text = "-----------------------------------------------------------------------------Tari" +
    "fler Bölümü---------------------------------------------------------------------" +
    "--------";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(544, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 51;
            this.label8.Text = "Tarif Adı:";
            // 
            // txtTarifAdi
            // 
            this.txtTarifAdi.Location = new System.Drawing.Point(620, 429);
            this.txtTarifAdi.Name = "txtTarifAdi";
            this.txtTarifAdi.Size = new System.Drawing.Size(144, 22);
            this.txtTarifAdi.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(785, 432);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 53;
            this.label9.Text = "Hazırlama Süresi (dk):";
            // 
            // txtHazirlamaSuresi
            // 
            this.txtHazirlamaSuresi.Location = new System.Drawing.Point(933, 429);
            this.txtHazirlamaSuresi.Name = "txtHazirlamaSuresi";
            this.txtHazirlamaSuresi.Size = new System.Drawing.Size(144, 22);
            this.txtHazirlamaSuresi.TabIndex = 54;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1083, 432);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 16);
            this.label14.TabIndex = 55;
            this.label14.Text = "Kategori: ";
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(1152, 427);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(144, 24);
            this.cmbKategori.TabIndex = 56;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(544, 471);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 16);
            this.label10.TabIndex = 57;
            this.label10.Text = "Talimatlar:";
            // 
            // txtTalimatlar
            // 
            this.txtTalimatlar.Location = new System.Drawing.Point(620, 460);
            this.txtTalimatlar.Multiline = true;
            this.txtTalimatlar.Name = "txtTalimatlar";
            this.txtTalimatlar.Size = new System.Drawing.Size(676, 52);
            this.txtTalimatlar.TabIndex = 58;
            // 
            // btnTarifEkle
            // 
            this.btnTarifEkle.Location = new System.Drawing.Point(1315, 427);
            this.btnTarifEkle.Name = "btnTarifEkle";
            this.btnTarifEkle.Size = new System.Drawing.Size(119, 27);
            this.btnTarifEkle.TabIndex = 59;
            this.btnTarifEkle.Text = "Tarif Ekle";
            this.btnTarifEkle.UseVisualStyleBackColor = true;
            this.btnTarifEkle.Click += new System.EventHandler(this.btnTarifEkle_Click);
            // 
            // btnTarifSil
            // 
            this.btnTarifSil.Location = new System.Drawing.Point(1315, 460);
            this.btnTarifSil.Name = "btnTarifSil";
            this.btnTarifSil.Size = new System.Drawing.Size(119, 27);
            this.btnTarifSil.TabIndex = 60;
            this.btnTarifSil.Text = "Tarif Sil";
            this.btnTarifSil.UseVisualStyleBackColor = true;
            this.btnTarifSil.Click += new System.EventHandler(this.btnTarifSil_Click);
            // 
            // btnTarifGuncelle
            // 
            this.btnTarifGuncelle.Location = new System.Drawing.Point(1315, 493);
            this.btnTarifGuncelle.Name = "btnTarifGuncelle";
            this.btnTarifGuncelle.Size = new System.Drawing.Size(119, 27);
            this.btnTarifGuncelle.TabIndex = 61;
            this.btnTarifGuncelle.Text = "Tarif Güncelle";
            this.btnTarifGuncelle.UseVisualStyleBackColor = true;
            this.btnTarifGuncelle.Click += new System.EventHandler(this.btnTarifGuncelle_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(553, 523);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(881, 16);
            this.label13.TabIndex = 62;
            this.label13.Text = resources.GetString("label13.Text");
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(544, 568);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 16);
            this.label15.TabIndex = 63;
            this.label15.Text = "Malzeme Seç: ";
            // 
            // cmbMevcutMalzemeSec
            // 
            this.cmbMevcutMalzemeSec.FormattingEnabled = true;
            this.cmbMevcutMalzemeSec.Location = new System.Drawing.Point(645, 565);
            this.cmbMevcutMalzemeSec.Name = "cmbMevcutMalzemeSec";
            this.cmbMevcutMalzemeSec.Size = new System.Drawing.Size(135, 24);
            this.cmbMevcutMalzemeSec.TabIndex = 64;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(785, 568);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 16);
            this.label16.TabIndex = 65;
            this.label16.Text = "Malzeme Birimi:";
            // 
            // cmbMevcutMalzemeBirimi
            // 
            this.cmbMevcutMalzemeBirimi.FormattingEnabled = true;
            this.cmbMevcutMalzemeBirimi.Location = new System.Drawing.Point(892, 565);
            this.cmbMevcutMalzemeBirimi.Name = "cmbMevcutMalzemeBirimi";
            this.cmbMevcutMalzemeBirimi.Size = new System.Drawing.Size(135, 24);
            this.cmbMevcutMalzemeBirimi.TabIndex = 66;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1048, 568);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 16);
            this.label17.TabIndex = 67;
            this.label17.Text = "Malzeme Miktarı:";
            // 
            // txtMevcutMalzemeMiktar
            // 
            this.txtMevcutMalzemeMiktar.Location = new System.Drawing.Point(1161, 567);
            this.txtMevcutMalzemeMiktar.Name = "txtMevcutMalzemeMiktar";
            this.txtMevcutMalzemeMiktar.Size = new System.Drawing.Size(135, 22);
            this.txtMevcutMalzemeMiktar.TabIndex = 68;
            // 
            // btnMevcutMalzemeEkle
            // 
            this.btnMevcutMalzemeEkle.Location = new System.Drawing.Point(1315, 552);
            this.btnMevcutMalzemeEkle.Name = "btnMevcutMalzemeEkle";
            this.btnMevcutMalzemeEkle.Size = new System.Drawing.Size(119, 43);
            this.btnMevcutMalzemeEkle.TabIndex = 69;
            this.btnMevcutMalzemeEkle.Text = " Mevcut Malzeme Ekle";
            this.btnMevcutMalzemeEkle.UseVisualStyleBackColor = true;
            this.btnMevcutMalzemeEkle.Click += new System.EventHandler(this.btnMevcutMalzemeEkle_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(541, 598);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(893, 16);
            this.label20.TabIndex = 70;
            this.label20.Text = resources.GetString("label20.Text");
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(551, 647);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 16);
            this.label21.TabIndex = 71;
            this.label21.Text = "Malzeme Adi:";
            // 
            // txtYeniMalzemeAdi
            // 
            this.txtYeniMalzemeAdi.Location = new System.Drawing.Point(645, 644);
            this.txtYeniMalzemeAdi.Name = "txtYeniMalzemeAdi";
            this.txtYeniMalzemeAdi.Size = new System.Drawing.Size(135, 22);
            this.txtYeniMalzemeAdi.TabIndex = 72;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1080, 647);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 16);
            this.label22.TabIndex = 73;
            this.label22.Text = "Birim Fiyati:";
            // 
            // txtYeniMalzemeBirimFiyat
            // 
            this.txtYeniMalzemeBirimFiyat.Location = new System.Drawing.Point(1161, 644);
            this.txtYeniMalzemeBirimFiyat.Name = "txtYeniMalzemeBirimFiyat";
            this.txtYeniMalzemeBirimFiyat.Size = new System.Drawing.Size(135, 22);
            this.txtYeniMalzemeBirimFiyat.TabIndex = 74;
            // 
            // btnYeniMalzemeEkle
            // 
            this.btnYeniMalzemeEkle.Location = new System.Drawing.Point(1315, 620);
            this.btnYeniMalzemeEkle.Name = "btnYeniMalzemeEkle";
            this.btnYeniMalzemeEkle.Size = new System.Drawing.Size(119, 46);
            this.btnYeniMalzemeEkle.TabIndex = 75;
            this.btnYeniMalzemeEkle.Text = "Yeni Malzeme Ekle";
            this.btnYeniMalzemeEkle.UseVisualStyleBackColor = true;
            this.btnYeniMalzemeEkle.Click += new System.EventHandler(this.btnYeniMalzemeEkle_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(539, 669);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(895, 16);
            this.label23.TabIndex = 76;
            this.label23.Text = resources.GetString("label23.Text");
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewDetay
            // 
            this.dataGridViewDetay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetay.Location = new System.Drawing.Point(1042, 44);
            this.dataGridViewDetay.Name = "dataGridViewDetay";
            this.dataGridViewDetay.RowHeadersWidth = 51;
            this.dataGridViewDetay.RowTemplate.Height = 24;
            this.dataGridViewDetay.Size = new System.Drawing.Size(488, 117);
            this.dataGridViewDetay.TabIndex = 77;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(1209, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(182, 16);
            this.label24.TabIndex = 78;
            this.label24.Text = "----------Detaylar Bölümü---------";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(541, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(486, 333);
            this.dataGridView1.TabIndex = 79;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1209, 182);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(201, 16);
            this.label25.TabIndex = 80;
            this.label25.Text = "----------Malzemeler Bölümü---------";
            // 
            // dataGridViewMalzemeler
            // 
            this.dataGridViewMalzemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMalzemeler.Location = new System.Drawing.Point(1042, 206);
            this.dataGridViewMalzemeler.Name = "dataGridViewMalzemeler";
            this.dataGridViewMalzemeler.RowHeadersWidth = 51;
            this.dataGridViewMalzemeler.RowTemplate.Height = 24;
            this.dataGridViewMalzemeler.Size = new System.Drawing.Size(488, 168);
            this.dataGridViewMalzemeler.TabIndex = 81;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(786, 647);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(101, 16);
            this.label26.TabIndex = 82;
            this.label26.Text = "Malzeme Birimi:";
            // 
            // cmbYeniMalzemeBirimi
            // 
            this.cmbYeniMalzemeBirimi.FormattingEnabled = true;
            this.cmbYeniMalzemeBirimi.Location = new System.Drawing.Point(892, 642);
            this.cmbYeniMalzemeBirimi.Name = "cmbYeniMalzemeBirimi";
            this.cmbYeniMalzemeBirimi.Size = new System.Drawing.Size(135, 24);
            this.cmbYeniMalzemeBirimi.TabIndex = 83;
            // 
            // TarifAdinaGoreAra
            // 
            this.TarifAdinaGoreAra.Location = new System.Drawing.Point(365, 34);
            this.TarifAdinaGoreAra.Name = "TarifAdinaGoreAra";
            this.TarifAdinaGoreAra.Size = new System.Drawing.Size(141, 28);
            this.TarifAdinaGoreAra.TabIndex = 84;
            this.TarifAdinaGoreAra.Text = "Tarif Adina Gore Ara";
            this.TarifAdinaGoreAra.UseVisualStyleBackColor = true;
            this.TarifAdinaGoreAra.Click += new System.EventHandler(this.TarifAdinaGoreAra_Click);
            // 
            // btnSifirla
            // 
            this.btnSifirla.Location = new System.Drawing.Point(374, 141);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(125, 32);
            this.btnSifirla.TabIndex = 85;
            this.btnSifirla.Text = "Sifirla";
            this.btnSifirla.UseVisualStyleBackColor = true;
            this.btnSifirla.Click += new System.EventHandler(this.btnSifirla_Click);
            // 
            // cmbMalzemelerSec
            // 
            this.cmbMalzemelerSec.FormattingEnabled = true;
            this.cmbMalzemelerSec.Location = new System.Drawing.Point(15, 84);
            this.cmbMalzemelerSec.Name = "cmbMalzemelerSec";
            this.cmbMalzemelerSec.Size = new System.Drawing.Size(344, 89);
            this.cmbMalzemelerSec.TabIndex = 86;
            // 
            // MalzemeyeGoreAra
            // 
            this.MalzemeyeGoreAra.Location = new System.Drawing.Point(365, 84);
            this.MalzemeyeGoreAra.Name = "MalzemeyeGoreAra";
            this.MalzemeyeGoreAra.Size = new System.Drawing.Size(141, 41);
            this.MalzemeyeGoreAra.TabIndex = 87;
            this.MalzemeyeGoreAra.Text = "Malzemeye Gore Ara";
            this.MalzemeyeGoreAra.UseVisualStyleBackColor = true;
            this.MalzemeyeGoreAra.Click += new System.EventHandler(this.MalzemeyeGoreAra_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(511, 16);
            this.label18.TabIndex = 88;
            this.label18.Text = "---------------------------------------------------------------------------------" +
    "---------------------------------------------";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(14, 182);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(511, 16);
            this.label27.TabIndex = 89;
            this.label27.Text = "---------------------------------------------------------------------------------" +
    "---------------------------------------------";
            // 
            // numMaliyetAraligiMin
            // 
            this.numMaliyetAraligiMin.Location = new System.Drawing.Point(228, 340);
            this.numMaliyetAraligiMin.Name = "numMaliyetAraligiMin";
            this.numMaliyetAraligiMin.Size = new System.Drawing.Size(112, 22);
            this.numMaliyetAraligiMin.TabIndex = 33;
            // 
            // numMaliyetAraligiMax
            // 
            this.numMaliyetAraligiMax.Location = new System.Drawing.Point(228, 312);
            this.numMaliyetAraligiMax.Name = "numMaliyetAraligiMax";
            this.numMaliyetAraligiMax.Size = new System.Drawing.Size(112, 22);
            this.numMaliyetAraligiMax.TabIndex = 34;
            // 
            // dataGridViewTarifOner
            // 
            this.dataGridViewTarifOner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTarifOner.Location = new System.Drawing.Point(17, 404);
            this.dataGridViewTarifOner.Name = "dataGridViewTarifOner";
            this.dataGridViewTarifOner.RowHeadersWidth = 51;
            this.dataGridViewTarifOner.RowTemplate.Height = 24;
            this.dataGridViewTarifOner.Size = new System.Drawing.Size(376, 135);
            this.dataGridViewTarifOner.TabIndex = 90;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(14, 565);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(95, 16);
            this.label28.TabIndex = 91;
            this.label28.Text = "Malzeme Seç: ";
            // 
            // cmbTarifOnerMalzemeSec
            // 
            this.cmbTarifOnerMalzemeSec.FormattingEnabled = true;
            this.cmbTarifOnerMalzemeSec.Location = new System.Drawing.Point(125, 562);
            this.cmbTarifOnerMalzemeSec.Name = "cmbTarifOnerMalzemeSec";
            this.cmbTarifOnerMalzemeSec.Size = new System.Drawing.Size(121, 24);
            this.cmbTarifOnerMalzemeSec.TabIndex = 92;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 598);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(101, 16);
            this.label29.TabIndex = 93;
            this.label29.Text = "Malzeme Birimi:";
            // 
            // cmbTarifOnerMalzemeBirimi
            // 
            this.cmbTarifOnerMalzemeBirimi.FormattingEnabled = true;
            this.cmbTarifOnerMalzemeBirimi.Location = new System.Drawing.Point(125, 592);
            this.cmbTarifOnerMalzemeBirimi.Name = "cmbTarifOnerMalzemeBirimi";
            this.cmbTarifOnerMalzemeBirimi.Size = new System.Drawing.Size(121, 24);
            this.cmbTarifOnerMalzemeBirimi.TabIndex = 94;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 635);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(107, 16);
            this.label30.TabIndex = 95;
            this.label30.Text = "Malzeme Miktarı:";
            // 
            // txtTarifOnerMalzemeMiktar
            // 
            this.txtTarifOnerMalzemeMiktar.Location = new System.Drawing.Point(125, 629);
            this.txtTarifOnerMalzemeMiktar.Name = "txtTarifOnerMalzemeMiktar";
            this.txtTarifOnerMalzemeMiktar.Size = new System.Drawing.Size(121, 22);
            this.txtTarifOnerMalzemeMiktar.TabIndex = 96;
            // 
            // btnTarifOnerMalzemeEkle
            // 
            this.btnTarifOnerMalzemeEkle.Location = new System.Drawing.Point(269, 559);
            this.btnTarifOnerMalzemeEkle.Name = "btnTarifOnerMalzemeEkle";
            this.btnTarifOnerMalzemeEkle.Size = new System.Drawing.Size(186, 34);
            this.btnTarifOnerMalzemeEkle.TabIndex = 97;
            this.btnTarifOnerMalzemeEkle.Text = "Tarif Oner Malzeme Ekle";
            this.btnTarifOnerMalzemeEkle.UseVisualStyleBackColor = true;
            this.btnTarifOnerMalzemeEkle.Click += new System.EventHandler(this.btnTarifOnerMalzemeEkle_Click);
            // 
            // btnTarifOnerMalzemeReset
            // 
            this.btnTarifOnerMalzemeReset.Location = new System.Drawing.Point(269, 642);
            this.btnTarifOnerMalzemeReset.Name = "btnTarifOnerMalzemeReset";
            this.btnTarifOnerMalzemeReset.Size = new System.Drawing.Size(186, 34);
            this.btnTarifOnerMalzemeReset.TabIndex = 98;
            this.btnTarifOnerMalzemeReset.Text = "Tarif Oner Malzeme Reset";
            this.btnTarifOnerMalzemeReset.UseVisualStyleBackColor = true;
            this.btnTarifOnerMalzemeReset.Click += new System.EventHandler(this.btnTarifOnerMalzemeReset_Click);
            // 
            // btnTarifOner
            // 
            this.btnTarifOner.Location = new System.Drawing.Point(269, 602);
            this.btnTarifOner.Name = "btnTarifOner";
            this.btnTarifOner.Size = new System.Drawing.Size(186, 34);
            this.btnTarifOner.TabIndex = 99;
            this.btnTarifOner.Text = "Tarif Oner ";
            this.btnTarifOner.UseVisualStyleBackColor = true;
            this.btnTarifOner.Click += new System.EventHandler(this.btnTarifOner_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1585, 691);
            this.Controls.Add(this.btnTarifOner);
            this.Controls.Add(this.btnTarifOnerMalzemeReset);
            this.Controls.Add(this.btnTarifOnerMalzemeEkle);
            this.Controls.Add(this.txtTarifOnerMalzemeMiktar);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cmbTarifOnerMalzemeBirimi);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.cmbTarifOnerMalzemeSec);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dataGridViewTarifOner);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.MalzemeyeGoreAra);
            this.Controls.Add(this.cmbMalzemelerSec);
            this.Controls.Add(this.btnSifirla);
            this.Controls.Add(this.TarifAdinaGoreAra);
            this.Controls.Add(this.cmbYeniMalzemeBirimi);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.dataGridViewMalzemeler);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.dataGridViewDetay);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnYeniMalzemeEkle);
            this.Controls.Add(this.txtYeniMalzemeBirimFiyat);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtYeniMalzemeAdi);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnMevcutMalzemeEkle);
            this.Controls.Add(this.txtMevcutMalzemeMiktar);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbMevcutMalzemeBirimi);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbMevcutMalzemeSec);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnTarifGuncelle);
            this.Controls.Add(this.btnTarifSil);
            this.Controls.Add(this.btnTarifEkle);
            this.Controls.Add(this.txtTalimatlar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtHazirlamaSuresi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTarifAdi);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFiltreleyerekAra);
            this.Controls.Add(this.cmbSiralamaSec);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.numMaliyetAraligiMax);
            this.Controls.Add(this.numMaliyetAraligiMin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbHazirlamaSuresiFiltre);
            this.Controls.Add(this.cmbKategoriFiltre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMalzemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaliyetAraligiMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaliyetAraligiMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTarifOner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKategoriFiltre;
        private System.Windows.Forms.ComboBox cmbHazirlamaSuresiFiltre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbSiralamaSec;
        private System.Windows.Forms.Button btnFiltreleyerekAra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTarifAdi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHazirlamaSuresi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTalimatlar;
        private System.Windows.Forms.Button btnTarifEkle;
        private System.Windows.Forms.Button btnTarifSil;
        private System.Windows.Forms.Button btnTarifGuncelle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbMevcutMalzemeSec;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbMevcutMalzemeBirimi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMevcutMalzemeMiktar;
        private System.Windows.Forms.Button btnMevcutMalzemeEkle;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtYeniMalzemeAdi;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtYeniMalzemeBirimFiyat;
        private System.Windows.Forms.Button btnYeniMalzemeEkle;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridView dataGridViewDetay;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridView dataGridViewMalzemeler;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbYeniMalzemeBirimi;
        private System.Windows.Forms.Button TarifAdinaGoreAra;
        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.CheckedListBox cmbMalzemelerSec;
        private System.Windows.Forms.Button MalzemeyeGoreAra;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numMaliyetAraligiMin;
        private System.Windows.Forms.NumericUpDown numMaliyetAraligiMax;
        private System.Windows.Forms.DataGridView dataGridViewTarifOner;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbTarifOnerMalzemeSec;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbTarifOnerMalzemeBirimi;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtTarifOnerMalzemeMiktar;
        private System.Windows.Forms.Button btnTarifOnerMalzemeEkle;
        private System.Windows.Forms.Button btnTarifOnerMalzemeReset;
        private System.Windows.Forms.Button btnTarifOner;
    }
}

