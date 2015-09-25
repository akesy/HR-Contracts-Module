using System.Collections.Generic;
using System.Linq;
using HR.Contracts.Domain.Entities;
using HR.Contracts.Services.Filters.Contracts;
using HR.Contracts.Shared.Enums;
using HR.Contracts.Shared.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HR.Contracts.UnitTests
{
    [TestClass]
    public class ContractFilterTest
    {
        [TestMethod]
        public void GivenContractsListWhenFilteringByNameThenContractsWithNameContainingFilterCriteriaAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 2, Salary = 3000 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractName, Value = "C1" }
            };
            var contractFilter = new ContractFilter();

            var expected = "C1";
            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.Single().Name, true);
        }

        [TestMethod]
        public void GivenContractsListWhenFilteringByDevelopersThenDeveloperContractsAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 2, Salary = 3000 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractType, Value = ContractType.Developer }
            };
            var contractFilter = new ContractFilter();

            var expected1 = "C1";
            var expected2 = "C2";
            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(expected1, actual.ElementAt(0).Name, true);
            Assert.AreEqual(expected2, actual.ElementAt(1).Name, true);
        }

        [TestMethod]
        public void GivenContractsListWhenFilteringByExperienceThenContractsWithExperienceEqualToFilterCriteriaAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 3, Salary = 3000 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractExperience, Value = 3 }
            };
            var contractFilter = new ContractFilter();

            var expected1 = "C1";
            var expected2 = "C3";
            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(expected1, actual.ElementAt(0).Name, true);
            Assert.AreEqual(expected2, actual.ElementAt(1).Name, true);
        }

        [TestMethod]
        public void GivenContractsListWhenFilterBySalaryThenContractsWithSalaryEqualToFilterCriteriaAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Developer, Experience = 3, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 5, Salary = 5000 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractSalaryEqualTo, Value = 5000m }
            };
            var contractFilter = new ContractFilter();

            var expected1 = "C1";
            var expected2 = "C3";
            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(expected1, actual.ElementAt(0).Name, true);
            Assert.AreEqual(expected2, actual.ElementAt(1).Name, true);
        }

        [TestMethod]
        public void GivenContractsListWhenFilterByTestersAndNameThenTestersContractsWithNameContainingFilterCriteriaAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Tester, Experience = 4, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 5, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 2, Salary = 3000 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractName, Value = "C1" },
                new ColumnFilterInfo { Type = ColumnFilterType.ContractType, Value = ContractType.Tester }
            };
            var contractFilter = new ContractFilter();

            var expected = "C1";
            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.Single().Name, true);
        }

        [TestMethod]
        public void GivenContractsListWhenFilterByTestersAndExperienceThenTestersContractsWithExperienceEqualToFilterCriteriaAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Tester, Experience = 4, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 4, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 5, Salary = 5500 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractType, Value = ContractType.Tester },
                new ColumnFilterInfo { Type = ColumnFilterType.ContractExperience, Value = 4 }
            };
            var contractFilter = new ContractFilter();

            var expected = "C1";
            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.Single().Name, true);
        }

        [TestMethod]
        public void GivenContractsListWhenFilterByExperienceAndSalaryThenContractsWithExperienceAndSalaryEqualToFilterCriteriaAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Tester, Experience = 4, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 4, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 4, Salary = 5500 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractExperience, Value = 4 },
                new ColumnFilterInfo { Type = ColumnFilterType.ContractSalaryEqualTo, Value = 5000m }
            };
            var contractFilter = new ContractFilter();

            var expected = "C1";
            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.Single().Name, true);
        }

        [TestMethod]
        public void GivenListOfContractsWhenFilteringByNullNameThenAllItemsAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Tester, Experience = 4, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 4, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 4, Salary = 5500 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractName }
            };
            var contractFilter = new ContractFilter();

            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(3, actual.Count());
            Assert.AreEqual("C1", actual.ElementAt(0).Name, true);
            Assert.AreEqual("C2", actual.ElementAt(1).Name, true);
            Assert.AreEqual("C3", actual.ElementAt(2).Name, true);
        }

        [TestMethod]
        public void GivenListOfContractsWhenFilteringByEmptyNameThenAllItemsAreReturned()
        {
            var contracts = new List<Contract>
            {
                new Contract { Name = "C1", Type = ContractType.Tester, Experience = 4, Salary = 5000 },
                new Contract { Name = "C2", Type = ContractType.Developer, Experience = 4, Salary = 8000 },
                new Contract { Name = "C3", Type = ContractType.Tester, Experience = 4, Salary = 5500 }
            }.AsQueryable();
            var filterCriteria = new List<ColumnFilterInfo>
            {
                new ColumnFilterInfo { Type = ColumnFilterType.ContractName, Value = string.Empty }
            };
            var contractFilter = new ContractFilter();

            var actual = contractFilter.Filter(contracts, filterCriteria);

            Assert.AreEqual(3, actual.Count());
            Assert.AreEqual("C1", actual.ElementAt(0).Name, true);
            Assert.AreEqual("C2", actual.ElementAt(1).Name, true);
            Assert.AreEqual("C3", actual.ElementAt(2).Name, true);
        }
    }
}