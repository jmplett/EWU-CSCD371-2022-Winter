using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
	[TestClass]
	public class SampleDataTests
	{
		[TestMethod]
		public void CSVRows_GetsAllTheRows_AllTheRowsMatch()
		{
			SampleData testData = new ();

			Assert.AreEqual("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", testData.CsvRows.First());
			Assert.AreEqual("50,Claudell,Leathe,cleathe1d@columbia.edu,30262 Steensland Way,Newport News,VA,87930", testData.CsvRows.Last());
			Assert.AreEqual(50, Enumerable.Count(testData.CsvRows));
		}
	}
}

