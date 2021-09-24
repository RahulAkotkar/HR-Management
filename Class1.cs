using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HRfuctions
{
    public class Class1
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;

        public static void createconnection()
        {

            con = new SqlConnection();
            con.ConnectionString = "Data Source=RAHUL;Initial Catalog=HRmangment; Integrated Security =true";
            con.Open();
            //Console.WriteLine("database connection successfull");
            Console.ReadKey();
            con.Close();

        }
        public static void PrintemployeeData()
        {

            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select * from employee", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable tab = ds.Tables[0];
            Console.WriteLine("eid\tename\tsalary\tdesignation\tdept_no\t\tcontact_no\temail");
            foreach (DataRow row in tab.Rows)
            {
                Console.WriteLine("\n"+row[0] + "\t" + row[1] + "\t" + row[2] + "\t" + row[3] + "\t\t" + row[4] + "\t\t" + row[5] + "\t" + row[6]);

            }
            con.Close();

           // Console.Read();

        }

        public static void Insertemployee(int eid,string ename,int salary,string designation,int deptno,int contact_no,string email)
        {
            int no = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("eid", eid);
                cmd.Parameters.AddWithValue("ename",ename);
                cmd.Parameters.AddWithValue("salary", salary);
                cmd.Parameters.AddWithValue("designation",designation);
                cmd.Parameters.AddWithValue("deptno", deptno);
                cmd.Parameters.AddWithValue("contact_no",contact_no);
                cmd.Parameters.AddWithValue("email",email);

                no = cmd.ExecuteNonQuery();
                Console.WriteLine("Employee data inserted sucessfully");
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            // return no;
 
        }

        public static void Getempusingeid(int eid)
        {
            SqlDataReader reader1 = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Getempusing_eid", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("eid", eid);
                cmd.Parameters.Add(param);

                reader1 = cmd.ExecuteReader();

                while (reader1.Read())
                {
                    Console.WriteLine(reader1[0] + "\t" + reader1[1] + "\t" + reader1[2] + "\t" + reader1[3] + "\t" + reader1[4] + "\t" + reader1[5] + "\t" + reader1[6]);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static void GetDepartmentUsingDno(int deptno)
        {
            SqlDataReader reader = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Get_Dept_Using_Deptno", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("dno", deptno);
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] );
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            //return reader;
        }


        public static void InsertDepartment1(string HOD, string loction, int deptno1)
        {
            int no = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert_Department1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("eid", eid1);
                cmd.Parameters.AddWithValue("HOD", HOD);
                cmd.Parameters.AddWithValue("loction", loction);
                cmd.Parameters.AddWithValue("deptno", deptno1);

                no = cmd.ExecuteNonQuery();
                Console.WriteLine("Department data inserted sucessfully");
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            // return no;

        }

        public static void UpdateDepartment(string HOD,string loction,int deptno)
        {
            int no = 0;
            try
            {
                
                con.Open();

                SqlCommand cmd = new SqlCommand("Update_Department", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("eid",eid);
                cmd.Parameters.AddWithValue("HOD",HOD);
               cmd.Parameters.AddWithValue("loction", loction);
                cmd.Parameters.AddWithValue("deptno",deptno);

                no = cmd.ExecuteNonQuery();

               
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            //return no;
        }

         public static int DeleteDepartment(int eid)
        {
            int no = 0;
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete_Department", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("eid",eid);
                no = cmd.ExecuteNonQuery();
                Console.WriteLine("\n Employee deleted succsefully");
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return no;
        }
    }

    }



