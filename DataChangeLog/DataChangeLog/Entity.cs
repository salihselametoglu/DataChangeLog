using SP.LoggerByChangingColumn;
using System;
using System.Diagnostics;

namespace DataChangeLog
{
    public class Person : ChangeHistoryLoggerByFile //ChangeHistoryLogger<Person>
    {
        private String _name;
        private String _surname;
        private Int16 _age;

        [IsWriteLogChangeValue(false)]
        public String Name
        {
            get => _name;
            set
            {
                _name = value;
                SetValue(this);
            }
        }

        [IsWriteLogChangeValue(true)]
        public String Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                SetValue(this);
            }
        }

        public String Note { get; set; }

        [IsWriteLogChangeValue(true)]
        public Int16 Age
        {
            get => _age;
            set
            {
                _age = value;
                SetValue(this);
            }
        }
    }

    public class Animal: ChangeHistoryLoggerByDB<Animal>
    {
        private String _name;
        private String _colour;

        [IsWriteLogChangeValue(false)]
        public String Name
        {
            get => _name;
            set
            {
                _name = value;
                SetValue(this);
            }
        }

        [IsWriteLogChangeValue(true)]
        public String Colour
        {
            get => _colour;
            set
            {
                _colour = value;
                SetValue(this);
            }
        }

        [IsWriteLogChangeValue(true)]
        public Int16 Age { get; set; }
    }
}
