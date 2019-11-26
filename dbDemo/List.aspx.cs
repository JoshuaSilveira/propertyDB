using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dbDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new PROPERTYDB();

            string query = "select * from tenants";

            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                result.InnerHtml += "<div class=\"listitem\">";

                string tenantid = row["tenantid"];

                string tenantfirstname = row["tenantfname"];
                result.InnerHtml += "<div class=\"col4\">" + tenantfirstname + "</div>";

                string tenantlastname = row["tenantlname"];
                result.InnerHtml += "<div class=\"col4\">" + tenantlastname + "</div>";

                string tenantphone = row["tenantphone"];
                result.InnerHtml += "<div class=\"col4\">" + tenantphone + "</div>";

                string tenantemail = row["tenantemail"];
                result.InnerHtml += "<div class=\"col4last\">" + tenantemail + "</div>";

                result.InnerHtml += "</div>";
            }
        }
    }
}