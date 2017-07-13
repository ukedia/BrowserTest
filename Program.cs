using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WatiN.Core;

namespace BrowserTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //using (var browser = new IE())
           using(var browser =  Browser.AttachTo<IE>(Find.ByTitle("Empirica Signal")))
            {
                var a = 0;
                    
                    }
            using (var browser = Browser.AttachTo<IE>(Find.ByTitle("QBE")))
            {
                //browser.TextField(Find.ByName("username")).ClickNoWait();
                //browser.TextField(Find.ByName("username")).TypeText("admin");
                //browser.TextField(Find.ByName("password")).ClickNoWait();
                //browser.TextField(Find.ByName("password")).TypeText("Prudentia@123");
                //browser.Button(Find.ByText("Submit")).Click();
                //browser.Link(Find.By("href", "#/eventinfo")).Click();
                //browser.GoTo("http://arisg7.ergomed.local:8080/Aris/login");
                //browser.WaitForComplete();

                //browser.SelectList(Find.ByName("dbnames")).Select("MDCO02");
                //browser.TextField(Find.ByName("userId")).TypeText("gbajpai");
                //browser.TextField(Find.ByName("password")).TypeText("Admin@123");
                //browser.Button(Find.ByName("LoginSubmitButton")).Click();
                browser.Button(Find.ByValue("SQL")).Click();
                using (var popup = Browser.AttachTo<IE>(Find.ByTitle("SQL")))
                {
                    popup.Button(Find.ByValue("Retrieve from Database")).ClickNoWait();
                    HtmlDialog lookup = browser.HtmlDialog(Find.ByTitle("Query LookUp"));
                    //using (var lookup = Browser.AttachTo<IE>(Find.ByUrl("http://arisg7.ergomed.local:8080/Aris/QBE/jsp/LoadQueryFromUseSQL.jsp")))
                    //{
                        lookup.TextField(Find.ByName("QUERY")).TypeText("PRU_QBE_MONTHLY_PROD_SUBMISSION");
                        lookup.Button(Find.ByValue("OK")).Click();
                        lookup.WaitForComplete();
                        lookup.Button(Find.ByValue("Select")).ClickNoWait();
                    //}
                    popup.WaitForComplete();
                    var sql = popup.TextField(Find.ByName("SQL_STRING")).Text;
                    sql = sql.Replace("##Start Date##", "'01-SEP-2016'").Replace("##End Date##", "'30-SEP-2016'").Replace("##PRODUCT GNAME##", "'Bivalirudin'").Replace("##COUNTRY##", "'USA'");
                    sql = sql.Replace(",         AER_PRODUCT AP", "");
                    sql = sql.Replace("AER_CNTRY   WHERE", "AER_CNTRY, AER_PRODUCT AP   WHERE");
                    popup.TextField(Find.ByName("SQL_STRING")).Value = sql;
                    popup.Button(Find.ByValue("OK")).Click();
                    popup.CheckBox(Find.ById("selectallChk")).ClickNoWait();
                    lookup = popup.HtmlDialog(Find.ByTitle("ARISg7"));
                    lookup.Button(Find.ByValue("Yes")).ClickNoWait();
                    popup.Link(Find.By("href", "javascript:generateReport(\"104\",\"2002\")")).ClickNoWait();
                    //lookup = popup.HtmlDialog(Find.ByTitle("ARISg7"));
                    //lookup.WaitUntilClosed();
                    //var progBrowser = Browser.AttachTo<IE>(Find.ByTitle("ARISg7"));
                    
                    var pdfBrowser = Browser.AttachTo<IE>(Find.ByTitle("ARISg"));
                    pdfBrowser.WaitForComplete();
                    string a = "";
                }
                    Console.Read();
            }
        }
    }
}
