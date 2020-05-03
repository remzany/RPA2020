using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


/// <summary>
/// Summary description for Codingvila
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Codingvila : System.Web.Services.WebService {

    public Codingvila () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataTable GetAllStudentsXML()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students with (NOLOCK)"))
            {
                cmd.Connection = con;
                DataSet ds = new DataSet();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds, "Students");
                }
                return ds.Tables[0];
            }
        }
    }

    [WebMethod]
    public string GetAllStudentsJSON()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students with (NOLOCK)"))
            {
                cmd.Connection = con;
                DataSet ds = new DataSet();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds, "Students");
                }
                return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
            }
        }
    }
}
