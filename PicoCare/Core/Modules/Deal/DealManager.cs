using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using RestSharp;

namespace PicoCRM.Core.Modules.Deal
{
   
    public  class DealManager
   
    {
    

           
        
       
           
        public async Task<string> CreateDeal(string DealTitle , string DealAmount , string Deal_About,string Deal_Stage ,string ipg)
           
        {
          
            var options = new RestClientOptions("https://api.hubapi.com/crm/v3/objects/deals")
            {
                ThrowOnAnyError = true,
                Timeout = 3000,


            };
            var client = new RestClient(options);

            var FieldData = new Fields.ActionCreateDeal
            {
                properties = new Fields.ActionCreateDeal.Properties
                {
                    amount = DealAmount,
                    dealname = DealTitle,
                    dealstage = Deal_Stage,
                    closedate = DateTime.UtcNow,
                    hubspot_owner_id = "113813853",
                    deal_desc = ipg ,
                    description = Deal_About,
                    pipeline = "default"
                }

            };
            var request = new RestRequest()

                        .AddHeader("Content-Type", "application/json")

                        .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")

                        .AddJsonBody(FieldData);
          
            var response = await client.PostAsync<Fields.ActionCreateDeal>(request);

            return response.id.ToString();

        


        }


        public  async Task<string>GetDealAssoc  (string DealID)
        {
            var options = new RestClientOptions($"https://api.hubapi.com/crm/v3/objects/deals/{DealID}/associations/contacts")
            {
                ThrowOnAnyError = true,
                Timeout = 3000,


            };
            var client = new RestClient(options);

            var request = new RestRequest()

                       .AddHeader("Content-Type", "application/json")

                       .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077");

            var response = await client.GetAsync<Fields.ActionGetDeal.Assocs.Response>(request);
            
            return response.results[1].id.ToString();
        }

        public async Task<Fields.ActionGetDeal.Read> GetDeal(string DealId)
        {
            var options = new RestClientOptions($"https://api.hubapi.com/crm/v3/objects/deals/{DealId}")
            {
                ThrowOnAnyError = true,
                Timeout = 3000,


            };
            var client = new RestClient(options);

            var request = new RestRequest()

                       .AddHeader("Content-Type", "application/json")
                       .AddQueryParameter("archived", "false")
                       .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")
           
                       .AddQueryParameter("properties", "amount")
           
                       .AddQueryParameter("properties", "dealstage")
                       .AddQueryParameter("properties", "dealname")
                       .AddQueryParameter("properties", "createdAt")
                       .AddQueryParameter("properties", "createdate")
                       .AddQueryParameter("properties", "description")
                       .AddQueryParameter("properties", "deal_desc")

                       .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077");

            var response = await client.GetAsync<Fields.ActionGetDeal.Read>(request);
            return response;
        }

        public async Task<Fields.ActionUpdateDeal.Response> UpdateDeal(string DealId , string DealTitle, string DealAmount, string Deal_About, string Deal_Stage, string ipg)
        {

            var options = new RestClientOptions($"https://api.hubapi.com/crm/v3/objects/deals/{DealId}")
            {
                ThrowOnAnyError = true,
                Timeout = 3000,


            };
            var client = new RestClient(options);
            var JsonBody = new Fields.ActionUpdateDeal.Request.Properties
            {

             
                    amount = DealAmount,
                    dealname = DealTitle,

                    dealstage = Deal_Stage,
                    hubspot_owner_id = "113813853",
                    deal_desc = ipg,
                    description = Deal_About,
                    closedate= DateTime.Now,
                    pipeline= "default"

                

            };
            string  JsonString =  JsonConvert.SerializeObject(JsonBody );
            MessageBox.Show(JsonString);
            var request = new RestRequest()

                     .AddHeader("Content-Type", "application/json")
                     .AddQueryParameter("archived", "false")
                     .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")
                     .AddBody(JsonString);
            
            var response = await client.PatchAsync<Fields.ActionUpdateDeal.Response>(request);
          
            return  response;

        }

        public async Task<DataTable> GetDealList()
        {

            #region Create DataTable for Contacts Fetched from Api

            DataSet dtSet;

            DataTable custTable = new DataTable("Deals");

            DataColumn dtColumn;


            DataRow myDataRow;


            // Create id column

      

            // Create Name column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(long);
            dtColumn.ColumnName = "DealId";
           
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            /// Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            // Create Address column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "DealName";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);
            // Create Address column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(long);
            dtColumn.ColumnName = "DealAmount";
      
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);
            // Create Address column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(DateTime);
            dtColumn.ColumnName = "CreateDate";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            custTable.Columns.Add(dtColumn);

            // Create Address column.
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "DealStage";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);
            // Make id column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = custTable.Columns["id"];
            custTable.PrimaryKey = PrimaryKeyColumns;


            dtSet = new DataSet();

            #endregion


            try
            {

                #region Get First Page Of Contacts From HubApi

                var options = new RestClientOptions("https://api.hubapi.com/crm/v3/objects/deals?")
                {
                    ThrowOnAnyError = true,
                    Timeout = 3000,

                };
                MessageBox.Show("1");
                var client = new RestClient(options);

                var request = new RestRequest()



                    .AddHeader("accept", "application/json")

                    .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")

                    .AddQueryParameter("archived", "false")


                    .AddQueryParameter("limit", "100");


                var response = await client.GetAsync<Deal.Fields.ActionListDeals.ListAll>(request);

                string? after = response?.paging?.next?.after;

               Deal.Fields.ActionListDeals.ListAll results2 = new Fields.ActionListDeals.ListAll();


                string json = JsonConvert.SerializeObject(response.results);


                foreach (var info in response.results)
                {
                    myDataRow = custTable.NewRow();

                    myDataRow["DealId"] = info.id;
                    myDataRow["DealName"] = info.properties.dealname;
                    myDataRow["DealAmount"] = info.properties.amount;

                    myDataRow["DealStage"] = info.properties.dealstage;


                    myDataRow["CreateDate"] = ToPersianDate(info.properties.createdate);

                    custTable.Rows.Add(myDataRow);
                }
                // Create a new DataSet



                int p = 0;

                int i = 0;


                #endregion

                #region Fetch Remaining Pages if Available And Add List To DataTable
                do


                {



                    request = new RestRequest()



                    .AddHeader("accept", "application/json")

                    .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")

                   

                    .AddQueryParameter("archived", "false")

                    .AddParameter("after", after)

                    .AddQueryParameter("limit", "100");

                    response = await client.GetAsync<Deal.Fields.ActionListDeals.ListAll>(request);

                    after = response?.paging?.next?.after;



                    string json2 = JsonConvert.SerializeObject(response.results);




                    foreach (var info in response.results)
                    {

                        myDataRow = custTable.NewRow();


                        myDataRow["DealId"] = info.id;
                        myDataRow["DealName"] = info.properties.dealname;
                        myDataRow["DealAmount"] = info.properties.amount;

                        myDataRow["DealStage"] = info.properties.dealstage;


                        myDataRow["CreateDate"] = ToPersianDate(info.properties.closedate);

                        custTable.Rows.Add(myDataRow);
                    }



                }




                while (after != null);

                dtSet.Tables.Add(custTable);




                return custTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return custTable;
            }

            #endregion

        }
        public string ToPersianDate(DateTime thisDate)
        {

            PersianCalendar pc = new PersianCalendar();
            string PersianDateConverter = "" + pc.GetYear(thisDate) + "/"
                + pc.GetMonth(thisDate) + "/"

                + pc.GetDayOfMonth(thisDate) + " " + pc.GetHour(thisDate) + ":" + pc.GetMinute(thisDate);
            return PersianDateConverter;
        }

    }



}
