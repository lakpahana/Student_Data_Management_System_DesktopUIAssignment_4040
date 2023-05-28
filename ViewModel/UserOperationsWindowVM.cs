using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Data_Management_System_DesktopUIAssignment.Model;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Win32;

namespace Student_Data_Management_System_DesktopUIAssignment.ViewModel
{
    public partial class UserOperationsWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string? pageTitle;


        [ObservableProperty]
        public string? firstNme;

        [ObservableProperty]
        public string? lastName;


        [ObservableProperty]
        public DateTime dateOfBirth = DateTime.Now;

        [ObservableProperty]
        public string? imageUrl = "/img/2.png";

        [ObservableProperty]
        public double gpa;

        public Student? SelectedStudent { get; set; }
        public ObservableCollection<Student> StudentsList = new();




        [RelayCommand]
        public void SaveOperation()
        {

            if (SelectedStudent != null)
            {
                if (MessageBox.Show("Are You Sure to Edit this Student?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do no stuff
                }
                else
                {

                    Student student = new Student(firstNme, lastName, gpa, dateOfBirth, imageUrl);
                    if (student.Validate())
                    {
                        StudentsList[StudentsList.IndexOf(SelectedStudent)] = new Student(firstNme, lastName, gpa, dateOfBirth, imageUrl);
                        CancelOperation();

                    }
                    else
                    {
                        MessageBox.Show("Please recheck the input fields and retry.");
                    }
                    
                }
            }
            else
            {
                Student student = new Student(firstNme, lastName, gpa, dateOfBirth, imageUrl);
                if (student.Validate())
                {
                    StudentsList.Add(student);
                    CancelOperation();

                }
                else
                {
                    MessageBox.Show("Please recheck the input fields and retry.");
                }
            }



        }

        public void PopulateSelectedStudentInfo()
        {
            if(SelectedStudent != null)
            {
                FirstNme = SelectedStudent.FirstName;
                lastName = SelectedStudent.LastName;
                dateOfBirth= SelectedStudent.DateOfBirth;
                imageUrl = SelectedStudent.ImageAddress;
                 gpa = SelectedStudent.Gpa;
            }
            else
            {
                MessageBox.Show("Please select a student");
            }
        }


        [RelayCommand]
        public void CancelOperation()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }



        private void Reset()
        {
            firstNme = string.Empty;
            lastName= string.Empty;
            dateOfBirth = DateTime.Now;
            gpa = 0;
            imageUrl = "/img/2.png";

        }

        [RelayCommand]
        public void ChoosePicture()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                ImageUrl = dialog.FileName;
            }
        }
    }
}
