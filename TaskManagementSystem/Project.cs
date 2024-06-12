using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem
{
    public class Project: IManipulation<Objective>
    {
        private List<Objective> tasks;

        public Project()
        {
            tasks= new List<Objective>();
        }

        public void Add(Objective task)
        {
            tasks.Add(task);
        }

        public void Remove(Objective task)
        {
            tasks.Remove(task);
        }
    }
}
