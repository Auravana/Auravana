using Auravana.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auravana.Domain.Validation
{
    public class IssueValidator : AbstractValidator<Issue>
    {
        public IssueValidator()
        {
            RuleFor(issue => issue.Created).GreaterThan(DateTime.MinValue);
            RuleFor(issue => issue.Creator).NotEqual(0);
        }
    }
}
