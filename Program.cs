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
           // Console.ForegroundColor = ConsoleColor.White;
           // Console.BackgroundColor = ConsoleColor.Red;
            //ConsoleColor foreground = Console.ForegroundColor; 
            Console.WriteLine("\n------------WELCOME TO HR MANAGMENET SYSTEM-----------");
            while (true)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=RAHUL;Initial Catalog=HRmangment; Integrated Security =true";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LoginPro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                Console.WriteLine("\nEnter The User_Name  :");
                user_name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("\nEnter The Password :");
                ConsoleKeyInfo key; string pass = "";
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                } while (key.Key != ConsoleKey.Enter);
                cmd.Parameters.AddWithValue("user_name", user_name);
                cmd.Parameters.AddWithValue("password", pass.TrimEnd());
                SqlDataReader reader = cmd.ExecuteReader();
                //password = Convert.ToInt32(Console.ReadLine());

                if (reader.HasRows)
                {
                    Console.WriteLine("\nYour are logged successfully");
                    //break;
                    int choice;
                    char ch;
                    Class1.createconnection();
                    do
                    {
                        Console.WriteLine("\n------TASK _YOU_WANT_PERFORM------");
                        Console.WriteLine("\n1.Print All Employee");
                        Console.WriteLine("\n2.Insert Employee");
                        Console.WriteLine("\n3.Serach Employee Based On EID");
                        Console.WriteLine("\n4.Print Department based on deptno");
                        Console.WriteLine("\n5.Insert Departments");
                        Console.WriteLine("\n6.Update Departments");
                        Console.WriteLine("\n7.Delete Employee ");
                        Console.WriteLine("\nEnter your choice");
                        choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:

                                Class1.PrintemployeeData();
                                break;

                            case 2:
                                Console.WriteLine("Enter employee details");
                                int eid = Convert.ToInt32(Console.ReadLine());
                                string ename = Console.ReadLine();
                                int salary = Convert.ToInt32(Console.ReadLine());
                                string designation = Console.ReadLine();
                                int deptno = Convert.ToInt32(Console.ReadLine());
                                int contact_no = Convert.ToInt32(Console.ReadLine());
                                string email = Console.ReadLine();
                                
                                Class1.Insertemployee(eid, ename, salary, designation, deptno, contact_no, email);
                                break;

                            case 3:
                                Console.WriteLine("Enter the EID which data you want serach");
                                int eid2 = Convert.ToInt32(Console.ReadLine());
                                Class1.Getempusingeid(eid2);
                                
                                break;
                            case 4:
                                Console.WriteLine("Enter department no to view details");
                                int Deptno = Convert.ToInt32(Console.ReadLine());
                                Class1.GetDepartmentUsingDno(Deptno);
                                break;

                            case 5:

                                Console.WriteLine("Enter Department Details HOD,location,deptno");
                                //int eid1 = Convert.ToInt32(Console.ReadLine());
                                string HOD = Console.ReadLine();
                                string loction = Console.ReadLine();
                                int deptno1 = Convert.ToInt32(Console.ReadLine());
                                if (loction == "Mumbai" || loction == "Pune")
                                {
                                    Class1.InsertDepartment1(HOD, loction, deptno1);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid location ");
                                }
                                break;
                            case 6:

                                Console.WriteLine("Enter the deptno which record you want update");
                               // eid = Convert.ToInt32(Console.ReadLine());
                                deptno = Convert.ToInt32(Console.ReadLine());
                                HOD = Console.ReadLine();
                                loction = Console.ReadLine();
                                deptno = Convert.ToInt32(Console.ReadLine());
                                Class1.UpdateDepartment(HOD, loction, deptno);
                                break;


                            case 7:

                                Console.WriteLine("Enter EID which record you want to delete");
                                deptno = Convert.ToInt32(Console.ReadLine());
                                Class1.DeleteDepartment(deptno);
                                break;


                            default:
                                Console.WriteLine("Invalid Case");
                                break;
                        }

                        Console.WriteLine("\n\nEnter y r Y to continue");
                        ch = Convert.ToChar(Console.ReadLine());

                    }
                    while (ch == 'Y' || ch == 'y');
                    Console.ReadLine();
                    Console.Read();

                }


                else
                {
                    Console.WriteLine("\nInvaid crendentials");
                    continue;

                }
            }
                                    
        }
    }
}
