using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Zibal_AspWebForm_SampleCode
{
    public partial class Request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void paybutton_Click(object sender, EventArgs e)
        {
            try
            {

                string url = "https://gateway.zibal.ir/v1/request"; // url
                Zibal.makeRequest Request = new Zibal.makeRequest(); // define Request
                Request.merchant = "zibal"; // String
                Request.orderId = "1000"; // String
                Request.amount = amount.Text; //Integer
                Request.callbackUrl = "http://localhost:5019/verify.aspx"; //String
                Request.description = "Hello Zibal !"; // String
                var httpResponse = Zibal.HttpRequestToZibal(url, JsonConvert.SerializeObject(Request));  // get Response
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) // make stream reader
                {
                    var responseText = streamReader.ReadToEnd(); // read Response
                    Zibal.makeRequest_response item = JsonConvert.DeserializeObject<Zibal.makeRequest_response>(responseText); // Deserilize as response class object
                    Response.Redirect("https://gateway.zibal.ir/start/" + item.trackId);                                                                                                           // you can access track id with item.trackId , result with item.result and message with item.message
                                                                                                                                                                                                   // in asp.net you can use Response.Redirect("https://gateway.zibal.ir/start/item.trackId"); for start gateway and redirect to third-party gateway page
                                                                                                                                                                                                   // also you can use Response.Redirect("https://gateway.zibal.ir/start/item.trackId/direct"); for start gateway page directly
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message); // print exception error
            }
        }
    }
}