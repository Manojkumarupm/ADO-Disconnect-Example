using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CategoryHelper
    {

        SqlConnection con;
        SqlCommand sqlcom;
        DataSet ds;
        SqlDataAdapter sda;
        public CategoryHelper()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDBConnectionString"].ToString());
            sqlcom = new SqlCommand();
            sda = new SqlDataAdapter("Select * from Category", con);
            sda.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ds = new DataSet();
            GetCategoryDetails();
        }
        public void GetCategoryDetails()
        {
            try
            {
                con.Open();

                
                sda.Fill(ds,"Category");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            try
            {
                List<Category> lst = new List<Category>();
                lst = ds.Tables[0].DataTableToList<Category>();
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string UpdateCategory(Category c)
        {
            try
            {
                DataRow dr = ds.Tables[0].Rows.Find(c.CategoryCode);
                dr["CategoryName"] = c.CategoryName;
                dr["Division"] = c.Division;
                dr["Region"] = c.Region;
                dr["SupplierId"] = c.SupplierId;
                dr["SupplierName"] = c.SupplierName;
                con.Open();
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                scb.DataAdapter.Update(ds, "Category");
                return "Updated Successfully";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
