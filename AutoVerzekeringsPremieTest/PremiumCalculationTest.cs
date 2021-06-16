using System;
using WindesheimAD2021AutoVerzekeringsPremie;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using Xunit;
using static WindesheimAD2021AutoVerzekeringsPremie.Implementation.PremiumCalculation;

namespace WindesheimAD2021AutoVerzekeringsPremie.Test
{
    public class PremiumCalculationTest
    {
        [Theory]
        [InlineData(30, 0, 2500, "01-01-2012", 129.41)]
        [InlineData(30, 0, 4000, "01-01-2012", 125.72)]
        [InlineData(30, 6, 2500, "01-01-2017", 141.39)]
        [InlineData(30, 6, 4000, "01-01-2017", 137.35)]
        [InlineData(21, 0, 2500, "01-01-2017", 148.82)]
        [InlineData(21, 0, 4000, "01-01-2017", 144.58)]
        [InlineData(21, 6, 2500, "01-01-2017", 141.39)]
        [InlineData(21, 6, 4000, "01-01-2017", 137.35)]
        public void PremiumCalculationCalculateBaseIfPerYearIsCorrectBasedOnAgeAndDriverlicensedateAndEndsWithTwoDecimals(int Age, int NoClaimInsurance, int PostalCode, string DriverLicenseDate, double basePremiumVehicle)
        {
            // Arrange 
            PolicyHolder policyHolder = new(Age, DriverLicenseDate, PostalCode, NoClaimInsurance);

            Vehicle vehicle = new(185, 12000, 2015);

            PremiumCalculation premiumCalc = new(vehicle, policyHolder, InsuranceCoverage.WA);

            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.YEAR;

            // Act
            double actualPremium = premiumCalc.PremiumPaymentAmount(paymentPeriod);

            // Assert
            Assert.Equal(basePremiumVehicle, actualPremium);


        }
        [Theory]
        [InlineData(30, 0, 2500, "01-01-2012", 11.05)]
        [InlineData(30, 0, 4000, "01-01-2012", 10.74)]
        [InlineData(30, 6, 2500, "01-01-2017", 12.08)]
        [InlineData(30, 6, 4000, "01-01-2017", 11.73)]
        [InlineData(21, 0, 2500, "01-01-2017", 12.71)]
        [InlineData(21, 0, 4000, "01-01-2017", 12.35)]
        [InlineData(21, 6, 2500, "01-01-2017", 12.08)]
        [InlineData(21, 6, 4000, "01-01-2017", 11.73)]
        public void PremiumCalculationCalculateBaseIfPerMonthIsCorrectBasedOnAgeAndDriverlicensedateAndEndsWithTwoDecimals(int Age, int NoClaimInsurance, int PostalCode, string DriverLicenseDate, double basePremiumVehicle)
        {
            // Arrange 
            PolicyHolder policyHolder = new(Age, DriverLicenseDate, PostalCode, NoClaimInsurance);

            Vehicle vehicle = new(185, 12000, 2015);

            PremiumCalculation premiumCalc = new(vehicle, policyHolder, InsuranceCoverage.WA);

            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.MONTH;

            // Act
            double actualPremium = premiumCalc.PremiumPaymentAmount(paymentPeriod);

            // Assert
            Assert.Equal(basePremiumVehicle, actualPremium);


        }
    }
}
