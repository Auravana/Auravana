using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Auravana.Domain.Entities
{
    /// <summary>
    /// Encapsulates all the data required for entry into the system.
    /// </summary>
    public class Issue
    {
        public Issue()
        {
            Created = DateTime.Now;
            Version = 1;
        }
        
        [HiddenInput(DisplayValue = false)]
        public int IssueID { get; set; }

        public DateTime Created { get; private set; }
        public DateTime LastUpdated { get; set; }
        public int Version { get; set; }
        public HabitatSystem PrimaryHabitatSystem { get; set; }
        public OperationalProcess PrimaryOperationalProcess { get; set; }
        public IssueCategory Category { get; set; }
        public IssueCreator CreatorType { get; set; }
        public int Creator { get; set; }
        public bool NotifyCreator { get; set; }
        public string Comment { get; set; }

        public override string ToString()
        {
            return this.Dump();
        }
    }
}
