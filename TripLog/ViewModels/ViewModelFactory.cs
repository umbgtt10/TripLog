using TripLog.Services;

namespace TripLog.ViewModels
{
    public class ViewModelFactory
    {
        public NewEntryPageViewModel BuildNewEntryPageViewModel()
        {
            return new NewEntryPageViewModel();
        }

        public DetailPageViewModel BuildDetailPageViewModel()
        {
            return new DetailPageViewModel();
        }
    }
}
