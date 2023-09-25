using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using System.Data.OleDb;

namespace Ogretmen_Asistan
{
    public partial class Yarismaform : MetroForm
    {
        //  sonislembilgisi.Text = "";
        public Yarismaform()
        {
            InitializeComponent();
        }

        #region Form Açılış - Kapanış
        private void Yarismaform_Load(object sender, EventArgs e)
        {
            Ayarlarim.Default.Yarismaform = "1";
            artieksiGrid.Refresh();
            ogrenciekle_dataGrid.Refresh();            
            try
            { this.anaTabloTableAdapter1.Fill(this.dBDataSet1.AnaTablo); }
            catch
            { MessageBox.Show("Veri tabanı bağlantı Problemi!!", "Artı - Eksi Tablosu"); }
            try
            {this.ogrencilerTabloTableAdapter1.Fill(this.dBDataSet1.OgrencilerTablo);}
            catch
            { MessageBox.Show("Veri tabanı bağlantı Problemi!!", "Öğrenci Ekle Tablosu"); }
            ogrenciekle_dataGrid.Sort(ogrenciekle_dataGrid.Columns[0], ListSortDirection.Ascending);

            string best = "test";
            if (best.ToString() == "best") { this.Text = okuladitex + " - Yarışma Takip"; }
            else { this.Text = "Yarışma Takip"; }

            allinside.SelectedTab = tab_sonuc;

            artieksi_DT.Text = DateTime.Now.ToShortDateString();
            sonislembilgisi.Text = "Hoş geldiniz...";
            yapimci.Text = Ayarlarim.Default.heroname;
        }
        private void Yarismaform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ayarlarim.Default.Yarismaform = "0";
            DBKaydet();
            dBDataSet1.Dispose();

            anaTabloTableAdapter1.Dispose();
            ogrencilerTabloTableAdapter1.Dispose();
            tableAdapterManager.Dispose();

            ogrencilerTabloTableAdapter1.Connection.Close();
            anaTabloTableAdapter1.Connection.Close();
            tableAdapterManager.Connection.Close();

        }

        #region Verileri Kaydet
        private void DBKaydet()
        {
            artieksiGrid.Refresh();
            ogrenciekle_dataGrid.Refresh();
            try
            {
                this.Validate();
                anaTabloTableAdapter.Update(dBDataSet1);
                ogrencilerTabloTableAdapter.Update(dBDataSet1);
                tableAdapterManager1.UpdateAll(dBDataSet1);
            }
            catch
            { ; }
        }
        #endregion

        #endregion

        #region Sonuçlar - Ana sayfa
        #endregion
        
        #region Aylık Sonuç
        
        private void ayliksonuc_no_SelectedValueChanged(object sender, EventArgs e)
        {
            ;
        }

        private void ayliksonuc_yenile_Click(object sender, EventArgs e)
        {
            ;
        }
        private void ayliksonuc_butun_Click(object sender, EventArgs e)
        {
            ;
        }


        private void ayliksonuc_Previous_Click(object sender, EventArgs e)
        {
            ogrbindingsource.MovePrevious();
        }
        private void ayliksonuc_Next_Click(object sender, EventArgs e)
        {
            ogrbindingsource.MoveNext();
        }

        #endregion
        
        #region Artı-Eksi

        #region Bütün Tikler
        private void hepsinisecchek_Click(object sender, EventArgs e)
        {
            if (hepsinisecchek.Text == "Hepsini Seç")
            {
                turkcechek.Checked = true;
                matechek.Checked = true;
                hayatchek.Checked = true;
                fenchek.Checked = true;

                derstakipchek.Checked = true;
                derstakip2chek.Checked = true;
                derstakip3chek.Checked = true;

                soruchek.Checked = true;
                soru2chek.Checked = true;

                ekstrachek.Checked = true;
                ekstra2chek.Checked = true;

                mendilchek.Checked = true;
                tirnakchek.Checked = true;

                davranischek.Checked = true;
                davranis2chek.Checked = true;
                davranis3chek.Checked = true;
                davranis4chek.Checked = true;
                hepsinisecchek.Text = "Hepsini Kaldır";
            }
            else
            {
                turkcechek.Checked = false;
                matechek.Checked = false;
                hayatchek.Checked = false;
                fenchek.Checked = false;

                derstakipchek.Checked = false;
                derstakip2chek.Checked = false;
                derstakip3chek.Checked = false;

                soruchek.Checked = false;
                soru2chek.Checked = false;

                ekstrachek.Checked = false;
                ekstra2chek.Checked = false;

                mendilchek.Checked = false;
                tirnakchek.Checked = false;

                davranischek.Checked = false;
                davranis2chek.Checked = false;
                davranis3chek.Checked = false;
                davranis4chek.Checked = false;
                hepsinisecchek.Text = "Hepsini Seç";
            }
        }
        #endregion

        #region Tanımlar
        int q1 = Convert.ToInt32("0"), q2 = Convert.ToInt32("0"), q3 = Convert.ToInt32("0"), q4 = Convert.ToInt32("0"),
            dt1 = Convert.ToInt32("0"), dt2 = Convert.ToInt32("0"), dt3 = Convert.ToInt32("0"),
            s1 = Convert.ToInt32("0"), s2 = Convert.ToInt32("0"),
            e1 = Convert.ToInt32("0"), e2 = Convert.ToInt32("0"),
            m1 = Convert.ToInt32("0"), t1 = Convert.ToInt32("0"),
            d1 = Convert.ToInt32("0"), d2 = Convert.ToInt32("0"), d3 = Convert.ToInt32("0"), d4 = Convert.ToInt32("0");
        int bilgitoplam = Convert.ToInt32("0"), temizliktoplam = Convert.ToInt32("0"), geneltoplam = Convert.ToInt32("0");
        #endregion

        #region Artı Butonu
        private void artieksi_artibut_Click(object sender, EventArgs e)
        {
            if (artieksi_no.Text == "")
            { MessageBox.Show("Lütfen öğrenci numarası giriniz."); }
            else
            {
                if (turkcechek.Checked == true)
                { q1 = Convert.ToInt32(puantex.Text); }
                if (matechek.Checked == true)
                { q2 = Convert.ToInt32(puantex.Text); }
                if (hayatchek.Checked == true)
                { q3 = Convert.ToInt32(puantex.Text); }
                if (fenchek.Checked == true)
                { q4 = Convert.ToInt32(puantex.Text); }

                if (derstakipchek.Checked == true)
                { dt1 = Convert.ToInt32(puantex.Text); }
                if (derstakip2chek.Checked == true)
                { dt2 = Convert.ToInt32(puantex.Text); }
                if (derstakip3chek.Checked == true)
                { dt3 = Convert.ToInt32(puantex.Text); }

                if (soruchek.Checked == true)
                { s1 = Convert.ToInt32(puantex.Text); }
                if (soru2chek.Checked == true)
                { s2 = Convert.ToInt32(puantex.Text); }

                if (ekstrachek.Checked == true)
                { e1 = Convert.ToInt32(puantex.Text); }
                if (ekstra2chek.Checked == true)
                { e2 = Convert.ToInt32(puantex.Text); }

                bilgitoplam = (q1 + q2 + q3 + q4) + (dt1 + dt2 + dt3) + (s1 + s2) + e1 + e2;

                if (mendilchek.Checked == true)
                { m1 = Convert.ToInt32(puantex.Text); }
                if (tirnakchek.Checked == true)
                { t1 = Convert.ToInt32(puantex.Text); }

                if (davranischek.Checked == true)
                { d1 = Convert.ToInt32(puantex.Text); }
                if (davranis2chek.Checked == true)
                { d2 = Convert.ToInt32(puantex.Text); }
                if (davranis3chek.Checked == true)
                { d3 = Convert.ToInt32(puantex.Text); }
                if (davranis4chek.Checked == true)
                { d4 = Convert.ToInt32(puantex.Text); }

                temizliktoplam = (m1 + t1) + (d1 + d2 + d3 + d4);

                geneltoplam = bilgitoplam + temizliktoplam;
                DateTime dt = Convert.ToDateTime(artieksi_DT.Text);
                // yıl, ay, gün, dersler, takip, soru, ekstra, bilgi toplam, temizlik, davranış, temizlik toplam, genel toplam
                dBDataSet1.AnaTablo.Rows.Add(Convert.ToInt32(artieksi_no.Text), dt.Year, dt.Month, dt.Day, 
                    q1, "0", q2, "0", q3, "0", q4, "0", 
                    dt1, "0", dt2, "0", dt3, "0", 
                    s1, "0", s2, "0", 
                    e1, "0", e2, "0", 
                    bilgitoplam, "0", 
                    m1, "0", t1, "0", 
                    d1, "0", d2, "0", d3, "0", d4, "0", 
                    temizliktoplam, "0", 
                    geneltoplam, "0");
                DBKaydet();
                sonislembilgisi.Text = "Artı verildi [ " + puantex.Text + " ] >> " + artieksi_isim.Text + ".";
            }
        }
        #endregion

        #region Eksi Butonu
        private void artieksi_eksibut_Click(object sender, EventArgs e)
        {
            if (turkcechek.Checked == true)
            { q1 = Convert.ToInt32("-" + puantex.Text); }
            if (matechek.Checked == true)
            { q2 = Convert.ToInt32("-" + puantex.Text); }
            if (hayatchek.Checked == true)
            { q3 = Convert.ToInt32("-" + puantex.Text); }
            if (fenchek.Checked == true)
            { q4 = Convert.ToInt32("-" + puantex.Text); }

            if (derstakipchek.Checked == true)
            { dt1 = Convert.ToInt32("-" + puantex.Text); }
            if (derstakip2chek.Checked == true)
            { dt2 = Convert.ToInt32("-" + puantex.Text); }
            if (derstakip3chek.Checked == true)
            { dt3 = Convert.ToInt32("-" + puantex.Text); }

            if (soruchek.Checked == true)
            { s1 = Convert.ToInt32("-" + puantex.Text); }
            if (soru2chek.Checked == true)
            { s2 = Convert.ToInt32("-" + puantex.Text); }

            if (ekstrachek.Checked == true)
            { e1 = Convert.ToInt32("-" + puantex.Text); }
            if (ekstra2chek.Checked == true)
            { e2 = Convert.ToInt32("-" + puantex.Text); }

            bilgitoplam = (q1 + q2 + q3 + q4) + (dt1 + dt2 + dt3) + (s1 + s2) + e1 + e2;

            if (mendilchek.Checked == true)
            { m1 = Convert.ToInt32("-" + puantex.Text); }
            if (tirnakchek.Checked == true)
            { t1 = Convert.ToInt32("-" + puantex.Text); }

            if (davranischek.Checked == true)
            { d1 = Convert.ToInt32("-" + puantex.Text); }
            if (davranis2chek.Checked == true)
            { d2 = Convert.ToInt32("-" + puantex.Text); }
            if (davranis3chek.Checked == true)
            { d3 = Convert.ToInt32("-" + puantex.Text); }
            if (davranis4chek.Checked == true)
            { d4 = Convert.ToInt32("-" + puantex.Text); }

            temizliktoplam = (m1 + t1) + (d1 + d2 + d3 + d4);

            geneltoplam = bilgitoplam + temizliktoplam;

            DateTime dt = Convert.ToDateTime(artieksi_DT.Text);
            // yıl, ay, gün, dersler, takip, soru, ekstra, bilgi toplam, temizlik, davranış, temizlik toplam, genel toplam
            dBDataSet1.AnaTablo.Rows.Add(Convert.ToInt32(artieksi_no.Text), 
                dt.Year, dt.Month, dt.Day,
                "0", q1, "0", q2, "0", q3, "0", q4, 
                "0", dt1, "0", dt2, "0", dt3, 
                "0", s1, "0", s2, 
                "0", e1, "0", e2, 
                "0", bilgitoplam, 
                "0", m1, "0", t1, 
                "0", d1, "0", d2, "0", d3, "0", d4, 
                "0", temizliktoplam, 
                "0", geneltoplam);
            DBKaydet();
            sonislembilgisi.Text = "Eksi verildi [ " + "-" + puantex.Text + " ] >> " + artieksi_isim.Text + ".";
        }
        #endregion

        #region Veri Kaldır
        private void kaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                anaTabloBindingSource.RemoveCurrent();
                sonislembilgisi.Text = "Girilen Artı-Eksi verisi kaldırıldı.";
            }
            catch { ; }
        }
        #endregion
        #endregion

        #region Öğrenciler
        #endregion

        #region Öğrenci Ekle
        private void temizle()
        {
            ogrenciekle_Isim.Clear();
            ogrenciekle_no.Clear();
            ogrenciekle_yascombo.Text = "";
            ogrenciekle_adres.Clear();
            ogrenciekle_baba.Clear();
            ogrenciekle_anne.Clear();
            ogrenciekle_kardescombo.Text = "";
            ogrenciekle_cep.Clear();
            ogrenciekle_ev.Clear();
            ogrenciekle_eposta.Clear();
            ogrenciekle_dogumDT.Text = DateTime.Today.ToShortDateString();
        }

        private void Ogrencikaldir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();
                Secim = MessageBox.Show("Öğrenci Kaldırılacak \r\nEminmisiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secim == DialogResult.Yes)
                {
                    /***************/
                    ogrencilerTabloBindingSource.RemoveCurrent();
                    sonislembilgisi.Text = "Öğrenci - " + ogrenciekle_Isim.Text + " - Kaldırıldı.";
                }
            }
            catch { ; }
        }
        private void Ogrenciguncelle_Click(object sender, EventArgs e)
        {
            //DBKaydet();
            sonislembilgisi.Text = "Öğrenci Güncellendi.";
        }
        private void Ogrenciekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ogrenciekle.Text == "Yeni Öğrenci")
                {
                    /***************/
                    ogrencilerTabloBindingSource.AddNew();

                    temizle();

                    Ogrencikaldir.Enabled = false;
                    Ogrenciguncelle.Enabled = false;
                    ogrenciekle_dataGrid.Enabled = false;
                    ogrenciekle_resimekle.Text = "Resim Ekle";
                    Ogrenciekle.Text = "Ekle - Sil";
                    sonislembilgisi.Text = "Öğrenci Ekleme işlemi...";
                }
                else
                {
                    DialogResult Sec = new DialogResult();
                    Sec = MessageBox.Show("Kaydetmek için Evet 'i \r\nİptal etmek için Hayır ' seçiniz.. ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Sec == DialogResult.Yes)
                    {
                        /***************/
                        this.Validate();
                        ogrencilerTabloBindingSource.EndEdit();
                        DBKaydet();

                        Ogrencikaldir.Enabled = true;
                        Ogrenciguncelle.Enabled = true;
                        ogrenciekle_dataGrid.Enabled = true;
                        ogrenciekle_resimekle.Text = "Resmi Güncelle";
                        Ogrenciekle.Text = "Yeni Öğrenci";
                        sonislembilgisi.Text = "Öğrenci Eklendi - " + ogrenciekle_Isim.Text + ".";
                    }
                    if (Sec == DialogResult.No)
                    {
                        /***************/
                        ogrencilerTabloBindingSource.RemoveCurrent();

                        Ogrencikaldir.Enabled = true;
                        Ogrenciguncelle.Enabled = true;
                        ogrenciekle_dataGrid.Enabled = true;
                        ogrenciekle_resimekle.Text = "Resmi Güncelle";
                        Ogrenciekle.Text = "Yeni Öğrenci";
                        sonislembilgisi.Text = "Öğrenci Ekleme işlemi iptal edildi.";
                    }

                }
            }
            catch { ; }
        }
        private void ogrenciekle_resimekle_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("  Düzgün görünmesi için, \r\nDikey = 999 Yatay = 999\r\noranlarına yakın bir çözünürlükte resim seçiniz!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.png";
                dosya.Title = "Öğrenci Resim Seçici";
                dosya.ShowDialog();
                string DosyaYolu = dosya.FileName;
                ogrenciekle_resim.ImageLocation = DosyaYolu;
                sonislembilgisi.Text = "Öğrenci resmi eklendi.";
            }
            catch
            {
                MessageBox.Show("Resim işleme başarısız, lütfen tekrar deneyin yada programı yeniden başlatın.. ", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
        
        #region Oyunlar
        private void kim50puanister_Click(object sender, EventArgs e)
        {
            kim50puanister ac = new kim50puanister();
            ac.ShowDialog();
        }
        #endregion
        
        #region Kilit
        private void lockon_Click(object sender, EventArgs e)
        {
            if (lockon.Text == "Kilitle")
            {
                allinside.Enabled = false;
                lockon.Text = "Aç";
                sonislembilgisi.Text = "Arayüz Kilitlendi.";
            }
            else
            {
                lockon.Text = "Kilitle";
                allinside.Enabled = true;
                sonislembilgisi.Text = "Arayüz Kilidi açıldı.";
            }
        }
        #endregion

        #region Ana Form
        Anaform ana;
        private void AnaformBut_Click(object sender, EventArgs e)
        {
            if (Ayarlarim.Default.Anaform == "1")
            {
                var ana = new Anaform();
                if (Application.OpenForms[ana.Name] == null)
                {
                    ana.Show();
                }
                else
                {
                    Application.OpenForms[ana.Name].Focus();
                }
            }
            else
            {
                ana = new Anaform();
                ana.Show();
            }

        }
        #endregion

        #region Saat
        private void saattarihtimer_Tick(object sender, EventArgs e)
        {
            saattarih.Text = DateTime.Now.ToShortTimeString();
        }
        #endregion Saat

        private void ayarlar_button_Click(object sender, EventArgs e)
        {
            Ayarlar af = new Ayarlar();
            af.ShowDialog();
        }


       
    }
}