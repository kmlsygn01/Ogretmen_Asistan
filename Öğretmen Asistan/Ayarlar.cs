using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/***/
using System.IO;
using System.Collections;
using MetroFramework.Forms;
using System.Runtime.InteropServices;
using System.Media;
using System.Diagnostics;

namespace Ogretmen_Asistan
{
    public partial class Ayarlar : MetroForm
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            zilyoltext.Text = Ayarlarim.Default.zildosyayolu;
            sayacyoltex.Text = Ayarlarim.Default.sayacdosyayolu;
            nameofhero.Text = Ayarlarim.Default.heroname;
            Password_tex.Text = Ayarlarim.Default.Passward;
            if (Ayarlarim.Default.Oncelik == "1")
                Degisiklik_toggle.Checked = true;
            else
                Degisiklik_toggle.Checked = false;

        }

        OpenFileDialog file = new OpenFileDialog();
        private void zildegis_but_Click(object sender, EventArgs e)
        {
            try
            {
                file.InitialDirectory = Application.StartupPath + "\\sound\\";
                //file.Filter = "Müzik Dosyaları(*.wav,*.mp3)|*.wav;*.mp3";
                file.Filter = "Müzik Dosyaları(*.wav)|*.wav";
                file.Title = "Zil sesi için - Ses Dosyası Seçiniz..";
                file.ShowDialog();

                string DosyaYolu = file.FileName;
                zilyoltext.Text = DosyaYolu;
                yol1 = DosyaYolu;
            }
            catch
            { MessageBox.Show("Seçim penceresi çalıştırılamadı!","Hata"); }
        }
        private void zilsaydegis_but_Click(object sender, EventArgs e)
        {
            try
            {
                file.InitialDirectory = Application.StartupPath + "\\sound\\";
                file.Filter = "Müzik Dosyaları(*.wav)|*.wav";
                file.Title = "Sayaç sesi için - Ses Dosyası Seçiniz..";
                file.ShowDialog();

                string DosyaYolu1 = file.FileName;
                sayacyoltex.Text = DosyaYolu1;
                yol2 = DosyaYolu1;
            }
            catch
            { MessageBox.Show("Seçim penceresi çalıştırılamadı!","Hata"); }
        }

        string yol1, yol2;        
        private void Ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ayarlarim.Default.zildosyayolu = yol1;
            Ayarlarim.Default.sayacdosyayolu = yol2;
            Ayarlarim.Default.heroname = nameofhero.Text;
            Ayarlarim.Default.Passward = Password_tex.Text;
            if (Degisiklik_toggle.Checked == true)
                Ayarlarim.Default.Oncelik = "1";
            else
                Ayarlarim.Default.Oncelik = "0";
                        
        }
        

    }
}
