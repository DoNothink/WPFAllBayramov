using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using WPFAllBayramov.ClassFolder;

namespace WPFAllBayramov.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для EditHouseWindow.xaml
    /// </summary>
    public partial class EditHouseWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=K218PC\SQLEXPRESS;
                        Initial Catalog=HousingDemoLightBayramov;
                        Integrated Security=True");
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        CBClass cBClass;
        public EditHouseWindow()
        {
            InitializeComponent();
            cBClass = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBClass.StatusSaleCBLoad(StatusSaleCB);
            cBClass.StatusCunstructionCBLoad(StatusConstrCB);
            cBClass.HousingComplexCBLoad(HouseComplexCB);
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
