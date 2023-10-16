using InvestmentCalculator.Commands;
using InvestmentCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InvestmentCalculator.ViewModels
{
    public class InvestmentPeriodsListingViewModel : ViewModelBase
    {
        /// <summary>
        /// Collection for view binding
        /// </summary>
        public ObservableCollection<InvestmentPeriodModel> InvestmentPeriods { get; }

        public double InvestmentInitial { get; set; }
        public double InvestmentMonthly { get; set; }
        public double IntrestRate { get; set; }
        public double Tax { get; set; }
        public uint PeriodLength { get; set; } = 1;
        public uint ReinvestmentYears { get; set; } = 1;

        public ICommand Calculate { get; }

        public InvestmentPeriodsListingViewModel()
        {
            InvestmentPeriods = new ObservableCollection<InvestmentPeriodModel>();
			Calculate = new CalculateCommand(this);
        }
    }
}
