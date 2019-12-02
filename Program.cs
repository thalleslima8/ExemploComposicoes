using ExemploComposição.Entities.Enums;
using System;
using ExemploComposição.Entities;

namespace ExemploComposição {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Digite o seu departamento: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.WriteLine("Nome: ");
            string name = Console.ReadLine();
            Console.WriteLine("Level (Junior, MidLevel ou Senior: ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine("Salario Base: ");
            double salario = double.Parse(Console.ReadLine());

            Departament dept = new Departament(deptName);
            Worker worker = new Worker(name, salario, level, dept);

            Console.WriteLine("Quantos Contratos serão cadastrados: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++) {
                Console.WriteLine($"Entre com a data do contrato #{i}: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.WriteLine("Duração (horas): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
                Console.WriteLine("-----------------------------------------------------------");
            }

            Console.WriteLine("Entre com o mes e com o ano para calcular o ganho (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse( monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("\nNome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Departament.Name);
            Console.WriteLine("Ganhos em " + monthAndYear + ": $" + worker.Income(year, month));
        }
    }}
