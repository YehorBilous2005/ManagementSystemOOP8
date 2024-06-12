using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class Project: IManipulation<Objective>
    {
        public List<Objective> Objectives { get; private set; }

        public string Name { get; private set; }

        public Project()
        {
            Objectives = new List<Objective>();
            Name = "No name";
        }

        public Project(string name)
        {
            Objectives = new List<Objective>();
            Name = name;
        }

        public void Add(Objective task)
        {
            Objectives.Add(task);
        }

        public void Add(params Objective[] tasks)
        {
            foreach (var task in tasks)
            {
                Objectives.Add(task);
            }
        }

        public void Remove(Objective task)
        {
            Objectives.Remove(task);
        }

        public void Remove(params Objective[] tasks)
        {
            foreach (var task in tasks)
            {
                Objectives.Remove(task);
            }
        }

        public List<Objective> DoneObjList()
        {
            var list = new List<Objective>();
            foreach (var objective in Objectives)
            {
                if (objective.IsDone)
                {
                    list.Add(objective);
                }
            }
            return list;
        }

        public List<Objective> OngoingObjList()
        {
            var list = new List<Objective>();
            foreach (var objective in Objectives)
            {
                if (!objective.IsDone)
                {
                    list.Add(objective);
                }
            }
            return list;
        }

        public double Status()
        {
            double sum = 0;
            foreach (var objective in Objectives)
            {
                sum += objective.Status;
            }
            return sum / Objectives.Count;
        }

        public bool IsDone()
        {
            foreach (var objective in Objectives)
            {
                if (!objective.IsDone)
                {
                    return false;
                }
            }
            return true;
        }

        public List<Objective> FreeObjectives()
        {
            var list = new List<Objective>();
            foreach (var objective in Objectives)
            {
                if (!objective.Executors.Any())
                {
                    list.Add(objective);
                }
            }
            return list;
        }

        public List<Objective> AfterDeadLineList()
        {
            var list = new List<Objective>();
            foreach (var objective in Objectives)
            {
                if (objective.DeadlineDate < DateTime.Now)
                {
                    list.Add(objective);
                }
            }
            return list;
        }

        public List<Objective> BeforeDeadLineList()
        {
            var list = new List<Objective>();
            foreach (var objective in Objectives)
            {
                if (objective.DeadlineDate > DateTime.Now)
                {
                    list.Add(objective);
                }
            }
            return list;
        }
    }
}
