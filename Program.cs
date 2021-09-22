using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using HRfuctions;

namespace HRMANAGEMENT
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string user_name;
            int password;

            Console.WriteLine("------------WELCOME TO HR MANAGMENET SYSTEM-----------");
            while (true)
            {
                Console.WriteLine("\nEnter The User_Name  :");
                user_name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("\nEnter The Password :");
                password = Convert.ToInt32(Console.ReadLine());

                if (user_name == "abc" && password == 123)
                {
                    Console.WriteLine("Your are logged successfully");
                    break;
                }
                else
                {
                    Console.WriteLine("Invaid crendentials");
                    continue;

                }
            }
                
            int choice;
            char ch;
            Class1.createconnection();
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Print All Departments");
                Console.WriteLine("2.Print Department based on deptno");
                Console.WriteLine("3.Insert Departments");
                Console.WriteLine("4.Update Departments");
                Console.WriteLine("5.Delete Departments");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());

               switch (choice)
                {
                    case 1:

                        Class1.PrintemployeeData();
                        break;

                    case 2:
                        Console.WriteLine("Enter department no to view details");
                        int Deptno = Convert.ToInt32(Console.ReadLine());
                        Class1.GetDepartmentUsingDno(Deptno);
                        break;
                    
                    case 3:

                        Console.WriteLine("Enter Department Details to Enter Deptno,dname,location,department head");
                        int eid = Convert.ToInt32(Console.ReadLine());
                        string HOD = Console.ReadLine();
                        string location = Console.ReadLine();
                        int deptno =Convert.ToInt32(Console.ReadLine());
                        Class1.InsertDepartment(eid,HOD,loction,deptno);                                               
                        break;
/*
                    case 4:
                        Department d3 = new Department();
                        Console.WriteLine("Enter Department Details to Update Deptno,dname,location,department head");
                        d3.Deptno = Convert.ToInt32(Console.ReadLine());
                        d3.Dname = Console.ReadLine();
                        d3.location = Console.ReadLine();
                        d3.dhead = Console.ReadLine();
                        d3.UpdateDepartment();
                        break;

                    case 5:
                        Department d4 = new Department();
                        Console.WriteLine("Enter Department no to delete");
                        d4.Deptno = Convert.ToInt32(Console.ReadLine());
                        d4.DeleteDepartment();
                        break;
                       */

                    default:
                        Console.WriteLine("Invalid Case");
                        break;
                }

                Console.WriteLine("Enter y r Y to continue");
                ch = Convert.ToChar(Console.ReadLine());

            }
            while (ch == 'Y' || ch == 'y');
            Console.ReadLine();
            Console.Read();

        }
    }
}
