using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicoCRM.Core.Modules.Deal
{
    public class Fields
    {
        public class ActionCreateDeal
        {
            public Properties properties { get; set; }
            public string? id { get; set; }

            public class Properties
            {
                public string? amount { get; set; }
                public DateTime closedate { get; set; }
                public string? dealname { get; set; }
                public string? dealstage { get; set; }
                public string hubspot_owner_id { get; set; }
                public string deal_desc { get; set; }
                public string description { get; set; }
                public string pipeline { get; set; }
            }




        }

        public class ActionGetDeal
        {

            public class Assocs
            {
                public class Response
                {
                    public List<Result> results { get; set; }
                }

                public class Result
                {
                    public string id { get; set; }
                    public string type { get; set; }
                }
            }



            public class Read
            {
                public string id { get; set; }
                public Properties properties { get; set; }
                public DateTime createdAt { get; set; }
                public DateTime updatedAt { get; set; }
                public bool archived { get; set; }
            }

            public class Properties
            {
                public string amount { get; set; }
                public DateTime closedate { get; set; }
                public DateTime createdate { get; set; }
                public string dealname { get; set; }


                public string deal_desc { get; set; }
                public string dealstage { get; set; }
                public DateTime hs_lastmodifieddate { get; set; }
                public string hs_object_id { get; set; }
                public string pipeline { get; set; }

                public string description { get; set; }
            }



        }

        public class ActionUpdateDeal
        {
            public class Request
            {

                public Properties properties { get; set; }

                public class Properties
                {
                    public string amount { get; set; }

                    public DateTime closedate { get; set; }

                    public string dealname { get; set; }

                    public string dealstage { get; set; }
                    public string description { get; set; }

                    public string deal_desc { get; set; }
                    public string hubspot_owner_id { get; set; }

                    public string pipeline { get; set; }
                }
              


            }

            public class Response
            {

                public string message { get; set; }
                   
                public string correlationId { get; set; }
                   
                public string category { get; set; }
                   
                public Links links { get; set; }
              

                public class Links
                {
                    public string knowledgebase { get; set; }
                }

                public string id { get; set; }

                public Properties properties { get; set; }

                public DateTime createdAt { get; set; }

                public DateTime updatedAt { get; set; }

                public bool archived { get; set; }



                public class Properties
                {

                    public string amount { get; set; }
                    public DateTime closedate { get; set; }
                    public DateTime createdate { get; set; }
                    public string dealname { get; set; }
                    public string dealstage { get; set; }


                    public DateTime hs_lastmodifieddate { get; set; }
                    public string hubspot_owner_id { get; set; }
                    public string pipeline { get; set; }
                }

            }
        }

        public class ActionListDeals
        {
            public class Properties
            {
                public string amount { get; set; }
                public DateTime closedate { get; set; }
                public DateTime createdate { get; set; }
                public string dealname { get; set; }
                public string dealstage { get; set; }
                public DateTime hs_lastmodifieddate { get; set; }
                public string hubspot_owner_id { get; set; }
                public string pipeline { get; set; }
            }

            public class Result
            {
                public string id { get; set; }

                public Properties properties { get; set; }
            }

            public class Next
            {
                public string after { get; set; }
                public string link { get; set; }
            }

            public class Paging
            {
                public Next next { get; set; }
            }

            public class ListAll
            {

                public List<Result> results { get; set; }
                public Paging paging { get; set; }
            }

        }
    }
}
