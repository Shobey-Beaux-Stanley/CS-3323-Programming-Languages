using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_HW7_Yield {
	/// <summary>
	/// This program is a prototype for my Principles of Programming language
	/// class's homework 7 assignment. Interesting numbers are considered
	/// to be a prime number added to a power of three. This program
	/// computes interesting numbers and the logic of this program
	/// will be implemented in Python later on to submit for grading.
	/// </summary>
	class Program {
		static void Main (string[] args) {
			int count = 0;
			foreach (double i in IsInterestingAfterNumber(0, 104)) {
				//if (count >= 10) {
					//break;
				//}
				Console.WriteLine(i + " is interesting.");
				count++;
			}
		}

		/// <summary>
		/// This function yields powers of 3^n
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static System.Collections.Generic.IEnumerable<double> PowersOfThree(double n) {
			for (double i = 1; i <= n; i++) {
				yield return Math.Pow(3, i);
			}
		}
		
		/// <summary>
		/// This function finds all interesting numbers up to and including
		/// the number given to it.
		/// </summary>
		/// <param name="number"></param>
		public static void IsInterestingToANumber(double number) {
			foreach (double i in PowersOfThree(number)) {
				if (i >= number) {
					break;
				}
				if (IsPrime(number - i)) {
					Console.WriteLine(number + " is interesting. ");
					break;
				}
			}
		}
		
		/// <summary>
		/// This function finds all interesting numbers after a number and
		/// to another number
		/// </summary>
		/// <param name="number"></param>
		/// <param name="lastValue"></param>
		/// <returns></returns>
		public static System.Collections.Generic.IEnumerable<double> IsInterestingAfterNumber(double number, double lastValue) {
			for (double j = number; j <= lastValue; j++) {
				foreach (double i in PowersOfThree(j)) {
					if (i >= j) {
						break;
					}
					if (IsPrime(j - i)) {
						yield return j;
						break;
					}
				}
			}
		}
		/// <summary>
		/// This will return true if the number passed to it is prime,
		/// else it will return false.
		/// </summary>
		/// <param name="number"></param>
		public static bool IsPrime(double number) {
			for (int i = 2; i < Math.Sqrt((number)); i++) {
				if (number % i == 0) {
					return false;
				}
			}
			return true;
		}
	}
}
