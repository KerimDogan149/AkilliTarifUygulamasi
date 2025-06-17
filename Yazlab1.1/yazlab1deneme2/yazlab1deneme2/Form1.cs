using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace yazlab1deneme2
{
    public partial class Form1 : Form
    {

        private int secilenTarifID = -1;  // Seçilen tarifin ID'sini saklamak için bir değişken
        public Form1()
        {
            InitializeComponent();

            // DataGridView için SelectionChanged olayını bağla
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        SQLiteConnection baglan = new SQLiteConnection(@"Data source=C:\Users\kerim\source\repos\yazlab1deneme2\yazlab1deneme2\bin\Debug\projeveritabani.db");

        private void Form1_Load(object sender, EventArgs e)
        {
            // Veritabanı bağlantısını kontrol et
            try
            {
                baglan.Open();
                MessageBox.Show("Veritabanına başarılı bir şekilde bağlanıldı.", "Bağlantı Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanılamadı: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }



            // Kategorileri ComboBox'a ekle
            cmbKategori.Items.AddRange(new string[] { "AnaYemek", "Tatli", "Salata", "Corba", "Baslangic", "Makarnalar", "Deniz Ürünleri", "Sandviç", "Burger", "Pizza" });
            cmbKategori.SelectedIndex = 0;

            // Sıralama seçimi için seçenekler
            cmbSiralamaSec.Items.Add("Seçiniz"); // Null gibi davranacak seçenek
            cmbSiralamaSec.Items.AddRange(new string[] { "Maliyet Artan", "Maliyet Azalan" });
            cmbSiralamaSec.SelectedIndex = 0; // Varsayılan olarak maliyet artan seçili olsun

            // Kategoriyi sıralama filtresi için de kullanıyoruz

            cmbKategoriFiltre.Items.Add("Seçiniz"); // Null gibi davranan varsayılan seçenek
            cmbKategoriFiltre.Items.AddRange(new string[] { "AnaYemek", "Tatli", "Salata", "Corba", "Baslangic", "Makarnalar", "Deniz Ürünleri", "Sandviç", "Burger", "Pizza" });
            cmbKategoriFiltre.SelectedIndex = 0; // Varsayılan olarak "Seçiniz" seçili olsun

            // Hazırlama süresi sıralama seçenekleri
            cmbHazirlamaSuresiFiltre.Items.Add("Seçiniz"); // Null gibi davranacak seçenek
            cmbHazirlamaSuresiFiltre.Items.AddRange(new string[] { "En Hızlıdan", "En Yavaştan" });
            cmbHazirlamaSuresiFiltre.SelectedIndex = 0; // Varsayılan olarak "Seçiniz" seçili olsun

            ////////
            DataGridViewSutunlariniEkle();
            cmbTarifOnerMalzemeBirimi.Items.AddRange(new string[] { "g", "ml" });
            cmbTarifOnerMalzemeBirimi.SelectedIndex = 0; // Varsayılan olarak gram birimini seçili yap
            MalzemeleriYukleTarifOner();




            // Tabloların var olup olmadığını kontrol et
            CheckIfTablesExist();


            MevcutMalzemeleriYukle();

            cmbMevcutMalzemeBirimi.Items.AddRange(new string[] { "g", "ml" });
            cmbMevcutMalzemeBirimi.SelectedIndex = 0; // Varsayılan olarak gram birimini seçili yap
            cmbYeniMalzemeBirimi.Items.AddRange(new string[] { "g", "ml" });
            cmbYeniMalzemeBirimi.SelectedIndex = 0; // Varsayılan olarak gram birimini seçili yap

            // Malzemeleri CheckedListBox'a yükle
            MevcutMalzemeleriYukleCmb();

            // Tarifleri listele
            listele();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["TarifID"].Value != null)
            {
                secilenTarifID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TarifID"].Value);
                MessageBox.Show("Seçilen Tarif ID: " + secilenTarifID.ToString());

                // Seçili tarifin detaylarını göster
                TarifDetayGoster(secilenTarifID);

                // Seçilen tarifin malzemelerini göster
                TarifMalzemeleriniGoster(secilenTarifID);

                // Seçili tarifin maliyetini hesapla
                TarifMaliyetiHesapla(secilenTarifID);

            }
            else
            {
                secilenTarifID = -1;
                MessageBox.Show("Hiçbir tarif seçilmedi.");
            }
        }


        private void TarifDetayGoster(int tarifID)
        {
            string query = "SELECT TarifAdi, Kategori, HazirlamaSuresi, Talimatlar FROM tarifler WHERE TarifID = @TarifID";
            SQLiteCommand komut = new SQLiteCommand(query, baglan);
            komut.Parameters.AddWithValue("@TarifID", tarifID);

            if (baglan.State == ConnectionState.Closed)
                baglan.Open();

            SQLiteDataReader reader = komut.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Columns.Add("Tarif Adı");
            dt.Columns.Add("Kategori");
            dt.Columns.Add("Hazırlama Süresi (dk)");
            dt.Columns.Add("Talimatlar");

            if (reader.Read())
            {
                dt.Rows.Add(reader["TarifAdi"].ToString(), reader["Kategori"].ToString(), reader["HazirlamaSuresi"].ToString(), reader["Talimatlar"].ToString());
            }

            dataGridViewDetay.DataSource = dt;

            reader.Close();

            if (baglan.State == ConnectionState.Open)
                baglan.Close();
        }

        public void listele()
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();

                // Tarifleri çekmek için SQL sorgusu
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT TarifID, TarifAdi, HazirlamaSuresi FROM tarifler", baglan);
                DataSet dset = new DataSet();
                adapter.Fill(dset, "tarifler");

                // DataGridView'e verileri atıyoruz
                dataGridView1.DataSource = dset.Tables[0];

                // Sıra numarası sütunu kontrol edilip ekleniyor
                if (!dataGridView1.Columns.Contains("SiraNo"))
                {
                    DataGridViewTextBoxColumn siraNoColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Sıra No",
                        Name = "SiraNo",
                        ReadOnly = true
                    };
                    dataGridView1.Columns.Insert(0, siraNoColumn);
                }

                // Maliyet sütunu kontrol edilip ekleniyor
                if (!dataGridView1.Columns.Contains("Maliyet"))
                {
                    DataGridViewTextBoxColumn maliyetColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Maliyet",
                        Name = "Maliyet",
                        ReadOnly = true
                    };
                    dataGridView1.Columns.Add(maliyetColumn);
                }

                // Sıra numarası ve maliyet alanları dolduruluyor
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // Sıra numarası
                    dataGridView1.Rows[i].Cells["SiraNo"].Value = (i + 1).ToString();

                    // Maliyet hesaplanıyor ve hücreye atanıyor
                    int tarifId = Convert.ToInt32(dataGridView1.Rows[i].Cells["TarifID"].Value);
                    decimal maliyet = TarifMaliyetiHesapla(tarifId);  // Maliyet hesaplama fonksiyonunu çağırıyoruz
                    dataGridView1.Rows[i].Cells["Maliyet"].Value = maliyet.ToString("C2"); // Maliyeti para birimi formatında gösteriyoruz
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarifler listelenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }
        }

        private void btnTarifEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTarifAdi.Text) ||
                string.IsNullOrWhiteSpace(cmbKategori.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(txtHazirlamaSuresi.Text) ||
                string.IsNullOrWhiteSpace(txtTalimatlar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtHazirlamaSuresi.Text, out int hazirlamaSuresi))
            {
                MessageBox.Show("Hazırlama süresi sayısal bir değer olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();

                string ekleSQL = "INSERT INTO tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar) VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar)";
                SQLiteCommand komut = new SQLiteCommand(ekleSQL, baglan);

                komut.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);
                komut.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                komut.Parameters.AddWithValue("@Talimatlar", txtTalimatlar.Text);

                komut.ExecuteNonQuery();
                MessageBox.Show("Tarif başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarif eklenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }

            listele();
        }

        private void btnTarifGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir tarif seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tarifId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TarifID"].Value);

            if (string.IsNullOrWhiteSpace(txtTarifAdi.Text) ||
                string.IsNullOrWhiteSpace(cmbKategori.SelectedItem?.ToString()) ||
                string.IsNullOrWhiteSpace(txtHazirlamaSuresi.Text) ||
                string.IsNullOrWhiteSpace(txtTalimatlar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtHazirlamaSuresi.Text, out int hazirlamaSuresi))
            {
                MessageBox.Show("Hazırlama süresi sayısal bir değer olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();

                string guncelleSQL = "UPDATE tarifler SET TarifAdi = @TarifAdi, Kategori = @Kategori, HazirlamaSuresi = @HazirlamaSuresi, Talimatlar = @Talimatlar WHERE TarifID = @TarifID";
                SQLiteCommand komut = new SQLiteCommand(guncelleSQL, baglan);

                komut.Parameters.AddWithValue("@TarifAdi", txtTarifAdi.Text);
                komut.Parameters.AddWithValue("@Kategori", cmbKategori.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                komut.Parameters.AddWithValue("@Talimatlar", txtTalimatlar.Text);
                komut.Parameters.AddWithValue("@TarifID", tarifId);

                komut.ExecuteNonQuery();
                MessageBox.Show("Tarif başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarif güncellenemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }

            listele();
        }

        // TARİF SİLME İŞLEMİ
        private void btnTarifSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir tarif seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tarifId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TarifID"].Value);

            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();

                // Tarif silme işlemi
                string silSQL = "DELETE FROM tarifler WHERE TarifID = @TarifID";
                SQLiteCommand komut = new SQLiteCommand(silSQL, baglan);
                komut.Parameters.AddWithValue("@TarifID", tarifId);

                komut.ExecuteNonQuery();
                MessageBox.Show("Tarif başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarif silinemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }

            listele();
        }

        private void TarifMalzemeleriniGoster(int tarifID)
        {
            string query = "SELECT Malzemeler.MalzemeAdi, TarifMalzeme.MalzemeMiktar, Malzemeler.MalzemeBirim " +
                           "FROM TarifMalzeme " +
                           "JOIN Malzemeler ON TarifMalzeme.MalzemeID = Malzemeler.MalzemeID " +
                           "WHERE TarifMalzeme.TarifID = @tarifID";

            using (SQLiteConnection connection = new SQLiteConnection(baglan.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tarifID", tarifID);

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable malzemeler = new DataTable();
                            adapter.Fill(malzemeler);

                            dataGridViewMalzemeler.DataSource = malzemeler;

                            if (dataGridViewMalzemeler.Columns.Count > 0)
                            {
                                dataGridViewMalzemeler.Columns[0].HeaderText = "Malzeme Adı";
                                dataGridViewMalzemeler.Columns[1].HeaderText = "Miktar";
                                dataGridViewMalzemeler.Columns[2].HeaderText = "Birim";
                            }
                        }
                    }
                }
                catch (SQLiteException sqlEx)
                {
                    MessageBox.Show("SQL Hatası: " + sqlEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MevcutMalzemeleriYukle()
        {
            // Malzemeler ComboBox'unu temizleyin
            cmbMevcutMalzemeSec.Items.Clear();

            try
            {
                // Veritabanı bağlantısı açık değilse aç
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                }

                // Malzeme adlarını veritabanından al
                string query = "SELECT MalzemeAdi FROM Malzemeler";
                SQLiteCommand command = new SQLiteCommand(query, baglan);
                SQLiteDataReader reader = command.ExecuteReader();

                // Veritabanından alınan her malzeme adını ComboBox'a ekleyin
                while (reader.Read())
                {
                    cmbMevcutMalzemeSec.Items.Add(reader["MalzemeAdi"].ToString());
                }

                // Varsayılan olarak ilk öğeyi seçili yapabilirsiniz (isteğe bağlı)
                if (cmbMevcutMalzemeSec.Items.Count > 0)
                {
                    cmbMevcutMalzemeSec.SelectedIndex = 0; // İlk malzemeyi seçili yap
                }

                reader.Close();
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show("Veritabanı hatası: " + sqlEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bağlantıyı kapat
                if (baglan.State == ConnectionState.Open)
                {
                    baglan.Close();
                }
            }
        }






        private void CheckIfTablesExist()
        {
            string query = "SELECT name FROM sqlite_master WHERE type='table' AND name='TarifMalzeme'";

            using (SQLiteConnection connection = new SQLiteConnection(baglan.ConnectionString))
            {
                try
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("TarifMalzeme tablosu veritabanında bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("SQL Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMevcutMalzemeEkle_Click(object sender, EventArgs e)
        {
            // Eğer tarif seçilmediyse uyarı ver
            if (secilenTarifID == -1)
            {
                MessageBox.Show("Lütfen önce bir tarif seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Girdi doğrulaması
            if (cmbMevcutMalzemeSec.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir malzeme seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMevcutMalzemeMiktar.Text))
            {
                MessageBox.Show("Lütfen malzeme miktarını girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbMevcutMalzemeBirimi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen malzeme birimini seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Miktarın doğru formatta olup olmadığını kontrol et
            if (!double.TryParse(txtMevcutMalzemeMiktar.Text, out double malzemeMiktar))
            {
                MessageBox.Show("Malzeme miktarı sayısal bir değer olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedMalzeme = cmbMevcutMalzemeSec.SelectedItem.ToString();
            string malzemeBirim = cmbMevcutMalzemeBirimi.SelectedItem.ToString();

            try
            {
                // Bağlantı kapalıysa aç
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    MessageBox.Show("Veritabanı bağlantısı açıldı.");
                }

                // Seçilen tarif için bu malzeme daha önce eklenmiş mi kontrol et
                string checkQuery = "SELECT MalzemeMiktar FROM TarifMalzeme WHERE TarifID = @TarifID AND MalzemeID = (SELECT MalzemeID FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi)";
                SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, baglan);
                checkCommand.Parameters.AddWithValue("@TarifID", secilenTarifID);
                checkCommand.Parameters.AddWithValue("@MalzemeAdi", selectedMalzeme);

                object result = checkCommand.ExecuteScalar();

                if (result != null)
                {
                    // Malzeme mevcutsa miktarı güncelle
                    double currentMiktar = Convert.ToDouble(result);
                    string updateQuery = "UPDATE TarifMalzeme SET MalzemeMiktar = @NewMiktar, MalzemeBirim = @MalzemeBirim WHERE TarifID = @TarifID AND MalzemeID = (SELECT MalzemeID FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi)";
                    SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, baglan);
                    updateCommand.Parameters.AddWithValue("@NewMiktar", currentMiktar + malzemeMiktar);
                    updateCommand.Parameters.AddWithValue("@MalzemeBirim", malzemeBirim);
                    updateCommand.Parameters.AddWithValue("@TarifID", secilenTarifID);
                    updateCommand.Parameters.AddWithValue("@MalzemeAdi", selectedMalzeme);
                    updateCommand.ExecuteNonQuery();
                    MessageBox.Show("Malzeme miktarı başarıyla güncellendi!");
                }
                else
                {
                    // Malzeme eklenmemişse yeni malzeme ekle
                    string insertQuery = "INSERT INTO TarifMalzeme (TarifID, MalzemeID, MalzemeMiktar, MalzemeBirim) VALUES (@TarifID, (SELECT MalzemeID FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi), @MalzemeMiktar, @MalzemeBirim)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, baglan);
                    insertCommand.Parameters.AddWithValue("@TarifID", secilenTarifID);
                    insertCommand.Parameters.AddWithValue("@MalzemeAdi", selectedMalzeme);
                    insertCommand.Parameters.AddWithValue("@MalzemeMiktar", malzemeMiktar);
                    insertCommand.Parameters.AddWithValue("@MalzemeBirim", malzemeBirim);
                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("Malzeme başarıyla tarife eklendi!");
                }

                // Malzeme eklendikten sonra dataGridViewMalzemeler'i yenile
                TarifMalzemeleriniGoster(secilenTarifID);
                listele(); // Tarif listesini yeniden yükle

            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show("SQL Hatası: " + sqlEx.Message + "\nStackTrace: " + sqlEx.StackTrace, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik hata: " + ex.Message + "\nStackTrace: " + ex.StackTrace, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // İşlem tamamlandıktan sonra veritabanı bağlantısını kapat
                if (baglan.State == ConnectionState.Open)
                {
                    baglan.Close();
                    MessageBox.Show("Veritabanı bağlantısı kapatıldı.");
                }
            }
        }


        private void btnYeniMalzemeEkle_Click(object sender, EventArgs e)
        {
            // Malzeme adı ve birim kontrolü
            if (string.IsNullOrWhiteSpace(txtYeniMalzemeAdi.Text))
            {
                MessageBox.Show("Lütfen malzeme adını girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbYeniMalzemeBirimi.SelectedItem?.ToString()))
            {
                MessageBox.Show("Lütfen malzeme birimini seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Malzeme birim fiyatının sayısal olup olmadığını kontrol et
            if (!decimal.TryParse(txtYeniMalzemeBirimFiyat.Text, out decimal malzemeBirimFiyat))
            {
                MessageBox.Show("Lütfen geçerli bir birim fiyatı girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string yeniMalzemeAdi = txtYeniMalzemeAdi.Text;
            string malzemeBirim = cmbYeniMalzemeBirimi.SelectedItem.ToString(); // Malzeme birimi alınıyor

            try
            {
                // Bağlantı kapalıysa aç
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                }

                // Veritabanında malzemenin zaten var olup olmadığını kontrol et
                string checkQuery = "SELECT COUNT(*) FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
                SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, baglan);
                checkCommand.Parameters.AddWithValue("@MalzemeAdi", yeniMalzemeAdi);

                // Eğer sonuç 0'dan büyükse, malzeme zaten var demektir
                int malzemeSayisi = Convert.ToInt32(checkCommand.ExecuteScalar());
                if (malzemeSayisi > 0)
                {
                    MessageBox.Show("Bu malzeme zaten mevcut, lütfen başka bir malzeme adı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Yeni malzemeyi veritabanına eklemek için SQL sorgusu
                string insertQuery = "INSERT INTO Malzemeler (MalzemeAdi, BirimFiyat, MalzemeBirim) VALUES (@MalzemeAdi, @BirimFiyat, @MalzemeBirim)";
                SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, baglan);
                insertCommand.Parameters.AddWithValue("@MalzemeAdi", yeniMalzemeAdi);
                insertCommand.Parameters.AddWithValue("@BirimFiyat", malzemeBirimFiyat);
                insertCommand.Parameters.AddWithValue("@MalzemeBirim", malzemeBirim);

                insertCommand.ExecuteNonQuery();

                MessageBox.Show("Yeni malzeme başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Malzemeler listesini yenileme işlemi burada yapılabilir (Mevcut malzeme listesini yeniden yükle)
                MevcutMalzemeleriYukle(); // Malzeme listesini güncellemek için kullanılıyor olabilir.

                // TextBox'ları temizle
                txtYeniMalzemeAdi.Clear();
                txtYeniMalzemeBirimFiyat.Clear();
                cmbYeniMalzemeBirimi.SelectedIndex = -1;
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show("SQL Hatası: " + sqlEx.Message + "\nStackTrace: " + sqlEx.StackTrace, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik hata: " + ex.Message + "\nStackTrace: " + ex.StackTrace, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // İşlem tamamlandıktan sonra veritabanı bağlantısını kapat
                if (baglan.State == ConnectionState.Open)
                {
                    baglan.Close();
                }
            }
        }

        private decimal TarifMaliyetiHesapla(int tarifID)
        {
            decimal toplamMaliyet = 0;

            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                }

                // Tarifin tüm malzemelerinin birim fiyatı ve miktarı üzerinden maliyet hesaplama
                string query = @"
            SELECT 
                Malzemeler.BirimFiyat, 
                TarifMalzeme.MalzemeMiktar 
            FROM 
                TarifMalzeme 
            JOIN 
                Malzemeler ON TarifMalzeme.MalzemeID = Malzemeler.MalzemeID 
            WHERE 
                TarifMalzeme.TarifID = @TarifID";

                SQLiteCommand command = new SQLiteCommand(query, baglan);
                command.Parameters.AddWithValue("@TarifID", tarifID);

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    decimal birimFiyat = reader["BirimFiyat"] != DBNull.Value ? Convert.ToDecimal(reader["BirimFiyat"]) : 0;
                    double miktar = reader["MalzemeMiktar"] != DBNull.Value ? Convert.ToDouble(reader["MalzemeMiktar"]) : 0;

                    toplamMaliyet += birimFiyat * (decimal)miktar;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Maliyet hesaplanırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                {
                    baglan.Close();
                }
            }

            return toplamMaliyet;
        }

        private void TarifAdinaGoreAra_Click(object sender, EventArgs e)
        {
            // Arama metni txtArama adlı TextBox'tan alınıyor
            string aramaMetni = txtArama.Text.Trim();

            try
            {
                // Veritabanı bağlantısı kapalıysa açılıyor
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();

                // Eğer arama metni boşsa tüm tarifleri göster, doluysa filtre uygula
                string query;
                if (string.IsNullOrEmpty(aramaMetni))
                {
                    query = "SELECT TarifID, TarifAdi, HazirlamaSuresi FROM tarifler";
                }
                else
                {
                    query = "SELECT TarifID, TarifAdi, HazirlamaSuresi FROM tarifler WHERE TarifAdi LIKE @AramaMetni";
                }

                SQLiteCommand command = new SQLiteCommand(query, baglan);
                if (!string.IsNullOrEmpty(aramaMetni))
                {
                    command.Parameters.AddWithValue("@AramaMetni", "%" + aramaMetni + "%");
                }

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataSet dset = new DataSet();
                adapter.Fill(dset, "tarifler");

                // Sonuçları DataGridView'de göster
                dataGridView1.DataSource = dset.Tables[0];

                // Sıra numarası ve maliyet sütunlarını güncelleme
                if (!dataGridView1.Columns.Contains("SiraNo"))
                {
                    DataGridViewTextBoxColumn siraNoColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Sıra No",
                        Name = "SiraNo",
                        ReadOnly = true
                    };
                    dataGridView1.Columns.Insert(0, siraNoColumn);
                }

                if (!dataGridView1.Columns.Contains("Maliyet"))
                {
                    DataGridViewTextBoxColumn maliyetColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Maliyet",
                        Name = "Maliyet",
                        ReadOnly = true
                    };
                    dataGridView1.Columns.Add(maliyetColumn);
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["SiraNo"].Value = (i + 1).ToString();
                    dataGridView1.Rows[i].Cells["Maliyet"].Value = ""; // Maliyet boş bırakılıyor, ileride hesaplanacak
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tarif arama işlemi sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            // Arama çubuğunu temizle
            txtArama.Clear();

            // Tüm tarifleri listele
            listele();
        }

        private void MalzemeyeGoreAra_Click(object sender, EventArgs e)
        {
            // Kullanıcının seçtiği malzemeleri alıyoruz
            List<string> secilenMalzemeler = new List<string>();
            foreach (var item in cmbMalzemelerSec.CheckedItems)
            {
                secilenMalzemeler.Add(item.ToString());
            }

            // Eğer malzeme seçilmemişse uyarı ver
            if (secilenMalzemeler.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir malzeme seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(baglan.ConnectionString))
                {
                    connection.Open();

                    // Tariflerin malzemelerini ve tarif ID'lerini alıyoruz
                    string query = @"
            SELECT 
                TarifMalzeme.TarifID, 
                GROUP_CONCAT(Malzemeler.MalzemeAdi, ',') AS TarifMalzemeleri 
            FROM 
                TarifMalzeme 
            JOIN 
                Malzemeler ON TarifMalzeme.MalzemeID = Malzemeler.MalzemeID 
            GROUP BY 
                TarifMalzeme.TarifID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable tariflerTablosu = new DataTable();
                            adapter.Fill(tariflerTablosu);

                            List<TarifEslesme> eslesmeler = new List<TarifEslesme>();

                            // Her tarif için malzemeleri kontrol edip eşleşme yüzdesini hesaplıyoruz
                            foreach (DataRow row in tariflerTablosu.Rows)
                            {
                                int tarifID = Convert.ToInt32(row["TarifID"]);
                                string tarifMalzemeleri = row["TarifMalzemeleri"].ToString().ToLower();
                                string[] tarifMalzemeListesi = tarifMalzemeleri.Split(',');

                                // Eşleşen malzeme sayısını hesapla
                                int eslesenMalzemeSayisi = secilenMalzemeler.Where(malzeme => tarifMalzemeListesi.Contains(malzeme.ToLower())).Count();

                                // Toplam malzeme sayısı ve eşleşme yüzdesi
                                int toplamMalzemeSayisi = tarifMalzemeListesi.Length;
                                double eslesmeYuzdesi = toplamMalzemeSayisi > 0 ? ((double)eslesenMalzemeSayisi / toplamMalzemeSayisi) * 100 : 0;

                                // Sadece eşleşme yüzdesi sıfırdan büyük olanları listeye ekliyoruz
                                if (eslesmeYuzdesi > 0)
                                {
                                    eslesmeler.Add(new TarifEslesme
                                    {
                                        TarifID = tarifID,
                                        EslesmeYuzdesi = eslesmeYuzdesi
                                    });
                                }
                            }

                            // Eşleşmeleri en yüksekten en düşüğe doğru sıralıyoruz
                            eslesmeler = eslesmeler.OrderByDescending(eslesme => eslesme.EslesmeYuzdesi).ToList();

                            // Eşleşme yüzdesiyle birlikte tarifleri ekranda gösterme
                            DataTable sonucTablosu = new DataTable();
                            sonucTablosu.Columns.Add("TarifID");
                            sonucTablosu.Columns.Add("TarifAdi");
                            sonucTablosu.Columns.Add("EslesmeYuzdesi");
                            sonucTablosu.Columns.Add("Maliyet");

                            foreach (var eslesme in eslesmeler)
                            {
                                // Tarifin adını bulmak için yeni bir sorgu yapıyoruz
                                string tarifAdiQuery = "SELECT TarifAdi FROM tarifler WHERE TarifID = @TarifID";
                                using (SQLiteCommand tarifAdiCommand = new SQLiteCommand(tarifAdiQuery, connection))
                                {
                                    tarifAdiCommand.Parameters.AddWithValue("@TarifID", eslesme.TarifID);
                                    object tarifAdiObj = tarifAdiCommand.ExecuteScalar();

                                    // Null kontrolü
                                    string tarifAdi = tarifAdiObj != null ? tarifAdiObj.ToString() : "Bilinmiyor";

                                    // Maliyeti Hesapla
                                    decimal maliyet = TarifMaliyetiHesapla(eslesme.TarifID);

                                    sonucTablosu.Rows.Add(eslesme.TarifID, tarifAdi, eslesme.EslesmeYuzdesi.ToString("F2") + "%", maliyet.ToString("C2"));
                                }
                            }

                            // Sonuçları DataGridView'de gösteriyoruz
                            dataGridView1.DataSource = sonucTablosu;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Malzemeye göre arama sırasında hata oluştu: " + ex.Message);
            }
        }

        class TarifEslesme
        {
            public int TarifID { get; set; }
            public double EslesmeYuzdesi { get; set; }
        }
        private void MevcutMalzemeleriYukleCmb()
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();

                // Mevcut malzemeleri veritabanından çekiyoruz
                string query = "SELECT MalzemeAdi FROM Malzemeler";
                SQLiteCommand command = new SQLiteCommand(query, baglan);
                SQLiteDataReader reader = command.ExecuteReader();

                // CheckedListBox'ı temizliyoruz
                cmbMalzemelerSec.Items.Clear();

                // Veritabanından çekilen her malzemeyi listeye ekliyoruz
                while (reader.Read())
                {
                    cmbMalzemelerSec.Items.Add(reader["MalzemeAdi"].ToString());
                }

                reader.Close();
            }
            catch (SQLiteException sqlEx)
            {
                MessageBox.Show("Veritabanı hatası: " + sqlEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }
        }


        private void FiltreleVeSiralaTarifler()
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();

                // SQL query başlangıcı, WHERE koşulları eklemek için hazırlık
                string query = @"
            SELECT 
                t.TarifID, t.TarifAdi, t.HazirlamaSuresi, 
                (SELECT SUM(m.BirimFiyat * tm.MalzemeMiktar) 
                 FROM TarifMalzeme tm 
                 JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID 
                 WHERE tm.TarifID = t.TarifID) AS Maliyet 
            FROM tarifler t 
            WHERE 1=1"; // 1=1 eklenmesi, dinamik olarak koşullar eklemek için kullanılır.

                // Kategori filtresi
                if (cmbKategoriFiltre.SelectedItem != null && cmbKategoriFiltre.SelectedItem.ToString() != "Seçiniz")
                {
                    query += " AND t.Kategori = @Kategori";
                }

                // Hazırlama süresi sıralama filtresi
                if (cmbHazirlamaSuresiFiltre.SelectedItem != null && cmbHazirlamaSuresiFiltre.SelectedItem.ToString() != "Seçiniz")
                {
                    if (cmbHazirlamaSuresiFiltre.SelectedItem.ToString() == "En Hızlıdan")
                        query += " ORDER BY t.HazirlamaSuresi ASC";
                    else if (cmbHazirlamaSuresiFiltre.SelectedItem.ToString() == "En Yavaştan")
                        query += " ORDER BY t.HazirlamaSuresi DESC";
                }

                // Maliyet aralığı filtresi
                if (numMaliyetAraligiMin.Value != 0 || numMaliyetAraligiMax.Value != 0)
                {
                    query += " AND (SELECT SUM(m.BirimFiyat * tm.MalzemeMiktar) FROM TarifMalzeme tm JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID WHERE tm.TarifID = t.TarifID) BETWEEN @MinMaliyet AND @MaxMaliyet";
                }

                // Sıralama filtresi
                if (cmbSiralamaSec.SelectedItem != null && cmbSiralamaSec.SelectedItem.ToString() != "Seçiniz")
                {
                    if (cmbSiralamaSec.SelectedItem.ToString() == "Maliyet Artan")
                        query += " ORDER BY Maliyet ASC";
                    else if (cmbSiralamaSec.SelectedItem.ToString() == "Maliyet Azalan")
                        query += " ORDER BY Maliyet DESC";
                }

                SQLiteCommand command = new SQLiteCommand(query, baglan);

                // Parametreleri ekle
                if (cmbKategoriFiltre.SelectedItem != null && cmbKategoriFiltre.SelectedItem.ToString() != "Seçiniz")
                {
                    command.Parameters.AddWithValue("@Kategori", cmbKategoriFiltre.SelectedItem.ToString());
                }

                if (numMaliyetAraligiMin.Value != 0 || numMaliyetAraligiMax.Value != 0)
                {
                    command.Parameters.AddWithValue("@MinMaliyet", numMaliyetAraligiMin.Value);
                    command.Parameters.AddWithValue("@MaxMaliyet", numMaliyetAraligiMax.Value);
                }

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable sonucTablosu = new DataTable();
                adapter.Fill(sonucTablosu);

                // Sonuçları DataGridView'de gösteriyoruz
                dataGridView1.DataSource = sonucTablosu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filtreleme ve sıralama sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }
        }

        private void btnFiltreleyerekAra_Click(object sender, EventArgs e)
        {
            // Filtreleme ve sıralama işlemini çalıştır
            FiltreleVeSiralaTarifler();
        }





        private void DataGridViewSutunlariniEkle()
        {
            // DataGridView'de zaten sütunlar varsa, tekrar eklemeyelim
            if (dataGridViewTarifOner.Columns.Count == 0)
            {
                // Sütunları manuel olarak ekliyoruz
                dataGridViewTarifOner.Columns.Add("MalzemeAdi", "Malzeme Adı");
                dataGridViewTarifOner.Columns.Add("MalzemeMiktar", "Malzeme Miktarı");
                dataGridViewTarifOner.Columns.Add("MalzemeBirimi", "Malzeme Birimi");
            }
        }

        private void MalzemeleriYukleTarifOner()
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                    baglan.Open();

                // Veritabanından malzemeleri çekiyoruz
                string query = "SELECT MalzemeAdi FROM Malzemeler";
                SQLiteCommand command = new SQLiteCommand(query, baglan);
                SQLiteDataReader reader = command.ExecuteReader();

                // ComboBox'u temizliyoruz
                cmbTarifOnerMalzemeSec.Items.Clear();

                // Malzemeleri ComboBox'a ekliyoruz
                while (reader.Read())
                {
                    cmbTarifOnerMalzemeSec.Items.Add(reader["MalzemeAdi"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Malzemeler yüklenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglan.State == ConnectionState.Open)
                    baglan.Close();
            }
        }

        private void btnTarifOnerMalzemeEkle_Click(object sender, EventArgs e)
        {
            // Malzeme seçim ve miktar kontrolü
            if (cmbTarifOnerMalzemeSec.SelectedItem == null || cmbTarifOnerMalzemeBirimi.SelectedItem == null || string.IsNullOrWhiteSpace(txtTarifOnerMalzemeMiktar.Text))
            {
                MessageBox.Show("Lütfen tüm malzeme bilgilerini seçin ve miktar girin.");
                return;
            }

            // Seçilen malzemelerin detayları
            string malzemeAdi = cmbTarifOnerMalzemeSec.SelectedItem.ToString();
            string malzemeBirim = cmbTarifOnerMalzemeBirimi.SelectedItem.ToString();
            string malzemeMiktar = txtTarifOnerMalzemeMiktar.Text;

            dataGridViewTarifOner.Rows.Add(malzemeAdi, malzemeMiktar, malzemeBirim);
        }

        private void btnTarifOnerMalzemeReset_Click(object sender, EventArgs e)
        {
            // DataGridView'i temizle
            dataGridViewTarifOner.Rows.Clear();
        }

        private void btnTarifOner_Click(object sender, EventArgs e)
        {
            // Seçilen malzemeleri topluyoruz
            List<string> secilenMalzemeler = dataGridViewTarifOner.Rows
                .Cast<DataGridViewRow>()
                .Where(row => row.Cells["MalzemeAdi"].Value != null)
                .Select(row => row.Cells["MalzemeAdi"].Value.ToString().ToLower())
                .ToList();

            // Eğer malzeme yoksa uyarı ver
            if (secilenMalzemeler.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir malzeme ekleyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Bağlantıyı aç
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                }

                string query = @"
            SELECT 
                TarifMalzeme.TarifID, 
                GROUP_CONCAT(Malzemeler.MalzemeAdi, ',') AS TarifMalzemeleri 
            FROM 
                TarifMalzeme 
            JOIN 
                Malzemeler ON TarifMalzeme.MalzemeID = Malzemeler.MalzemeID 
            GROUP BY 
                TarifMalzeme.TarifID";

                SQLiteCommand command = new SQLiteCommand(query, baglan);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataTable tariflerTablosu = new DataTable();
                adapter.Fill(tariflerTablosu);

                // Tariflerin eşleşme yüzdelerini hesaplıyoruz
                List<TarifEslesme> eslesmeler = new List<TarifEslesme>();

                foreach (DataRow row in tariflerTablosu.Rows)
                {
                    int tarifID = Convert.ToInt32(row["TarifID"]);
                    string tarifMalzemeleri = row["TarifMalzemeleri"].ToString().ToLower();
                    string[] tarifMalzemeListesi = tarifMalzemeleri.Split(',');

                    // Eşleşen malzeme yüzdesini hesapla
                    int eslesenMalzemeSayisi = secilenMalzemeler.Count(malzeme => tarifMalzemeListesi.Contains(malzeme));
                    double eslesmeYuzdesi = tarifMalzemeListesi.Length > 0 ? ((double)eslesenMalzemeSayisi / tarifMalzemeListesi.Length) * 100 : 0;

                    if (eslesmeYuzdesi > 0)
                    {
                        eslesmeler.Add(new TarifEslesme { TarifID = tarifID, EslesmeYuzdesi = eslesmeYuzdesi });
                    }
                }

                eslesmeler = eslesmeler.OrderByDescending(eslesme => eslesme.EslesmeYuzdesi).ToList();

                // Eşleşme sonuçlarını görüntüleme
                DataTable sonucTablosu = new DataTable();
                sonucTablosu.Columns.Add("TarifID");
                sonucTablosu.Columns.Add("TarifAdi");
                sonucTablosu.Columns.Add("EslesmeYuzdesi");
                sonucTablosu.Columns.Add("Maliyet");

                foreach (var eslesme in eslesmeler)
                {
                    string tarifAdiQuery = "SELECT TarifAdi FROM tarifler WHERE TarifID = @TarifID";
                    SQLiteCommand tarifAdiCommand = new SQLiteCommand(tarifAdiQuery, baglan);
                    tarifAdiCommand.Parameters.AddWithValue("@TarifID", eslesme.TarifID);
                    object tarifAdiObj = tarifAdiCommand.ExecuteScalar();

                    string tarifAdi = tarifAdiObj != null ? tarifAdiObj.ToString() : "Bilinmiyor";
                    decimal maliyet = TarifMaliyetiHesapla(eslesme.TarifID);

                    sonucTablosu.Rows.Add(eslesme.TarifID, tarifAdi, eslesme.EslesmeYuzdesi.ToString("F2") + "%", maliyet.ToString("C2"));
                }

                dataGridView1.DataSource = sonucTablosu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Malzemeye göre arama sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı en son kapat
                if (baglan.State == ConnectionState.Open)
                {
                    baglan.Close();
                }
            }
        }






    }
}