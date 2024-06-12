using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem
{
    public class Worker
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        private List<Objective> tasks;

        public Worker(string name, string surname)
        {
            Name = name;
            Surname = surname;
            tasks = new List<Objective>();
        }
    }
}
