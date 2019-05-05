﻿using Flurl;
using Flurl.Http;
using NogginBug.Data.Model;
using OpenQA.Selenium.Remote;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;


[assembly: CollectionBehavior(DisableTestParallelization = true)] 
namespace NogginBug.Tests.Features.Steps
{
    [Binding]
    public class SharedSteps
    {
        private readonly RemoteWebDriver _webDriver;

        public SharedSteps(RemoteWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Given(@"there are (.*) bugs with status open")]
        public async Task GivenThereAreBugsWithStatusOpen(int numOpenBugs)
        {
            var bugs = Enumerable.Range(1, numOpenBugs)
                .Select(i => new {
                    id = Guid.NewGuid(),
                    title = $"Bug {i}",
                    description = $"Bug description {i}",
                    status = BugStatus.Open,
                    openedDate = Shared.MayThe4th.AddHours(-i)
                }).ToList();

            await Shared.SiteUrl
                .AppendPathSegment("api/v1/bugs")
                .PutJsonAsync(bugs);
        }


        [When(@"I visit the '(.*)' page")]
        public void WhenIVisitPage(string page)
        {
            string UrlForPage()
            {
                switch(page)
                {
                    case "home": return Shared.SiteUrl;
                    default: throw new Exception($"Unknow page '{page}'");
                }
            }
            _webDriver.Navigate().GoToUrl(UrlForPage());
        }
    }
}