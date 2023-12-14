using System.Data;

namespace Lab_1_Ed_1
{
    public partial class Form1 : Form
    {
        public List<int> procList = new List<int>(); // массив CPU Burst процессов
        public int count = 0; // сумма CPU Burst всех процессов
        public int Q = 2; // квант времени на один процесс
        public char[,] arr; // Двумерный массив, "таблица" процессов
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("RR");
            comboBox1.Items.Add("SJF");
            comboBox1.Items.Add("RR SJF");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Выводим ошибку если ввод пустой
            if (textBox1.Text == "")
            {
                MessageBox.Show("Empty input.");
                return;
            }
            int cpuBurst = Int32.Parse(textBox1.Text);
            textBox1.Text = "";

            // Выводим ошибку если слишком большой или нулевой ввод
            if (cpuBurst == 0 || cpuBurst > 30)
            {
                MessageBox.Show("Cpu Burst must be in range 1...30.");
                return;
            }

            count += cpuBurst;
            procList.Add(cpuBurst); // Добавляем процесс в массив

            DataTable pcs = new DataTable(); // Создаем таблицу для DataGridView контрола
            pcs.Columns.Add("Процесс"); 

            arr = new char[procList.Count, count]; // Создаем двумерный массив/табличку процессов

            // Добавляем в табличку столбцы с номерами CPU Burst
            for (int i = 0; i < count; i++)
            {
                pcs.Columns.Add((i + 1).ToString());
            }

            // Заполняем всю табличку Гшками
            for (int i = 0; i < procList.Count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    arr[i, j] = 'Г';
                }
            }
            
            // Если выбран алгоритм RR
            if (comboBox1.SelectedItem.ToString() == "RR")
            {
                int ptr = 0; // Указатель на текущий процесс
                int maxTime = Q; // Копируем выделяемый на процесс квант времени, т.к. в дальнейшем он будет изменяться
                List<int> procListCopy = new List<int>(procList); // Копируем массив процессов, т.к. в дальнейшем он будет изменяться

                // Проходимся от 0 до суммы CPU Burst процессов
                for (int i = 0; i < count; i++)
                {
                    // Если процесс еще не завершил выполнение и квант выделенного на него времени не закончился
                    if (procListCopy[ptr] > 0 && maxTime > 0)
                    { 
                        arr[ptr, i] = 'И';   // Отмечаем что в данный момент времени выполняетмя именно этот процесс
                        maxTime--; // Уменьшем квант выделенного времени на 1
                        procListCopy[ptr]--; // Уменьшаем оставшееся время выполнения на 1
                    }
                    else
                    {
                        // "Передаем выполнение" другому процессу
                        ptr++;
                        i--;
                    }

                    // Если квант времени на выделенный процесс закончился, обновляем его и передаем выполнение следующему процессу
                    if (maxTime == 0)
                    {
                        maxTime = Q;
                        ptr++;
                    }

                    // Переполнение указателя на процесс
                    if (ptr == procListCopy.Count)
                    {
                        ptr = 0;
                    }
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "SJF")
            {
                List<int> procListCopy = new List<int>(procList);
                int ptr = 0; // Указатель на CPU Burst/момент времени!!!

                // Проходимся по всем процессам
                for (int i = 0; i < procListCopy.Count; i++)
                {
                    int minVal = procListCopy.Min(); // Храним минимальное значение из всех процессов
                    int index = procListCopy.IndexOf(minVal); // Храним позицию процесса с минимальным значением в массиве

                    // До тех пор пока процесс не завершился
                    while (minVal > 0)
                    {
                        arr[index, ptr] = 'И'; // Отмечаем его как выполняемый в данный момент
                        minVal--; // Уменьшаем оставшееся время выполнения на 1
                        ptr++; // Переключаемся на следующий "момент времени"
                    }

                    // Устанавливаем выполненному процессу большое значение в массиве чтобы больше в 108 строчке его никогда не выбрало)))
                    procListCopy[index] = 10000;
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "RR SJF")
            {
                int sortPtr = 0; // Указатель на процесс в отсортированном массиве
                int maxTime = Q; // Копия кванта времени выделяемого на процесс
                List<int> procListCopy = new List<int>(procList);
                List<int> procListSorted = new List<int>(procList); // Отсортированный массив 
                procListSorted.Sort();
                int ptr = procListCopy.IndexOf(procListSorted[sortPtr]); // Ищем индекс первого элемента(наименьшего) отсортированного массива в изначальном массиве

                // Проходимся по всем CPU Burst(моментам времени)
                for (int i = 0; i < count; i++)
                {
                    // Если процесс еще не завершил выполнение и квант выделенного на него времени не закончился
                    if (procListCopy[ptr] > 0 && maxTime > 0)
                    {
                        arr[ptr, i] = 'И'; // Отмечаем процесс как выполняемый в данный момент времени
                        maxTime--; // Уменьшаем квант выделенного на процесс времени на 1
                        procListCopy[ptr]--;  // Уменьшаем оставшеемя время выполнения процесса на 1
                        procListSorted[sortPtr]--; // Уменьшаем оставшеемя время выполнения процесса на 1
                    }
                    else
                    {
                        sortPtr++; // Переключаемся на следующий процесс

                        // Переполнение указателя на процесс
                        if (sortPtr >= procListSorted.Count)
                        {
                            sortPtr = 0;
                        }
                        ptr = procListCopy.IndexOf(procListSorted[sortPtr]); // сопоставляем индекс следующего наименьшего процесса 
                        i--;
                        maxTime = Q;
                    }
                     

                    // Время выделенное на выполнение процесса закончилось
                    if (maxTime == 0)
                    {
                        maxTime = Q;
                        sortPtr++; // Переключаемся на следующий процесс
                        

                        // переполнение указатея на процесс
                        if (sortPtr >= procListSorted.Count)
                        {
                            sortPtr = 0;
                        }
                        ptr = procListCopy.IndexOf(procListSorted[sortPtr]); // сопоставляем индекс следующего наименьшего процесса
                    }
                }
            }

            // Убираем Гшки после крайней Ишки в таблице 
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

            // "Переформатируем" двумерный массив-таблицу в таблицу для DataGridView
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

        // Обработчик сброса процессов
        private void button2_Click(object sender, EventArgs e)
        {
            procList.Clear();
            label3.Text = "";
            label5.Text = "";
            count = 0;
            dataGridView1.DataSource = new DataTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Считаем среднее время ожидания
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

            // Считаем вреднее время выполнения
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

        // Обработчик ввода CPU Burst процесса, не дает вводить буквы
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}