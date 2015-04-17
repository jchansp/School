using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Database.Tests
{
    [TestClass]
    public class Countries : SqlDatabaseTestClass
    {
        private SqlDatabaseTestActions Database_RetrieveRandomCountryTestData;

        public Countries()
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
            SqlDatabaseTestAction Database_RetrieveRandomCountryTest_TestAction;
            var resources = new ComponentResourceManager(typeof (Countries));
            RowCountCondition rowCountCondition1;
            Database_RetrieveRandomCountryTestData = new SqlDatabaseTestActions();
            Database_RetrieveRandomCountryTest_TestAction = new SqlDatabaseTestAction();
            rowCountCondition1 = new RowCountCondition();
            // 
            // Database_RetrieveRandomCountryTest_TestAction
            // 
            Database_RetrieveRandomCountryTest_TestAction.Conditions.Add(rowCountCondition1);
            resources.ApplyResources(Database_RetrieveRandomCountryTest_TestAction,
                "Database_RetrieveRandomCountryTest_TestAction");
            // 
            // rowCountCondition1
            // 
            rowCountCondition1.Enabled = true;
            rowCountCondition1.Name = "rowCountCondition1";
            rowCountCondition1.ResultSet = 1;
            rowCountCondition1.RowCount = 1;
            // 
            // Database_RetrieveRandomCountryTestData
            // 
            Database_RetrieveRandomCountryTestData.PosttestAction = null;
            Database_RetrieveRandomCountryTestData.PretestAction = null;
            Database_RetrieveRandomCountryTestData.TestAction = Database_RetrieveRandomCountryTest_TestAction;
        }

        #endregion

        [TestMethod]
        public void Database_RetrieveRandomCountryTest()
        {
            var testActions = Database_RetrieveRandomCountryTestData;
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