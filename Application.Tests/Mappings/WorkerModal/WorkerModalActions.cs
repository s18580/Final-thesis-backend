using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Application.Tests.Mappings.WorkerModal
{
    public class WorkerModalActions
    {
        private static WorkerModal WorkerModal { get; set; }
        public static void InitPage(IWebDriver driver)
        {
            WorkerModal = new WorkerModal(driver);
        }

        public static void AddAssignment()
        {
            WorkerModal.AddWorkerButton.Click();
            Thread.Sleep(500);
        }

        public static void PopulateAssignmentDetails(bool isLeader, string worker)
        {
            WorkerModal.WorkersDropdown.Click();
            IReadOnlyList<IWebElement> workers = WorkerModal.DropdownElements;
            if (workers.Count != 0)
            {
                workers[0].Click();
            }

            if (isLeader) WorkerModal.IsLeader.Click();
        }

    }
}
