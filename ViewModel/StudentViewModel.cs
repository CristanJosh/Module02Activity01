using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Activity01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Activity01.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _student;

        private string _fullName;


        public StudentViewModel() 
        {
            //Initialize  a sample student model. coordination with Model
            _student = new Student { FirstName="Cristan", LastName="Nuguid", Age=21};

            //UI Thread Management
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());

            Students = new ObservableCollection<Student>
            {
                new Student {FirstName = "Loren", LastName = "Sangalang", Age = 22},
                new Student {FirstName = "Lean", LastName = "Sangalangs", Age = 21},
                new Student {FirstName = "Rits", LastName = "Sy", Age = 23},
                new Student {FirstName = "Mark", LastName = "Soberano", Age = 24},


            };
        }

        public ObservableCollection<Student> Students { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public ICommand LoadStudentDataCommand { get; }



        
        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000);
            FullName = $"{_student.FirstName} {_student.LastName}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected async void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
