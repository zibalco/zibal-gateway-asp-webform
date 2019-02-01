using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;

namespace Zibal_AspWebForm_SampleCode
{
    public partial class verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strtrackId = Request.Form["trackId"]; // شماره تراکنش
            string strOrderId = Request.Form["OrderId"]; // شماره سفارش در سیستم شما
            string strsuccess = Request.Form["success"]; // موفق بودن یا نبودن تراکنش
            string url = "https://gateway.zibal.ir/verify"; // آدرس متد وریفای
            if (strsuccess == "1")
            {
                result.Text = "تراکنش موفقیت آمیز بود";
                Zibal.verifyRequest VerifyReq = new Zibal.verifyRequest();
                VerifyReq.merchant = "zibal"; // در این بخش باید کد مرچنت خود را قرار دهید
                VerifyReq.trackId = strtrackId;
                var httpResponse = Zibal.HttpRequestToZibal(url, JsonConvert.SerializeObject(VerifyReq));  // get Response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) // make stream reader
                {
                    var responseText = streamReader.ReadToEnd(); // read Response
                    Zibal.verifyResponse item = JsonConvert.DeserializeObject<Zibal.verifyResponse>(responseText); // Deserilize as response class object
                    result.Text += "<br /> زمان پرداخت : " + item.paidAt + "<br /> وضعیت پرداخت : " + item.status + "<br /> مبلغ پرداخت : " + item.amount;
                    result.Text += "</br /> نتیجه درخواست : " + item.result + "<br /> پیغام : " + item.message;
                }

            }
            else
            {
                result.Text = "تراکنش با خطا همراه بود";
            }
           
        }
    }
}