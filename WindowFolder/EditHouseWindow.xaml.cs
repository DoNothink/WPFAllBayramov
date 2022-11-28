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
        SqlConnection sqlConnection = new SqlConnection(GlobalClass.sqlConnection);
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        CBClass CBClass;

        public EditHouseWindow()
        {
            InitializeComponent();
            CBClass = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CBClass.CBLoad(HousingComplexCB, "NameHousingComplex", "IdNameHousingComplex", "NameHousingComplex");
            CBClass.CBLoad(CityCB, "City", "IdCity", "CityName");
            CBClass.CBLoad(StatusCB, "StatusConstructionHousingComple",
                "IdStatusConstructionHousingComplex",
                "StatusConstructionHousingComplex");
            CBClass.CBLoad(StreetCB, "Street", "IdStreet", "NameStreet");
            /*==================*/
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("SELECT * FROM dbo.HousesInComplexes " +
                    $"WHERE IdHousesInComplexes= '{VariableClass.HouseId}'", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                StreetCB.SelectedValue = dataReader[1].ToString();
                HouseNumberTB.Text = dataReader[2].ToString();
                CostHouseTB.Text = dataReader[3].ToString();
                AdditionalTB.Text = dataReader[4].ToString();
                HousingComplexCB.SelectedValue = dataReader[5].ToString();
                CityCB.SelectedValue = dataReader[6].ToString();
                StatusCB.SelectedValue = dataReader[7].ToString();
                AddedValueTB.Text = dataReader[8].ToString();
                BuildingCostTB.Text = dataReader[9].ToString();
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

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("UPDATE " +
                    "dbo.HousesInComplexes " +
                    $"SET [IdStreet] = '{StreetCB.SelectedValue.ToString()}', " +
                    $"[NumberHouse] = '{HouseNumberTB.Text}'," +
                    $"[CostHouseConstruction] = '{int.Parse(CostHouseTB.Text)}'," +
                    $"[AdditionalCostApartamentHouse] = '{int.Parse(AdditionalTB.Text)}'," +
                    $"[IdNameHousingComplex] = '{int.Parse(HousingComplexCB.SelectedValue.ToString())}'," +
                    $"[IdStatusConstructionHousingComplex] = '{int.Parse(StatusCB.SelectedValue.ToString())}'," +
                    $"[AddedValue] = '{int.Parse(AddedValueTB.Text)}'," +
                    $"[BuildingCosts] = '{int.Parse(BuildingCostTB.Text)}' " +
                    $"WHERE IdHousesInComplexes = '{VariableClass.HouseId}'", sqlConnection);
                sqlCommand.ExecuteNonQuery();

                MBClass.InfoMB("Данные упешно отредактированы");
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
