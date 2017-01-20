namespace HumansTestClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StudentsAndWorkers;

    public class StartTest
    {
        public static void Main()
        {
            var students = InitializeStudents();
            PrintCollection(students);

            var sortedByGrade = students
                .OrderBy(st => st.Grade);
            PrintCollection(sortedByGrade);

            var workers = InitializeWorkers();
            PrintCollection(workers);

            var sortedByMoneyPHDescending = workers
                .OrderByDescending(w => w.EarnedMoneyPerHour());
            PrintCollection(sortedByMoneyPHDescending);

            var mergedList = new List<Human>();
            mergedList.AddRange(students);
            mergedList.AddRange(workers);
            PrintCollection(mergedList);

            var mergedAndSorted = mergedList
                .OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName);
            PrintCollection(mergedAndSorted);
          
           
        }

        public static List<Student> InitializeStudents()
        {
            var studList = new List<Student>();
            studList.Add(new Student("Dido", "Didov", 6));
            studList.Add(new Student("Maria", "Todeva", 7));
            studList.Add(new Student("Kamen", "Nikov", 1));
            studList.Add(new Student("Stanislav", "Dokov", 2));
            studList.Add(new Student("Dimitar", "Dimitrov", 8));
            studList.Add(new Student("Stoyan", "Ivanov", 10));
            studList.Add(new Student("Nikolay", "Nedkov", 9));
            studList.Add(new Student("Denislav", "Dimov", 2));
            studList.Add(new Student("Svetoslav", "Grigorov", 3));
            studList.Add(new Student("Doroteya", "Georgieva", 4));

            return studList;
        }

        public static List<Worker> InitializeWorkers()
        {
            var workerList = new List<Worker>();
            workerList.Add(new Worker("Dimata", "Rusnaka", 200, 8));
            workerList.Add(new Worker("Kolio", "Stoyanov", 400, 10));
            workerList.Add(new Worker("Rusko", "Rusev", 300, 9));
            workerList.Add(new Worker("Dinio", "Dinev", 300, 12));
            workerList.Add(new Worker("Taralyan", "Drinkov", 200, 4));
            workerList.Add(new Worker("Ivan", "Stoev", 200, 6));
            workerList.Add(new Worker("Lili", "Spasova", 200, 7));
            workerList.Add(new Worker("Asya", "Stoeva", 300, 10));
            workerList.Add(new Worker("Alex", "Donev", 500, 12));
            workerList.Add(new Worker("Greta", "Ivanova", 200, 6));

            return workerList;

        }

        public static void PrintCollection<T>(IEnumerable<T> collection)
            where T : Human
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

    }
}
