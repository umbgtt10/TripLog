using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog.Views
{
    public class TripLogMainPageFactory
    {
        public NavigationPage BuildMainPage()
        {
            var mainPage = new MainPage();
            var tripLogNavigation = new TripLogNavigation(mainPage.Navigation);
            var viewFactory = new ViewFactory();
            var viewModelFactory = new ViewModelFactory(tripLogNavigation);
            var factory = new TripLogFactory(viewFactory, viewModelFactory, tripLogNavigation);
            var vm = new MainPageViewModel(factory);
            mainPage.SetViewModel(vm);

            return new NavigationPage(mainPage);
        }
    }
}
