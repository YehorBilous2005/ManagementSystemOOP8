using ManagementSystem;

namespace OOP8
{
    static class Program
    {
        delegate void Delegate(Worker worker);

        public static void Main(string[] args)
        {
            var team = new Team();
            var yehor = new Worker("Yehor", "Bilous");
            team.Members.Add(yehor);
            foreach (var member in team.Members)
            {
                Console.WriteLine(member.Name + ' ' + member.Surname);
            }
            Console.WriteLine(" /////");

            Delegate a = team.Add;

            a(yehor);

            team.Add(yehor);
            var anton = new Worker("Anton", "Andr");
            team.Add(anton);
            foreach (var member in team.Members)
            {
                Console.WriteLine(member.Name + ' ' + member.Surname);
            }
            team.Remove(yehor);
            team.Remove(yehor);

            Console.WriteLine(" ");
            foreach (var member in team.Members)
            {
                Console.WriteLine(member.Name + ' ' + member.Surname);
            }

            Console.WriteLine(" ");
            var project1 = new Project();
            team.Add(project1);
            var task1 = new Objective("1");
            var task2 = new Objective("2");
            var task3 = new Objective("3");
            task1.ChangeStatus(0.5);
            task2.ChangeStatus(1);
            task3.ChangeStatus(0.1);
            project1.Add(task1, task2, task3);
            foreach (var task in project1.Objectives)
            {
                Console.WriteLine(task.Name);
            }
            Console.WriteLine(" ");
            foreach (var task in project1.OngoingObjList())
            {
                Console.WriteLine(task.Name);
            }
            Console.WriteLine(" ");
            Console.WriteLine(project1.Status());

            Console.WriteLine(" ");
            Console.WriteLine(project1.IsDone());
            task1.SetReadiness(true);
            task2.SetReadiness(true);
            task3.SetReadiness(true);
            Console.WriteLine(" ");
            foreach (var task in project1.OngoingObjList())
            {
                Console.WriteLine(task.Name);
            }
            Console.WriteLine(project1.IsDone());
            Console.WriteLine(project1.Status());

            Console.WriteLine(" ");
            team.Add(yehor);
            yehor.Add(task3);
            yehor.Add(task1);
            anton.Add(task2);

            Console.WriteLine(" ");
            foreach (var obj in project1.Objectives)
            {
                Console.WriteLine(obj.Name);
            }
            var task4 = new Objective("4");
            var task5 = new Objective("5");
            var task6 = new Objective("6");
            project1.Add(task4, task5, task6);

            Console.WriteLine(" ");
            foreach (var obj in project1.Objectives)
            {
                Console.WriteLine(obj.Name);
            }

            Console.WriteLine("ad ");
            foreach (var obj in project1.FreeObjectives())
            {
                Console.WriteLine(obj.Name);
            }
            team.ObjAutoDistribution();

            Console.WriteLine("Free");
            foreach (var obj in project1.FreeObjectives())
            {
                Console.WriteLine(obj.Name);
            }

            Console.WriteLine("Busy");
            foreach (var obj in project1.Objectives)
            {
                Console.WriteLine(obj.Name);
            }

            Console.WriteLine();
            foreach (var executor in task1.Executors)
            {
                Console.WriteLine(executor.Name);
            }
            Console.WriteLine(" ");

            anton.Add(task1);
            foreach (var executor in task1.Executors)
            {
                Console.WriteLine(executor.Name);
            }
            Console.WriteLine(" ");
            Console.WriteLine(yehor.WorkLoad());
        }
    }
}
