using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Database.Tests
{
    [TestClass]
    public class Students : SqlDatabaseTestClass
    {
        private SqlDatabaseTestActions Database_PersistStudentsTestData;

        public Students()
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
            SqlDatabaseTestAction Database_PersistStudentsTest_TestAction;
            var resources = new ComponentResourceManager(typeof (Students));
            Database_PersistStudentsTestData = new SqlDatabaseTestActions();
            Database_PersistStudentsTest_TestAction = new SqlDatabaseTestAction();
            // 
            // Database_PersistStudentsTest_TestAction
            // 
            resources.ApplyResources(Database_PersistStudentsTest_TestAction, "Database_PersistStudentsTest_TestAction");
            // 
            // Database_PersistStudentsTestData
            // 
            Database_PersistStudentsTestData.PosttestAction = null;
            Database_PersistStudentsTestData.PretestAction = null;
            Database_PersistStudentsTestData.TestAction = Database_PersistStudentsTest_TestAction;
        }

        #endregion

        [TestMethod]
        public void Database_PersistStudentsTest()
        {
            var testActions = Database_PersistStudentsTestData;
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