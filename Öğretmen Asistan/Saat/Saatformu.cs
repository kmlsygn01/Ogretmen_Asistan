using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ogretmen_Asistan
{
    public partial class Saatformu : Form
    {
        public Saatformu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width -15, scrn.Bounds.Top+30);
                    return;
                }
            }
        }

        private Graphics FGraphics = null;
        private Bitmap FBitmap = null;
        private Bitmap FBackground = null;
        private Bitmap FOverlay = null;
        private Bitmap FHour = null;
        private Bitmap FMinute = null;
        private Bitmap FSecond = null;
        private Bitmap FDot = null;
        private byte FOpacity = 0xff;

        
        private void Form1_Load(object sender, EventArgs e)
        {
            ana = new Anaform();
            ana.Show();

            /* Zemin resmini yukle */
            FBackground = new Bitmap(".\\resource\\trad.png");

            /* Kaplama icin resmi yukle. Kaplama programa ayri bir gorsellik katiyor. Sadece onun icin. */
            FOverlay = new Bitmap(".\\resource\\trad_highlights.png");

            /* Saat icin resmi yukle */
            FHour = new Bitmap(".\\resource\\trad_h.png");

            /* Dakika icin resmi yukle */
            FMinute = new Bitmap(".\\resource\\trad_m.png");

            /* Saniye icin resmi yukle */
            FSecond = new Bitmap(".\\resource\\trad_s.png");

            /* Nokta icin resmi yukle */
            FDot = new Bitmap(".\\resource\\trad_dot.png");

            /* Ana formun genislik ve yuksekligini Background resmi ile ayni yap ki tasma veya kirpilma olmasin. */
            this.Width = FBackground.Width;
            this.Height = FBackground.Height;

            /* Programin can damari burada. Ana formu "Katmanli Pencere" sitiline gecirmeliyiz.
               Yoksa hicbir etkisi olmaz! */
            long style = CreateParams.ExStyle;
            style |= Windows.WS_EX_LAYERED;
            Windows.SetWindowLong(this.Handle, Windows.GWL_EXSTYLE, (IntPtr)style);

            /* Hafizada, ana form boyutlarinda bos bir resim olusturuyoruz.
               Resim formati 32bit Alpha Channel. Burasi cok onemli. Yoksa golgeler olusmaz! */
            FBitmap = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            /* Basit bir teknik. Grahics sinifi aslinda TCanvas sinifina denk duser, unutmayin!
               FGraphics ile yapilan cizimler aynen FBitmap nesnesine yapilir. Dogal olarak
               formumuza cizmis olacagiz. Ayni TForm sinifindaki Canvas nesnesi gibi! */
            FGraphics = Graphics.FromImage(FBitmap);

            /* Opacity (Donukluk). Delphi formlarindaki AlphaBlendValue ile aynidir.
               Fakat burada FOpacity degiskeni ile formumuzun donuklugunu (yada saydamligini)
               ayarlayacagiz. Bkz. procedure UpdateLayeredForm; */
            FOpacity = 0xef; /* 0xff = tam donuk. */

            /* Evet. Formu artik cizebiliriz. */
            RepaintForm();

            /* Iste en onemli proseduru cagirma zamani. Hersey tamam, artik Windows'a
               form uzerinde olusturdugumuz resmi, pencere ile butunlestirme zamani geldi. */
            UpdateLayeredForm();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* Her saniye form alanini yeniden cizmek zorundayiz. */
            RepaintForm();

            /* Ayrica cizdigimiz form alanini guncellemeliyiz. */
            UpdateLayeredForm();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Windows.ReleaseCapture();
                Windows.SendMessage(this.Handle, Windows.WM_SYSCOMMAND, Windows.SC_DRAGMOVE, 0x0);
            }
        }

        private void RepaintForm()
        {
            /* Herseyi temizlemek gerek. Onceki cizimler silinmezse ust uste biner. */
            ClearGraphics();

            /* Zemin resmini ciz. */
            PaintBackground();

            /* Saat parcalarini ciz. */
            PaintElements();

            /* Kaplama resmini ciz. */
            PaintOverlay();
        }
        private void UpdateLayeredForm()
        {
            /* Desktop ile uyumlu bir DC olustur. */
            IntPtr SrcDC = Windows.CreateCompatibleDC(IntPtr.Zero);

            /* Olusturdugumuz DC ile uyumlu yeni bir DC daha olusturmaliyiz. Kopyalama icin. */
            IntPtr DestDC = Windows.CreateCompatibleDC(SrcDC);

            /* Cizim yaptigimiz resmin Windows tarafidan anlasilan HBITMAP turunden degiskene ata.
               Bu kisim onemli. Cizim yaptigimiz resmi gercek dunyaya getiriyoruz.
               BitmapHandle degiskeni artik Windows tarafindan kullanilanilabilir duruma geldi. */
            IntPtr BitmapHandle = FBitmap.GetHbitmap(Color.FromArgb(0));

            /* SrcDC de bitmap secilmeli */
            IntPtr PrevBitmap = Windows.SelectObject(DestDC, BitmapHandle);

            /* Boyutlar ve konum */
            Windows.Size Size = new Windows.Size()
            {
                X = Width,
                Y = Height
            };

            Windows.Point S = new Windows.Point()
            {
                X = 0,
                Y = 0
            };

            Windows.Point P = new Windows.Point()
            {
                X = Left,
                Y = Top
            };

            Windows.BlendFunction BlendFunc = new Windows.BlendFunction()
            {
                BlendOp = Windows.AC_SRC_OVER,
                BlendFlags = 0x00, /* Sifir olmali */
                AlphaFormat = Windows.AC_SRC_ALPHA,
                SourceConstantAlpha = FOpacity /* Ana formun donukluk degeri. 0 = tam saydam, 255 = tam donuk. */
            };

            /* Microsoft'un sihirli fonksiyonu! Oylesine onemli ki, aslinda butun kiyamet burada kopuyor.
              Detayli aciklamayi MSDN' den mutlaka okuyunuz. http://msdn.microsoft.com/en-us/library/ms633556(VS.85).aspx */
            Windows.UpdateLayeredWindow(this.Handle, SrcDC, ref P, ref Size, DestDC,
                ref S, 0, ref BlendFunc, Windows.ULW_ALPHA);

            /* SrcDC yi eski haline getir. */
            Windows.SelectObject(SrcDC, PrevBitmap);

            /* ve Bitmap'i yok et. Yoksa hafiza sizmasi olur. */
            Windows.DeleteObject(BitmapHandle);

            /* DC leri yok et. */
            Windows.DeleteDC(DestDC);
            Windows.DeleteDC(SrcDC);

        }
        private void PaintBackground()
        {
            FGraphics.DrawImage(FBackground, 0, 0);
        }
        private void PaintOverlay()
        {
            FGraphics.DrawImage(FOverlay, 0, 0);
        }
        private void ClearGraphics()
        {
            FGraphics.Clear(Color.FromArgb(0x00000000));
        }
        private void PaintElements()
        {

            /* Acilari su anki saate gore hesapla. */
            DateTime Now = DateTime.Now;
            int Hour = Now.Hour;
            int Minute = Now.Minute;
            int Second = Now.Second;
            Single AngleS = Second * 6;
            Single AngleM = Minute * 6 + AngleS / 60;
            Single AngleH = Hour * 30 + AngleM / 12;

            /* Orta noktayi ekran genisligine gore bul. */
            Single Dx = this.Width / 2 - 1;
            Single Dy = this.Height / 2 - 1;
            Single Ox = -6; // -13 div 2
            Single Oy = -64; // -129 div 2;

            /* Cizim alaninin durumunu sakla. */
            System.Drawing.Drawing2D.GraphicsState State = FGraphics.Save();

            /* Baslangic cizim noktasini formun ortasina konumlandir. */
            FGraphics.TranslateTransform(Dx, Dy);

            /* Saat parcasini ciz */
            FGraphics.RotateTransform(AngleH);
            FGraphics.DrawImage(FHour, Ox, Oy, 13, 129);
            FGraphics.RotateTransform(-AngleH);

            /* Dakika parcasini ciz */
            FGraphics.RotateTransform(AngleM);
            FGraphics.DrawImage(FMinute, Ox, Oy, 13, 129);
            FGraphics.RotateTransform(-AngleM);

            /* Saniye parcasini ciz */
            FGraphics.RotateTransform(AngleS);
            FGraphics.DrawImage(FSecond, Ox, Oy, 13, 129);
            FGraphics.RotateTransform(-AngleS);

            /* Nokta parcasini ciz */
            FGraphics.DrawImage(FDot, Ox, Oy, 13, 129);

            /* Cizim alaninin durumunu eski haline getir. */
            FGraphics.Restore(State);

        }

        Anaform ana;
        Yarismaform yaris;
        private void öğretmenAsistanToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void yarışmaTakipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ayarlarim.Default.Yarismaform == "1")
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

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {            
                var ayarlar = new Ayarlar();
                ayarlar.Show();            
            
        }
    }
}
