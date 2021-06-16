using Xunit;
using WindesheimAD2021AutoVerzekeringsPremie.Implementation;
using static WindesheimAD2021AutoVerzekeringsPremie.Implementation.PremiumCalculation;

namespace AutoVerzekeringTest
{
    public class InsuranceCoveragesTests
    {
        [Fact]
        public void BasePremiumCoverageWAPerYearIsCorrect()
        {
            //Arrange
            Vehicle Vehicle = new Vehicle(2500, 20000, 2015);
            PolicyHolder PolicyHolder = new PolicyHolder(22, "05-04-2020", 1311, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.YEAR;

            //Act
            PremiumCalculation coveragePremium = new PremiumCalculation(Vehicle, PolicyHolder, InsuranceCoverage.WA);
            double actual = coveragePremium.PremiumPaymentAmount(paymentPeriod);
            double expected = 424.89;

            //Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void BasePremiumCoverageWAPerMonthIsCorrect()
        {
            //Arrange
            Vehicle Vehicle = new Vehicle(2500, 20000, 2015);
            PolicyHolder PolicyHolder = new PolicyHolder(21, "01-07-2020", 1329, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.MONTH;

            //Act
            PremiumCalculation coveragePremium = new PremiumCalculation(Vehicle, PolicyHolder, InsuranceCoverage.WA);
            double actual = coveragePremium.PremiumPaymentAmount(paymentPeriod);
            double expected = 36.29;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BasePremiumCoverageWAPLUSPerYearIsCorrect()
        {
            //Arrange
            Vehicle Vehicle = new Vehicle(2500, 20000, 2015);
            PolicyHolder PolicyHolder = new PolicyHolder(21, "01-07-2020", 1336, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.YEAR;

            //Act
            PremiumCalculation coveragePremium = new PremiumCalculation(Vehicle, PolicyHolder, InsuranceCoverage.WA_PLUS);
            double actual = coveragePremium.PremiumPaymentAmount(paymentPeriod);
            double expected = 509.86;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BasePremiumCoverageWAPLUSPerMonthIsCorrect()
        {
            //Arrange
            Vehicle Vehicle = new Vehicle(2500, 20000, 2015);
            PolicyHolder PolicyHolder = new PolicyHolder(21, "01-07-2020", 1300, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.MONTH;

            //Act
            PremiumCalculation coveragePremium = new PremiumCalculation(Vehicle, PolicyHolder, InsuranceCoverage.WA_PLUS);
            double actual = coveragePremium.PremiumPaymentAmount(paymentPeriod);
            double expected = 43.55;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BasePremiumCoverageALLRISKPerYearIsCorrect()
        {
            //Arrange
            Vehicle Vehicle = new Vehicle(2500, 20000, 2015);
            PolicyHolder PolicyHolder = new PolicyHolder(21, "01-07-2020", 1326, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.YEAR;

            //Act
            PremiumCalculation coveragePremium = new PremiumCalculation(Vehicle, PolicyHolder, InsuranceCoverage.ALL_RISK);
            double actual = coveragePremium.PremiumPaymentAmount(paymentPeriod);
            double expected = 849.78;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BasePremiumCoverageALLRISKPerMonthIsCorrect()
        {
            //Arrange
            Vehicle Vehicle = new Vehicle(2500, 20000, 2015);
            PolicyHolder PolicyHolder = new PolicyHolder(21, "01-07-2020", 1339, 0);
            PaymentPeriod paymentPeriod = PremiumCalculation.PaymentPeriod.MONTH;

            //Act
            PremiumCalculation coveragePremium = new PremiumCalculation(Vehicle, PolicyHolder, InsuranceCoverage.ALL_RISK);
            double actual = coveragePremium.PremiumPaymentAmount(paymentPeriod);
            double expected = 72.58;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}