using Capgemini.EMS.BussinessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;

namespace Capgemini.EMP.PL
{
    class Program
    {


        static void Main(string[] args)
        {

            while (true)
            {


                Console.WriteLine("1 Add employee, 2 Employee List, 3 Update Employee, 4 Delete Employee , 5 Exit");

                Console.WriteLine("Enter you choice");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        Employeelist();
                        break;
                    case 3:
                        UpdateEmploye();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("invlid input");
                        break;



                }

            }
        }

        private static void DeleteEmployee()
        {
            string input;
            int empId;

            do
            {
                Console.WriteLine("enter employee id");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));
            //emp id-check
            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee not found");
                return;
            }
            var isDelete = EmployeeBL.Delete(empId);
            if (isDelete)
            {
                Console.WriteLine("Delete successfull");
            }
            else
            {
                Console.WriteLine("delete unsuccessfull");
            }
        }
    
            private static void UpdateEmploye()
            {
                //emp id
                string input;
                int empId;

                do
                {
                    Console.WriteLine("enter employee id");
                    input = Console.ReadLine();

                } while (!int.TryParse(input, out empId));
                //emp id-check
                var existingEmployee = EmployeeBL.GetById(empId);
                if (existingEmployee == null)
                {
                    Console.WriteLine("Employee not found");

                }
                //name/doj
                Employee newEmp = new Employee();
                newEmp.Id = empId;
                do
                {
                    Console.WriteLine("Enter employee name");
                    input = Console.ReadLine();
                } while (string.IsNullOrEmpty(input));
                newEmp.Name = input;

                DateTime dateOfJoining;
                do
                {
                    Console.WriteLine("Enter date of joining");
                    input = Console.ReadLine();
                } while (!DateTime.TryParse(input, out dateOfJoining));
                newEmp.DateOfJoining = dateOfJoining;
                var isUpdated = EmployeeBL.Update(existingEmployee);
                if (isUpdated)
                {
                    Console.WriteLine("employee updated successfully");
                }
                else
                {
                    Console.WriteLine("Employee update failed");
                }

            }

            private static void Employeelist()
            {
                var list = EmployeeBL.GetList();
                Console.WriteLine("employee list");
                foreach (var emp in list)
                {
                    Console.WriteLine(emp);
                }
            }

            private static void AddEmployee()
            {
                Employee newEmployee = new Employee();


                string input;
                int empId;
                DateTime dateOfJoining;
                do
                {
                    Console.WriteLine("enter employee id");
                    input = Console.ReadLine();

                } while (!int.TryParse(input, out empId));
                newEmployee.Id = empId;

                do
                {
                    Console.WriteLine("Enter employee name");
                    input = Console.ReadLine();
                } while (string.IsNullOrEmpty(input));
                newEmployee.Name = input;

                do
                {
                    Console.WriteLine("Enter date of joining");
                    input = Console.ReadLine();
                } while (!DateTime.TryParse(input, out dateOfJoining));
                newEmployee.DateOfJoining = dateOfJoining;


                //call BL
                try
                {
                    bool isAdded = EmployeeBL.Add(newEmployee);
                    if (isAdded)
                    {
                        Console.WriteLine("Employee added successfully");
                    }
                    else
                    {
                        Console.WriteLine("Employee add failed");
                    }

                }
                catch (EmsException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }
    }

