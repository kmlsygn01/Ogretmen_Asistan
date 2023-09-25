using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*******Eklenen Kütüphaneler********/
using System.IO;
using System.Collections;
using MetroFramework.Forms;
using System.Media;
using System.Diagnostics;
using Microsoft.VisualBasic;  

namespace Ogretmen_Asistan
{
    public partial class Anaform : MetroForm
    {
        public Anaform()
        {
            InitializeComponent();

        }

        #region Form Yüklenirken
        private void Form1_Load(object sender, EventArgs e)
        {
            Ogretmen_Asistan.Ayarlarim.Default.Anaform = "1";
            try
            {
                allyukle();
                dosyaoku();
            }
            catch
            {
                MessageBox.Show("Yükleme özelliği çalıştırılamadı.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Derscek();
            Derspanel.Size = new Size(130, 30);
            metroTabControl1.SelectedTab = metroTabPage1;
            Gunler_tab();
            yapimci.Text = Ayarlarim.Default.heroname;

        }

        public void Gunler_tab()
        {
            /*
                Monday. Pazartesi.
                Tuesday. Salı
                Wednesday. Çarşamba.
                Thursday. Perşembe.
                Friday. Cuma.
                Saturday. Cumartesi.
                Sunday. Pazar.
             */
            if ("Monday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
            {
                DersTablari.SelectedTab = Pazartesitab;
                On_Gun.Text = "Pazartesi";

                On_ders1.Text = pztilkders.Text;
                On_ders2.Text = pztikiders.Text;
                On_ders3.Text = pztucders.Text;
                On_ders4.Text = pztdortders.Text;
                On_ders5.Text = pztbesders.Text;
                On_ders6.Text = pztaltiders.Text;
            }
            if ("Tuesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
            {
                DersTablari.SelectedTab = Salitab;
                On_Gun.Text = "Salı";

                On_ders1.Text = saliilkders.Text;
                On_ders2.Text = saliikiders.Text;
                On_ders3.Text = saliucders.Text;
                On_ders4.Text = salidortders.Text;
                On_ders5.Text = salibesders.Text;
                On_ders6.Text = salialtiders.Text;
            }
            if ("Wednesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
            {
                DersTablari.SelectedTab = Carsambatab;
                On_Gun.Text = "Çarşamba";

                On_ders1.Text = carsilkders.Text;
                On_ders2.Text = carsikiders.Text;
                On_ders3.Text = carsucders.Text;
                On_ders4.Text = carsdortders.Text;
                On_ders5.Text = carsbesders.Text;
                On_ders6.Text = carsaltiders.Text;
            }
            if ("Thursday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
            {
                DersTablari.SelectedTab = Persembetab;
                On_Gun.Text = "Perşembe";

                On_ders1.Text = perilkders.Text;
                On_ders2.Text = perikiders.Text;
                On_ders3.Text = perucders.Text;
                On_ders4.Text = perdortders.Text;
                On_ders5.Text = perbesders.Text;
                On_ders6.Text = peraltiders.Text;
            }
            if ("Friday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
            {
                DersTablari.SelectedTab = Cumatab;
                On_Gun.Text = "Cuma";

                On_ders1.Text = cumailkders.Text;
                On_ders2.Text = cumaikiders.Text;
                On_ders3.Text = cumaucders.Text;
                On_ders4.Text = cumadortders.Text;
                On_ders5.Text = cumabesders.Text;
                On_ders6.Text = cumaaltiders.Text;
            }
            if ("Saturday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
            { 
                DersTablari.SelectedTab = Pazartesitab;
                On_Gun.Text = "Pazartesi";

                On_ders1.Text = pztilkders.Text;
                On_ders2.Text = pztikiders.Text;
                On_ders3.Text = pztucders.Text;
                On_ders4.Text = pztdortders.Text;
                On_ders5.Text = pztbesders.Text;
                On_ders6.Text = pztaltiders.Text;
            }
            if ("Sunday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
            { 
                DersTablari.SelectedTab = Pazartesitab;
                On_Gun.Text = "Pazartesi";

                On_ders1.Text = pztilkders.Text;
                On_ders2.Text = pztikiders.Text;
                On_ders3.Text = pztucders.Text;
                On_ders4.Text = pztdortders.Text;
                On_ders5.Text = pztbesders.Text;
                On_ders6.Text = pztaltiders.Text;
            }
        }

        #endregion

        #region Rastgele Bölümü

        #region İsimleri a-Z Sırala
        public void listasc()
        {
            try
            {
                ArrayList list1 = new ArrayList();
                foreach (object o in ogrlist.Items)
                    list1.Add(o);
                list1.Sort();
                ogrlist.Items.Clear();
                foreach (object o in list1)
                {
                    ogrlist.Items.Add(o);
                }

                ArrayList list2 = new ArrayList();
                foreach (object o in ogrlist.Items)
                    list2.Add(o);
                list2.Sort();
                ogrlist.Items.Clear();
                foreach (object o in list2)
                {
                    ogrlist.Items.Add(o);
                }
            }
            catch
            { ; }
        }
        public void listasc2()
        {
            try
            {
                ArrayList list1 = new ArrayList();
                foreach (object o in ogrlist2.Items)
                    list1.Add(o);
                list1.Sort();
                ogrlist2.Items.Clear();
                foreach (object o in list1)
                {
                    ogrlist2.Items.Add(o);
                }

                ArrayList list2 = new ArrayList();
                foreach (object o in ogrlist2.Items)
                    list2.Add(o);
                list2.Sort();
                ogrlist2.Items.Clear();
                foreach (object o in list2)
                {
                    ogrlist2.Items.Add(o);
                }
            }
            catch
            { ; }
        }
        public void listasc3()
        {
            try
            {
                ArrayList list1 = new ArrayList();
                foreach (object o in ogrlist3.Items)
                    list1.Add(o);
                list1.Sort();
                ogrlist3.Items.Clear();
                foreach (object o in list1)
                {
                    ogrlist3.Items.Add(o);
                }

                ArrayList list2 = new ArrayList();
                foreach (object o in ogrlist3.Items)
                    list2.Add(o);
                list2.Sort();
                ogrlist3.Items.Clear();
                foreach (object o in list2)
                {
                    ogrlist3.Items.Add(o);
                }
            }
            catch
            { ; }
        }
        public void turkcelistasc()
        {
            try
            {
                ArrayList list1 = new ArrayList();
                foreach (object o in turkcelist.Items)
                    list1.Add(o);
                list1.Sort();
                turkcelist.Items.Clear();
                foreach (object o in list1)
                {
                    turkcelist.Items.Add(o);
                }

                ArrayList list2 = new ArrayList();
                foreach (object o in turkceseclist.Items)
                    list2.Add(o);
                list2.Sort();
                turkceseclist.Items.Clear();
                foreach (object o in list2)
                {
                    turkceseclist.Items.Add(o);
                }
            }
            catch
            { ;}
        }
        public void matelistasc()
        {
            try
            {
                ArrayList list1 = new ArrayList();
                foreach (object o in matelist.Items)
                    list1.Add(o);
                list1.Sort();
                matelist.Items.Clear();
                foreach (object o in list1)
                {
                    matelist.Items.Add(o);
                }

                ArrayList list2 = new ArrayList();
                foreach (object o in mateseclist.Items)
                    list2.Add(o);
                list2.Sort();
                mateseclist.Items.Clear();
                foreach (object o in list2)
                {
                    mateseclist.Items.Add(o);
                }
            }
            catch
            { ;}
        }
        public void hayatlistasc()
        {
            try
            {
                ArrayList list1 = new ArrayList();
                foreach (object o in hayatlist.Items)
                    list1.Add(o);
                list1.Sort();
                hayatlist.Items.Clear();
                foreach (object o in list1)
                {
                    hayatlist.Items.Add(o);
                }

                ArrayList list2 = new ArrayList();
                foreach (object o in hayatseclist.Items)
                    list2.Add(o);
                list2.Sort();
                hayatseclist.Items.Clear();
                foreach (object o in list2)
                {
                    hayatseclist.Items.Add(o);
                }
            }
            catch
            { ;}
        }
        public void fenlistasc()
        {
            try
            {
                ArrayList list1 = new ArrayList();
                foreach (object o in fenlist.Items)
                    list1.Add(o);
                list1.Sort();
                fenlist.Items.Clear();
                foreach (object o in list1)
                {
                    fenlist.Items.Add(o);
                }

                ArrayList list2 = new ArrayList();
                foreach (object o in fenseclist.Items)
                    list2.Add(o);
                list2.Sort();
                fenseclist.Items.Clear();
                foreach (object o in list2)
                {
                    fenseclist.Items.Add(o);
                }
            }
            catch
            { ;}
        }
        #endregion

        #region Seçim Butonları
        int rsayi;
        Random r = new Random();
        private void sec_Click(object sender, EventArgs e)
        {//seç


            if (durum.Text == "0")
            {
                try
                {
                    rsayi = r.Next(Convert.ToInt32(ogrlist.Items.Count));

                    secilenisim.Text = ogrlist.Items[rsayi].ToString();

                    //ogrlist.Items.Remove(secilenisim.Text);

                    //ogrseclist.Items.Add(secilenisim.Text);
                }
                catch
                {
                    ;// secilenisim.Text = "Listeyi Boşaltın!";
                }
                listasc();
            }
            else if (durum.Text == "1")
            {
                try
                {
                    rsayi = r.Next(Convert.ToInt32(ogrlist2.Items.Count));

                    secilenisim.Text = ogrlist2.Items[rsayi].ToString();
                    ogrlist2.Items.Remove(secilenisim.Text);
                    ogrseclist2.Items.Add(secilenisim.Text);
                }
                catch
                { durum.Text = "0"; }
            }
            else if (durum.Text == "2")
            {
                try
                {
                    rsayi = r.Next(Convert.ToInt32(ogrlist3.Items.Count));

                    secilenisim.Text = ogrlist3.Items[rsayi].ToString();
                    ogrlist3.Items.Remove(secilenisim.Text);
                    ogrseclist3.Items.Add(secilenisim.Text);
                }
                catch
                { durum.Text = "1"; }
            }
            else
                MessageBox.Show("Program Çöktü");
        }
        private void turkcesec_Click(object sender, EventArgs e)
        {
            try
            {
                rsayi = r.Next(turkcelist.Items.Count);

                turkcesecilenisim.Text = turkcelist.Items[rsayi].ToString();

                turkcelist.Items.Remove(turkcesecilenisim.Text);

                turkceseclist.Items.Add(turkcesecilenisim.Text);
            }
            catch
            {
                turkcesecilenisim.Text = "Listeyi Boşaltın!";
            }
            turkcelistasc();
        }
        private void matesec_Click(object sender, EventArgs e)
        {
            try
            {
                rsayi = r.Next(matelist.Items.Count);

                matesecilenisim.Text = matelist.Items[rsayi].ToString();

                matelist.Items.Remove(matesecilenisim.Text);

                mateseclist.Items.Add(matesecilenisim.Text);
            }
            catch
            {
                matesecilenisim.Text = "Listeyi Boşaltın!";
            }
            matelistasc();
        }
        private void hayatsec_Click(object sender, EventArgs e)
        {
            try
            {
                rsayi = r.Next(hayatlist.Items.Count);

                hayatsecilenisim.Text = hayatlist.Items[rsayi].ToString();

                hayatlist.Items.Remove(hayatsecilenisim.Text);

                hayatseclist.Items.Add(hayatsecilenisim.Text);
            }
            catch
            {
                hayatsecilenisim.Text = "Listeyi Boşaltın!";
            }
            hayatlistasc();
        }
        private void fensec_Click(object sender, EventArgs e)
        {
            try
            {
                rsayi = r.Next(fenlist.Items.Count);

                fensecilenisim.Text = fenlist.Items[rsayi].ToString();

                fenlist.Items.Remove(fensecilenisim.Text);

                fenseclist.Items.Add(fensecilenisim.Text);
            }
            catch
            {
                fensecilenisim.Text = "Listeyi Boşaltın!";
            }
            fenlistasc();
        }
        #endregion

        #region Direk Seç Butonları
        private void ogrdireksec_Click(object sender, EventArgs e)
        {
            try
            {
                secilenisim.Text = ogrlist.SelectedItem.ToString();

                ogrlist.Items.Remove(secilenisim.Text);

                ogrseclist.Items.Add(secilenisim.Text);
            }
            catch
            {
                secilenisim.Text = "Listeyi Boşaltın!";
            }
            listasc();
        }
        private void turkcedireksec_Click(object sender, EventArgs e)
        {
            try
            {
                turkcesecilenisim.Text = turkcelist.SelectedItem.ToString();

                turkcelist.Items.Remove(turkcesecilenisim.Text);

                turkceseclist.Items.Add(turkcesecilenisim.Text);
            }
            catch
            {
                turkcesecilenisim.Text = "Listeyi Boşaltın!";
            }
            turkcelistasc();
        }
        private void matedireksec_Click(object sender, EventArgs e)
        {
            try
            {
                matesecilenisim.Text = matelist.SelectedItem.ToString();

                matelist.Items.Remove(matesecilenisim.Text);

                mateseclist.Items.Add(matesecilenisim.Text);
            }
            catch
            {
                matesecilenisim.Text = "Listeyi Boşaltın!";
            }
            matelistasc();
        }
        private void hayatdireksec_Click(object sender, EventArgs e)
        {
            try
            {
                hayatsecilenisim.Text = hayatlist.SelectedItem.ToString();

                hayatlist.Items.Remove(hayatsecilenisim.Text);

                hayatseclist.Items.Add(hayatsecilenisim.Text);
            }
            catch
            {
                hayatsecilenisim.Text = "Listeyi Boşaltın!";
            }
            hayatlistasc();
        }
        private void fendireksec_Click(object sender, EventArgs e)
        {
            try
            {
                fensecilenisim.Text = fenlist.SelectedItem.ToString();

                fenlist.Items.Remove(fensecilenisim.Text);

                fenseclist.Items.Add(fensecilenisim.Text);
            }
            catch
            {
                fensecilenisim.Text = "Listeyi Boşaltın!";
            }
            fenlistasc();
        }
        #endregion

        #region Öğrencili Seç Butonları
        private void turkceogrsec_Click(object sender, EventArgs e)
        {
            if (durum.Text == "0")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist.Items.Count);
                        secilenisim.Text = ogrlist.Items[rsayi].ToString();
                        ogrlist.Items.Remove(secilenisim.Text);
                        ogrseclist.Items.Add(secilenisim.Text);
                    }
                    catch
                    { secilenisim.Text = "Listeyi Boşaltın!"; }
                    listasc();

                    rsayi = r.Next(turkcelist.Items.Count);

                    turkcesecilenisim.Text = secilenisim.Text + " : " + turkcelist.Items[rsayi].ToString();

                    turkcelist.Items.Remove(turkcesecilenisim.Text);
                    turkceseclist.Items.Add(turkcesecilenisim.Text);
                }
                catch
                {
                    turkcesecilenisim.Text = "Listeyi Boşaltın!";
                }
                turkcelistasc();
            }
            else if (durum.Text == "1")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist2.Items.Count);
                        secilenisim.Text = ogrlist2.Items[rsayi].ToString();
                        ogrlist2.Items.Remove(secilenisim.Text);
                        ogrseclist2.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(turkcelist.Items.Count);

                        turkcesecilenisim.Text = secilenisim.Text + " : " + turkcelist.Items[rsayi].ToString();

                        turkcelist.Items.Remove(turkcesecilenisim.Text);
                        turkceseclist.Items.Add(turkcesecilenisim.Text);
                    }
                    catch
                    { durum.Text = "0"; }
                    
                }
                catch
                {
                    turkcesecilenisim.Text = "Listeyi Boşaltın!";
                }
                turkcelistasc();
            }
            else if (durum.Text == "2")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist3.Items.Count);
                        secilenisim.Text = ogrlist3.Items[rsayi].ToString();
                        ogrlist3.Items.Remove(secilenisim.Text);
                        ogrseclist3.Items.Add(secilenisim.Text); 
                        listasc();

                        rsayi = r.Next(turkcelist.Items.Count);

                        turkcesecilenisim.Text = secilenisim.Text + " : " + turkcelist.Items[rsayi].ToString();

                        turkcelist.Items.Remove(turkcesecilenisim.Text);
                        turkceseclist.Items.Add(turkcesecilenisim.Text);
                    }
                    catch
                    { durum.Text = "1"; }
                    
                }
                catch
                {
                    turkcesecilenisim.Text = "Listeyi Boşaltın!";
                }
                turkcelistasc();
            }
            else
                MessageBox.Show("Program Çöktü");
        }
        private void mateogrsec_Click(object sender, EventArgs e)
        {
            if (durum.Text == "0")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist.Items.Count);
                        secilenisim.Text = ogrlist.Items[rsayi].ToString();
                        ogrlist.Items.Remove(secilenisim.Text);
                        ogrseclist.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(matelist.Items.Count);

                        matesecilenisim.Text = secilenisim.Text + " : " + matelist.Items[rsayi].ToString();

                        matelist.Items.Remove(matesecilenisim.Text);
                        mateseclist.Items.Add(matesecilenisim.Text);
                    }
                    catch
                    { secilenisim.Text = "Listeyi Boşaltın!"; }
                    
                }
                catch
                {
                    matesecilenisim.Text = "Listeyi Boşaltın!";
                }
                matelistasc();
            }
            else if (durum.Text == "1")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist2.Items.Count);
                        secilenisim.Text = ogrlist2.Items[rsayi].ToString();
                        ogrlist2.Items.Remove(secilenisim.Text);
                        ogrseclist2.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(matelist.Items.Count);

                        matesecilenisim.Text = secilenisim.Text + " : " + matelist.Items[rsayi].ToString();

                        matelist.Items.Remove(matesecilenisim.Text);
                        mateseclist.Items.Add(matesecilenisim.Text);
                    }
                    catch
                    { durum.Text = "0"; }
                    
                }
                catch
                {
                    matesecilenisim.Text = "Listeyi Boşaltın!";
                }
                matelistasc();
            }
            else if (durum.Text == "2")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist3.Items.Count);
                        secilenisim.Text = ogrlist3.Items[rsayi].ToString();
                        ogrlist3.Items.Remove(secilenisim.Text);
                        ogrseclist3.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(matelist.Items.Count);

                        matesecilenisim.Text = secilenisim.Text + " : " + matelist.Items[rsayi].ToString();

                        matelist.Items.Remove(matesecilenisim.Text);
                        mateseclist.Items.Add(matesecilenisim.Text);
                    }
                    catch
                    { durum.Text = "1"; }
                   
                }
                catch
                {
                    matesecilenisim.Text = "Listeyi Boşaltın!";
                }
                matelistasc();
            }
            else
                MessageBox.Show("Program Çöktü");
        }
        private void hayatogrsec_Click(object sender, EventArgs e)
        {
            if (durum.Text == "0")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist.Items.Count);
                        secilenisim.Text = ogrlist.Items[rsayi].ToString();
                        ogrlist.Items.Remove(secilenisim.Text);
                        ogrseclist.Items.Add(secilenisim.Text); 
                        listasc();

                        rsayi = r.Next(hayatlist.Items.Count);

                        hayatsecilenisim.Text = secilenisim.Text + " : " + hayatlist.Items[rsayi].ToString();

                        hayatlist.Items.Remove(hayatsecilenisim.Text);
                        hayatseclist.Items.Add(hayatsecilenisim.Text);
                    }
                    catch
                    { secilenisim.Text = "Listeyi Boşaltın!"; }
                   
                }
                catch
                {
                    hayatsecilenisim.Text = "Listeyi Boşaltın!";
                }
                hayatlistasc();
            }
            else if (durum.Text == "1")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist2.Items.Count);
                        secilenisim.Text = ogrlist2.Items[rsayi].ToString();
                        ogrlist2.Items.Remove(secilenisim.Text);
                        ogrseclist2.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(hayatlist.Items.Count);

                        hayatsecilenisim.Text = secilenisim.Text + " : " + hayatlist.Items[rsayi].ToString();

                        hayatlist.Items.Remove(hayatsecilenisim.Text);
                        hayatseclist.Items.Add(hayatsecilenisim.Text);
                    }
                    catch
                    { durum.Text = "0"; }
                }
                catch
                {
                    hayatsecilenisim.Text = "Listeyi Boşaltın!";
                }
                hayatlistasc();
            }
            else if (durum.Text == "2")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist3.Items.Count);
                        secilenisim.Text = ogrlist3.Items[rsayi].ToString();
                        ogrlist3.Items.Remove(secilenisim.Text);
                        ogrseclist3.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(hayatlist.Items.Count);

                        hayatsecilenisim.Text = secilenisim.Text + " : " + hayatlist.Items[rsayi].ToString();

                        hayatlist.Items.Remove(hayatsecilenisim.Text);
                        hayatseclist.Items.Add(hayatsecilenisim.Text);
                    }
                    catch
                    { durum.Text = "1"; }
                    
                }
                catch
                {
                    hayatsecilenisim.Text = "Listeyi Boşaltın!";
                }
                hayatlistasc();
            }
            else
                MessageBox.Show("Program Çöktü");
        }
        private void fenogrsec_Click(object sender, EventArgs e)
        {
            if (durum.Text == "0")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist.Items.Count);
                        secilenisim.Text = ogrlist.Items[rsayi].ToString();
                        ogrlist.Items.Remove(secilenisim.Text);
                        ogrseclist.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(fenlist.Items.Count);

                        fensecilenisim.Text = secilenisim.Text + " : " + fenlist.Items[rsayi].ToString();

                        fenlist.Items.Remove(fensecilenisim.Text);
                        fenseclist.Items.Add(fensecilenisim.Text);
                    }
                    catch
                    { secilenisim.Text = "Listeyi Boşaltın!"; }
                    
                }
                catch
                {
                    fensecilenisim.Text = "Listeyi Boşaltın!";
                }
                fenlistasc();
            }
            else if (durum.Text == "1")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist2.Items.Count);
                        secilenisim.Text = ogrlist2.Items[rsayi].ToString();
                        ogrlist2.Items.Remove(secilenisim.Text);
                        ogrseclist2.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(fenlist.Items.Count);

                        fensecilenisim.Text = secilenisim.Text + " : " + fenlist.Items[rsayi].ToString();

                        fenlist.Items.Remove(fensecilenisim.Text);
                        fenseclist.Items.Add(fensecilenisim.Text);
                    }
                    catch
                    { durum.Text = "0"; }
                    
                }
                catch
                {
                    fensecilenisim.Text = "Listeyi Boşaltın!";
                }
                fenlistasc();
            }
            else if (durum.Text == "2")
            {
                try
                {
                    try
                    {
                        rsayi = r.Next(ogrlist3.Items.Count);
                        secilenisim.Text = ogrlist3.Items[rsayi].ToString();
                        ogrlist3.Items.Remove(secilenisim.Text);
                        ogrseclist3.Items.Add(secilenisim.Text);
                        listasc();

                        rsayi = r.Next(fenlist.Items.Count);

                        fensecilenisim.Text = secilenisim.Text + " : " + fenlist.Items[rsayi].ToString();

                        fenlist.Items.Remove(fensecilenisim.Text);
                        fenseclist.Items.Add(fensecilenisim.Text);
                    }
                    catch
                    { durum.Text="1"; }
                    
                }
                catch
                {
                    fensecilenisim.Text = "Listeyi Boşaltın!";
                }
                fenlistasc();
            }
            else
                MessageBox.Show("Program Çöktü");
        }
        #endregion

        #region Öğrenci Listesi Değiştirme
        private void suankiders_Click(object sender, EventArgs e)
        {
            durum.Text = "1";
        }
        private void dersadi_Click(object sender, EventArgs e)
        {
            durum.Text = "2";
        }
        private void metroPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            durum.Text = "0";
        }
        #endregion

        #region İsim Ekle Butonları

        private void isimekle_Click(object sender, EventArgs e)
        {//ekle
            if (isimekletex.Text == "")
            {
                MessageBox.Show("Boş bırakılamaz! ");
            }

            /*Daha Sonra ListBox ' a veri yüklemek için bir değişken tanımlıyoruz */
            else
            {
                string veri = isimekletex.Text;
                if (ogrlist.Items.Contains(veri))
                {
                    MessageBox.Show("Aynı Verilerden Daha Önce Eklenmiş ! ");

                }
                else
                {
                    ogrlist.Items.Add(veri);
                    isimekletex.Text = "";

                }
            }
            listasc();
        }
        private void turkcesoruekle_Click(object sender, EventArgs e)
        {
            if (turkceisimekletex.Text == "")
            {
                MessageBox.Show("Boş bırakılamaz! ");
            }

            /*Daha Sonra ListBox ' a veri yüklemek için bir değişken tanımlıyoruz */
            else
            {
                string veri = turkceisimekletex.Text;
                if (turkcelist.Items.Contains(veri))
                {
                    MessageBox.Show("Aynı Verilerden Daha Önce Eklenmiş ! ");

                }
                else
                {
                    turkcelist.Items.Add(veri);
                    turkceisimekletex.Text = "";

                }
            }
            Save_ALL();
            turkcelistasc();
        }
        private void matesoruekle_Click(object sender, EventArgs e)
        {
            if (mateisimekletex.Text == "")
            {
                MessageBox.Show("Boş bırakılamaz! ");
            }

            /*Daha Sonra ListBox ' a veri yüklemek için bir değişken tanımlıyoruz */
            else
            {
                string veri = mateisimekletex.Text;
                if (matelist.Items.Contains(veri))
                {
                    MessageBox.Show("Aynı Verilerden Daha Önce Eklenmiş ! ");

                }
                else
                {
                    matelist.Items.Add(veri);
                    mateisimekletex.Text = "";

                }
            }
            Save_ALL();
            matelistasc();
        }
        private void hayatsoruekle_Click(object sender, EventArgs e)
        {
            if (hayatisimekletex.Text == "")
            {
                MessageBox.Show("Boş bırakılamaz! ");
            }

            /*Daha Sonra ListBox ' a veri yüklemek için bir değişken tanımlıyoruz */
            else
            {
                string veri = hayatisimekletex.Text;
                if (hayatlist.Items.Contains(veri))
                {
                    MessageBox.Show("Aynı Verilerden Daha Önce Eklenmiş ! ");

                }
                else
                {
                    hayatlist.Items.Add(veri);
                    hayatisimekletex.Text = "";

                }
            }
            Save_ALL();
            hayatlistasc();
        }
        private void fensoruekle_Click(object sender, EventArgs e)
        {
            if (fenisimekletex.Text == "")
            {
                MessageBox.Show("Boş bırakılamaz! ");
            }

            /*Daha Sonra ListBox ' a veri yüklemek için bir değişken tanımlıyoruz */
            else
            {
                string veri = fenisimekletex.Text;
                if (fenlist.Items.Contains(veri))
                {
                    MessageBox.Show("Aynı Verilerden Daha Önce Eklenmiş ! ");

                }
                else
                {
                    fenlist.Items.Add(veri);
                    fenisimekletex.Text = "";

                }
            }
            Save_ALL();
            fenlistasc();
        }

        #endregion

        #region İsim Sil Butonları

        private void isimsil_Click(object sender, EventArgs e)
        {//sil
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(ogrlist);
            selectedItems = ogrlist.SelectedItems;

            if (ogrlist.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    ogrlist.Items.Remove(selectedItems[i]);
            }
            Save_ALL();
        }
        private void turkcesorusil_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(turkcelist);
            selectedItems = turkcelist.SelectedItems;

            if (turkcelist.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    turkcelist.Items.Remove(selectedItems[i]);
            }
            Save_ALL();
        }
        private void matesorusil_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(matelist);
            selectedItems = matelist.SelectedItems;

            if (matelist.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    matelist.Items.Remove(selectedItems[i]);
            }
            Save_ALL();
        }
        private void hayatsorusil_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(hayatlist);
            selectedItems = hayatlist.SelectedItems;

            if (hayatlist.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    hayatlist.Items.Remove(selectedItems[i]);
            }
            Save_ALL();
        }
        private void fensorusil_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(fenlist);
            selectedItems = fenlist.SelectedItems;

            if (fenlist.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    fenlist.Items.Remove(selectedItems[i]);
            }
            Save_ALL();
        }

        #endregion

        #region Seçilerin Listesini Boşalt

        public void bosalt()
        {
            object[] objCollection = new object[ogrseclist.Items.Count];
            ogrseclist.Items.CopyTo(objCollection, 0);

            ogrlist.Items.AddRange(objCollection);
            listasc();
            ogrseclist.Items.Clear();
        }
        public void bosalt_ogrenci()
        {
            object[] objCollection2 = new object[ogrseclist2.Items.Count];
            ogrseclist2.Items.CopyTo(objCollection2, 0);

            ogrlist2.Items.AddRange(objCollection2);
            listasc2();
            ogrseclist2.Items.Clear();

            object[] objCollection3 = new object[ogrseclist3.Items.Count];
            ogrseclist3.Items.CopyTo(objCollection3, 0);

            ogrlist3.Items.AddRange(objCollection3);
            listasc3();
            ogrseclist3.Items.Clear();
        }
        public void turkcebosalt()
        {
            turkcelist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//turkcelist.txt"))
                {
                    StreamReader streamturkce = new StreamReader(Application.StartupPath + "//lib//turkcelist.txt");
                    string turkcesatir = streamturkce.ReadLine();
                    while (turkcesatir != null)
                    {
                        turkcelist.Items.Add(turkcesatir);
                        turkcesatir = streamturkce.ReadLine();
                    }
                    streamturkce.Close();
                    listasc();
                    listasc2();
                    listasc3();
                }
                turkceseclist.Items.Clear();
            }
            catch
            {
                ;
            }
            /*object[] turkceCollection = new object[turkceseclist.Items.Count];
            turkceseclist.Items.CopyTo(turkceCollection, 0);

            turkcelist.Items.AddRange(turkceCollection);
            turkcelistasc();
            turkceseclist.Items.Clear();*/
        }
        public void matebosalt()
        {
            matelist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//matelist.txt"))
                {
                    StreamReader streammate = new StreamReader(Application.StartupPath + "//lib//matelist.txt");
                    string matesatir = streammate.ReadLine();
                    while (matesatir != null)
                    {
                        matelist.Items.Add(matesatir);
                        matesatir = streammate.ReadLine();
                    }
                    streammate.Close();
                    listasc();
                    listasc2();
                    listasc3();
                }
                mateseclist.Items.Clear();
            }
            catch
            {
                ;
            }/*
            object[] mateCollection = new object[mateseclist.Items.Count];
            mateseclist.Items.CopyTo(mateCollection, 0);

            matelist.Items.AddRange(mateCollection);
            matelistasc();
            mateseclist.Items.Clear();*/
        }
        public void hayatbosalt()
        {
            hayatlist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//hayatlist.txt"))
                {
                    StreamReader streamhayat = new StreamReader(Application.StartupPath + "//lib//hayatlist.txt");
                    string hayatsatir = streamhayat.ReadLine();
                    while (hayatsatir != null)
                    {
                        hayatlist.Items.Add(hayatsatir);
                        hayatsatir = streamhayat.ReadLine();
                    }
                    streamhayat.Close();
                    listasc();
                    listasc2();
                    listasc3();
                }
                hayatseclist.Items.Clear();
            }
            catch
            {
                ;
            }
            /* object[] hayatCollection = new object[hayatseclist.Items.Count];
             hayatseclist.Items.CopyTo(hayatCollection, 0);

             hayatlist.Items.AddRange(hayatCollection);
             hayatlistasc();
             hayatseclist.Items.Clear();*/
        }
        public void fenbosalt()
        {
            fenlist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//fenlist.txt"))
                {
                    StreamReader streamfen = new StreamReader(Application.StartupPath + "//lib//fenlist.txt");
                    string fensatir = streamfen.ReadLine();
                    while (fensatir != null)
                    {
                        fenlist.Items.Add(fensatir);
                        fensatir = streamfen.ReadLine();
                    }
                    streamfen.Close();
                    listasc();
                    listasc2();
                    listasc3();
                }
                fenseclist.Items.Clear();
            }
            catch
            {
                ;
            }/* object[] fenCollection = new object[fenseclist.Items.Count];
            fenseclist.Items.CopyTo(fenCollection, 0);

            fenlist.Items.AddRange(fenCollection);
            fenlistasc();
            fenseclist.Items.Clear();*/
        }

        private void ogrbosalt_Click(object sender, EventArgs e)
        {//Toplu Çıkar
            //bosalt();
            bosalt_ogrenci();            
        }
        private void turkcecleanlist_Click(object sender, EventArgs e)
        {
            bosalt_ogrenci();
            turkcebosalt();
        }
        private void matecleanlist_Click(object sender, EventArgs e)
        {
            bosalt_ogrenci();
            matebosalt();
        }
        private void hayatcleanlist_Click(object sender, EventArgs e)
        {
            bosalt_ogrenci();
            hayatbosalt();
        }
        private void fencleanlist_Click(object sender, EventArgs e)
        {
            bosalt_ogrenci();
            fenbosalt();
        }

        #endregion

        #region Listeden Listeye

        private void ogrsectolist_Click(object sender, EventArgs e)
        {// >>

            if (ogrseclist.SelectedItem == null)//secılı eleman yoksa en basa don
                return;
            else
            {
                ogrlist.Items.Add(ogrseclist.SelectedItem);
                ogrseclist.Items.Remove(ogrseclist.SelectedItem);

            }
            listasc();
        }
        private void ogrlistosec_Click(object sender, EventArgs e)
        {// <<

            if (ogrlist.SelectedItem == null)//secılı eleman yoksa en basa don
                return;
            else
            {
                ogrseclist.Items.Add(ogrlist.SelectedItem);
                ogrlist.Items.Remove(ogrlist.SelectedItem);
            }
            listasc();
        }

        private void turkcesectolist_Click(object sender, EventArgs e)
        {
            if (turkcelist.SelectedItem == null)
                return;
            else
            {
                turkceseclist.Items.Add(turkcelist.SelectedItem);
                turkcelist.Items.Remove(turkcelist.SelectedItem);
            }
            turkcelistasc();
        }
        private void turkcelistosec_Click(object sender, EventArgs e)
        {
            if (turkcelist.SelectedItem == null)
                return;
            else
            {
                turkceseclist.Items.Add(turkcelist.SelectedItem);
                turkcelist.Items.Remove(turkcelist.SelectedItem);
            }
            turkcelistasc();
        }

        private void matesectolist_Click(object sender, EventArgs e)
        {
            if (matelist.SelectedItem == null)
                return;
            else
            {
                mateseclist.Items.Add(matelist.SelectedItem);
                matelist.Items.Remove(matelist.SelectedItem);
            }
            matelistasc();
        }
        private void matelistosec_Click(object sender, EventArgs e)
        {
            if (matelist.SelectedItem == null)
                return;
            else
            {
                mateseclist.Items.Add(matelist.SelectedItem);
                matelist.Items.Remove(matelist.SelectedItem);
            }
            matelistasc();
        }

        private void hayatsectolist_Click(object sender, EventArgs e)
        {
            if (hayatlist.SelectedItem == null)
                return;
            else
            {
                hayatseclist.Items.Add(hayatlist.SelectedItem);
                hayatlist.Items.Remove(hayatlist.SelectedItem);
            }
            hayatlistasc();
        }
        private void hayatlistosec_Click(object sender, EventArgs e)
        {
            if (hayatlist.SelectedItem == null)
                return;
            else
            {
                hayatseclist.Items.Add(hayatlist.SelectedItem);
                hayatlist.Items.Remove(hayatlist.SelectedItem);
            }
            hayatlistasc();
        }

        private void fensectolist_Click(object sender, EventArgs e)
        {
            if (fenlist.SelectedItem == null)
                return;
            else
            {
                fenseclist.Items.Add(fenlist.SelectedItem);
                fenlist.Items.Remove(fenlist.SelectedItem);
            }
            fenlistasc();
        }
        private void fenlistosec_Click(object sender, EventArgs e)
        {
            if (fenlist.SelectedItem == null)
                return;
            else
            {
                fenseclist.Items.Add(fenlist.SelectedItem);
                fenlist.Items.Remove(fenlist.SelectedItem);
            }
            fenlistasc();
        }
        #endregion

        #region Tüm Liste Elemanlarını Kaldır

        DialogResult Secim = new DialogResult();
        private void tumogrsil_Click(object sender, EventArgs e)
        {//ana listeyi sil

            Secim = MessageBox.Show("Bütün öğrenci listesi silinecek?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {

                ogrlist.Items.Clear();
                ogrseclist.Items.Clear();
            }
        }
        private void turkceallclean_Click(object sender, EventArgs e)
        {
            Secim = MessageBox.Show("Bütün soru listesi silinecek?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {

                turkcelist.Items.Clear();
                turkceseclist.Items.Clear();
            }
        }
        private void mateallclean_Click(object sender, EventArgs e)
        {
            Secim = MessageBox.Show("Bütün soru listesi silinecek?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {

                matelist.Items.Clear();
                mateseclist.Items.Clear();
            }
        }
        private void hayatallclean_Click(object sender, EventArgs e)
        {
            Secim = MessageBox.Show("Bütün soru listesi silinecek?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {

                hayatlist.Items.Clear();
                hayatseclist.Items.Clear();
            }
        }
        private void fenallclean_Click(object sender, EventArgs e)
        {
            Secim = MessageBox.Show("Bütün soru listesi silinecek?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {

                fenlist.Items.Clear();
                fenseclist.Items.Clear();
            }
        }

        #endregion

        #region Sayaç

        private void surebaslat_Click(object sender, EventArgs e)
        {
            if (rasgelesurebut.Text == "Başlat")
            {
                try
                {
                    if (saat.Checked == true || dakika.Checked == true || saniye.Checked == true)
                    {
                        if (sure.Text != "")
                        {
                            if (saat.Checked == true)
                            {
                                say.Text = ((int.Parse(sure.Text)) * 60 * 60).ToString();
                            }
                            else if (dakika.Checked == true)
                            {
                                say.Text = ((int.Parse(sure.Text)) * 60).ToString();
                            }
                            else if (saniye.Checked == true)
                            {
                                say.Text = ((int.Parse(sure.Text))).ToString();
                            }
                            timer1.Start();
                            rasgelesurebut.ForeColor = Color.Red;
                            rasgelesurebut.Text = "Durdur";
                        }
                        else
                        {
                            MessageBox.Show("Süreyi girin.", "Hata");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Süre tipini seçin.", "Hata");
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "Hata");
                }
            }
            else if (rasgelesurebut.Text == "Durdur")
            {
                timer1.Stop();
                tlabel.Stop();
                say.Text = "00";
                say.Visible = true;
                say.ForeColor = Color.Black;
                rasgelesurebut.ForeColor = Color.Red;
                rasgelesurebut.Text = "Başlat";
            }
        }
        #endregion

        #region Label İşlemleri

        public void Label1YanSon()
        {
            tlabel.Start();
        }

        public void tLabel1_Tick(object sender, EventArgs e)
        {
            say.Visible = !say.Visible;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            say.Text = ((int.Parse(say.Text) - 1).ToString());
            if (int.Parse(say.Text) < 10)
            {
                say.ForeColor = Color.Red;
            }
            else
            {
                say.ForeColor = Color.Purple;
            }
            if (int.Parse(say.Text) < 1)
            {
                timer1.Stop();
                Label1YanSon();
                tlabel.Stop();
                /***------***/
                if (kisa_Zil.Checked == true)
                {
                    SoundPlayer zil2 = new SoundPlayer();
                    if (Ayarlarim.Default.sayacdosyayolu == "Default")
                    { zil2.SoundLocation = Application.StartupPath + "\\sound\\ding.wav"; }
                    else
                    { zil2.SoundLocation = Ayarlarim.Default.sayacdosyayolu; }
                    zil2.Play();
                }
                /***------***/
                say.Text = "00";
                say.Visible = true;
                say.ForeColor = Color.Black;
                rasgelesurebut.ForeColor = Color.Black;
                rasgelesurebut.Text = "Başlat";
            }
        }

        #endregion

        #region Dosya aç

        private void turkcedosya_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "//lib//turkcelist.txt");
                DialogResult result = MessageBox.Show("İşleminiz bittimi?", "Onaylama", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    /*********** Türkçe *************/
                    turkcelist.Items.Clear();
                    try
                    {
                        if (File.Exists(Application.StartupPath + "//lib//turkcelist.txt"))
                        {
                            StreamReader streamturkce = new StreamReader(Application.StartupPath + "//lib//turkcelist.txt");
                            string turkcesatir = streamturkce.ReadLine();
                            while (turkcesatir != null)
                            {
                                turkcelist.Items.Add(turkcesatir);
                                turkcesatir = streamturkce.ReadLine();
                            }
                            streamturkce.Close();
                            listasc();

                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }
            catch
            { ; }
        }
        private void matedosya_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "//lib//matelist.txt");
                DialogResult result = MessageBox.Show("İşleminiz bittimi?", "Onaylama", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    /*********** Matematik *************/
                    matelist.Items.Clear();
                    try
                    {
                        if (File.Exists(Application.StartupPath + "//lib//matelist.txt"))
                        {
                            StreamReader streammate = new StreamReader(Application.StartupPath + "//lib//matelist.txt");
                            string matesatir = streammate.ReadLine();
                            while (matesatir != null)
                            {
                                matelist.Items.Add(matesatir);
                                matesatir = streammate.ReadLine();
                            }
                            streammate.Close();
                            listasc();

                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }
            catch
            { ; }
        }
        private void hayatdosya_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "//lib//hayatlist.txt");
                DialogResult result = MessageBox.Show("İşleminiz bittimi?", "Onaylama", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    /*********** Hayat Bilgisi *************/
                    hayatlist.Items.Clear();
                    try
                    {
                        if (File.Exists(Application.StartupPath + "//lib//hayatlist.txt"))
                        {
                            StreamReader streamhayat = new StreamReader(Application.StartupPath + "//lib//hayatlist.txt");
                            string hayatsatir = streamhayat.ReadLine();
                            while (hayatsatir != null)
                            {
                                hayatlist.Items.Add(hayatsatir);
                                hayatsatir = streamhayat.ReadLine();
                            }
                            streamhayat.Close();
                            listasc();

                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }
            catch
            { ; }
        }
        private void fendosya_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "//lib//fenlist.txt");
                DialogResult result = MessageBox.Show("İşleminiz bittimi?", "Onaylama", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    /*********** Fen Bilimleri *************/
                    fenlist.Items.Clear();
                    try
                    {
                        if (File.Exists(Application.StartupPath + "//lib//fenlist.txt"))
                        {
                            StreamReader streamfen = new StreamReader(Application.StartupPath + "//lib//fenlist.txt");
                            string fensatir = streamfen.ReadLine();
                            while (fensatir != null)
                            {
                                fenlist.Items.Add(fensatir);
                                fensatir = streamfen.ReadLine();
                            }
                            streamfen.Close();
                            listasc();

                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }
            catch
            { ; }
        }

        #endregion

        #region Ayarlar

        private void ayarlar_button_Click(object sender, EventArgs e)
        {
            Ayarlar ay = new Ayarlar();
            if (Ayarlarim.Default.Passward == "")
            {
                ay.ShowDialog();
            }
            else
            {
                string veri = Interaction.InputBox("Bilgi Girişi", "Şifrenizi girin.", "");
                if (Ayarlarim.Default.Passward == veri)
                { ay.ShowDialog(); }
                else
                    MessageBox.Show("Şifre Yanlış!", "Uyarı");
            }
        }
        #endregion

        #region Yazım büyütme küçültme
        private void font_up_Click(object sender, EventArgs e)
        {
            turkcesecilenisim.Font = new Font(turkcesecilenisim.Font.FontFamily, turkcesecilenisim.Font.Size + 4);
            fensecilenisim.Font = new Font(fensecilenisim.Font.FontFamily, fensecilenisim.Font.Size + 4);
            matesecilenisim.Font = new Font(matesecilenisim.Font.FontFamily, matesecilenisim.Font.Size + 4);
            hayatsecilenisim.Font = new Font(hayatsecilenisim.Font.FontFamily, hayatsecilenisim.Font.Size + 4);
        }
        private void font_down_Click(object sender, EventArgs e)
        {
            turkcesecilenisim.Font = new Font(turkcesecilenisim.Font.FontFamily, turkcesecilenisim.Font.Size - 4);
            fensecilenisim.Font = new Font(fensecilenisim.Font.FontFamily, fensecilenisim.Font.Size - 4);
            matesecilenisim.Font = new Font(matesecilenisim.Font.FontFamily, matesecilenisim.Font.Size - 4);
            hayatsecilenisim.Font = new Font(hayatsecilenisim.Font.FontFamily, hayatsecilenisim.Font.Size - 4);
        }
        #endregion

        #region liste çizimi
        private void ogrlist_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.White);//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(ogrlist.Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
        #endregion
        #endregion

        #region Zil Bölümü

        public void zilical()
        {
            if (zilsescheck.Checked == true && kalansure.Text == time.ToString("HH:mm") + ":00")
             {
                 SoundPlayer zil = new SoundPlayer();
                 if (Ayarlarim.Default.zildosyayolu == "Default")
                 { zil.SoundLocation = Application.StartupPath + "\\sound\\giris.wav"; }
                 else if (Ayarlarim.Default.zildosyayolu == " ")
                 { zil.SoundLocation = Application.StartupPath + "\\sound\\giris.wav"; }
                 else if (Ayarlarim.Default.zildosyayolu == "")
                 { zil.SoundLocation = Application.StartupPath + "\\sound\\giris.wav"; }
                 else
                 { zil.SoundLocation = Ayarlarim.Default.zildosyayolu; }
                 zil.Play();
             }
        }
        public void zilicalcikis()
        {
            if (zilsescheck.Checked == true)
            { 
            SoundPlayer zils = new SoundPlayer();
            string konumd = Application.StartupPath + "\\sound\\cikis.wav";
            zils.SoundLocation = konumd;
            zils.Play();
            
            }
        }

        public void light_zil()
        {
            ilkzil.Theme = MetroFramework.MetroThemeStyle.Light;
            ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Light;
            ikizil.Theme = MetroFramework.MetroThemeStyle.Light;
            ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Light;
            uczil.Theme = MetroFramework.MetroThemeStyle.Light;
            uczilcikis.Theme = MetroFramework.MetroThemeStyle.Light;
            dortzil.Theme = MetroFramework.MetroThemeStyle.Light;
            dortzilcikis.Theme = MetroFramework.MetroThemeStyle.Light;
            beszil.Theme = MetroFramework.MetroThemeStyle.Light;
            beszilcikis.Theme = MetroFramework.MetroThemeStyle.Light;
            altizil.Theme = MetroFramework.MetroThemeStyle.Light;
            altizilcikis.Theme = MetroFramework.MetroThemeStyle.Light;
        }
        public void dark_zil()
        {
            ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
            ilkzil.UseCustomBackColor = false;
            ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
            ilkzilcikis.UseCustomBackColor = false;
            ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
            ikizil.UseCustomBackColor = false;
            ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
            ikizilcikis.UseCustomBackColor = false;
            uczil.Theme = MetroFramework.MetroThemeStyle.Dark;
            uczil.UseCustomBackColor = false;
            uczilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
            uczilcikis.UseCustomBackColor = false;
            dortzil.Theme = MetroFramework.MetroThemeStyle.Dark;
            dortzil.UseCustomBackColor = false;
            dortzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
            dortzilcikis.UseCustomBackColor = false;
            beszil.Theme = MetroFramework.MetroThemeStyle.Dark;
            beszil.UseCustomBackColor = false;
            beszilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
            beszilcikis.UseCustomBackColor = false;
            altizil.Theme = MetroFramework.MetroThemeStyle.Dark;
            altizil.UseCustomBackColor = false;
            altizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
            altizilcikis.UseCustomBackColor = false;
        }
        public void refreshzil()
        {
            ilkzil.Refresh();
            ilkzilcikis.Refresh();
            ikizil.Refresh();
            ikizilcikis.Refresh();
            uczil.Refresh();
            uczilcikis.Refresh();
            dortzil.Refresh();
            dortzilcikis.Refresh();
            beszil.Refresh();
            beszilcikis.Refresh();
            altizil.Refresh();
            altizilcikis.Refresh();
        }

        public void zilcek()
        {
            Ziltimer.Start();
            if (Zilcheck.Checked == true)
            {

                dersbitmelabel.Visible = true;
                kalansure.Visible = true;

                ilkzil.Enabled = true;
                ilkzilcikis.Enabled = true;
                ikizil.Enabled = true;
                ikizilcikis.Enabled = true;
                uczil.Enabled = true;
                uczilcikis.Enabled = true;
                dortzil.Enabled = true;
                dortzilcikis.Enabled = true;
                beszil.Enabled = true;
                beszilcikis.Enabled = true;
                altizil.Enabled = true;
                altizilcikis.Enabled = true;

                saveallzil.Enabled = true;
            }
            else
            {

                dersbitmelabel.Visible = false;
                kalansure.Visible = false;

                ilkzil.Enabled = false;
                ilkzilcikis.Enabled = false;
                ikizil.Enabled = false;
                ikizilcikis.Enabled = false;
                uczil.Enabled = false;
                uczilcikis.Enabled = false;
                dortzil.Enabled = false;
                dortzilcikis.Enabled = false;
                beszil.Enabled = false;
                beszilcikis.Enabled = false;
                altizil.Enabled = false;
                altizilcikis.Enabled = false;

                saveallzil.Enabled = false;

               // suankiders.Text = "Zil Devredışı.";
            }
        }

        DateTime time = DateTime.Now;
        public void Ziltimer_Tick(object sender, EventArgs e)
        {
            string kisa_zaman = DateTime.Now.ToShortTimeString();

            if (DateTime.Now.TimeOfDay < TimeSpan.Parse(ilkzil.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(ilkzil.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Derseler başlamadı.";
                dersbitmelabel.Text = " Dersin başlamasına kalan süre :";
                zilical();
                light_zil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(ilkzil.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(ilkzilcikis.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(ilkzilcikis.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Birinci derstesiniz.";
                try
                {
                    if ("Monday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        pztilkders.BackColor = Color.Maroon;
                        pztilkders.ForeColor = Color.White;
                        pztilkders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = pztilkders.Text;
                    }
                    if ("Tuesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        saliilkders.BackColor = Color.Maroon;
                        saliilkders.ForeColor = Color.White;
                        saliilkders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = saliilkders.Text;
                    }
                    if ("Wednesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        carsilkders.BackColor = Color.Maroon;
                        carsilkders.ForeColor = Color.White;
                        carsilkders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = carsilkders.Text;
                    }
                    if ("Thursday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        perilkders.BackColor = Color.Maroon;
                        perilkders.ForeColor = Color.White;
                        perilkders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = perilkders.Text;
                    }
                    if ("Friday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        cumailkders.BackColor = Color.Maroon;
                        cumailkders.ForeColor = Color.White;
                        cumailkders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = cumailkders.Text;
                    }
                    if ("Saturday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                    if ("Sunday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                }
                catch { }
                dersbitmelabel.Text = " Dersin bitmesine kalan süre :";
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = true;
                ilkzil.UseCustomForeColor = true;
                refreshzil();

            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(ilkzilcikis.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(ikizil.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(ikizil.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Birinci ders tenefüsündesiniz.";
                dersbitmelabel.Text = " Dersin başlamasına kalan süre :";
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = true;
                ilkzilcikis.UseCustomForeColor = true;
                refreshzil();
            }

            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(ikizil.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(ikizilcikis.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(ikizilcikis.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " İkinci derstesiniz.";
                dersbitmelabel.Text = " Dersin bitmesine kalan süre :";
                try
                {
                    if ("Monday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        pztikiders.BackColor = Color.Maroon;
                        pztikiders.ForeColor = Color.White;
                        pztikiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = pztikiders.Text;
                    }
                    if ("Tuesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        saliikiders.BackColor = Color.Maroon;
                        saliikiders.ForeColor = Color.White;
                        saliikiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = saliikiders.Text;
                    }
                    if ("Wednesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        carsikiders.BackColor = Color.Maroon;
                        carsikiders.ForeColor = Color.White;
                        carsikiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = carsikiders.Text;
                    }
                    if ("Thursday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        perikiders.BackColor = Color.Maroon;
                        perikiders.ForeColor = Color.White;
                        perikiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = perikiders.Text;
                    }
                    if ("Friday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        cumailkders.BackColor = Color.Maroon;
                        cumailkders.ForeColor = Color.White;
                        cumailkders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = cumaikiders.Text;
                    }
                    if ("Saturday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                    if ("Sunday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                }
                catch { }
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = true;
                ikizil.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(ikizilcikis.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(uczil.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(uczil.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " İkinci ders tenefüsündesiniz.";
                dersbitmelabel.Text = " Dersin başlamasına kalan süre :";
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = false;
                ikizil.UseCustomForeColor = false;
                ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizilcikis.UseCustomBackColor = true;
                ikizilcikis.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(uczil.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(uczilcikis.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(uczilcikis.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Üçüncü derstesiniz.";
                dersbitmelabel.Text = " Dersin bitmesine kalan süre :";
                try
                {
                    if ("Monday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        pztucders.BackColor = Color.Maroon;
                        pztucders.ForeColor = Color.White;
                        pztucders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = pztucders.Text;
                    }
                    if ("Tuesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        saliucders.BackColor = Color.Maroon;
                        saliucders.ForeColor = Color.White;
                        saliucders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = saliucders.Text;
                    }
                    if ("Wednesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        carsucders.BackColor = Color.Maroon;
                        carsucders.ForeColor = Color.White;
                        carsucders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = carsucders.Text;
                    }
                    if ("Thursday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        perucders.BackColor = Color.Maroon;
                        perucders.ForeColor = Color.White;
                        perucders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = perucders.Text;
                    }
                    if ("Friday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        cumaucders.BackColor = Color.Maroon;
                        cumaucders.ForeColor = Color.White;
                        cumaucders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = cumaucders.Text;
                    }
                    if ("Saturday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                    if ("Sunday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                }
                catch { }
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = false;
                ikizil.UseCustomForeColor = false;
                ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizilcikis.UseCustomBackColor = false;
                ikizilcikis.UseCustomForeColor = false;
                uczil.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczil.UseCustomBackColor = true;
                uczil.UseCustomForeColor = true;

                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(uczilcikis.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(dortzil.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(dortzil.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Üçüncü ders tenefüsündesiniz.";
                dersbitmelabel.Text = " Dersin başlamasına kalan süre :";
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = false;
                ikizil.UseCustomForeColor = false;
                ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizilcikis.UseCustomBackColor = false;
                ikizilcikis.UseCustomForeColor = false;
                uczil.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczil.UseCustomBackColor = false;
                uczil.UseCustomForeColor = false;
                uczilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczilcikis.UseCustomBackColor = true;
                uczilcikis.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(dortzil.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(dortzilcikis.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(dortzilcikis.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Dördüncü derstesiniz.";
                dersbitmelabel.Text = " Dersin bitmesine kalan süre :";
                try
                {
                    if ("Monday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        pztdortders.BackColor = Color.Maroon;
                        pztdortders.ForeColor = Color.White;
                        pztdortders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = pztdortders.Text;
                    }
                    if ("Tuesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        salidortders.BackColor = Color.Maroon;
                        salidortders.ForeColor = Color.White;
                        salidortders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = salidortders.Text;
                    }
                    if ("Wednesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        carsdortders.BackColor = Color.Maroon;
                        carsdortders.ForeColor = Color.White;
                        carsdortders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = carsdortders.Text;
                    }
                    if ("Thursday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        perdortders.BackColor = Color.Maroon;
                        perdortders.ForeColor = Color.White;
                        perdortders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = perdortders.Text;
                    }
                    if ("Friday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        cumadortders.BackColor = Color.Maroon;
                        cumadortders.ForeColor = Color.White;
                        cumadortders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = cumadortders.Text;
                    }
                    if ("Saturday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                    if ("Sunday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                }
                catch { }
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = false;
                ikizil.UseCustomForeColor = false;
                ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizilcikis.UseCustomBackColor = false;
                ikizilcikis.UseCustomForeColor = false;
                uczil.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczil.UseCustomBackColor = false;
                uczil.UseCustomForeColor = false;
                uczilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczilcikis.UseCustomBackColor = false;
                uczilcikis.UseCustomForeColor = false;
                dortzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzil.UseCustomBackColor = true;
                dortzil.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(dortzilcikis.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(beszil.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(beszil.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Dördüncü ders tenefüsündesiniz.";
                dersbitmelabel.Text = " Dersin başlamasına kalan süre :";
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = false;
                ikizil.UseCustomForeColor = false;
                ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizilcikis.UseCustomBackColor = false;
                ikizilcikis.UseCustomForeColor = false;
                uczil.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczil.UseCustomBackColor = false;
                uczil.UseCustomForeColor = false;
                uczilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczilcikis.UseCustomBackColor = false;
                uczilcikis.UseCustomForeColor = false;
                dortzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzil.UseCustomBackColor = false;
                dortzil.UseCustomForeColor = false;
                dortzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzilcikis.UseCustomBackColor = true;
                dortzilcikis.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(beszil.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(beszilcikis.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(beszilcikis.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Beşinci derstesiniz.";
                dersbitmelabel.Text = " Dersin bitmesine kalan süre :";
                try
                {
                    if ("Monday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        pztbesders.BackColor = Color.Maroon;
                        pztbesders.ForeColor = Color.White;
                        pztbesders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = pztbesders.Text;
                    }
                    if ("Tuesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        salibesders.BackColor = Color.Maroon;
                        salibesders.ForeColor = Color.White;
                        salibesders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = salibesders.Text;
                    }
                    if ("Wednesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        carsbesders.BackColor = Color.Maroon;
                        carsbesders.ForeColor = Color.White;
                        carsbesders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = carsbesders.Text;
                    }
                    if ("Thursday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        perbesders.BackColor = Color.Maroon;
                        perbesders.ForeColor = Color.White;
                        perbesders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = perbesders.Text;
                    }
                    if ("Friday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        cumabesders.BackColor = Color.Maroon;
                        cumabesders.ForeColor = Color.White;
                        cumabesders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = cumabesders.Text;
                    }
                    if ("Saturday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                    if ("Sunday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                }
                catch { }
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = false;
                ikizil.UseCustomForeColor = false;
                ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizilcikis.UseCustomBackColor = false;
                ikizilcikis.UseCustomForeColor = false;
                uczil.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczil.UseCustomBackColor = false;
                uczil.UseCustomForeColor = false;
                uczilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczilcikis.UseCustomBackColor = false;
                uczilcikis.UseCustomForeColor = false;
                dortzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzil.UseCustomBackColor = false;
                dortzil.UseCustomForeColor = false;
                dortzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzilcikis.UseCustomBackColor = false;
                dortzilcikis.UseCustomForeColor = false;
                beszil.Theme = MetroFramework.MetroThemeStyle.Dark;
                beszil.UseCustomBackColor = true;
                beszil.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(beszilcikis.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(altizil.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(altizil.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Beşinci ders tenefüsündesiniz.";
                dersbitmelabel.Text = " Dersin başlamasına kalan süre :";
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = false;
                ikizil.UseCustomForeColor = false;
                ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizilcikis.UseCustomBackColor = false;
                ikizilcikis.UseCustomForeColor = false;
                uczil.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczil.UseCustomBackColor = false;
                uczil.UseCustomForeColor = false;
                uczilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczilcikis.UseCustomBackColor = false;
                uczilcikis.UseCustomForeColor = false;
                dortzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzil.UseCustomBackColor = false;
                dortzil.UseCustomForeColor = false;
                dortzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzilcikis.UseCustomBackColor = false;
                dortzilcikis.UseCustomForeColor = false;
                beszil.Theme = MetroFramework.MetroThemeStyle.Dark;
                beszil.UseCustomBackColor = false;
                beszil.UseCustomForeColor = false;
                beszilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                beszilcikis.UseCustomBackColor = true;
                beszilcikis.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(altizil.Text) && DateTime.Now.TimeOfDay < TimeSpan.Parse(altizilcikis.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(altizilcikis.Text) - Convert.ToDateTime(kisa_zaman));
                suankiders.Text = " Altıncı derstesiniz.";
                dersbitmelabel.Text = " Dersin bitmesine kalan süre :";
                try
                {
                    if ("Monday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        pztaltiders.BackColor = Color.Maroon;
                        pztaltiders.ForeColor = Color.White;
                        pztaltiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = pztaltiders.Text;
                    }
                    if ("Tuesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        salialtiders.BackColor = Color.Maroon;
                        salialtiders.ForeColor = Color.White;
                        salialtiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = salialtiders.Text;
                    }
                    if ("Wednesday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        carsaltiders.BackColor = Color.Maroon;
                        carsaltiders.ForeColor = Color.White;
                        carsaltiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = carsaltiders.Text;
                    }
                    if ("Thursday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        peraltiders.BackColor = Color.Maroon;
                        peraltiders.ForeColor = Color.White;
                        peraltiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = peraltiders.Text;
                    }
                    if ("Friday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        cumaaltiders.BackColor = Color.Maroon;
                        cumaaltiders.ForeColor = Color.White;
                        cumaaltiders.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
                        dersadi.Text = cumaaltiders.Text;
                    }
                    if ("Saturday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                    if ("Sunday" == Convert.ToString(DateTime.Now.DayOfWeek.ToString()))
                    {
                        dersadi.Text = "İyi Tatiller.";
                    }
                }
                catch { }
                zilical();
                light_zil();
                ilkzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzil.UseCustomBackColor = false;
                ilkzil.UseCustomForeColor = false;
                ilkzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ilkzilcikis.UseCustomBackColor = false;
                ilkzilcikis.UseCustomForeColor = false;
                ikizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizil.UseCustomBackColor = false;
                ikizil.UseCustomForeColor = false;
                ikizilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                ikizilcikis.UseCustomBackColor = false;
                ikizilcikis.UseCustomForeColor = false;
                uczil.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczil.UseCustomBackColor = false;
                uczil.UseCustomForeColor = false;
                uczilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                uczilcikis.UseCustomBackColor = false;
                uczilcikis.UseCustomForeColor = false;
                dortzil.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzil.UseCustomBackColor = false;
                dortzil.UseCustomForeColor = false;
                dortzilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                dortzilcikis.UseCustomBackColor = false;
                dortzilcikis.UseCustomForeColor = false;
                beszil.Theme = MetroFramework.MetroThemeStyle.Dark;
                beszil.UseCustomBackColor = false;
                beszil.UseCustomForeColor = false;
                beszilcikis.Theme = MetroFramework.MetroThemeStyle.Dark;
                beszilcikis.UseCustomBackColor = false;
                beszilcikis.UseCustomForeColor = false;
                altizil.Theme = MetroFramework.MetroThemeStyle.Dark;
                altizil.UseCustomBackColor = true;
                altizil.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay == TimeSpan.Parse(altizilcikis.Text))
            {
                zilical();
                suankiders.Text = " Dersler bitmiştir.";
                altizilcikis.UseCustomBackColor = true;
                altizilcikis.UseCustomForeColor = true;
                refreshzil();
            }
            if (DateTime.Now.TimeOfDay > TimeSpan.Parse(altizilcikis.Text))
            {
                kalansure.Text = Convert.ToString(Convert.ToDateTime(ilkzil.Text) - Convert.ToDateTime(kisa_zaman));
                dersbitmelabel.Text = " Dersin başlamasına kalan süre :";
                dark_zil();
                refreshzil();
            }



        }

        private void Zilcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (Zilcheck.Checked == true)
                zilcek();
            else
                Ziltimer.Stop();
        }

        private void degispanelbuton_Click(object sender, EventArgs e)
        {
            degistirpanel.Visible = true;
        }
        #endregion

        #region Saat Tarih
        private void saattimer_Tick(object sender, EventArgs e)
        {
            saatlabel.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString(); // DateTime.Now.ToString();
        }

        private void saatlabel_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(saatlabel.Text);
            MessageBox.Show("Tarih - Saat Kopyalandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Ders Programı
        private void dersprogac_Click(object sender, EventArgs e)
        {
            if (dersprogac.Text == "Ders Programı")
            {
                Derspanel.Size = new Size(400, 392);
                dersprogac.Text = "Küçült";
            }
            else
            {
                Derspanel.Size = new Size(130, 30);
                dersprogac.Text = "Ders Programı";
            }
        }
        public void Derscek()
        {
            pztilkders.Text = Ayarlarim.Default.pz1;
            pztikiders.Text = Ayarlarim.Default.pz2;
            pztucders.Text = Ayarlarim.Default.pz3;
            pztdortders.Text = Ayarlarim.Default.pz4;
            pztbesders.Text = Ayarlarim.Default.pz5;
            pztaltiders.Text = Ayarlarim.Default.pz6;

            saliilkders.Text = Ayarlarim.Default.sl1;
            saliikiders.Text = Ayarlarim.Default.sl2;
            saliucders.Text = Ayarlarim.Default.sl3;
            salidortders.Text = Ayarlarim.Default.sl4;
            salibesders.Text = Ayarlarim.Default.sl5;
            salialtiders.Text = Ayarlarim.Default.sl6;

            carsilkders.Text = Ayarlarim.Default.cr1;
            carsikiders.Text = Ayarlarim.Default.cr2;
            carsucders.Text = Ayarlarim.Default.cr3;
            carsdortders.Text = Ayarlarim.Default.cr4;
            carsbesders.Text = Ayarlarim.Default.cr5;
            carsaltiders.Text = Ayarlarim.Default.cr6;

            perilkders.Text = Ayarlarim.Default.pr1;
            perikiders.Text = Ayarlarim.Default.pr2;
            perucders.Text = Ayarlarim.Default.pr3;
            perdortders.Text = Ayarlarim.Default.pr4;
            perbesders.Text = Ayarlarim.Default.pr5;
            peraltiders.Text = Ayarlarim.Default.pr6;

            cumailkders.Text = Ayarlarim.Default.cm1;
            cumaikiders.Text = Ayarlarim.Default.cm2;
            cumaucders.Text = Ayarlarim.Default.cm3;
            cumadortders.Text = Ayarlarim.Default.cm4;
            cumabesders.Text = Ayarlarim.Default.cm5;
            cumaaltiders.Text = Ayarlarim.Default.cm6;
        }
        private void Derskaydet_Click(object sender, EventArgs e)
        {
            Ayarlarim.Default.pz1 = pztilkders.Text;
            Ayarlarim.Default.pz2 = pztikiders.Text;
            Ayarlarim.Default.pz3 = pztucders.Text;
            Ayarlarim.Default.pz4 = pztdortders.Text;
            Ayarlarim.Default.pz5 = pztbesders.Text;
            Ayarlarim.Default.pz6 = pztaltiders.Text;

            Ayarlarim.Default.sl1 = saliilkders.Text;
            Ayarlarim.Default.sl2 = saliikiders.Text;
            Ayarlarim.Default.sl3 = saliucders.Text;
            Ayarlarim.Default.sl4 = salidortders.Text;
            Ayarlarim.Default.sl5 = salibesders.Text;
            Ayarlarim.Default.sl6 = salialtiders.Text;

            Ayarlarim.Default.cr1 = carsilkders.Text;
            Ayarlarim.Default.cr2 = carsikiders.Text;
            Ayarlarim.Default.cr3 = carsucders.Text;
            Ayarlarim.Default.cr4 = carsdortders.Text;
            Ayarlarim.Default.cr5 = carsbesders.Text;
            Ayarlarim.Default.cr6 = carsaltiders.Text;

            Ayarlarim.Default.pr1 = perilkders.Text;
            Ayarlarim.Default.pr2 = perikiders.Text;
            Ayarlarim.Default.pr3 = perucders.Text;
            Ayarlarim.Default.pr4 = perdortders.Text;
            Ayarlarim.Default.pr5 = perbesders.Text;
            Ayarlarim.Default.pr6 = peraltiders.Text;

            Ayarlarim.Default.cm1 = cumailkders.Text;
            Ayarlarim.Default.cm2 = cumaikiders.Text;
            Ayarlarim.Default.cm3 = cumaucders.Text;
            Ayarlarim.Default.cm4 = cumadortders.Text;
            Ayarlarim.Default.cm5 = cumabesders.Text;
            Ayarlarim.Default.cm6 = cumaaltiders.Text;

        }
        #endregion

        #region Ayarların Yüklenmesi ve Kaydı

        public void allyukle()
        {
            if (Ayarlarim.Default.zilchek == "1")
            {
                Zilcheck.CheckState = CheckState.Checked;
                zilcek();
            }
            else
                Zilcheck.CheckState = CheckState.Unchecked;

            if (Ayarlarim.Default.zilses == "1")
                zilsescheck.CheckState = CheckState.Checked;
            else
                zilsescheck.CheckState = CheckState.Unchecked;

            if (Ayarlarim.Default.kisaZil == "1")
                kisa_Zil.CheckState = CheckState.Checked; 
            else
                kisa_Zil.CheckState = CheckState.Unchecked; 

            
            ilkzil.Text = Ayarlarim.Default.ilkzil;
            ilkzilcikis.Text = Ayarlarim.Default.ilkzilcikis;
            ikizil.Text = Ayarlarim.Default.ikizil;
            ikizilcikis.Text = Ayarlarim.Default.ikizilcikis;
            uczil.Text = Ayarlarim.Default.uczil;
            uczilcikis.Text = Ayarlarim.Default.uczilcikis;
            dortzil.Text = Ayarlarim.Default.dortzil;
            dortzilcikis.Text = Ayarlarim.Default.dortzilcikis;
            beszil.Text = Ayarlarim.Default.beszil;
            beszilcikis.Text = Ayarlarim.Default.beszilcikis;
            altizil.Text = Ayarlarim.Default.altizil;
            altizilcikis.Text = Ayarlarim.Default.altizilcikis;

            degisilkzil.Text = Ayarlarim.Default.ilkzil;
            degisilkzilcikis.Text = Ayarlarim.Default.ilkzilcikis;
            degisikizil.Text = Ayarlarim.Default.ikizil;
            degisikizilcikis.Text = Ayarlarim.Default.ikizilcikis;
            degisuczil.Text = Ayarlarim.Default.uczil;
            degisuczilcikis.Text = Ayarlarim.Default.uczilcikis;
            degisdortzil.Text = Ayarlarim.Default.dortzil;
            degisdortzilcikis.Text = Ayarlarim.Default.dortzilcikis;
            degisbeszil.Text = Ayarlarim.Default.beszil;
            degisbeszilcikis.Text = Ayarlarim.Default.beszilcikis;
            degisaltizil.Text = Ayarlarim.Default.altizil;
            degisaltizilcikis.Text = Ayarlarim.Default.altizilcikis;
        }
        public void allkaydet()
        {
            if (Zilcheck.CheckState == CheckState.Checked)
                Ayarlarim.Default.zilchek = "1"; 
            else
                Ayarlarim.Default.zilchek = "0";

            if (zilsescheck.CheckState == CheckState.Checked)
                Ayarlarim.Default.zilses = "1"; 
            else
                Ayarlarim.Default.zilses = "0";

            if (kisa_Zil.CheckState == CheckState.Checked)
                Ayarlarim.Default.kisaZil = "1"; 
            else
                Ayarlarim.Default.kisaZil = "0"; 

            Ayarlarim.Default.ilkzil = ilkzil.Text;
            Ayarlarim.Default.ilkzilcikis = ilkzilcikis.Text;
            Ayarlarim.Default.ikizil = ikizil.Text;
            Ayarlarim.Default.ikizilcikis = ikizilcikis.Text;
            Ayarlarim.Default.uczil = uczil.Text;
            Ayarlarim.Default.uczilcikis = uczilcikis.Text;
            Ayarlarim.Default.dortzil = dortzil.Text;
            Ayarlarim.Default.dortzilcikis = dortzilcikis.Text;
            Ayarlarim.Default.beszil = beszil.Text;
            Ayarlarim.Default.beszilcikis = beszilcikis.Text;
            Ayarlarim.Default.altizil = altizil.Text;
            Ayarlarim.Default.altizilcikis = altizilcikis.Text;

            Ayarlarim.Default.Save();
        }
        public void dosyaoku()
        {
            ogrlist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//ogrlist.txt"))
                {
                    StreamReader ogrenci = new StreamReader(Application.StartupPath + "//lib//ogrlist.txt");
                    string satir = ogrenci.ReadLine();
                    while (satir != null)
                    {
                        ogrlist.Items.Add(satir);
                        satir = ogrenci.ReadLine();
                    }
                    ogrenci.Close();
                    listasc();

                }
            }
            catch
            {
                ;
            }
            /******** Orta Öğrenciler *******/
            ogrlist2.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//ogrlist2.txt"))
                {
                    StreamReader ogrenci = new StreamReader(Application.StartupPath + "//lib//ogrlist2.txt");
                    string satir = ogrenci.ReadLine();
                    while (satir != null)
                    {
                        ogrlist2.Items.Add(satir);
                        satir = ogrenci.ReadLine();
                    }
                    ogrenci.Close();
                    listasc();

                }
            }
            catch
            {
                ;
            }
            /******* Düşük Öğrenciler *******/
            ogrlist3.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//ogrlist3.txt"))
                {
                    StreamReader ogrenci = new StreamReader(Application.StartupPath + "//lib//ogrlist3.txt");
                    string satir = ogrenci.ReadLine();
                    while (satir != null)
                    {
                        ogrlist3.Items.Add(satir);
                        satir = ogrenci.ReadLine();
                    }
                    ogrenci.Close();
                    listasc();

                }
            }
            catch
            {
                ;
            }

            /*********** Türkçe *************/
            turkcelist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//turkcelist.txt"))
                {
                    StreamReader streamturkce = new StreamReader(Application.StartupPath + "//lib//turkcelist.txt");
                    string turkcesatir = streamturkce.ReadLine();
                    while (turkcesatir != null)
                    {
                        turkcelist.Items.Add(turkcesatir);
                        turkcesatir = streamturkce.ReadLine();
                    }
                    streamturkce.Close();
                    listasc();

                }
            }
            catch
            {
                ;
            }
            /*********** Matematik *************/
            matelist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//matelist.txt"))
                {
                    StreamReader streammate = new StreamReader(Application.StartupPath + "//lib//matelist.txt");
                    string matesatir = streammate.ReadLine();
                    while (matesatir != null)
                    {
                        matelist.Items.Add(matesatir);
                        matesatir = streammate.ReadLine();
                    }
                    streammate.Close();
                    listasc();

                }
            }
            catch
            {
                ;
            }
            /*********** Hayat Bilgisi *************/
            hayatlist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//hayatlist.txt"))
                {
                    StreamReader streamhayat = new StreamReader(Application.StartupPath + "//lib//hayatlist.txt");
                    string hayatsatir = streamhayat.ReadLine();
                    while (hayatsatir != null)
                    {
                        hayatlist.Items.Add(hayatsatir);
                        hayatsatir = streamhayat.ReadLine();
                    }
                    streamhayat.Close();
                    listasc();

                }
            }
            catch
            {
                ;
            }
            /*********** Fen Bilimleri *************/
            fenlist.Items.Clear();
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//fenlist.txt"))
                {
                    StreamReader streamfen = new StreamReader(Application.StartupPath + "//lib//fenlist.txt");
                    string fensatir = streamfen.ReadLine();
                    while (fensatir != null)
                    {
                        fenlist.Items.Add(fensatir);
                        fensatir = streamfen.ReadLine();
                    }
                    streamfen.Close();
                    listasc();

                }
            }
            catch
            {
                ;
            }
            /********* Not **********/
            try
            {
                if (File.Exists(Application.StartupPath + "//lib//not.txt"))
                {
                    StreamReader streamnot = new StreamReader(Application.StartupPath + "//lib//not.txt");
                    Not.Text = streamnot.ReadLine();
                    streamnot.Close();

                }
            }
            catch
            {
                ;
            }
        }

        private void saveallzil_Click(object sender, EventArgs e)
        {
            try
            {                
                ilkzil.Text = degisilkzil.Text;
                ilkzilcikis.Text = degisilkzilcikis.Text;
                ikizil.Text = degisikizil.Text;
                ikizilcikis.Text = degisikizilcikis.Text;
                uczil.Text = degisuczil.Text;
                uczilcikis.Text = degisuczilcikis.Text;
                dortzil.Text = degisdortzil.Text;
                dortzilcikis.Text = degisdortzilcikis.Text;
                beszil.Text = degisbeszil.Text;
                beszilcikis.Text = degisbeszilcikis.Text;
                altizil.Text = degisaltizil.Text;
                altizilcikis.Text = degisaltizilcikis.Text;
                allkaydet();
                allyukle();

            }
            catch
            {
                MessageBox.Show("Kaydetme özelliği çalıştırılamadı.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                degistirpanel.Visible = false;
            }
            finally
            {
                MessageBox.Show("Kaydetme başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                degistirpanel.Visible = false;
            }

        }

        #endregion

        #region Form Kapanırken Ve Yenileme İşlemi
        public void Save_ALL()
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\lib"))
                { }
                else
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\lib");
                }
                String[] Dizi = new String[ogrlist.Items.Count];
                ogrlist.Items.CopyTo(Dizi, 0);
                System.IO.File.WriteAllLines(Application.StartupPath + "\\lib\\ogrlist.txt", Dizi);

                String[] turkceDizi = new String[turkcelist.Items.Count];
                turkcelist.Items.CopyTo(turkceDizi, 0);
                System.IO.File.WriteAllLines(Application.StartupPath + "\\lib\\turkcelist.txt", turkceDizi);

                String[] mateDizi = new String[matelist.Items.Count];
                matelist.Items.CopyTo(mateDizi, 0);
                System.IO.File.WriteAllLines(Application.StartupPath + "\\lib\\matelist.txt", mateDizi);

                String[] hayatDizi = new String[hayatlist.Items.Count];
                hayatlist.Items.CopyTo(hayatDizi, 0);
                System.IO.File.WriteAllLines(Application.StartupPath + "\\lib\\hayatlist.txt", hayatDizi);

                String[] fenDizi = new String[fenlist.Items.Count];
                fenlist.Items.CopyTo(fenDizi, 0);
                System.IO.File.WriteAllLines(Application.StartupPath + "\\lib\\fenlist.txt", fenDizi);

                StreamWriter nots = new StreamWriter(Application.StartupPath + "\\lib\\not.txt");
                nots.WriteLine(Not.Text);
                nots.Close();

            }
            catch
            {
                MessageBox.Show("Kayıt işlemi başarısız!", "Bilgi");
                try
                {
                    File.Delete(Application.StartupPath + "\\lib\\ogrlist.txt");
                    File.Delete(Application.StartupPath + "\\lib\\turkcelist.txt");
                    File.Delete(Application.StartupPath + "\\lib\\matelist.txt");
                    File.Delete(Application.StartupPath + "\\lib\\hayatlist.txt");
                    File.Delete(Application.StartupPath + "\\lib\\fenlist.txt");
                }
                catch
                {
                    if (File.Exists(Application.StartupPath + "\\lib"))
                    { }
                    else
                    {
                        System.IO.Directory.CreateDirectory(Application.StartupPath + "\\lib");
                        File.Create(Application.StartupPath + "\\lib\\ogrlist.txt");
                        File.Create(Application.StartupPath + "\\lib\\turkcelist.txt");
                        File.Create(Application.StartupPath + "\\lib\\matelist.txt");
                        File.Create(Application.StartupPath + "\\lib\\hayatlist.txt");
                        File.Create(Application.StartupPath + "\\lib\\fenlist.txt");
                    }
                }

            }
            finally
            {
                allkaydet();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ogretmen_Asistan.Ayarlarim.Default.Anaform = "0";

            //bosalt();
            bosalt_ogrenci();
            turkcebosalt();
            matebosalt();
            hayatbosalt();
            fenbosalt();

            Save_ALL();
        }
        private void restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        #endregion

        #region Yarışma Formu
        Yarismaform yaris;
        private void YarismaTakipBut_Click(object sender, EventArgs e)
        {
            if (Ogretmen_Asistan.Ayarlarim.Default.Yarismaform == "1")
            {
                var yaris = new Yarismaform();
                if (Application.OpenForms[yaris.Name] == null)
                {
                    yaris.Show();
                }
                else
                {
                    Application.OpenForms[yaris.Name].Focus();
                }
            }
            else
            {
                yaris = new Yarismaform();
                yaris.Show();

            }
        }
        #endregion

        #region Eklentiler (Admin - Sahip)
        private void admin_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Bu düzenleme bölümü sadece yetkili girişi içindir!", "Dikkat");
            string veri = Interaction.InputBox("Admin Girişi", "Şifre", "");
            if (veri == "820KemSay2095")
            {
                this.MaximumSize = new Size(1280, 560);
                this.Size = new Size(1280, 560);
            }


        }
        private void Sahip_Click(object sender, EventArgs e)
        {
            //Process.Start("https://www.instagram.com/sayginkizilkaya/");
        }
        #endregion

        #region bugged

        /*  private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] veriler1 = new string[ogrlist.Items.Count];
                for (int i = 0; i < ogrlist.Items.Count; i++)
                {
                    veriler1[i] = ogrlist.Items[i].ToString();
                }

                List<string> veriler2 = new List<string>();
                foreach (var item in ogrlist.Items)
                {
                    veriler2.Add(item.ToString());
                }

                var veriler3 = ogrlist.Items.Cast<String>().ToArray();

                
                rsayi = r.Next(0,veriler3.Length);

                secilenisim.Text = veriler3[rsayi].ToString();

                ogrlist.Items.Remove(secilenisim.Text);   

                ogrseclist.Items.Add(veriler3[rsayi].ToString());
            }
            catch
            {
                secilenisim.Text = "Listeyi Boşaltın!";
            }
            listasc();

        }*/
        #endregion
    }
}
