using System;
using TripLog.Models;

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
            private set
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
            private set
            {
                if (title != value)
                {
                    title = value;
                    Notify(nameof(Title));
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
            private set
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
            private set
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
            private set
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
            private set
            {
                if (date != value)
                {
                    date = value;
                    Notify(nameof(Date));
                }
            }
        }

        public override void Init(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }
    }
}