using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataLayer;
using AppValidator;

namespace StudentViolationManagementSystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string adminSelection = AdminMenu();

            switch (adminSelection)
            {
                case "1":
                    Console.WriteLine("Warning: Creating a new file will delete the current existing file!");
                    Console.WriteLine();
                    List<string> dataInput = GetData();
                    StudentViolationManagementSystemTextFileStream.CreateUpdateFile(true, dataInput);
                    break;
                case "2":
                    Console.WriteLine("Updating the current existing file...");
                    Console.WriteLine();
                    List<string> dataUpdate = GetData();
                    StudentViolationManagementSystemTextFileStream.CreateUpdateFile(false, dataUpdate);
                    break;
                case "3":
                    Console.WriteLine("Reading contents of the current existing file..");
                    Console.WriteLine();
                    DisplayData();
                    break;
                default:
                    break;
            }
        }

        private static string AdminMenu()
        {
            Console.WriteLine("STUDENTS' VIOLATION Data - Select from MENU:");
            Console.WriteLine();
            Console.WriteLine("Input '1' to create a new file and input contents.");
            Console.WriteLine("Input '2' to update or add data to the file.");
            Console.WriteLine("Input '3' to read the file.");
            Console.WriteLine("Input '4' to delete the file.");

            Console.WriteLine();
            Console.Write("ADMIN INPUT: ");
            string adminMenuSelection = Console.ReadLine();
            Console.WriteLine();

            return adminMenuSelection;
        }

        private static List<string> GetData()
        {
            List<string> dataList = new List<string>();

            string studNo, studName, studVio, vioType;
            int studPoints;
            do
            {
                Console.Write("Input Student Number: ");
                studNo = Console.ReadLine();

                if (DataValidator.ValidateStudentNumber(studNo))
                {
                    dataList.Add(studNo);
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
                Console.WriteLine();
                Console.WriteLine("Name format : Surname, Given name MI");
                Console.WriteLine();
                Console.Write("Input Student Name: ");
                studName = Console.ReadLine();
                dataList.Add(studName);

                Console.Write("Input Student Violation: ");
                studVio = Console.ReadLine();
                dataList.Add(studVio);

                Console.WriteLine();
                Console.WriteLine("Violation type list: ");
                Console.WriteLine("Minor Violation");
                Console.WriteLine("Major Violation");
                Console.WriteLine("Grave Violation");
                Console.WriteLine();

                Console.Write("Input Violation Type: ");
                vioType = Console.ReadLine();

                studPoints = ViolationPoints.GetPoints(vioType);

                dataList.Add(studPoints.ToString());

                if (DataValidator.ValidateViolationType(vioType))
                {
                    dataList.Add(vioType);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                    Console.WriteLine();
                }

            }
            while (studNo.Length != 0 && vioType.Length != 0);

            Console.WriteLine("Exit Input Mode. Closing application.");

            return dataList;
        }
        

        private static void DisplayData()
        {
            List<string> dataContent = StudentViolationManagementSystemTextFileStream.ReadFile();

            foreach (var data in dataContent)
            {
                Console.WriteLine($"DATA: { data.ToUpper()}");
            }
        }
    }
}
