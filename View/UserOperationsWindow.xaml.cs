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
using System.Windows.Shapes;
using Student_Data_Management_System_DesktopUIAssignment.ViewModel;

namespace Student_Data_Management_System_DesktopUIAssignment.View
{
    /// <summary>
    /// Interaction logic for UserOperationsWindow.xaml
    /// </summary>
    public partial class UserOperationsWindow : Window
    {
        public UserOperationsWindow(UserOperationsWindowVM userOperationsWindowVM)
        {
            DataContext = userOperationsWindowVM;
            InitializeComponent();
        }
    }
}
