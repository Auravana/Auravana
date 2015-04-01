using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auravana.Domain.Entities;
using Auravana.Domain.Concrete;
using Moq;
using Auravana.Domain.Abstract;

namespace Auravana.UnitTests
{
    [TestClass]
    public class IssueProcessorTests
    {
        [TestMethod]
        public void SubmitTest()
        {
            var issue = new Issue
            {
                PrimaryOperationalProcess = OperationalProcess.IncidentResponse,
                PrimaryHabitatSystem = HabitatSystem.LifeSupport,
                Category = IssueCategory.Incident,
                Creator = 42
            };

            var mockRepository = new Mock<IIssueRepository>();

            var processor = new IssueProcessor(mockRepository.Object);

            processor.SubmitToIssueTracking(issue);
        }
    }
}
