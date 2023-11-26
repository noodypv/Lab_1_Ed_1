using System.Data;

namespace Lab_1_Ed_1
{
    public partial class Form1 : Form
    {
        public List<int> procList = new List<int>();
        public int count = 0;
        public int Q = 2;
        public char[,] arr;

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("RR");
            comboBox1.Items.Add("SJF");
            comboBox1.Items.Add("RR SJF");
            comboBox1.SelectedIndex = 0;
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

            if (cpuBurst == 0 || cpuBurst > 30)
            {
                MessageBox.Show("Cpu Burst must be in range 1...30.");
                return;
            }

            count += cpuBurst;
            procList.Add(cpuBurst);

            DataTable pcs = new DataTable();
            pcs.Columns.Add("Процесс");

            arr = new char[procList.Count, count];

            for (int i = 0; i < count; i++)
            {
                pcs.Columns.Add((i + 1).ToString());
            }

            for (int i = 0; i < procList.Count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    arr[i, j] = 'Г';
                }
            }

            if (comboBox1.SelectedItem.ToString() == "RR")
            {
                int ptr = 0;
                int maxTime = Q;
                List<int> procListCopy = new List<int>(procList);

                for (int i = 0; i < count; i++)
                {
                    if (procListCopy[ptr] > 0 && maxTime > 0)
                    {
                        arr[ptr, i] = 'И';
                        maxTime--;
                        procListCopy[ptr]--;
                    }
                    else
                    {
                        ptr++;
                        i--;
                    }

                    if (maxTime == 0)
                    {
                        maxTime = Q;
                        ptr++;
                    }

                    if (ptr == procListCopy.Count)
                    {
                        ptr = 0;
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "SJF")
            {
                List<int> procListCopy = new List<int>(procList);
                int ptr = 0;
                for (int i = 0; i < procListCopy.Count; i++)
                {
                    int minVal = procListCopy.Min();
                    int index = procListCopy.IndexOf(minVal);

                    while (minVal > 0)
                    {
                        arr[index, ptr] = 'И';
                        minVal--;
                        ptr++;
                    }

                    procListCopy[index] = 10000;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "RR SJF")
            {
                int sortPtr = 0;
                int maxTime = Q;
                List<int> procListCopy = new List<int>(procList);
                List<int> procListSorted = new List<int>(procList);
                procListSorted.Sort();
                int ptr = procListCopy.IndexOf(procListSorted[sortPtr]);

                for (int i = 0; i < count; i++)
                {
                    if (procListCopy[ptr] > 0 && maxTime > 0)
                    {
                        arr[ptr, i] = 'И';
                        maxTime--;
                        procListCopy[ptr]--;
                        procListSorted[sortPtr]--;
                    }
                    else
                    {
                        sortPtr++;
                        if (sortPtr >= procListSorted.Count)
                        {
                            sortPtr = 0;
                        }
                        ptr = procListCopy.IndexOf(procListSorted[sortPtr]);
                        i--;
                        maxTime = Q;
                    }

                    if (maxTime == 0)
                    {
                        maxTime = Q;
                        sortPtr++;

                        if (sortPtr >= procListSorted.Count)
                        {
                            sortPtr = 0;
                        }
                        ptr = procListCopy.IndexOf(procListSorted[sortPtr]);
                    }
                }
            }

            for (int i = 0; i < procList.Count; i++)
            {
                for (int j = count - 1; j > 0; j--)
                {
                    if (arr[i, j] == 'И')
                    {
                        break;
                    }
                    arr[i, j] = ' ';
                }
            }

            for (int i = 0; i < procList.Count; i++)
            {
                DataRow row = pcs.NewRow();
                for (int j = 0; j < count; j++)
                {
                    row["Процесс"] = "Процесс " + (i + 1).ToString();
                    row[(j + 1).ToString()] = arr[i, j];
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
            count = 0;
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
                for (int j = 0; j < count; j++)
                {
                    if (arr[i, j] == 'Г')
                    {
                        avgWaitTime++;
                    }
                }
            }
            avgWaitTime /= procList.Count;
            label3.Text = avgWaitTime.ToString();

            int avgExecTime = 0;
            for (int i = 0; i < procList.Count; i++)
            {
                for (int j = count - 1; j >= 0; j--)
                {
                    if (arr[i, j] == 'И')
                    {
                        avgExecTime += (j + 1);
                        break;
                    }
                }
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}