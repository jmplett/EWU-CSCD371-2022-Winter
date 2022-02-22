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

		[TestMethod]
		public void SortsRowsByState_CountsNumberOfUniqueStates_SuccessWhen27States()
        {
			SampleData testData = new();
			Assert.AreEqual(27,Enumerable.Count(testData.GetUniqueSortedListOfStatesGivenCsvRows()));
        }

		[TestMethod]
		public void SortsRowsByState_ChecksIfStatesAreUnique_SuccessDistinctIsTrue()
        {
			SampleData testData = new();
			Assert.IsTrue(testData.CsvRows.SequenceEqual(testData.CsvRows.Distinct()));
        }

		[TestMethod]
		public void SortRowsByState_ChecksIfStatesInOrder_SuccessWhenInOrder()
        {
			SampleData testData = new();
			testData.GetUniqueSortedListOfStatesGivenCsvRows();
			Assert.IsTrue(testData.CsvRows.SequenceEqual(testData.CsvRows.OrderBy(item=>item)));
        }

        [TestMethod]
        public void People_GetsAllRows_AllRowsMatch()
        {
			SampleData testData = new();
			Assert.AreEqual("Priscilla,Jenyns", $"{testData.People.First().FirstName},{testData.People.First().LastName}");
			Assert.AreEqual("Claudell,Leathe", $"{testData.People.Last().FirstName},{testData.People.Last().LastName}");
			Assert.AreEqual(50, Enumerable.Count(testData.People));
		}

        [TestMethod]
        public void FilterByEmailAddress_ReturnsMatchingFirstLastNames()
        {
			SampleData testData = new();

			Predicate<string> filter = email => email == "pjenyns0@state.gov";
			Assert.AreEqual<(string, string)>(("Priscilla","Jenyns"),testData.FilterByEmailAddress(filter).First());
			Assert.AreEqual<int>(1, testData.FilterByEmailAddress(filter).Count());

			filter = email => email.Contains(".edu");
			Assert.AreEqual<(string, string)>(("Fremont","Pallaske"), testData.FilterByEmailAddress(filter).First());
			Assert.AreEqual<(string, string)>(("Claudell", "Leathe"), testData.FilterByEmailAddress(filter).Last());
			Assert.AreEqual<int>(5, testData.FilterByEmailAddress(filter).Count());
		}
	}
}

