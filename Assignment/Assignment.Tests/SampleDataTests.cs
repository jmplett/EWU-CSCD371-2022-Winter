using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment.Tests
{
	[TestClass]
	public class SampleDataTests
	{
		[TestMethod]
		public void CSVRows_GetsAllTheRows_TheRowsMatch()
		{
			SampleData testData = new ();

			Assert.AreEqual("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", testData.CsvRows.First());
			Assert.AreEqual("15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021", testData.CsvRows.ElementAt(14));
			Assert.AreEqual("25,Jedd,Boissier,jboissiero@cbsnews.com,1 Arrowood Crossing,San Diego,CA,96101", testData.CsvRows.ElementAt(24));
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
		public void SortRowsByState_HardCodedSpokaneAddresses_SuccessWhenOnly1RecordReturned()
		{
			SampleData testData = new();

            List<string> addresses = new();
			addresses.Add("8,Joly,Scneider,jscneider7@pagesperso-orange.fr,53 Grim Point,Spokane,WA,99022");
			addresses.Add("15,Phillida,Chastagnier,pchastagniere@reference.com,1 Rutledge Point,Spokane,WA,99021");
			addresses.Add("19,Fayette,Dougherty,fdoughertyi@stanford.edu,6487 Pepper Wood Court,Spokane,WA,99021");

			IEnumerable <string> spokaneAddresses = addresses.Select(item => item.Split(',')[6]).Distinct();
			IEnumerable<string> testDataAddresses = testData.GetUniqueSortedListOfStatesGivenCsvRows();

			Assert.AreEqual(spokaneAddresses.Count(), testDataAddresses.Select(item => "WA").Distinct().Count());

		}

		[TestMethod]
		public void SortRowsByState_ChecksIfStatesInOrder_SuccessWhenInOrder()
        {
			SampleData testData = new();
			Assert.AreEqual(testData.GetUniqueSortedListOfStatesGivenCsvRows().First(), (testData.GetUniqueSortedListOfStatesGivenCsvRows().OrderBy(item=>item).First()));
			Assert.AreEqual(testData.GetUniqueSortedListOfStatesGivenCsvRows().Last(), (testData.GetUniqueSortedListOfStatesGivenCsvRows().OrderBy(item => item).Last()));
			Assert.IsTrue(testData.GetUniqueSortedListOfStatesGivenCsvRows().SequenceEqual(testData.GetUniqueSortedListOfStatesGivenCsvRows().OrderBy(item => item)));

		}

        [TestMethod]
        public void People_ContainsAllFields()
        {
			SampleData testData = new();
			var person = testData.People.First();
			string test = 
				person.FirstName + "," + 
				person.LastName + "," + 
				person.EmailAddress + "," + 
				person.Address.StreetAddress + "," + 
				person.Address.City + "," + 
				person.Address.State + "," + 
				person.Address.Zip;
			Assert.AreEqual("Arthur,Myles,amyles1c@miibeian.gov.cn,4718 Thackeray Pass,Mobile,AL,37308", test);
        }

        [TestMethod]
        public void People_GetsAllRows_MatchSortedFirstLast()
        {
			SampleData testData = new();
			Assert.AreEqual("Arthur,Myles", $"{testData.People.First().FirstName},{testData.People.First().LastName}");
			Assert.AreEqual("Amelia,Toal", $"{testData.People.Last().FirstName},{testData.People.Last().LastName}");
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
			Assert.AreEqual<(string, string)>(("Fayette", "Dougherty"), testData.FilterByEmailAddress(filter).Last());
			Assert.AreEqual<int>(5, testData.FilterByEmailAddress(filter).Count());
		}

        [TestMethod]
        public void GivenPeople_GetAggregateListOfStates_CheckIfUniqueStatesMatch()
        {
			SampleData testData = new();
            
			IEnumerable<IPerson>? pPeople = testData.People.Where(person => person.FirstName.StartsWith('P')).Select(person => person);
			Assert.AreEqual(2, pPeople.Count());

			string? states = testData.GetAggregateListOfStatesGivenPeopleCollection(pPeople);
			Assert.AreEqual<string>("MT,WA", states);

			states = testData.GetAggregateListOfStatesGivenPeopleCollection(testData.People);
			Assert.AreEqual<string>("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", states);
		}

        [TestMethod]
        public void GivenUniqueStatesFromPeopleAndCsvRows_SuccessWhenMatching()
        {
			SampleData testData = new();
			Assert.AreEqual(
				testData.GetAggregateSortedListOfStatesUsingCsvRows(),
				testData.GetAggregateListOfStatesGivenPeopleCollection(testData.People));
        }
	}
}

