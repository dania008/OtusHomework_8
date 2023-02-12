using System.Diagnostics.Metrics;

internal class Program
{
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public Employee Left { get; set; }
        public Employee Right { get; set; }

        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }
    }

    class BinaryTree
    {
        private Employee root;
        bool isFindSalary = false;

        public void AddEmployee(string name, int salary)
        {
            var employee = new Employee(name, salary);
            if (root == null)
            {
                root = employee;
            }
            else
            {
                AddEmployee(root, employee);
            }
        }

        private void AddEmployee(Employee current, Employee employee)
        {
            if (employee.Salary < current.Salary)
            {
                if (current.Left == null)
                {
                    current.Left = employee;
                }
                else
                {
                    AddEmployee(current.Left, employee);
                }
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = employee;
                }
                else
                {
                    AddEmployee(current.Right, employee);
                }
            }
        }

        public void PrintInOrder()
        {
            PrintInOrder(root);
        }

        private void PrintInOrder(Employee current)
        {
            if (current == null)
            {
                return;
            }

            PrintInOrder(current.Left);
            Console.WriteLine(current.Name + " - " + current.Salary);
            PrintInOrder(current.Right);
        }
        public void FindEmployee(int salary)
        {
            FindEmployee(root, salary);
        }
        private void FindEmployee(Employee current, int salary)
        {
            if (salary == current.Salary)
            {
                Console.WriteLine(current.Name);
                return;
            }

            if (salary < current.Salary && current.Left != null)
            {
                FindEmployee(current.Left, salary);
                return;
            }

            if (salary > current.Salary && current.Right != null)
            {
                FindEmployee(current.Right, salary);
                return;
            }
            Console.WriteLine("Сотрудник не найден");
        }
    }

    static void Main(string[] args)
    {
        var tree = new BinaryTree();
        while (true)
        {
            while (true)
            {
                Console.Write("Введите имя сотрудника (или оставьте поле пустым, чтобы продолжить): ");
                var name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    break;
                }

                Console.Write("Введите зарплату сотрудника: ");
                var salary = int.Parse(Console.ReadLine());

                tree.AddEmployee(name, salary);
            }

            Console.WriteLine();
            Console.WriteLine("Имена сотрудников и зарплаты в порядке возрастания зарплаты:");
            tree.PrintInOrder();
            while (true)
            {
                Console.WriteLine("Введите интересующую вас зарплату: ");
                tree.FindEmployee(int.Parse(Console.ReadLine()));
                Console.WriteLine("Введите 0, чтобы начать сначала, или 1 для поиска другой зарплаты:");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    continue;
                }
                else
                {
                    throw new Exception("Неверная команда");
                }
            }
        }
    }
}