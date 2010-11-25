﻿using HoplaHelpdesk.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HoplaHelpdesk.ViewModels;
using HoplaHelpdesk.Models;
using System.Collections.Generic;

namespace HoplaHelpdesk.Tests
{
    
    
    /// <summary>
    ///This is a test class for ProblemSearchTest and is intended
    ///to contain all ProblemSearchTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProblemSearchTest
    {
        CategoryTagSelectionViewModel catTag = null; // TODO: Initialize to an appropriate value
        List<Problem> problems = null; // TODO: Initialize to an appropriate value
        List<Tag> tags = null;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #region Test Setup
        [TestInitialize()]
        public void MyTestInitialize()
        {    
            catTag = new CategoryTagSelectionViewModel
            {
                Categories = new List<CategoryWithListViewModel>
                {
                    new CategoryWithListViewModel
                    {
                        Id = 1,
                        Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                        {
                            new Tag
                            {
                                Id = 1,
                                Category_Id = 1
                            },
                            new Tag
                            {
                                Id = 2,
                                Category_Id = 1
                            }
                        }
                    },
                    new CategoryWithListViewModel
                    {
                        Id = 2,
                        Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                        {
                            new Tag
                            {
                                Id = 3,
                                Category_Id = 2
                            },
                            new Tag
                            {
                                Id = 4,
                                Category_Id = 2
                            }
                        }
                    }

                }
            };



            tags = new List<Tag>
            {
                catTag.Categories[0].TagList[0],
                catTag.Categories[0].TagList[1],
                catTag.Categories[1].TagList[0],
                catTag.Categories[1].TagList[1]
            };


            problems = new List<Problem>{
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    { 
                        tags[0],
                        tags[1]
                    },
                    Id = 1
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    { 
                        tags[0],
                        tags[1]
                    },
                    Id = 2
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    {
                    },
                    Id = 3
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    { 
                        tags[0]
                    },
                    Id = 4
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    {
                        tags[1]
                    },
                    Id = 5
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    { 
                        tags[3]
                    },
                    Id = 6
                }
            };

        }
        #endregion

        /// <summary>
        ///A test for Search
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Documents and Settings\\aba\\My Documents\\3.SW\\P3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void SearchTest1()
        {
            #region Test Setup
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            tags[0].IsSelected = true;
            tags[0].IsSelected = true;
            #endregion


            #region Test Run
            actual = ProblemSearch.Search(catTag,problems,tags);
            #endregion

            #region Assertions
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
            #endregion
        }
    }
}
