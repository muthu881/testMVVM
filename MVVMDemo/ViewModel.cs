using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MVVMDemo
{
    public class ViewModel : ViewModelBase
    {
        private Student _student;
        private ObservableCollection<Student> _students;
        private ICommand _SubmitCommand;

        public Student Student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
                NotifyPropertyChanged("Student");
            }
        }
        public ObservableCollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                NotifyPropertyChanged("Students");
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.Submit(),
                        null);
                }
                return _SubmitCommand;
            }
        }


        public ViewModel()
        {
            Student = new Student();
            Students = new ObservableCollection<Student>();
            Students.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Students_CollectionChanged);

            Student = new Student();
            Student.Age = 30;
            Student.Name = "Karthi";
            Student.JoiningDate = DateTime.Today.Date;
            Student.Course = "";
            Students.Add(Student);
            Student.Name = "Iyappan";
            Students.Add(Student);
            Student.Name = "Kumar";
            Students.Add(Student);

            var firstPdfPath = "test";
            var secondPdfPath = "test1";

            var name = $"Begin compare {firstPdfPath} & {secondPdfPath}";
          var data =  JsonConvert.SerializeObject(Students);
        }

        public float YPosition { get; set; }
        public float Height { get; set; }

        public float EndYPosition => YPosition + Height;

        void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Students");
        }
        
        private void Submit()
        {
            Student.JoiningDate = DateTime.Today.Date;
            Students.Add(Student);
            Student = new Student();
        }
    }
}
