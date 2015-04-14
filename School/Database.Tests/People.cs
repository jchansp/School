using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Database.Tests
{
    [TestClass]
    public class People : SqlDatabaseTestClass
    {
        private SqlDatabaseTestActions SetPeopleTestData;

        public People()
        {
            InitializeComponent();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            InitializeTest();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CleanupTest();
        }

        #region Designer support code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SqlDatabaseTestAction SetPeopleTest_TestAction;
            var resources = new ComponentResourceManager(typeof (People));
            SetPeopleTestData = new SqlDatabaseTestActions();
            SetPeopleTest_TestAction = new SqlDatabaseTestAction();
            // 
            // SetPeopleTest_TestAction
            // 
            resources.ApplyResources(SetPeopleTest_TestAction, "SetPeopleTest_TestAction");
            // 
            // SetPeopleTestData
            // 
            SetPeopleTestData.PosttestAction = null;
            SetPeopleTestData.PretestAction = null;
            SetPeopleTestData.TestAction = SetPeopleTest_TestAction;
        }

        #endregion

        [TestMethod]
        public void SetPeopleTest()
        {
            var testActions = SetPeopleTestData;
            // Execute the pre-test script
            // 
            Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            var pretestResults = TestService.Execute(PrivilegedContext, PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                var testResults = TestService.Execute(ExecutionContext, PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                var posttestResults = TestService.Execute(PrivilegedContext, PrivilegedContext,
                    testActions.PosttestAction);
            }
        }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //

        #endregion
    }
}