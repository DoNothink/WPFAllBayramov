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
        public void Status_Construction_Housing_Complex(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter("Select RoleId, RoleName " +
                    "From dbo.[Role] Order by RoleId ASC", sqlConnection);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet.Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.Tables["[Role]"].Columns["RoleName"].ToString();
                comboBox.SelectedValuePath = dataSet.Tables["[Role]"].Columns["RoleId"].ToString();
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
    }
}
