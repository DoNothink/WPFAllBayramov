using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;

namespace WPFAllBayramov.ClassFolder
{
    class CBClass
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=K218PC\SQLEXPRESS;
                        Initial Catalog=HousingDemoLightBayramov;
                        Integrated Security=True");
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        /// <summary>
        /// метод отвечающий за загрузку статуса продажи
        /// (sold/ready)
        /// в ComboBox
        /// </summary>
        public void StatusSaleCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IDSaleStatus, Status_Sale " +
                    "From dbo.[StatusSale] Order by IdSaleStatus ASC", sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[StatusSale]");
                comboBox.ItemsSource = dataSet.Tables["[StatusSale]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.Tables["[StatusSale]"].Columns["Status_Sale"].ToString();
                comboBox.SelectedValuePath = dataSet.Tables["[StatusSale]"].Columns["IDSaleStatus"].ToString();
            }
            catch(Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// метод отвечабщий за загрузку статуса строительства
        /// (built/plan)
        /// в ComboBox
        /// </summary>
        public void StatusCunstructionCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select IDStatus, Status_Construction_Housing_Complex " +
                    "From dbo.[StatusConstruction] Order by IdStatus ASC",sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet,"[StatusConstruction]");
                comboBox.ItemsSource = dataSet.Tables["[StatusConstruction]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.Tables["[StatusConstruction]"].Columns["Status_Construction_Housing_Complex"].ToString();
                comboBox.SelectedValuePath = dataSet.Tables["[StatusConstruction]"].Columns["IDStatus"].ToString();
            }
            catch(Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Метод отвечающий за загрузку жилищного комплекса
        /// в ComboBox
        /// </summary>
        public void HousingComplexCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select Id_Housing_Complex, Name_Housing_Complex " +
                    "From dbo.[houses_in_complexes] Order by Id_Housing_Complex ASC", sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[houses_in_complexes]");
                comboBox.ItemsSource = dataSet.Tables["[houses_in_complexes]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.Tables["[houses_in_complexes]"].Columns["Name_Housing_Complex"].ToString();
                comboBox.SelectedValuePath = dataSet.Tables["[houses_in_complexes]"].Columns["Id_Housing_Complex"].ToString();

            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
