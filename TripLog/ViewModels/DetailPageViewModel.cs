using System;
using System.Windows.Input;
using TripLog.Models;
using Xamarin.Forms;

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

        private ICommand backCommand;

        public ICommand BackCommand
        {
            get
            {
                if(backCommand == null)
                {
                    backCommand = new Command(BackProcedure);
                }

                return backCommand;
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

        private void BackProcedure()
        {
            // Move back to the main page!
        }
    }
}