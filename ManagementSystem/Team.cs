using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class Team : IManipulation<Worker>, IManipulation<Project>
    {
        public List<Project> Projects { get; private set; }
        public List<Worker> Members { get; private set; }

        public Team()
        {
            Members = new List<Worker>();
            Projects = new List<Project>();
        }

        public void Add(Worker member)
        {
            Members.Add(member);
            member.InTeam = true;
        }

        public void Remove(Worker member)
        {
            Members.Remove(member);
            foreach (var objective in member.Objectives)
            {
                objective.Remove(member);
            }
            member.Objectives.Clear();
        }

        public void Add(Project project)
        {
            Projects.Add(project);
        }

        public void Remove(Project project)
        {
            Projects.Remove(project);
        }

        public void ObjAutoDistribution()
        {
            foreach (var project in Projects)
            {
                var list = project.FreeObjectives();
                while (list.Any())
                {
                    foreach (var member in Members)
                    {
                        if (list.Any())
                        {
                            member.Add(list.Last());
                            list.Remove(list.Last());
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
