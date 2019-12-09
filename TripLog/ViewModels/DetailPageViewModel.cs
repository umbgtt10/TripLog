using System;
using TripLog.Models;

namespace TripLog.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private TripLogEntry entry;
        public TripLogEntry Entry
        {
            get
            {
                return entry;
            }
            set
            {
                if (value != entry)
                {
                    entry = value;
                    Notify(nameof(Entry));
                }
            }
        }

        public override void Init(TripLogEntry entry)
        {
            this.Entry = entry;
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }
    }
}