using System;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Xunit;

namespace WindesheimAD2021AutoVerzekeringsPremie.Test
{
    public class PolicyHolderTest
    {
        [Theory]
        [InlineData(21,"01-01-2018", 3)]
        [InlineData(24,"01-01-2016", 5)]
        [InlineData(21,"01-01-2014", 7)]
        [InlineData(16,"01-01-2022", -1)]
        public void PolicyHolderLicenseAgeCanBeCalculatedByDividingAgeWithCurrentYear(int age,string startDate, int expectedAge)
        {
            // Arrange 
            PolicyHolder policyHolder = new(age, startDate, 1333, 0);

            // Act
            int actualAge = policyHolder.LicenseAge;

            // Assert
            Assert.Equal(expectedAge, actualAge);

        }

    }
}
