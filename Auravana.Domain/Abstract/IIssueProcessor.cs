using Auravana.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auravana.Domain.Abstract
{
    public interface IIssueProcessor
    {
        void SubmitToIssueTracking(Issue issue);
    }
}
