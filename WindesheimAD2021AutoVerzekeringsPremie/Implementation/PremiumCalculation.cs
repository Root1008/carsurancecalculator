using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindesheimAD2021AutoVerzekeringsPremie.Implementation
{
    internal class PremiumCalculation
    {
        public double PremiumAmountPerYear { get; private set; }
        private readonly int PRECISION = 2;

        internal enum PaymentPeriod
        {
            YEAR,
            MONTH
        }
                
        internal PremiumCalculation(Vehicle vehicle, PolicyHolder policyHolder, InsuranceCoverage coverage)
        {
            
            double premium = 0d;
            premium += CalculateBasePremium(vehicle);

            // LicenseAge moet < 5, niet <=5.
            if(policyHolder.Age < 23 || policyHolder.LicenseAge < 5)
            {
                premium *= 1.15;
            }

            premium = UpdatePremiumForPostalCode(premium, policyHolder.PostalCode);

            if(coverage == InsuranceCoverage.WA_PLUS)
            {
                premium *= 1.2;
            } else if (coverage == InsuranceCoverage.ALL_RISK)
            {
                premium *= 2;
            }

            premium = UpdatePremiumForNoClaimYears(premium, policyHolder.NoClaimYears);
            // Math.Round toevoeged voor 2 kommas na de 0.00 inplaats van 0.5128381959319.
            PremiumAmountPerYear = Math.Round(premium, PRECISION);
        }

        private static double UpdatePremiumForNoClaimYears(double premium, int years)
        {
            // int moet double worden bij NoClaimPrecentage, hierdoor worden ervaren bestuurders niet 0.  
            double NoClaimPercentage = (years - 5) * 5;
            if (NoClaimPercentage > 65) { NoClaimPercentage = 65; }
            if (NoClaimPercentage < 0) { NoClaimPercentage = 0; }
            return premium * ((100 - NoClaimPercentage) / 100);
        }

        private static double UpdatePremiumForPostalCode(double premium, int postalCode) => postalCode switch
        {
            >= 1000 and < 3600 => premium * 1.05,
            < 4500 => premium * 1.02,
            _ => premium,
        };

        internal double PremiumPaymentAmount(PaymentPeriod period)
        {
            double result = period == PaymentPeriod.YEAR ? PremiumAmountPerYear / 1.025 : PremiumAmountPerYear / 12;
            return Math.Round(result, PRECISION);
        }

        internal static double CalculateBasePremium(Vehicle vehicle)
        {
            // Result in een double aangeven, return met Math.Round. Omdat we hierdoor normale euro bedragen krijgen bij het uitrekenen van basis voertuig premie.  
            double result = vehicle.ValueInEuros / 100 - vehicle.Age + vehicle.PowerInKw / 5 / 3;
            return Math.Round(result, 2);

        }
    }
}


