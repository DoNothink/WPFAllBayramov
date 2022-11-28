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
    /// Логика взаимодействия для HouseList.xaml
    /// </summary>
    public partial class HouseList : Window
    {
        SqlConnection sqlConnection = new SqlConnection(GlobalClass.sqlConnection);
        SqlCommand sqlCommand;
        DGClass dgClass;

        public HouseList()
        {
            InitializeComponent();
            dgClass = new DGClass(ListHousingDG);
        }

        /// <summary>
        /// ЛОАДЕД))) РАБОТАЕТ
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadHouseList();
        }

        private void RedactMI_Click(object sender, RoutedEventArgs e)
        {
            if (ListHousingDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку!!!");
            }
            else
            {
                try
                {
                    VariableClass.HouseId = dgClass.SelectId();
                    new EditHouseWindow().ShowDialog();
                    LoadHouseList();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        /// <summary>
        /// воркает
        /// </summary>
        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            bool resultMB = MBClass.QuestionMB("Вы действительно " +
                "хотите удалить дом?..");
            if (resultMB == true)
            {


                if (ListHousingDG.SelectedItem == null)
                {
                    MBClass.ErrorMB("Вы не выбрали строку!!!");
                }
                else
                {
                    try
                    {
                        sqlConnection.Open();
                        VariableClass.HouseId = dgClass.SelectId();
                        sqlCommand = new SqlCommand("DELETE FROM dbo.[HousesInComplexes]" +
                            $"WHERE IdHousesInComplexes={VariableClass.HouseId}",sqlConnection);
                        sqlCommand.ExecuteNonQuery();

                        MBClass.InfoMB("Дома больше нет. Зря строили.");
                    }
                    catch (Exception ex)
                    {
                        MBClass.ErrorMB(ex);
                    }
                    finally
                    {
                        sqlConnection.Close();
                        LoadHouseList();
                    }
                }
            }
        }

        /// <summary>
        /// ПОИСК РАБОТАЕТ
        /// </summary>
        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgClass.LoadDG("SELECT * FROM dbo.[HousesView] " +
                $"WHERE NameHousingComplex LIKE '%{SearchTB.Text}%' " +
                $"OR NameStreet LIKE '%{SearchTB.Text}%' " +
                $"OR NumberHouse LIKE '%{SearchTB.Text}%'");
        }

        /// <summary>
        /// РАБОТАЕТ
        /// </summary>
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        /// <summary>
        /// РАБОТАЕТ
        /// </summary>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
                new AddHouseWindow().Show();
        }

        private void LoadHouseList()
        {
            dgClass.LoadDG("SELECT * FROM dbo.[HousesView]");
        }
    }
}
