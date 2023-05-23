
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;
using System;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        private void StudentOutput()
        {
            textBox1.Text = "Таблица: Студент" + Environment.NewLine;

            for (int i = 0; i < studentCount; i++)
            {
                textBox1.Text += "№ Студента: " + students[i].IdStudent;
                textBox1.Text += ", ФИО: " + students[i].Fio;
                textBox1.Text += ", Пол: " + students[i].Gender;
                textBox1.Text += ", Дата рождения: " + students[i].DateBithday;
                textBox1.Text += ", № группы: " + students[i].IdGroup;
                textBox1.Text += ", № зачетки: " + students[i].IdZachetka + Environment.NewLine;
            }
        }
        private void GroupsOutput()
        {
            textBox1.Text = "Таблица группа" + Environment.NewLine;
            for (int i = 0; i < groupCount; i++)
            {
                textBox1.Text += " № группы: " + groups[i].IdGroup;
                textBox1.Text += ", Название группы: " + groups[i].NameGroup + Environment.NewLine;
            }
        }
        private void ConferencesOutput()
        {
            textBox1.Text = "Таблица конференции" + Environment.NewLine;
            for (int i = 0; i < conferenceCount; i++)
            {
                textBox1.Text += " № конференции: " + conferences[i].Id;
                textBox1.Text += ", Название конференции: " + conferences[i].Name;
                textBox1.Text += ", Место проведения: " + conferences[i].Name;
                textBox1.Text += ", Дата начала: " + conferences[i].DateBegin;
                textBox1.Text += ", Дата окончания: " + conferences[i].DateEnd + Environment.NewLine;
            }
        }
        private void TeachersOutput()
        {
            textBox1.Text = "Таблица научных руководителей" + Environment.NewLine;
            for (int i = 0; i < teacherCount; i++)
            {
                textBox1.Text += " № сотрудника: " + teachers[i].Id;
                textBox1.Text += ", ФИО сотрудника: " + teachers[i].Fio;
                textBox1.Text += ", Кафедра: " + teachers[i].department;
                textBox1.Text += ", Должность: " + teachers[i].position + Environment.NewLine;
            }
        }
    }
}
