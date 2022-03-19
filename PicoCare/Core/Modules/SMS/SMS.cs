


using RestSharp;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace PicoCRM.Core.Modules.SMS
{
    
    public class Handler
    {

       

        public class Send
        {
           public async Task<string> SendWelcome(string name, string lastname, string phone, string customercode)
            {
                var options = new RestClientOptions("http://ippanel.com:8080/")
                {
                    ThrowOnAnyError = true,
                    Timeout = 2000
                };
               
                var client = new RestClient(options);

                var request = new RestRequest()

                .AddQueryParameter("apikey", "yGSsWR4YZzwnE1gikCr6g6WrOQ0Fe0NJ3Kk494ZtHkI=")

                .AddQueryParameter("pid", "yyxz8h4rfm")

                .AddQueryParameter("fnum", "3000505")

                .AddQueryParameter("tnum", phone)

                .AddQueryParameter("p1", "name")

                .AddQueryParameter("p2", "lastname")

                .AddQueryParameter("p3", "score")
                .AddQueryParameter("p4", "totalscore")
                .AddQueryParameter("p5", "trackingcode")


                .AddQueryParameter("v1", name)

                .AddQueryParameter("v2", lastname)

                .AddQueryParameter("v3", "2")
                .AddQueryParameter("v4", "4")
                .AddQueryParameter("v5", "5");
              



                var  response = await client.GetAsync(request);

                

                return  response.Content;
            }


            public async Task<string> SendTranaction(string Phone , string FullName, string DealTitle , string TotalDealAmount ,string IPG ,string ServicePrice, string DealDate , string DealStage , string DealId  )
            {
               
                PersianCalendar pc = new PersianCalendar();
                string PersianDateConverter = "" + pc.GetYear(DateTime.Now) + "/"
                    + pc.GetMonth(DateTime.Now) + "/"
                    
                    + pc.GetDayOfMonth(DateTime.Now);

                var options = new RestClientOptions("http://ippanel.com:8080/")
                {
                    ThrowOnAnyError = true,
                    Timeout = 5000
                };

                var client = new RestClient(options);

                var request = new RestRequest()

                .AddQueryParameter("apikey", "yGSsWR4YZzwnE1gikCr6g6WrOQ0Fe0NJ3Kk494ZtHkI=")

                .AddQueryParameter("pid", "yyxz8h4rfm")

                .AddQueryParameter("fnum", "3000505")

                .AddQueryParameter("tnum", Phone)

                .AddQueryParameter("p1", "fullname")

                .AddQueryParameter("p2", "title")

                .AddQueryParameter("p3", "TotalPayment")
                .AddQueryParameter("p4", "IPG")
                .AddQueryParameter("p5", "amount")
                .AddQueryParameter("p6", "date")

                .AddQueryParameter("p7", "stage")
                .AddQueryParameter("p8", "id")



                .AddQueryParameter("v1", FullName)

                .AddQueryParameter("v2", DealTitle)

                .AddQueryParameter("v3", TotalDealAmount)
                .AddQueryParameter("v4", IPG)
                .AddQueryParameter("v5", ServicePrice)
                .AddQueryParameter("v6", DealDate)
                
                .AddQueryParameter("v7", DealStage)
                
                .AddQueryParameter("v8",DealId);







                var response = await client.GetAsync(request);



                return response.Content;

            }

             public async Task<string> SendReportToAdmin(string fullname,string AdminPhone, string DealAmount, string DealTitle, string TotalRevenue,string about, string trackingcode)
             {
                await Task.Delay(2000);

                DateTime thisDate = DateTime.Now;
                 PersianCalendar pc = new PersianCalendar();
                 string PersianDateConverter = "" + pc.GetYear(thisDate) + "/"
                     + pc.GetMonth(thisDate)+"/"

                     + pc.GetDayOfMonth(thisDate);
                
                try
                {
                    var options = new RestClientOptions("http://ippanel.com:8080/")
                    {
                        ThrowOnAnyError = true,
                        Timeout = 5000
                    };
                 
                    

                    var client = new RestClient(options);

                    var request = new RestRequest()


                        .AddQueryParameter("apikey", "yGSsWR4YZzwnE1gikCr6g6WrOQ0Fe0NJ3Kk494ZtHkI=")


                        .AddQueryParameter("pid", "hys7gcbv0e")


                        .AddQueryParameter("fnum", "3000505")

                        .AddQueryParameter("tnum", AdminPhone)

                        .AddQueryParameter("p1", "FullName")

                        .AddQueryParameter("p2", "title")

                        .AddQueryParameter("p3", "time")

                        .AddQueryParameter("p4", "amount")

                        .AddQueryParameter("p5", "totals")

                        .AddQueryParameter("p6", "about")

                        .AddQueryParameter("p7", "trackingcode")

                        .AddQueryParameter("v1", fullname)

                        .AddQueryParameter("v2", DealTitle)

                        .AddQueryParameter("v3", PersianDateConverter + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second)

                        .AddQueryParameter("v4", DealAmount)

                        .AddQueryParameter("v5", TotalRevenue)

                        .AddQueryParameter("v6", about)

                        .AddQueryParameter("v7", trackingcode);



                    var response = await client.GetAsync(request);
                    return response.Content;
                }
                catch (Exception ex)
                {
                    return "12"+ ex.Message;
                    
                }

          



               
               



             }
        }

    }

    
}

