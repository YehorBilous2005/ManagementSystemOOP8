using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ManagementSystem
{
    public class Worker : IManipulation<Objective> 
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public bool InTeam { get; set; }

        public List<Objective> Objectives { get; private set; }

        public Worker(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Objectives = new List<Objective>();
            InTeam = false;
        }

        public Worker()
        {
            Name = "No name";
            Surname = "No surname";
            Objectives = new List<Objective>();
            InTeam = false;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeSurname(string surname)
        {
            Surname = surname;
        }

        public void Add(Objective objective)
        {
            if (InTeam && objective != null)
            {
                Objectives.Add(objective);
                objective.Add(this);
            }
        }

        public void Remove(Objective objective)
        {
            if (Objectives.Contains(objective) && objective != null)
            {
                Objectives.Remove(objective);
                objective.Remove(this);
            }
        }

        public double WorkLoad()
        {
            double sum = 0;
            foreach (var objective in Objectives)
            {
                sum += 1 - objective.Status;
            }
            return sum;
        }
    }
}
