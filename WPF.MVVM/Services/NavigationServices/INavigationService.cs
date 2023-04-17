using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MVVM.Base;

namespace WPF.MVVM.Services.NavigationServices
{
    public interface INavigationService
    {
        BaseViewModel CurrentView { get; }

        void NavigateTo<T>() where T : BaseViewModel;
    }
}
