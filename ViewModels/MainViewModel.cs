using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// ViewModel for InvestmentDataInputView and InvestmentPeriodsListingView DataContext
        /// </summary>
        public InvestmentPeriodsListingViewModel InvestmentPeriodsListingViewModel { get; }

        public MainViewModel()
        {
            InvestmentPeriodsListingViewModel = new InvestmentPeriodsListingViewModel();
        }
    }
}
