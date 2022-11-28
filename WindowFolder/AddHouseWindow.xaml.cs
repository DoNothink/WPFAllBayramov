using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для AddHouseWindow.xaml
    /// </summary>
    public partial class AddHouseWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(GlobalClass.sqlConnection);
        SqlCommand sqlCommand;
        CBClass CBClass;

        public AddHouseWindow()
        {
            InitializeComponent();
            CBClass = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CBClass.CBLoad(HousingComplexCB, "NameHousingComplex", "IdNameHousingComplex", "NameHousingComplex");
            CBClass.CBLoad(CityCB,"City","IdCity","CityName");
            CBClass.CBLoad(StatusCB, "StatusConstructionHousingComple",
                "IdStatusConstructionHousingComplex",
                "StatusConstructionHousingComplex");
            CBClass.CBLoad(StreetCB,"Street","IdStreet","NameStreet");
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HousingComplexCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите ЖК");
            }
            else if (CityCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите город");
            }
            else if (StatusCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите статус");
            }
            else if (StreetCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Выберите улицу");
            }
            else if (string.IsNullOrWhiteSpace(HouseNumberTB.Text))
            {
                MBClass.ErrorMB("Введите номер дома");
                HouseNumberTB.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("INSERT INTO dbo.[HousesInComplexes] " +
                        "(IdStreet, NumberHouse, CostHouseConstruction, " +
                        "AdditionalCostApartamentHouse, IdNameHousingComplex, " +
                        "IdCity, IdStatusConstructionHousingComplex, " +
                        "AddedValue, BuildingCosts) " +
                        $"VALUES ('{StreetCB.SelectedValue.ToString()}', " +
                        $"'{HouseNumberTB.Text}', " +
                        $"'{int.Parse(CostHouseTB.Text)}', " +
                        $"'{int.Parse(AdditionalTB.Text)}', " +
                        $"'{HousingComplexCB.SelectedValue.ToString()}', " +
                        $"'{CityCB.SelectedValue.ToString()}', " +
                        $"'{StatusCB.SelectedValue.ToString()}'," +
                        $"'{int.Parse(AddedValueTB.Text)}', " +
                        $"'{int.Parse(BuildingCostTB.Text)}')", sqlConnection);
                    sqlCommand.ExecuteNonQuery();

                    MBClass.InfoMB("Дом успешно добавлен");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
