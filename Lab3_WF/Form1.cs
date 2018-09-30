using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table.Rows.Clear();
            Table.Columns.Clear();
           // Control ctr = new Control();
            List<char>[] t= Control.GetTable();
            int maxrows=0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i].Count > maxrows)
                    maxrows = t[i].Count;
            }
            Table.Columns.Add("names", "Names");
            for (int i = 0; i < maxrows; i++)
            {
                Table.Columns.Add((i+1).ToString(), (1+i).ToString());
            }
            Table.Rows.Add(t.Length);
            for (int i = 0; i < t.Length; i++)
            {
                Table.Rows[i].Cells[0].Value = i+1;
                for (int j = 1; j <= t[i].Count; j++)
                {
                    Table.Rows[i].Cells[j].Value = t[i][j-1];
                }
            }
        }
    }
}
