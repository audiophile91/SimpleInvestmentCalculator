using InvestmentCalculator.Models;
using InvestmentCalculator.ViewModels;

namespace InvestmentCalculator.Commands
{
    /// <summary>
    /// Command serving Calculate button in InvestmentDataInputView
    /// </summary>
    public class CalculateCommand : CommandBase
    {
        /// <summary>
        /// Referention to program InvestmentPeriodsListingViewModel
        /// </summary>
        private InvestmentPeriodsListingViewModel Invest;

        /// <summary>
        /// Constructor who handles InvestmentPeriodsListingViewModel referention initialization
        /// </summary>
        /// <param name="_investmentPeriodsListingViewModel">Passed ViewModel</param>
        public CalculateCommand(InvestmentPeriodsListingViewModel _investmentPeriodsListingViewModel)
        {
            Invest = _investmentPeriodsListingViewModel;
        }

        /// <summary>
        /// Execution of command binded to button
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object? parameter)
        {
            // Obesrvable collection referention
            var list = Invest.InvestmentPeriods;

            // Clear current periods list if needed
            list.Clear();

            // Number of periods to calculate
            uint periodsLimit = Invest.ReinvestmentYears * 12 / Invest.PeriodLength;

            // Investment input variable initialized with declared ammount
            double investedMoney = Invest.InvestmentInitial;

            for (uint period = 1; period <= periodsLimit; period++)
            {             
                // Add every calculated period model to ObservableCollection
                Invest.InvestmentPeriods.Add(new InvestmentPeriodModel(investedMoney, Invest.IntrestRate, Invest.Tax, period, Invest.PeriodLength, Invest.InvestmentInitial, Invest.InvestmentMonthly));

                // Update local variable holding ammount of cash for reinvestment with last item on the list values
                investedMoney = list.Last().WithdrawnValue;
            }
        }
    }
}
