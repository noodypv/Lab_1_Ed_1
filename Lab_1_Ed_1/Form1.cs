using System.Data;

namespace Lab_1_Ed_1
{
    public partial class Form1 : Form
    {
        public struct Proc
        {
            public int Arrive;
            public int CpuBurst;
        }

        public List<Proc> procList = new List<Proc>();
        public int largest = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Empty input.");
                return;
            }

            int cpuBurst = Int32.Parse(textBox1.Text);
            textBox1.Text = "";

            if (cpuBurst == 0)
            {
                MessageBox.Show("You cannot add a proccess with CPU burst 0.");
                return;
            }

            if (procList.Count == 0)
            {
                procList.Add(new Proc { Arrive = 0, CpuBurst = cpuBurst });
            }
            else
            {
                procList.Add(new Proc
                {
                    Arrive = procList[procList.Count - 1].Arrive + procList[procList.Count - 1].CpuBurst,
                    CpuBurst = cpuBurst
                });
            }

            DataTable pcs = new DataTable();

            pcs.Columns.Add("Процесс");

            for (int i = 0; i < procList[procList.Count - 1].Arrive + procList[procList.Count - 1].CpuBurst; i++)
            {
                pcs.Columns.Add((i + 1).ToString());
            }

            for (int i = 0; i < procList.Count; i++)
            {
                DataRow row = pcs.NewRow();
                row["Процесс"] = "Процесс " + (i + 1).ToString();

                for (int j = 0; j < procList[i].Arrive; j++)
                {
                    row[(j + 1).ToString()] = "Г";
                }

                for (int j = 0; j < procList[i].CpuBurst; j++)
                {
                    row[((procList[i]).Arrive + j + 1).ToString()] = "И";
                }

                pcs.Rows.Add(row);
            }
            dataGridView1.DataSource = pcs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            procList.Clear();
            label3.Text = "";
            label5.Text = "";
            dataGridView1.DataSource = new DataTable();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int avgWaitTime = 0;
            for (int i = 0; i < procList.Count; i++)
            {
                avgWaitTime += procList[i].Arrive;
            }
            avgWaitTime /= procList.Count;
            label3.Text = avgWaitTime.ToString();

            int avgExecTime = 0;
            for (int i = 0; i < procList.Count; i++)
            {
                avgExecTime += procList[i].Arrive + procList[i].CpuBurst;
            }
            avgExecTime /= procList.Count;
            label5.Text = avgExecTime.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}