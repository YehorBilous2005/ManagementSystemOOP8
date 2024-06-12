using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem
{
    public class Objective
    {
        public int? Index { get; private set; }
        public string Description { get; private set; }
        public bool IsDone { get; private set; }
        public int Status { get; private set; }

        public Worker? Executor {get; private set; }

        public Objective()
        {
            Index = null;
            Description = string.Empty;
            IsDone = false;
            Status = 0;
            Executor = null;
        }

        public void ChangeStatus(int status)
        {
            status = status > 100? 100 : status;
            status = status < 0 ? 0 : status;
            Status = status;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void IsFinished()
        {
            IsDone = true;
            Status = 100;
        }

        public void ChangeExecutor(Worker executor)
        {
            Executor = executor;
        }

        public void RemoveExecutor()
        {
            Executor = null;
        }
    }
}
