using Auravana.Domain.Abstract;
using Auravana.Domain.Entities;
using AutoMapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auravana.Domain.Concrete
{
    public class EfIssueRepository : IIssueRepository
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly EfDbContext _context = new EfDbContext();
        
        public IEnumerable<Issue> Issues
        {
            get { return _context.Issues; }
        }

        public void SaveIssue(Issue issue)
        {
            if (issue.IssueID == 0)
            {
                _context.Issues.Add(issue);
            }
            else
            {
                var existingIssue = _context.Issues.Find(issue.IssueID);
                if (existingIssue != null)
                {
                    existingIssue = Mapper.Map<Issue>(issue);
                }
            }

            _context.SaveChanges();

            log.Debug("Issue:{0}{1}", Environment.NewLine, issue);
        }

        public Issue DeleteIssue(int issueID)
        {
            var existingIssue = _context.Issues.Find(issueID);

            if (existingIssue != null)
            {
                _context.Issues.Remove(existingIssue);
                _context.SaveChanges();
            }

            return existingIssue;
        }
    }
}
