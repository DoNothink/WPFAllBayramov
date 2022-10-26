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
using WPFAllBayramov.ClassFolder;

namespace WPFAllBayramov.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для HouseList.xaml
    /// </summary>
    public partial class HouseList : Window
    {
        DGClass dgClass;
        public HouseList()
        {
            InitializeComponent();
            dgClass = new DGClass(ListHousingDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgClass.LoadDG("Select Name_Housing_Complex," +
                " Street," +
                " Number_House," +
                "Status_Construction_Housing_Complex," +
                "Status_Sale" +
                " From dbo.apartments_in_houses," +
                "dbo.houses_in_complexes");
        }
        private void RedactMI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new EditHouseWindow().Show();
            }
            catch (Exception ex)
            {

                MBClass.ErrorMB(ex.Message);
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VariableClass.HouseId = dgClass.SelectId();
            }
            catch(Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
        }
        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgClass.LoadDG("Select Name_Housing_Complex," +
                " Street," +
                " Number_House," +
                "Status_Construction_Housing_Complex," +
                "Status_Sale" +
                " From dbo.apartments_in_houses," +
                "dbo.houses_in_complexes " +
                $"WHERE Name_Housing_Complex Like '%{SearchTB.Text}%' " +
                $"OR Street Like '%{SearchTB.Text}%' " +
                $"OR Number_House Like '%{SearchTB.Text}%'");
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new AddHouseWindow().Show();
            }
            catch (Exception ex)
            {

                MBClass.ErrorMB(ex.Message);
            }
        }
    }
}
