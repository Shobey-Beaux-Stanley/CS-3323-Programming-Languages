using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_HW6_ListToHtmlTable {
	class Student {
		private string studentID;
		private string firstName;
		private string lastName;
		private int score;
		private string letter;

		/// <summary>
		/// Default constructor with no parameters.
		/// </summary>
		public Student () {
		}

		public Student (string studentID, string firstName, string lastName,
			int score, string letter) {
			this.studentID = studentID;
			this.firstName = firstName;
			this.lastName = lastName;
			this.score = score;
			this.letter = letter;
		}

		public string StudentID { get { return studentID; } set { studentID = value; } }
		public string FirstName { get { return firstName; } set { firstName = value; } }
		public string LastName { get { return lastName; } set { lastName = value; } }
		public int Score { get { return score; } set { score = value; } }
		public string Letter { get { return letter; } set { letter = value; } }

		public override string ToString () {
			return studentID + " " + firstName + " " + lastName +
				" " + score.ToString() + " " + letter;
		}
	}
}
