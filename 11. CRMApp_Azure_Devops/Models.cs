using CRMApp;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace CRMApp
{
    public class Application
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("n");
        public DateTime cre_time { get; set; } = DateTime.UtcNow;
        public DateTime mod_time { get; set; } = DateTime.UtcNow;
        public string application_id { get; set; }
        public string applicant { get; set; }
        public string applicationType { get; set; }
    }


    public class ApplicaitonCreateModel
    {
        public string application_id { get; set; }
        public string applicant { get; set; }
        public string applicationType { get; set; }

    }
    public class ApplicationUpdateModel
    {
        public string application_id { get; set; }
        public string applicant { get; set; }
        public string applicationType { get; set; }
    }

    public class ApplicationTableEntity : TableEntity
    {
        public DateTime cre_time { get; set; }
        public DateTime mod_time { get; set; }
        public string application_id { get; set; }
        public string applicant { get; set; }
        public string applicationType { get; set; }

    }

    public static class Mappings
    {
        public static ApplicationTableEntity ToTableEntity(this Application application)
        {
            return new ApplicationTableEntity()
            {
                PartitionKey = "TODO",
                RowKey = application.Id,
                application_id = application.application_id,
                cre_time = application.cre_time,
                mod_time = application.mod_time,
                applicant = application.applicant,
                applicationType = application.applicationType
            };
        }

        public static Application ToApplication(this ApplicationTableEntity application)
        {
            return new Application()
            {
                Id = application.RowKey,
                application_id = application.application_id,
                cre_time = application.cre_time,
                mod_time = application.mod_time,
                applicant = application.applicant,
                applicationType = application.applicationType
            };
        }
    }
}


