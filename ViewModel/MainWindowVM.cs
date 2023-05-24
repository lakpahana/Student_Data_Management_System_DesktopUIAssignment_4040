using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_Data_Management_System_DesktopUIAssignment.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Student_Data_Management_System_DesktopUIAssignment.View;

namespace Student_Data_Management_System_DesktopUIAssignment.ViewModel
{
    public partial class MainWindowVM : ObservableObject
    {

        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent =null;

        public MainWindowVM()
        {

            students = new ObservableCollection<Student>();
            students.Add(new Student("Saj", "Avs", 10.32, DateTime.Now, "\\img\\2.png"));
            students.Add(new Student("Saj", "Avs", 10.32, DateTime.Now, "\\img\\1.png"));
            students.Add(new Student("Saj", "Avs", 10.32, DateTime.Now, "\\img\\4.png"));

        }

        [RelayCommand]
        public void CloseWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }

        [RelayCommand]
        public void AddaStudent()
        {
            UserOperationsWindowVM AddAStudentVM = new();
            AddAStudentVM.pageTitle = "Add Student";
            AddAStudentVM.StudentsList = students;
            AddAStudentVM.SelectedStudent = null;

            UserOperationsWindow AddAStudentWindow = new UserOperationsWindow(AddAStudentVM);
            AddAStudentWindow.Show();

        }

        [RelayCommand]
        public void DeleteaStudent()
        {
            //MessageBox.Show("Test");
            if (SelectedStudent != null)
            {
                if (MessageBox.Show("Are You Sure to Delete the Student?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do no stuff
                }
                else
                {
                    students.Remove(SelectedStudent);
                    SelectedStudent = null;
                }


            }
            else
            {
                MessageBox.Show("Please select a student to continue");
            }
        }



        [RelayCommand]
        public void EditaStudent()
        {
            if (selectedStudent != null)
            {
                UserOperationsWindowVM EditAStudentVM = new();
                EditAStudentVM.pageTitle = "Edit Student";
                EditAStudentVM.StudentsList = students;
                EditAStudentVM.SelectedStudent = selectedStudent;
                EditAStudentVM.PopulateSelectedStudentInfo();
                UserOperationsWindow EditAStudentWindow = new UserOperationsWindow(EditAStudentVM);
                EditAStudentWindow.Show();

            }
            else
            {
                MessageBox.Show("Please select a Student.");
            }

        }


     
    }
}
