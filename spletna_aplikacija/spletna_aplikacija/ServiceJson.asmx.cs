using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace spletna_aplikacija
{
    /// <summary>
    /// Summary description for ServiceJson
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceJson : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetMiljardersJSON()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM miljarder"))
                {
                    cmd.Connection = con;
                    DataSet ds = new DataSet();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds, "miljarder");
                    }
                    return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
                }
            }
        }
    }
}
