using System;
using System.Windows.Input;
using TripLog.Models;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryPageViewModel : ViewModelBase
    {
        private string notes;
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                if(notes != value)
                {
                    notes = value;
                    Notify(nameof(Notes));
                }
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    Notify(nameof(Title));
                    SaveCommand.ChangeCanExecute();
                }
            }
        }

        private int rating;
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    Notify(nameof(Rating));
                }
            }
        }

        private double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    Notify(nameof(Latitude));
                }
            }
        }

        private double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    Notify(nameof(Longitude));
                }
            }
        }

        private double date;
        public double Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    Notify(nameof(Date));
                }
            }
        }

        private Command saveCommand;
        public Command SaveCommand
        { 
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new Command(
                      SaveProcedure,
                      CanSaveCommandBeExecuted);
                }

                return saveCommand;
            }
            set => saveCommand = value;
        }

        public override void Init(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        private void SaveProcedure()
        {
            // Store new entry!

            // Move to the main page!
        }

        private bool CanSaveCommandBeExecuted()
        {
            return !string.IsNullOrEmpty(Title);
        }
    }
}