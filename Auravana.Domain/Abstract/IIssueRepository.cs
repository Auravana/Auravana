using Auravana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auravana.Domain.Abstract
{
    public interface IIssueRepository
    {
        IEnumerable<Issue> Issues { get; }
        void SaveIssue(Issue issue);
        Issue DeleteIssue(int issueID);
    }
}
