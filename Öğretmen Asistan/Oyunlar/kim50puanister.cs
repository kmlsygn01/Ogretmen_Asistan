using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing; 
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Ogretmen_Asistan
{
    public partial class kim50puanister : MetroForm
    {
        Label[] labelDizi;
        Button[] butonDizi;
        public kim50puanister()
        {
            InitializeComponent();
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=kimister.accdb");
        public OleDbCommand kmt = new OleDbCommand();
        int[] sayilar = new int[16];
        Random r = new Random();
        int randomSayac = 0, soruSayac = 1, uretilmeyecekSayac = 0, imlecNerde = 10, jokerSayisi = 0;
        string dogruCevap,yarismaciCevap;
        int[] uretilmeyecekSayilar = new int[3];
        int rastgele = 0, uretilmeyecekSayi = 0, jokerk = 0,dak;
        string kazanilan = "";
        Boolean durumu = false, radioKontrol = false;
        void radioButonlarıGoster() 
        {
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
        }
        void radioButonlarıGosterme() 
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
        }

        void radioButonlarıSecme()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }       

        void rastgeleSayi()
        {

            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select  count(*) from sorular ";
            int kayitSayisi=int.Parse( kmt.ExecuteScalar().ToString());            
            bag.Close();

                int rastgele;
                randomSayac = 0;
                while (randomSayac < 16)
                {
                    rastgele = r.Next(1, (kayitSayisi+1));//1 ile kayıt sayısı arasında rastgele sayı üretiliyor
                    if (Array.IndexOf(sayilar, rastgele) == -1) //dizinin içinde aynı sayı yoksa 
                    {
                        sayilar[randomSayac] = rastgele;
                        randomSayac++;
                    } 
                }
        }      
   
        void soruAl(int a)
        { 
           bag.Open();
           kmt.Connection = bag;
           kmt.CommandText = "Select  * from sorular where soruId=" + sayilar[a]   ;
           OleDbDataReader oku;
           oku = kmt.ExecuteReader();
           while (oku.Read())
           {
               label13.Text =soruSayac+" - " + oku[1].ToString(); 
                radioButton1.Text=oku[2].ToString();
                radioButton2.Text=oku[3].ToString();
                radioButton3.Text=oku[4].ToString();
                radioButton4.Text=oku[5].ToString();
                dogruCevap = oku[6].ToString();
           }
           oku.Dispose();
           bag.Close();
        } 
        void labelArkaPlanRenkSifirla()
        {
            for (int i = 0; i < 10; i++)
            {
                labelDizi[i].BackColor = Color.CornflowerBlue;
            }
        }
        void LabelleriOlustur()
        {
            labelDizi = new Label[10];
            for (int i = 0; i < 10; i++)
            {
                labelDizi[i] = new Label();
                labelDizi[i].BackColor = Color.Transparent;
            }
            for (int i = 0; i < labelDizi.Length; i++)
            {
                if (i==0) 
                {
                    labelDizi[i].ForeColor = Color.Red;
                    labelDizi[i].Text = "50"; 
                }
                else if (i == 1)
                {
                    labelDizi[i].ForeColor = Color.Orange;
                    labelDizi[i].Text = "40";
                }
                else if (i == 2)
                {
                    labelDizi[i].ForeColor = Color.Yellow;
                    labelDizi[i].Text = "30";
                }
                else if (i == 3)
                {
                    labelDizi[i].ForeColor = Color.Yellow;
                    labelDizi[i].Text = "25";
                }
                else if (i == 4)
                {
                    labelDizi[i].ForeColor = Color.Yellow;
                    labelDizi[i].Text = "20";
                }
                else if (i == 5)
                {
                    labelDizi[i].ForeColor = Color.Yellow;
                    labelDizi[i].Text = "15";
                }
                else if (i == 6)
                {
                    labelDizi[i].ForeColor = Color.Yellow;
                    labelDizi[i].Text = "10";
                }
                else if (i == 7)
                {
                    labelDizi[i].ForeColor = Color.Yellow;
                    labelDizi[i].Text = "5";
                }
                else if (i == 8)
                {
                    labelDizi[i].ForeColor = Color.Yellow;
                    labelDizi[i].Text = "3";
                }
                else if (i == 9)
                {
                    labelDizi[i].ForeColor = Color.Yellow;
                    labelDizi[i].Text = "1";
                }
                labelDizi[i].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                
                this.Controls.Add(labelDizi[i]);
                labelDizi[i].Location = new Point(675, (55)+i*25);
            }
        }

        void butonOlustur()
        {
            butonDizi = new MetroFramework.Controls.MetroButton[10];            
            for (int i = 0; i < butonDizi.Length; i++)
            {
                butonDizi[i] = new MetroFramework.Controls.MetroButton();
                butonDizi[i].Text = "Yardım";
                butonDizi[i].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                butonDizi[i].Click += new EventHandler(islem2);
                this.Controls.Add( butonDizi[i]);
                butonDizi[i].Location = new Point(50, (55) + i * 25);
            }
        }

        private void islem2(object sender, EventArgs e)
        {
            if (dogruCevap == radioButton1.Text) uretilmeyecekSayi = 1;
            if (dogruCevap == radioButton2.Text) uretilmeyecekSayi = 2;
            if (dogruCevap == radioButton3.Text) uretilmeyecekSayi = 3;
            if (dogruCevap == radioButton4.Text) uretilmeyecekSayi = 4;
            secenekRastgeleSayi(); 
            if (rastgele == 1) radioButton1.Visible = false;
            if (rastgele == 2) radioButton2.Visible = false;
            if (rastgele == 3) radioButton3.Visible = false;
            if (rastgele == 4) radioButton4.Visible = false;
            butonDizi[jokerSayisi].Enabled = false;
            jokerSayisi++;
        }    
   
        void secenekRastgeleSayi()
        {
            Random r = new Random();
            while (true)
            {
                rastgele = r.Next(1, 5);
                if (Array.IndexOf(uretilmeyecekSayilar, rastgele) == -1 && rastgele != uretilmeyecekSayi)
                {
                    uretilmeyecekSayilar[uretilmeyecekSayac] = rastgele;
                    uretilmeyecekSayac++; 
                    break;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rastgeleSayi();
            soruAl(soruSayac);
            timer1.Enabled = true;   
            dak = 60;
            label15.Text = "60";
            LabelleriOlustur(); 
            butonOlustur();
        }
        
        private void btnCevapla_Click(object sender, EventArgs e)
        {
            
            Array.Clear(uretilmeyecekSayilar, 0, 3);
            uretilmeyecekSayac = 0;
            dak = 60;
            if (jokerSayisi<10) jokerk = 0;
            else    jokerk = 4;
           
            if (soruSayac <= 15)
            {
                if (radioButton1.Checked) yarismaciCevap = radioButton1.Text;
                if (radioButton2.Checked) yarismaciCevap = radioButton2.Text;
                if (radioButton3.Checked) yarismaciCevap = radioButton3.Text;
                if (radioButton4.Checked) yarismaciCevap = radioButton4.Text;
                if (yarismaciCevap == dogruCevap)
                {
                    if(imlecNerde-1>=0)
                    {
                    labelDizi[imlecNerde-1].BackColor = Color.Gray;
                    kazanilan = labelDizi[imlecNerde - 1].Text.ToString();
                    if(imlecNerde<10)labelDizi[imlecNerde].BackColor = Color.CornflowerBlue;
                    imlecNerde--;
                    } 
                }
                else
                {
                     MessageBox.Show("Yanlış Cevapladınız!! \r\n Doğru olan cevap : " + dogruCevap + "\r\n 2 Jokeriniz alındı !!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     if (jokerSayisi < 10 && imlecNerde<=10)
                        {
                            for (int i = jokerSayisi; i < jokerSayisi + 2; i++)
                            {
                                butonDizi[i].ForeColor = Color.White;
                                butonDizi[i].Enabled  = false;
                                jokerk++;
                                if ((jokerSayisi+jokerk)==10)
                                {
                                    jokerSayisi=jokerSayisi+jokerk;
                                    jokerk = 2 - jokerk;
                                    if (imlecNerde + jokerk <10)
                                    {
                                        labelDizi[imlecNerde].BackColor = Color.CornflowerBlue;
                                        labelDizi[imlecNerde + jokerk].BackColor = Color.Gray;
                                        kazanilan = labelDizi[imlecNerde + jokerk].Text.ToString(); 
                                    }
                                    else
                                    {
                                        kazanilan = "0";
                                        label2.Text = String.Format("{0:C0} ", double.Parse(kazanilan));
                                      radioButonlarıGosterme();
                                      label13.Visible = false;
                                      btnCevapla.Visible = false;
                                      btnTekrarOyna.Visible = true;
                                      radioButonlarıGosterme();
                                      labelArkaPlanRenkSifirla();
                                      timer1.Enabled = false;
                                    }
                                   
                                    imlecNerde = imlecNerde + jokerk;
                                    durumu = true;
                                    break; 
                                }                               
                            }
                            if (durumu == false)
                            {
                                jokerSayisi = jokerSayisi + 2;
                                
                            }                       
                           
                        }
                        else
                        {
                            if (imlecNerde+jokerk   < 10)
                            {
                                labelDizi[imlecNerde + jokerk].BackColor = Color.Gray;
                                kazanilan = labelDizi[imlecNerde + jokerk].Text.ToString();
                                labelDizi[imlecNerde].BackColor = Color.CornflowerBlue;
                                imlecNerde = imlecNerde + jokerk; 
                            }
                            else
                            {
                                if (soruSayac < 14)
                                {
                                    kazanilan = "0";
                                    label2.Text = String.Format("{0:C0} ", double.Parse(kazanilan));
                                    radioButonlarıGosterme();
                                    label13.Visible = false;
                                    timer1.Enabled = false;
                                    btnCevapla.Visible = false;
                                    btnTekrarOyna.Visible = true;
                                    labelArkaPlanRenkSifirla();
                                    radioKontrol = true;
                                }
                            }
                        }                      
                    
                }
                soruSayac++;
                if(soruSayac<16) soruAl(soruSayac);
                if (soruSayac == 16)
                {
                    label2.Text = String.Format("Sorular bitmiştir.\n Yeni Sorular için Tekrar \n butonuna tıklayınız !\n  {0:C0}",double.Parse(kazanilan) );
                    radioButonlarıGosterme();
                    label13.Visible = false;
                    btnCevapla.Visible = false;
                    btnTekrarOyna.Visible = true;
                    timer1.Enabled = false; 
                    labelArkaPlanRenkSifirla();
                    radioKontrol = true;
                }
                
            }
            DialogResult cevap;
            if (soruSayac ==15)
            {
                cevap = MessageBox.Show("Yarışmadan çekilmek istiyor musun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cevap == DialogResult.Yes)
                {
                    kazanilan = (double.Parse(kazanilan) / 2).ToString();
                    label2.Text = String.Format(" {0:C0} " ,double.Parse(kazanilan)); 
                    radioButonlarıGosterme();
                    label13.Visible = false;
                    btnCevapla.Visible = false;
                    btnTekrarOyna.Visible = true;
                    timer1.Enabled = false; 
                    labelArkaPlanRenkSifirla();
                    radioKontrol = true;
                }

            }

            if (imlecNerde < 10 && radioKontrol==false)  radioButonlarıGoster();
            radioButonlarıSecme();
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dak > 0)
            {
                dak--;
                label15.Text = dak.ToString();
            } 
            else
            {
                btnCevapla.PerformClick();
                
            }
        }

        private void btnTekrarOyna_Click(object sender, EventArgs e)
        {
            btnCevapla.Visible = true;
            btnTekrarOyna.Visible = false;
            radioButonlarıGoster();
            label13.Visible = true;
            soruSayac = 1;
            rastgeleSayi();
            soruAl(soruSayac);
            timer1.Enabled = true;
            btnCevapla.Enabled = true;
            imlecNerde = 10;
            jokerSayisi = 0;
            jokerk = 0;
            durumu = false;
            kazanilan = "";
            radioKontrol = false;
                     
            dak = 60; 
            label2.Text = "";
            for (int i = 0; i < 10; i++)
            {
                butonDizi[i].Enabled = true;
                butonDizi[i].ForeColor = Color.Blue;
            }
        }
    }
}
 