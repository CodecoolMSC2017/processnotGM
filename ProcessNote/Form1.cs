using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            Process process = new Process();
            process.StartInfo.FileName = text;
            process.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadProcessList();
        }

        private void loadProcessList()
        {
            listView1.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                string[] tag = new string[] { p.ProcessName, p.Id.ToString() };
                ListViewItem item = new ListViewItem(tag);
                item.Tag = p;
                listView1.Items.Add(item);
            }
        }

     

        private void stopButton_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            Process process = (Process)item.Tag;
            process.Kill();
            loadProcessList();
            
        }

      

        private void listView1_MouseHover(object sender, EventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            Process process = (Process)item.Tag;
            MessageBox.Show("\nprocess  Name : " + process.ProcessName + "\nprocess Time : " + process.PrivilegedProcessorTime.ToString() + "\nprocess Threads : " + process.Threads.Count + "\nprocess StartTime : " + process.StartTime + "\nprocess Memory Size : " + process.PrivateMemorySize);

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            { 

            ListViewItem item = e.Item;
            
            Process process = (Process)item.Tag;
            MessageBox.Show("\nprocess  Name : " + process.ProcessName + "\nprocess Time : " + process.PrivilegedProcessorTime.ToString() + "\nprocess Threads : " + process.Threads.Count + "\nprocess StartTime : " + process.StartTime + "\nprocess Memory Size : " + process.PrivateMemorySize);
               
            }
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(TopMost == false) {
            TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }
    }
}

