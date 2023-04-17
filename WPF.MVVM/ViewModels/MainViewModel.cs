using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MVVM.Base;
using WPF.MVVM.Services.NavigationServices;

namespace WPF.MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public INavigationService NavigationService { get => _navigationService; set => SetProperty(ref _navigationService, value); }


        public RelayCommand NavigateToHome { get; set; }
        public RelayCommand NavigateToAdditional { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigateToHome = new RelayCommand(obj => { NavigationService.NavigateTo<HomeViewModel>(); }, obj => true);
            NavigateToAdditional = new RelayCommand(obj => { NavigationService.NavigateTo<AdditionalViewModel>(); }, obj => true);
        }
    }
}
