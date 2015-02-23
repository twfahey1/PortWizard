using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace PortWizard
{
    public partial class Form1 : Form
    {
        static Dictionary<string, int> ProcessNameIDDictionary = new Dictionary<string, int>();
        public List<Port> ProcessInfoList = new List<Port>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        /// <summary>
        /// Centers things out to the center of form during events like resize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            flowLayoutPanel1.Left = (this.ClientSize.Width - flowLayoutPanel1.Width) / 2;
            flowLayoutPanel1.Top = (this.ClientSize.Height - flowLayoutPanel1.Height) / 2;
        }*/
    
        private void init()
        {
            ProcessListView.Items.Clear();
            List<Port> _CurrentStatPorts = GetNetStatPorts();

            foreach (Port _proc in _CurrentStatPorts)
            {
                if (_proc.port_number.Equals("80") || _proc.port_number.Equals("443"))
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = (_proc.process_name);
                    lvItem.SubItems.Add(_proc.port_number);
                    lvItem.SubItems.Add(_proc.PID);
                    ProcessListView.Items.Add(lvItem);
                }
            }
        }
        
        public void KillProcess(int ID)
        {
            Process p = Process.GetProcessById(ID);
            p.Kill();
        }

       
        public static List<Port> GetNetStatPorts()
        {
            var Ports = new List<Port>();
 
            try {
            using (Process p = new Process()) {
 
                ProcessStartInfo ps = new ProcessStartInfo();
                ps.Arguments = "-a -n -o";
                ps.FileName = "netstat.exe";
                ps.UseShellExecute = false;
                ps.WindowStyle = ProcessWindowStyle.Hidden;
                ps.RedirectStandardInput = true;
                ps.RedirectStandardOutput = true;
                ps.RedirectStandardError = true;
 
                p.StartInfo = ps;
                p.Start();
 
                StreamReader stdOutput = p.StandardOutput;
                StreamReader stdError = p.StandardError;
 
                string content = stdOutput.ReadToEnd() + stdError.ReadToEnd();
                string exitStatus = p.ExitCode.ToString();
      
                if (exitStatus != "0") {
                // Command Errored. Handle Here If Need Be
                }
 
                //Get The Rows
                string[] rows = Regex.Split(content, "\r\n");
                foreach (string row in rows) {
                //Split it baby
                string[] tokens = Regex.Split(row, "\\s+");
                if (tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP"))) {
                    string localAddress = Regex.Replace(tokens[2], @"\[(.*?)\]", "1.1.1.1");
                    Ports.Add(new Port {
                    protocol = localAddress.Contains("1.1.1.1") ? String.Format("{0}v6",tokens[1]) : String.Format("{0}v4",tokens[1]),
                    port_number = localAddress.Split(':')[1],
                    process_name = tokens[1] == "UDP" ? LookupProcess(Convert.ToInt16(tokens[4])) : LookupProcess(Convert.ToInt16(tokens[5])),
                    PID = tokens[1] == "UDP" ? tokens[4] : tokens[5]
                    });
                }
                }
            }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return Ports;
        }

        public static string LookupProcess(int pid)
        {
            string procName;
            try
            {
                procName = Process.GetProcessById(pid).ProcessName;
                
            }
            catch (Exception) { procName = "-"; }

            return procName;
        }

        // ===============================================
        // The Port Class We're Going To Create A List Of
        // ===============================================
        public class Port
        {
            public string name
            {
                get
                {
                    return string.Format("{0} ({1} port {2})", this.process_name, this.protocol, this.port_number, this.PID);
                }
                set { }
            }
            public string port_number { get; set; }
            public string process_name { get; set; }
            public string protocol { get; set; }
            public string PID { get; set; }
        }

        private void ProcessListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ResizeListsToFit(ListView listView)
        {
            for (int i = 0; i < listView.Columns.Count - 1; i++)
                listView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.Columns[listView.Columns.Count - 1].Width = -2;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeListsToFit(ProcessListView);
        }

        private void ProcessListView_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    contextMenuStrip1.Show(listView, e.Location);
                }
            }
        }

        private void endProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedProcessID = ProcessListView.SelectedItems[0].SubItems[2].Text;
            
            KillProcess(Convert.ToInt32(selectedProcessID));
            MessageBox.Show("killed");
            init();
            //KillProcess(Form1.ProcessNameIDDictionary.Keys.Contains())
        }
    }
}
