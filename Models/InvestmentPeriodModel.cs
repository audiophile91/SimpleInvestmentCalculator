namespace InvestmentCalculator.Models
{
    /// <summary>
    /// Model who's intention is to handle all calculations within give investment data
    /// </summary>
    public class InvestmentPeriodModel
    {
        /// <summary>
        /// Holds investment length in months
        /// </summary>
        private readonly uint _periodLengthMonths;
 
        /// <summary>
        /// Holds passed ID for period
        /// </summary>
        public uint PeriodID { get; }
        /// <summary>
        /// Holds passed investment cash ammount
        /// </summary>
        public double InvestedValue { get; }
        /// <summary>
        /// Holds calculated profit ammount rounded to 2 float point places
        /// </summary>
        public double Profit { get; }
        /// <summary>
        /// Holds calculated profit tax rounded to 2 float point places
        /// </summary>
        public double ProfitTax { get; }
        /// <summary>
        /// Holds initial investment ammount
        /// </summary>
        public double InvestmentSavingsInitial;
        /// <summary>
        /// Holds calculated periodly saved money due to given monthly savings
        /// </summary>
        public double InvestmentSavingsPeriodly { get; }
        /// <summary>
        /// Holds calculated string informing about total time passed since investment cycle began
        /// </summary>
        public string InvestmentTimeSpan => GetInvestmentTimeSpan();
        /// <summary>
        /// Holds calculated taxed profit ammount rounded to 2 float point places
        /// </summary>
        public double ProfitTaxed => Math.Round(Profit - ProfitTax, 2);
        /// <summary>
        /// Holds calculated investment collection ammount rounded to 2 float point places
        /// </summary>
        public double WithdrawnValue => Math.Round(InvestedValue + ProfitTaxed, 2);
        /// <summary>
        /// Holds calculated total invested savings, initial + periodly
        /// </summary>
        public double InvestedSavings => Math.Round((PeriodID - 1) * InvestmentSavingsPeriodly + InvestmentSavingsInitial, 2);
        /// <summary>
        /// Holds calculated total profit rounded to 2 float point places
        /// </summary>
        public double ProfitTotal => Math.Round(WithdrawnValue - InvestedSavings, 2);
        public string TotalPercentageProfit => $"{Math.Round((WithdrawnValue - InvestedSavings) / InvestedSavings * 100, 2)} %";

        /// <summary>
        /// Constructor automaticaly sets some investment variables due to given parameters input
        /// </summary>
        /// <param name="investedValue">Total cash frozen in an investment</param>
        /// <param name="intrestRate">Percentage format yearly intrest rate</param>
        /// <param name="intrestTax">Percentage format profits taxation</param>
        /// <param name="periodID">Counter of investment period</param>
        /// <param name="periodLengthMonths">Number of months that investment will take before collection</param>
        /// <param name="investmentSavingsInitial">Initial ammount of invested savings</param>
        /// <param name="investmentSavingsMonthly">Monthly saved ammount of cash for reinvestments</param>
        public InvestmentPeriodModel(double investedValue, double intrestRate, double intrestTax, uint periodID, uint periodLengthMonths, double investmentSavingsInitial, double investmentSavingsMonthly)
        {
            _periodLengthMonths = periodLengthMonths;
            PeriodID = periodID;
            InvestmentSavingsInitial = investmentSavingsInitial;
            // Calculated the period savings ammount due to period length in months
            InvestmentSavingsPeriodly = investmentSavingsMonthly * periodLengthMonths;       
            // Adds to invested ammount periodly saved ammount only at period ID > 1 because initialy its set to InvestmentSavingsInitial in Command Exectute before calculations iteration
            InvestedValue = Math.Round(investedValue + (periodID > 1 ? InvestmentSavingsPeriodly : 0), 2);
            Profit = Math.Round(investedValue * (intrestRate * 0.01) * (periodLengthMonths / 12.0), 2);
            ProfitTax = Math.Round(Profit * (intrestTax * 0.01), 2);
        }
        /// <summary>
        /// Calculates properly formated string for InvestmentTimeSpan
        /// </summary>
        /// <returns>Formated time span</returns>
        private string GetInvestmentTimeSpan()
        {
            uint monthsPassed = PeriodID * _periodLengthMonths;

            string monthForm = monthsPassed % 12 == 1 ? "month" : "months";
            string yearForm = monthsPassed / 12 < 2 ? "year" : "years";

            if (monthsPassed < 12) return $"{monthsPassed} {monthForm}";

            if (monthsPassed % 12 == 0) return $"{monthsPassed / 12} {yearForm}";

            return $"{monthsPassed / 12} {yearForm} {monthsPassed % 12} {monthForm}";
        }
    }
}
