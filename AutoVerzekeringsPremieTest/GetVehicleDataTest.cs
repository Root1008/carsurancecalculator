using System;
using Xunit;

using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using static WindesheimAD2021AutoVerzekeringsPremie.Implementation.PremiumCalculation;

namespace WindesheimAD2021AutoVerzekeringsPremie.test
{
    public class GetVehicleDataTest
    {
        [Fact]
        public void PremiumCalculationCalculateBasePremiumFromVehicleIsCorrectlyCalculated()
        {
            // Arrange
            Vehicle vehicle = new(185, 12000, 2015);

            // Act 
            double actualPremiumCalc = CalculateBasePremium(vehicle);
            double expectedPremiumCalc = 126.33;

            // Assert
            Assert.Equal(expectedPremiumCalc, actualPremiumCalc);

        }

        [Theory]
        [InlineData (90, 2000, 1998, 3)]
        [InlineData (180, 23000, 2012, 233)]
        [InlineData (250, 70000, 2020, 715.67)]
        public void CalculateBasePremiumValueFromDifferentVehicles(int PowerInKw, int ValueInEuros, int ConstructionYear, double expectedValue)
        {
            //Arrange
            Vehicle vehicle = new Vehicle(PowerInKw, ValueInEuros, ConstructionYear);

            //Act
            double actualValue = CalculateBasePremium(vehicle);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }

    }

}

