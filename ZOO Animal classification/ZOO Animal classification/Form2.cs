using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZOO_Animal_classification
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {

            InitializeComponent();
        }
   
        private void Form2_Load(object sender, EventArgs e)
        {
            
            try
            {
                const string RelativePath = "../../Resources/zoo.csv";
                string[] Lines = File.ReadAllLines(RelativePath);
                string[] Fields;
                Fields = Lines[0].Split(new char[] { ',' });
                int Cols = Fields.GetLength(0);
                DataTable dt = new DataTable();
                for (int i = 0; i < Cols; i++)
                    dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                DataRow Row;
                for (int i = 1; i < Lines.GetLength(0); i++)
                {
                    Fields = Lines[i].Split(new char[] { ',' });
                    Row = dt.NewRow();
                    for (int f = 0; f < Cols; f++)
                        Row[f] = Fields[f];
                    dt.Rows.Add(Row);
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error is " + ex.ToString());
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
