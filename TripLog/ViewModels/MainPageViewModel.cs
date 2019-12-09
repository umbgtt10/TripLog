using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TripLog.Models;
using TripLog.Views;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<TripLogEntry> entries;

        public ObservableCollection<TripLogEntry> Entries
        {
            get
            {
                return entries;
            }
            private set
            {
                if(entries != value)
                {
                    entries = value;
                    Notify(nameof(Entries));
                }
            }
        }

        private ICommand newCommand;

        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new Command(NewProcedure);
                }

                return newCommand;
            }
        }

        private TripLogEntry detailSelectItem;

        public TripLogEntry DetailSelectedItem
        {
            get
            {
                return detailSelectItem;
            }
            set
            {
                if(detailSelectItem != value)
                {
                    detailSelectItem = value;
                    DetailProcedure(detailSelectItem);
                    detailSelectItem = null;
                }
            }
        }

        private TripLogFactory factory;

        public MainPageViewModel(TripLogFactory factory)
        {
            this.factory = factory;
        }

        private void NewProcedure()
        {
            this.factory.NavigateToNewPage();
        }

        public void DetailProcedure(TripLogEntry entry)
        {
            this.factory.NavigateToDetailPage(entry);
        }

        public override void Init()
        {
            var items = new List<TripLogEntry>
            {
                new TripLogEntry
                {
                    Title = "Washington Monument",
                    Notes = "Amazing!",
                    Rating = 3,
                    Date = new DateTime(2017, 2, 5),
                    Latitude = 38.8895,
                    Longitude = -77.0352
                },
                new TripLogEntry
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring!",
                    Rating = 4,
                    Date = new DateTime(2017, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                },
                new TripLogEntry
                {
                    Title = "Golden Gate Bridge",
                    Notes = "Foggy, but beautiful.",
                    Rating = 5,
                    Date = new DateTime(2017, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                }
            };

            Entries = new ObservableCollection<TripLogEntry>(items);
        }

        public override void Init(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
