using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class Objective : IManipulation<Worker>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsDone { get; private set; }
        public double Status { get; private set; }
        public List<Worker> Executors { get; private set; }

        public DateTime DeadlineDate { get; private set; }

        public Objective()
        {
            Name = "No name";
            Description = string.Empty;
            IsDone = false;
            Status = 0;
            Executors = new List<Worker>();
            DeadlineDate = DateTime.Now;
        }

        public Objective(string name)
        {
            Name = name;
            Description = string.Empty;
            IsDone = false;
            Status = 0;
            Executors = new List<Worker>();
            DeadlineDate = DateTime.Now;
        }

        public void ChangeStatus(double status)
        {
            Status = status > 1? 1 : status < 0 ? 0 : status;
            IsDone = status == 1 ? true : false;
        }

        public void SetReadiness(bool isDone)
        {
            IsDone = isDone;
            Status = isDone ? 1 : 0;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void Add(Worker executor)
        {
            Executors.Add(executor);
            if (!executor.Objectives.Contains(this))
            {
                executor.Add(this);
            }
        }

        public void Remove(Worker executor)
        {
            Executors.Remove(executor);
            if (executor.Objectives.Contains(this))
            {
                executor.Remove(this);
            }
        }

        public void ChangeDeadLine(DateTime date)
        {
            DeadlineDate = date;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public bool IsOngoing()
        {
            return DateTime.Now < DeadlineDate;
        }

        public bool IsExpired()
        {
            return DateTime.Now > DeadlineDate;
        }
    }
}
