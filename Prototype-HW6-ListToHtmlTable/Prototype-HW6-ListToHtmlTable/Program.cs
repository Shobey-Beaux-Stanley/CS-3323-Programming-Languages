using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Prototype_HW6_ListToHtmlTable {
	/// <summary>
	/// This program is a prototype for a Python program in my 
	/// Principles of Programming Languages class. Since I am
	/// unfamiliar with Python, I decided to use C# to at least
	/// figure the logic for the program out, so that all I have
	/// to do is mess around with the Python language.
	/// </summary>
	class Program {
		static void Main (string[] args) {
			int i = 0;
			decimal n = 0;
			List<Student> studentList = new List<Student>();
			StringBuilder inputBuilder = new StringBuilder();
			inputBuilder.Append(File.ReadAllText(@"input.txt"));
			inputBuilder = inputBuilder.Replace(Environment.NewLine, "/");//Used forward slash to make removing lines easier

			//This loop is to ensure that all forward slash characters are removed and replaced with one space
			for (int j = 0; j < inputBuilder.Length; j++) {
				if (inputBuilder[j] == '/') {
					if (inputBuilder[j + 1] == '/') {
						while (inputBuilder[j + 1] == '/')
							inputBuilder.Remove(j + 1, 1);
						inputBuilder.Remove(j, 1);
					}
					else {
						inputBuilder.Remove(j, 1);
					}
					inputBuilder.Insert(j, ' ');
				}
			}
			//This loop will check for duplicate spaces and make sure there is only one between each element
			for (int j = 0; j < inputBuilder.Length; j++) {
				if (inputBuilder[j] == ' ') {
					if (inputBuilder[j + 1] == ' ') {
						while (inputBuilder[j + 1] == ' ')
							inputBuilder.Remove(j + 1, 1);
					}
				}
			}
			//Variables to make object in loop
			string[] elements = inputBuilder.ToString().Split(' ');
			string studentID = " ";
			string firstName = " ";
			string lastName = " ";
			int score = 0;
			string letter = " ";

			//Loop through elements and create Student objects
			while (i < elements.Length) {
				
				//This checks for the optional city/state fields and skips the loop past them
				while (decimal.TryParse(elements[i], out n) == false){
					i += 1;
				}

				studentID = elements[i].Trim();
				firstName = elements[i + 1].Trim();
				lastName = elements[i + 2].Trim();
				score = Convert.ToInt32(elements[i + 3].Trim());
				letter = elements[i + 4];
				Student student = new Student(studentID, firstName, lastName, score, letter);
				studentList.Add(student);
				i += 5;
				if (elements.Length - i < 4) {//Checks to see if there are no more elements. In other words, at the end of the txt file read in.
					break;
				}
			}
			for (int j = 0; j < studentList.Count; j++) {
				Console.WriteLine(studentList[j]);
			}
			//This block makes the html file and writes to it
			File.Create("output.html");
			StreamWriter writer = new StreamWriter("../../output.html");
			writer.WriteLine("<!DOCTYPE html>");
			writer.WriteLine("<html>");
			writer.WriteLine("<body>");
			writer.WriteLine("<table border=\"1\">");
			for (int j = 0; j < studentList.Count; j++) {
				writer.WriteLine("<tr>");
				writer.Write("<td>");
				writer.Write(studentList[j].StudentID);
				writer.WriteLine("</td>");
				writer.WriteLine("<td>" + studentList[j].FirstName + "</td>");
				writer.WriteLine("<td>" + studentList[j].LastName + "</td>");
				writer.WriteLine("</tr>");
			}
			writer.WriteLine("</table>");
			writer.WriteLine("</body>");
			writer.WriteLine("</html>");
			writer.Close();
			
		}
	}
}
