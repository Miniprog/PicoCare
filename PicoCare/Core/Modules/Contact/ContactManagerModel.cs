

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PicoCRM.Core.Modules.Contact.Models
{



    public class Fields
    {
        public class ActionCreate

        {

            public class Request
            {

                public Properties? properties { get; set; }

                public class Properties
                {
                    public string? company { get; set; }
                    public string? email { get; set; }
                    public string? firstname { get; set; }
                    public string? lastname { get; set; }
                    public string? phone { get; set; }
                    public string? website { get; set; }
                   


                }
            }

            public class Response
            {
                public int id { get; set; }

                public Properties? properties { get; set; }
                public string? status { get; set; }
                public string? message { get; set; }

                public string? correlationId { get; set; }
                public string? category { get; set; }

                public class Properties
                {
                    public string? company { get; set; }
                    public DateTime createdate { get; set; }
                    public string? email { get; set; }
                    public string? firstname { get; set; }
                    public string? lastname { get; set; }
                    public string? phone { get; set; }
                    public string? website { get; set; }
                    public string? hs_all_contact_vids { get; set; }
                    public string? hs_is_contact { get; set; }
                    public string? total_revenue { get; set; }
                }

                public class Error
                {

                }
            }

        }

        public class ActionGet
        {
            public class Request
            {

                public class Search
                {
                    public List<Filtergroup> filterGroups { get; set; }
                    public List<string> sorts { get; set; }
                    public string query { get; set; }
                    public List<string> properties { get; set; }
                    public int limit { get; set; }
                    public int after { get; set; }
                }

                public class Filtergroup
                {
                    public List<Filter> filters { get; set; }
                }

                public class Filter
                {
                    public string value { get; set; }
                    public string propertyName { get; set; }

                    [JsonProperty("operator")]
                    public string _operator { get; set; }
                }

            }
            public class Response
            {

                public class Search
                {
                    public int total { get; set; }
                    public List<Result> results { get; set; }
                }

                public class Result
                {
                    public string id { get; set; }
                    public Properties properties { get; set; }
                    public DateTime createdAt { get; set; }
                    public DateTime updatedAt { get; set; }
                    public bool archived { get; set; }
                }

                public class Properties
                {
                    public DateTime createdate { get; set; }
                    public string hs_object_id { get; set; }
                    public DateTime lastmodifieddate { get; set; }
                    public string firstname { get; set; }
                    public string total_revenue { get; set; }
                }

            }
        }

        public class ListContacts
        {
            public class Response
            {
                public List<Result>? results { get; set; }
                public Paging? paging { get; set; }

                public class Properties
                {
                    public DateTime createdate { get; set; }
                    public string email { get; set; }
                    public string firstname { get; set; }
                    public string hs_object_id { get; set; }
                    public DateTime lastmodifieddate { get; set; }
                    public string lastname { get; set; }
                    public string? phone { get; set; }
                    public string? total_revenue { get; set; }
                }

                public class Result
                {
                    public string id { get; set; }
                    public Properties properties { get; set; }
                    public DateTime createdAt { get; set; }
                    public DateTime updatedAt { get; set; }
                    public bool archived { get; set; }
                }

                public class Next
                {
                    public string? after { get; set; }
                    public string? link { get; set; }
                }

                public class Paging
                {
                    public Next? next { get; set; }
                }
            }
        }

        public class AssociateContact
        {

            public class ListAssocDeals
            {
                public List<Result> results { get; set; }
                public Paging paging { get; set; }
            }

            public class Paging
            {
                public Next next { get; set; }
            }

            public class Next
            {
                public string after { get; set; }
                public string link { get; set; }
            }

            public class Result
            {
                public string id { get; set; }
                public string type { get; set; }
            }

        }
        public class DeleteContact
        {
            public class MoveContactToRecyclebin
            {

            }
            public class PermanentDelete
            {

            }
        }

        public class ActionGetContactInfo
        {

            public class ContactData
            {
                public string id { get; set; }
                public Properties properties { get; set; }
                public DateTime createdAt { get; set; }
                public DateTime updatedAt { get; set; }
                public bool archived { get; set; }
            }

            public class Properties
            {
                public DateTime createdate { get; set; }
                public string email { get; set; }
                public string firstname { get; set; }
                public string hs_object_id { get; set; }
                public DateTime lastmodifieddate { get; set; }
           
                public string total_revenue { get; set; }
                public string phone { get; set; }
            }

        }
    }

}
