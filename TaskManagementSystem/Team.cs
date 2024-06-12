using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem
{
    public class Team : IManipulation<Worker>, IManipulation<Project>
    {
        private List<Project> projects;
        private List<Worker> members;

        public Team()
        {
            members = new List<Worker>();
            projects = new List<Project>();
        }

        public void Add(Worker member)
        {
            members.Add(member);
        }

        public void Remove(Worker member)
        {
            members.Remove(member);
        }

        public void Add(Project project)
        {
            projects.Add(project);
        }

        public void Remove(Project project)
        {
            projects.Remove(project);
        }

        public List<Worker> MemberList()
        {
            return members;
        }

        public List<Project> ProjectList()
        {
            return projects;
        }
    }
}
