using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Database.Tests
{
    [TestClass]
    public class Teachers : SqlDatabaseTestClass
    {
        private SqlDatabaseTestActions Database_PersistTeachersTestData;

        public Teachers()
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
            SqlDatabaseTestAction Database_PersistTeachersTest_TestAction;
            var resources = new ComponentResourceManager(typeof (Teachers));
            Database_PersistTeachersTestData = new SqlDatabaseTestActions();
            Database_PersistTeachersTest_TestAction = new SqlDatabaseTestAction();
            // 
            // Database_PersistTeachersTest_TestAction
            // 
            resources.ApplyResources(Database_PersistTeachersTest_TestAction, "Database_PersistTeachersTest_TestAction");
            // 
            // Database_PersistTeachersTestData
            // 
            Database_PersistTeachersTestData.PosttestAction = null;
            Database_PersistTeachersTestData.PretestAction = null;
            Database_PersistTeachersTestData.TestAction = Database_PersistTeachersTest_TestAction;
        }

        #endregion

        [TestMethod]
        public void Database_PersistTeachersTest()
        {
            var testActions = Database_PersistTeachersTestData;
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