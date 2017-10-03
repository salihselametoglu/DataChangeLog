using DataChangeLog.DBOperation;
using System;
using System.Windows.Forms;

namespace DataChangeLog
{
    public partial class TestForm : Form
    {
        Person _person;

        public TestForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var a = new DBOperation<Person>();

            a.Update(_person);
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            _person = new Person();

            txtName.DataBindings.Add(new Binding("Text", _person, "Name"));
            txtSurname.DataBindings.Add(new Binding("Text", _person, "Surname"));
            txtNote.DataBindings.Add(new Binding("Text", _person, "Note"));
            txtAge.DataBindings.Add(new Binding("Text", _person, "Age"));
        }
    }
}
