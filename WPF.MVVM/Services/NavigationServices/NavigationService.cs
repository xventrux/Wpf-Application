using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MVVM.Base;

namespace WPF.MVVM.Services.NavigationServices
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, BaseViewModel> _viewModelFactory;

        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                SetProperty(ref _currentView, value);
            }
        }

        public NavigationService(Func<Type, BaseViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            var vm = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = vm;
        }
    }
}
