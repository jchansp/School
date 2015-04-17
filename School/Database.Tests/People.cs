using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Database.Tests
{
    [TestClass]
    public class People : SqlDatabaseTestClass
    {
        private SqlDatabaseTestActions Database_PersistPeopleTestData;

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
            SqlDatabaseTestAction Database_PersistPeopleTest_TestAction;
            var resources = new ComponentResourceManager(typeof (People));
            Database_PersistPeopleTestData = new SqlDatabaseTestActions();
            Database_PersistPeopleTest_TestAction = new SqlDatabaseTestAction();
            // 
            // Database_PersistPeopleTest_TestAction
            // 
            resources.ApplyResources(Database_PersistPeopleTest_TestAction, "Database_PersistPeopleTest_TestAction");
            // 
            // Database_PersistPeopleTestData
            // 
            Database_PersistPeopleTestData.PosttestAction = null;
            Database_PersistPeopleTestData.PretestAction = null;
            Database_PersistPeopleTestData.TestAction = Database_PersistPeopleTest_TestAction;
        }

        #endregion

        [TestMethod]
        public void Database_PersistPeopleTest()
        {
            var testActions = Database_PersistPeopleTestData;
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