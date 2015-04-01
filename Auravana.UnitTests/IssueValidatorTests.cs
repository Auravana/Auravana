using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auravana.Domain.Validation;
using Auravana.Domain.Entities;

namespace Auravana.UnitTests
{
    [TestClass]
    public class IssueValidatorTests
    {
        private readonly IssueValidator _validator = new IssueValidator();

        [TestMethod]
        public void HappyPath1()
        {
            var issue = new Issue
            {
                PrimaryOperationalProcess = OperationalProcess.IncidentResponse,
                PrimaryHabitatSystem = HabitatSystem.LifeSupport,
                Category = IssueCategory.Incident,
                Creator = 42
            };

            var result = _validator.Validate(issue);

            Assert.IsTrue(result.IsValid, string.Format("Should be valid but isn't due to: \r\n{0}", string.Join("\r\n", result.Errors)));
        }
    }
}
