using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace _1
{
    public struct Student
    {
        public int IdStudent;
        public int IdZachetka;
        public string Fio;
        public string DateBithday;
        public string Gender;
        public int IdGroup;
    }
    public struct Group
    {
        public int IdGroup;
        public string NameGroup;
    }
    public struct Conference
    {
        public int Id;
        public string Name;
        public string Place;
        public string DateBegin;
        public string DateEnd;
    }
    public struct Teacher
    {
        public int Id;
        public string Fio;
        public string position;
        public string department;
    }
}