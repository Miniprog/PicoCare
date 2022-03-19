﻿



using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using static PicoCRM.Core.Modules.Contact.Models.Fields;

namespace PicoCRM.Core.Modules.Contact
{

    public class ContactManager
    {
       
        public class CreateContact

         {


             public async Task<string> Create(string FullName , string  PhoneNummber )
             {
                 try
                 {

                     var options = new RestClientOptions("https://api.hubapi.com/crm/v3/objects/contacts")
                     {
                         ThrowOnAnyError = true,
                         Timeout = 3000,


                     };

                     var ContactData = new ActionCreate.Request
                     {
                         properties = new ActionCreate.Request.Properties
                         {
                             firstname = FullName,
                             email = PhoneNummber + "@PicoCRM.ir",
                             phone = PhoneNummber,

                         }
                     };

                     string ContactDataJson = JsonConvert.SerializeObject(ContactData);

                     var client = new RestClient(options);

                     var request = new RestRequest()

                         .AddHeader("Content-Type", "application/json")

                         .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")

                         .AddJsonBody(ContactData);

                     var response = await client.PostAsync<ActionCreate.Response>(request);

                     return response.properties.hs_all_contact_vids.ToString();
                 }
                 catch (Exception ex)
                 {
                     if (ex.Message.Contains("Conflict"))
                     {
                        GetContact getContact = new GetContact();

                        var result = await getContact.GetId(PhoneNummber);
                        return result;

                     }
                     else
                     {
                         return "0";
                     }
                    
                 }
             }




         }

         public class DeleteContact
         {
            public bool GDPRDelete(string contactid)
            {
                return true;
            }
         }

         public class UpdateContact

         {
             
         }

         public class GetContact
         {

             public async Task<string> GetId(string PhoneNumber  )
             {
                 try
                 {
                     var options = new RestClientOptions($"https://api.hubapi.com/crm/v3/objects/contacts/search")
                     {
                         ThrowOnAnyError = true,
                         Timeout = 10000,


                     };

                     var client = new RestClient(options);

                    var SearchData = new ActionGet.Request.Search
                    {


                        filterGroups = new List<ActionGet.Request.Filtergroup>
                        {
                            new ActionGet.Request.Filtergroup
                            {
                                filters = new List<ActionGet.Request.Filter>
                                {
                                    new ActionGet.Request.Filter

                                    {
                                        propertyName = "phone",
                                     
                                        value= PhoneNumber,
                                       
                                        _operator ="EQ"


                                    }
                                }
                            }
                        },
                        
                        properties=  new  List<string>
                        { 
                         "phone",
                         "firstname",

                        },
                        limit=100,
                       
                        query="",
                        sorts = new List<string>
                        {
                            "string"
                        } 
                        



                         
                     };

                    string DesStr = JsonConvert.SerializeObject(SearchData);
                    
            

                    var request = new RestRequest()

                        .AddHeader("Content-Type", "application/json")

                        .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")
                        .AddBody(DesStr, "application/json");      



                     var response = await client.PostAsync<ActionGet.Response.Search>(request);
                   
                 
                    
                    return response.results[0].id.ToString();
                 }

                 catch (Exception e )
                 {
                     MessageBox.Show(e.Message);
                     return null ;
                 }

               
             }
            public async Task<string> GetRevenue(string PhoneNumber)
            {
                try
                {
                    var options = new RestClientOptions($"https://api.hubapi.com/crm/v3/objects/contacts/search")
                    {
                        ThrowOnAnyError = true,
                        Timeout = 10000,


                    };

                    var client = new RestClient(options);

                    var SearchData = new ActionGet.Request.Search
                    {


                        filterGroups = new List<ActionGet.Request.Filtergroup>
                        {
                            new ActionGet.Request.Filtergroup
                            {
                                filters = new List<ActionGet.Request.Filter>
                                {
                                    new ActionGet.Request.Filter

                                    {
                                        propertyName = "phone",

                                        value= PhoneNumber,

                                        _operator ="EQ"


                                    }
                                }
                            }
                        },

                        properties = new List<string>
                        {
                         "phone",
                         "firstname",
                         "total_revenue",

                        },
                        limit = 100,

                        query = "",
                        sorts = new List<string>
                        {
                            "string"
                        }





                    };

                    string DesStr = JsonConvert.SerializeObject(SearchData);



                    var request = new RestRequest()

                        .AddHeader("Content-Type", "application/json")

                        .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")
                        .AddBody(DesStr, "application/json");



                    var response = await client.PostAsync<ActionGet.Response.Search>(request);



                    return response.total.ToString() ;
                }

                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }


            }
            public async Task<ActionGetContactInfo.ContactData> GetContactProp(string ContactId)
            {
                var options = new RestClientOptions($"https://api.hubapi.com/crm/v3/objects/contacts/{ContactId}")
                {
                    ThrowOnAnyError = true,
                    Timeout = 3000,


                };
                var client = new RestClient(options);

                var request = new RestRequest()

                           .AddHeader("Content-Type", "application/json")
                           .AddQueryParameter("archived", "false")
                           .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")

                           .AddQueryParameter("properties", "firstname")

                           .AddQueryParameter("properties", "phone")
                           .AddQueryParameter("properties", "email")
                           .AddQueryParameter("properties", "createdAt")
                           .AddQueryParameter("properties", "updatedAt")

                           .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077");

                var response = await client.GetAsync<ActionGetContactInfo.ContactData>(request);
                return response;
            }
        }

          
        public class AssociateContact
            
        {
               
            public  string ToDeal(string contactid , string dealid)
                
            {
                try
                {
                    var options = new RestClientOptions($"https://api.hubapi.com/crm/v3/objects/contact/{contactid}/associations/deal/{dealid}/contact_to_deal")
                    {
                        ThrowOnAnyError = true,
                        Timeout = 10000,


                    };

                    var client = new RestClient(options);

                    var request = new RestRequest()


                        .AddHeader("Content-Type", "application/json")



                        .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077");


                    var responce = client.PutAsync(request);
                    return responce.Result.Content;


                }
                catch (Exception ex)
                {
                    return ex.Message;
                }



            }

            public async Task<Models.Fields.AssociateContact.ListAssocDeals> GetAssocDeals(string contactid)
            {

                try
                {
                    var options = new RestClientOptions($"https://api.hubapi.com/crm/v3/objects/contacts/{contactid}/associations")
                    {
                        ThrowOnAnyError = true,
                        Timeout = 10000,

                    };

                    var client = new RestClient(options);


                    var request = new RestRequest()


                        .AddHeader("Content-Type", "application/json")



                        .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077");



                    var responce = await client.GetAsync<Models.Fields.AssociateContact.ListAssocDeals>(request);

                    return responce;

                }

                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    Models.Fields.AssociateContact.ListAssocDeals listAssocDeals = new Models.Fields.AssociateContact.ListAssocDeals();
                    return listAssocDeals;
                }
            }
                 
        

            
        }
        
        public class ListContact
        
        {


             private string after { get; set; }

             private int counter { get; set; }



             public async Task<DataTable> GetContactList()
             {

                 #region Create DataTable for Contacts Fetched from Api

                 DataSet dtSet;

                 DataTable custTable = new DataTable("Contacts");

                 DataColumn dtColumn;


                 DataRow myDataRow;


                 // Create id column

                 dtColumn = new DataColumn();
                 dtColumn.DataType = typeof(Int32);
                 dtColumn.ColumnName = "شناسه کاربری";
                 
                 dtColumn.ReadOnly = false;
                 dtColumn.Unique = true;
                 // Add column to the DataColumnCollection.
                 custTable.Columns.Add(dtColumn);

                 // Create Name column.
                 dtColumn = new DataColumn();
                 dtColumn.DataType = typeof(String);
                 dtColumn.ColumnName = "Name";
                 dtColumn.Caption = "نام و نام خانوادگی";
                 dtColumn.AutoIncrement = false;
                 dtColumn.ReadOnly = false;
                 dtColumn.Unique = false;
                 /// Add column to the DataColumnCollection.
                 custTable.Columns.Add(dtColumn);

                 // Create Address column.
                 dtColumn = new DataColumn();
                 dtColumn.DataType = typeof(String);
                 dtColumn.ColumnName = "MobileNum";
                 dtColumn.Caption = "موبایل";
                 dtColumn.ReadOnly = false;
                 dtColumn.Unique = false;
                 // Add column to the DataColumnCollection.
                 custTable.Columns.Add(dtColumn);
                 // Create Address column.
                 dtColumn = new DataColumn();
                 dtColumn.DataType = typeof(String);
                 dtColumn.ColumnName = "TotalRevenue";
                 dtColumn.Caption = "مجموع تراکنش ها";
                 dtColumn.ReadOnly = false;
                 dtColumn.Unique = false;
                 // Add column to the DataColumnCollection.
                 custTable.Columns.Add(dtColumn);
                // Create Address column.
                dtColumn = new DataColumn();
                dtColumn.DataType = typeof(DateTime);
                dtColumn.ColumnName = "CreateDate";
                dtColumn.Caption = "مجموع تراکنش ها";
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

                     var options = new RestClientOptions("https://api.hubapi.com/crm/v3/objects/contacts?")
                     {
                         ThrowOnAnyError = true,
                         Timeout = 3000,

                     };

                     var client = new RestClient(options);

                     var request = new RestRequest()



                         .AddHeader("accept", "application/json")

                         .AddQueryParameter("hapikey", "3ad5de2d-b2b7-450f-9396-8039cf878077")

                         .AddQueryParameter("archived", "false")

                         .AddQueryParameter("properties", "phone")

                         .AddQueryParameter("properties", "total_revenue")

                         .AddQueryParameter("limit", "100");


                     var response = await client.GetAsync<ListContacts.Response>(request);

                     string? after = response?.paging?.next?.after;

                     ListContacts.Response.Result results2 = new ListContacts.Response.Result();


                     string json = JsonConvert.SerializeObject(response.results);


                     foreach (var info in response.results)
                     {
                         myDataRow = custTable.NewRow();

                         myDataRow["شناسه کاربری"] = info.id;
                         myDataRow["Name"] = info.properties.firstname + " " + info.properties.lastname;
                         myDataRow["MobileNum"] = info.properties.phone;

                         myDataRow["TotalRevenue"] = info.properties.total_revenue;
                     
                       
                        myDataRow["CreateDate"] = ToPersianDate(info.createdAt);

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

                          .AddQueryParameter("properties", "phone")
                          .AddQueryParameter("properties","firstname")
                         .AddQueryParameter("properties", "total_revenue")

                         .AddQueryParameter("archived", "false")

                         .AddParameter("after", after)

                         .AddQueryParameter("limit", "100");

                         response = await client.GetAsync<ListContacts.Response>(request);

                         after = response?.paging?.next?.after;



                         string json2 = JsonConvert.SerializeObject(response.results);




                         foreach (var info in response.results)
                         {

                             myDataRow = custTable.NewRow();

                             myDataRow["شناسه کاربری"] = info.id;
                             myDataRow["Name"] = info.properties.firstname + " " + info.properties.lastname;
                             myDataRow["MobileNum"] = info.properties.phone;
                             myDataRow["TotalRevenue"] = info.properties.total_revenue;
                            
                            myDataRow["CreateDate"] = ToPersianDate(info.updatedAt);

                            custTable.Rows.Add(myDataRow);
                         }




                     }




                     while (after != null);

                     dtSet.Tables.Add(custTable);




                     return custTable;
                 }
                 catch (Exception ex)
                 {

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

     

    
}

