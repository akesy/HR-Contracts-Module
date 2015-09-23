using System;
using HR.Contracts.Domain.Abstract;
using HR.Contracts.Domain.Concrete;
using HR.Contracts.Shared.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HR.Contracts.UnitTests
{
    [TestClass]
    public class SalaryCalculationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenNoExperienceWhenCalculatingMinimumWageThenExceptionIsThrown()
        {
            var contractType = ContractType.Developer;
            var experience = 0;
            ISalaryPolicy policy = new DefaultSalaryPolicy();

            policy.GetMinimumWage(contractType, experience);
        }


        [TestMethod]
        public void GivenDeveloperContractAndFirstExperienceThresholdWhenCalculatingMinimumWageThenFirstThresholdIsReturned()
        {
            var contractType = ContractType.Developer;
            var experience = 2;
            ISalaryPolicy policy = new DefaultSalaryPolicy();

            var expected = 2500;
            var actual = policy.GetMinimumWage(contractType, experience);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenDeveloperContractAndSecondExperienceThresholdWhenCalculatingMinimumWageThenSecondThresholdIsReturned()
        {
            var contractType = ContractType.Developer;
            var experience = 3;
            ISalaryPolicy policy = new DefaultSalaryPolicy();

            var expected = 5000;
            var actual = policy.GetMinimumWage(contractType, experience);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenDeveloperContractAndThirdExperienceThresholdWhenCalculatingMinimumWageThenThirdThresholdIsReturned()
        {
            var contractType = ContractType.Developer;
            var experience = 6;
            ISalaryPolicy policy = new DefaultSalaryPolicy();

            var expected = 5500;
            var actual = policy.GetMinimumWage(contractType, experience);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTesterContractAndFirstExperienceThresholdWhenCalculatingMinimumWageThenFirstThresholdIsReturned()
        {
            var contractType = ContractType.Tester;
            var experience = 1;
            ISalaryPolicy policy = new DefaultSalaryPolicy();

            var expected = 2000;
            var actual = policy.GetMinimumWage(contractType, experience);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTesterContractAndSecondExperienceThresholdWhenCalculatingMinimumWageThenSecondThresholdIsReturned()
        {
            var contractType = ContractType.Tester;
            var experience = 2;
            ISalaryPolicy policy = new DefaultSalaryPolicy();

            var expected = 2700;
            var actual = policy.GetMinimumWage(contractType, experience);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTesterContractAndThirdExperienceThresholdWhenCalculatingMinimumWageThenThirdThresholdIsReturned()
        {
            var contractType = ContractType.Tester;
            var experience = 5;
            ISalaryPolicy policy = new DefaultSalaryPolicy();

            var expected = 3200;
            var actual = policy.GetMinimumWage(contractType, experience);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenDeveloperContractWhenCalculatingSalaryThenCalculationIsCorrect()
        {
            var contractType = ContractType.Developer;
            var experience = 3;
            var minWage = 5000;
            ISalaryCalculator calculator = new DefaultSalaryCalculator();

            var expected = 5375;
            var actual = calculator.Calculate(contractType, experience, minWage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenTesterContractWhenCalculatingSalaryThenCalculationIsCorrect()
        {
            var contractType = ContractType.Tester;
            var experience = 1;
            var minWage = 2000;
            ISalaryCalculator calculator = new DefaultSalaryCalculator();

            var expected = 2600;
            var actual = calculator.Calculate(contractType, experience, minWage);

            Assert.AreEqual(expected, actual);
        }
    }
}