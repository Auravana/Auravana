using Auravana.Domain.Abstract;
using Auravana.Domain.Entities;
using Auravana.Domain.Validation;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auravana.Domain.Concrete
{
    public class IssueProcessor : IIssueProcessor
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        private readonly IssueValidator _validator;
        private readonly IIssueRepository _repository;

        public IssueProcessor(IIssueRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _repository = repository;

            _validator = new IssueValidator();            
        }

        public void SubmitToIssueTracking(Issue issue)
        {
            var results = _validator.Validate(issue);

            if (results.IsValid == false)
            {                
                var resultString = string.Join(Environment.NewLine, results.Errors);
                log.Error("Invalid issue:{0}{1}", Environment.NewLine, resultString);
                //should do some logging here

                throw new ArgumentException(resultString, "issue");
            }
            else
            {
                _repository.SaveIssue(issue);
            }
        }
    }
}
