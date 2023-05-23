using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        public static int studentCount;
        public static int groupCount;
        public static int conferenceCount;
        public static int teacherCount;
        public string CurrDir = Directory.GetCurrentDirectory() + @"\\data\\";
        public string CurrDirCounter = Directory.GetCurrentDirectory() + @"\\data\\counters.txt";
        Student[] students = new Student[100];
        Group[] groups = new Group[100];
        Conference[] conferences = new Conference[100];
        Teacher[] teachers = new Teacher[100];     
        public Form1()
        {
            InitializeComponent();
        }
        private void OutputBtn_Click(object sender, EventArgs e)
        {
            switch (cmbTableOutput.SelectedIndex)
            {
                case 0:
                    ReadDataStudents();
                    StudentOutput();
                    break;
                case 1:
                    ReadDataGroups();
                    GroupsOutput();
                    break;
                case 2:
                    ConferencesOutput();
                    break;
                case 3:
                    TeachersOutput();
                    break;
                default:
                    textBox1.Text = "Таблица не выбрана";
                    break;
            }
        }
        private void PreLoadElements()
        {
            cmbAddRow.Items.Add("Студенты");
            cmbAddRow.Items.Add("Группы");
            cmbAddRow.Items.Add("Конференции");
            cmbAddRow.Items.Add("Научные руководители");
            cmbTableOutput.Items.Add("Студенты");
            cmbTableOutput.Items.Add("Группы");
            cmbTableOutput.Items.Add("Конференции");
            cmbTableOutput.Items.Add("Научные руководители");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PreLoadElements();
            CounterCheck();
        }
        // new rows columns
        private void TurnOffElements()
        {
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
        }
        private void ListElementsStudents()
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            label2.Visible = true;
            label2.Text = "Номер студента";
            label3.Visible = true;
            label3.Text = "Номер группы";
            label4.Visible = true;
            label4.Text = "Номер зачетки";
            label5.Visible = true;
            label5.Text = "Дата рождения";
            label6.Visible = true;
            label6.Text = "Пол студента";
            label8.Visible = true;
            label8.Text = "ФИО студента";
        }
        private void ListElementsConferences()
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            label2.Visible = true;
            label2.Text = "Номер конференции";
            label3.Visible = true;
            label3.Text = "Название конференции";
            label4.Visible = true;
            label4.Text = "Место проведения";
            label5.Visible = true;
            label5.Text = "Дата начала";
            label6.Visible = true;
            label6.Text = "Дата окончания";
        }
        private void ListElementsTeachers()
        {
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label2.Visible = true;
            label2.Text = "Номер сотрудника";
            label3.Visible = true;
            label3.Text = "ФИО сотрудника";
            label4.Visible = true;
            label4.Text = "Кафедра сотрудника";
            label5.Visible = true;
            label5.Text = "Должность сотрудника";
        }
        private void ListElementsGroups()
        {
            textBox2.Visible = true;
            textBox5.Visible = true;
            label2.Visible = true;
            label2.Text = "Номер группы";
            label3.Visible = true;
            label3.Text = "Название группы";
        }
        private void cmbAddRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            TurnOffElements();
            switch (cmbAddRow.SelectedIndex)
            {
                case 0: // students
                    ClearTextBoxes();
                    ListElementsStudents();
                    break;
                case 1: // groups
                    ClearTextBoxes();
                    ListElementsGroups();
                    break;
                case 2: // conferences
                    ClearTextBoxes();
                    ListElementsConferences();
                    break;
                case 3: // teachers
                    ClearTextBoxes();
                    ListElementsTeachers();
                    break;
                default:
                    break;
            }
        }
        private void AddRowBtn_Click(object sender, EventArgs e)
        {
            CounterCheck();
            switch (cmbAddRow.SelectedIndex)
                {
                    case 0:
                    if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                    {
                        MessageBox.Show("Вы не ввели все значения");
                        break;
                    }
                        WriteDataStudents(students);
                        ClearTextBoxes();
                        studentCount++;
                        CounterWrite();
                        MessageBox.Show("Запись добавлена!");
                        break;
                    case 1:
                        if (textBox5.Text == "" || textBox2.Text == "")
                        {
                            MessageBox.Show("Вы не ввели все значения");
                            break;
                        }
                        groups[groupCount].IdGroup = Int32.Parse(textBox5.Text);
                        groups[groupCount].NameGroup = textBox2.Text;
                        WriteDataGroups(groups);
                        ClearTextBoxes();
                        groupCount++;
                        CounterWrite();
                        MessageBox.Show("Запись добавлена!");
                        break;
                case 2:
                        if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                        {
                            MessageBox.Show("Вы не ввели все значения");
                            break;
                        }
                        conferences[conferenceCount].Id = Int32.Parse(textBox5.Text);
                        conferences[conferenceCount].Name = textBox2.Text;
                        conferences[conferenceCount].Place = textBox3.Text;
                        conferences[conferenceCount].DateBegin = textBox4.Text;
                        conferences[conferenceCount].DateEnd = textBox6.Text;
                        ClearTextBoxes();
                        conferenceCount++;
                        CounterWrite();
                        MessageBox.Show("Запись добавлена!");
                        break;
                case 3:
                    if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                    {
                        MessageBox.Show("Вы не ввели все значения");
                        break;
                    }
                    teachers[teacherCount].Id = Int32.Parse(textBox5.Text);
                    teachers[teacherCount].Fio = textBox2.Text;
                    teachers[teacherCount].department = textBox3.Text;
                    teachers[teacherCount].position = textBox4.Text;
                    ClearTextBoxes();
                    teacherCount++;
                    CounterWrite();
                    MessageBox.Show("Запись добавлена!");
                    break;
                default:
                    break;
                }
        }
        void ClearTextBoxes(){
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
        void WriteDataStudents(Student [] students)
        {
            File.AppendAllText(CurrDir + "students.txt", students[studentCount].IdZachetka.ToString() + ",");
            File.AppendAllText(CurrDir + "students.txt", students[studentCount].IdGroup.ToString() + ",");
            File.AppendAllText(CurrDir + "students.txt", students[studentCount].IdStudent.ToString() + ",");
            File.AppendAllText(CurrDir + "students.txt", students[studentCount].DateBithday + ",");
            File.AppendAllText(CurrDir + "students.txt", students[studentCount].Fio + ",");
            File.AppendAllText(CurrDir + "students.txt", students[studentCount].Gender + "\n");
        }
        void WriteDataGroups(Group[] groups)
        {
            File.AppendAllText(CurrDir + "groups.txt", groups[groupCount].IdGroup.ToString() + ",");
            File.AppendAllText(CurrDir + "groups.txt", groups[groupCount].NameGroup.ToString() + ",\n");
        }
        void ReadDataStudents()
        {
            FileStream file1 = new FileStream(CurrDir + "students.txt", FileMode.OpenOrCreate);
            StreamReader readFile = new StreamReader(file1);
            int numberRow = 0; // номер записи
            string currentValue = "";
            for (int x = 0; x < studentCount; x++)
            {
                currentValue = "";
                numberRow = 0;
                string buffer = readFile.ReadLine();
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] == ',')
                    {
                        AddDataFromFileStudents(currentValue, numberRow, x);
                        currentValue = "";
                        numberRow++;
                        i++;
                    }
                    if (i!=buffer.Length)
                        currentValue += buffer[i];
                }
            }
            readFile.Close();
        }
        void ReadDataGroups()
        {

            FileStream file1 = new FileStream(CurrDir + "students.txt", FileMode.OpenOrCreate);
            StreamReader readFile = new StreamReader(file1);
            int numberRow = 0; // номер записи
            string currentValue = "";
            for (int x = 0; x < groupCount; x++)
            {
                currentValue = "";
                numberRow = 0;
                string buffer = readFile.ReadLine();
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] == ',')
                    {
                        AddDataFromFileGroups(currentValue, numberRow, x);
                        currentValue = "";
                        numberRow++;
                        i++;
                    }
                    if (i != buffer.Length)
                        currentValue += buffer[i];
                }
            }
            readFile.Close();
        }
        private void AddDataFromFileGroups(string currentValue, int numberRow, int studentCount)
        {
            switch (numberRow)
            {
                case 0:
                    groups[groupCount].IdGroup = Int32.Parse(currentValue);
                    break;
                case 1:
                    groups[groupCount].NameGroup = currentValue;
                    break;
                default:
                    break;
            }
        }
        private void AddDataFromFileStudents(string currentValue, int numberRow, int studentCount)
        {
            switch (numberRow)
            {
                case 0:
                    students[studentCount].IdZachetka = Int32.Parse(currentValue);
                    break;
                case 1:
                    students[studentCount].IdGroup = Int32.Parse(currentValue);
                    break;
                case 2:
                    students[studentCount].IdStudent = Int32.Parse(currentValue);
                    break;
                case 3:
                    students[studentCount].DateBithday = currentValue.ToString();
                    break;
                case 4:
                    students[studentCount].Fio = currentValue.ToString();
                    break;
                case 5:
                    students[studentCount].Gender = currentValue.ToString();
                    break;
                default:
                    break;
            }
        }
            private void cmbTableOutput_SelectedIndexChanged(object sender, EventArgs e)
            {
                textBox1.Text = "";
            }
        void CounterCheck()
        {
            FileStream file1 = new FileStream(CurrDirCounter, FileMode.OpenOrCreate);
            StreamReader readFile = new StreamReader(file1);
            studentCount = Int32.Parse(readFile.ReadLine());
            groupCount = Int32.Parse(readFile.ReadLine());
            conferenceCount = Int32.Parse(readFile.ReadLine());
            teacherCount = Int32.Parse(readFile.ReadLine());
            file1.Close();
        }
        void CounterWrite()
        {
            string[] counters = {studentCount.ToString(),groupCount.ToString()
                    , conferenceCount.ToString(), teacherCount.ToString()};
            File.WriteAllLines(CurrDirCounter, counters);
        }
      

    }

}
