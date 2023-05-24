using Student_Data_Management_System_DesktopUIAssignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Student_Data_Management_System_DesktopUIAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_Selected(object sender, RoutedEventArgs e)
        {
     
            if (sender is DataGrid dataGrid)
            {
                var selectedItem = dataGrid.SelectedItem;
                Student student = (Student)dataGrid.SelectedItem;
              
                if(student != null)
                {

                    fName.Text = "First Name : " + student.FirstName;

                    lName.Text = "Last Name : " + student.LastName;

                    dOb.Text = "Date of Birth : " + student.DateOfBirth.ToShortDateString();

                    gPA.Text = "GPA : " +  student.Gpa.ToString();

                    imgProfi.Source = new BitmapImage(new Uri(student.ImageAddress, UriKind.Relative));
                }
                else
                {
                    fName.Text = string.Empty;
                    dOb.Text =string.Empty;
                    gPA.Text = string.Empty;
                    lName.Text = "Select a Student to view details.";
                    imgProfi.Source = new BitmapImage(new Uri("/img/3.png", UriKind.Relative));
                    //uDetails.IsEnabled = false;
                }




            }
        }
        public static ImageSource CreateImageSourceFromUrl(string imageUrl)
        {
            Uri imageUri = new Uri(imageUrl);
            BitmapImage bitmapImage = new BitmapImage(imageUri);
            return bitmapImage;
        }
    }
}
