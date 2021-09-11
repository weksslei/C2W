using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C2W
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Backup_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }

        private void Backup_Load(object sender, EventArgs e)
        {
            //pro.StartInfo = new ProcessStartInfo("cmd.exe", @"/c NET TIME \\SERVER /SET /YES");
            //Process.Start("C:/Arquivos de programas/MySQL/MySQL Server 6.0/bin/mysqldump.exe",@"/c --host localhost teste -u root -p 123 > C:\back.sql");

            //progressBar1.Visible = false
        }


        //private void btnBackup_Click(object sender, EventArgs e)
        //{
        //    progressBar1.Visible = true;
        //    progressBar1.Value = 100;

        //    //quando executar fara o codigo seguinte

        //    //exemplo do path
        //    string path = "C:";

        //    MysqlBackup_Restore(path, "backup");

        //    //corre uma thread com o processo que faz o backup ou restore
        //    Thread t = new Thread(delegate () { MySqlProcess(path); });
        //    t.Start();

        //    progressBar1.Visible = false;
        //}

        ////Metodo que cria o batch file com os comandos de backup ou restore
        //private static void MysqlBackup_Restore(string path, string type)
        //{
        //    //Caminho onde o mysql esta instalado
        //    string cmd = "\"C:\\Arquivos de programas\\MySQL\\MySQL Server 6.0\\bin\"";

        //    //create a bath file to run the script database.
        //    StreamWriter sw = File.CreateText(path + "\\MySqlbackup.cmd");
        //    //sw.WriteLine("c:");
        //    sw.WriteLine("cd\\");
        //    sw.WriteLine("cd " + cmd);

        //    if (type == "backup")
        //    {
        //        //se for backup
        //        sw.WriteLine("mysqldump.exe --host localhost teste -u root -p > \"" + path + "\\MySqlbackup.sql\"");
        //    }
        //    else
        //    {
        //        //se for restore
        //        sw.WriteLine("mysql.exe --user=root --password=123 < \"" + path + "\\MySqlbackup.sql\"");
        //    }

        //    sw.Close();
        //}

        //private static void MySqlProcess(string Path)
        //{
        //    //cria o processo a correr o MySqlbackup.cmd
        //    Process.Start(Path + "\\MySqlbackup.cmd");
        //}






    }
}
