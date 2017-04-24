// ***********************************************************************
// Assembly         : EntryLister
//
// Author           : Nicholas Tyler
// Created          : 04-24-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 04-24-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntryLister.Annotations;

namespace EntryLister.Models.DataControllers
{
    /// <summary>
    /// <see cref="EntryStorage"/> is dedicated to storing the entry collection.
    /// </summary>
    public class EntryStorage : INotifyPropertyChanged
    {
        public EntryStorage()
        {
            this.EntryCollection = new ObservableCollection<string>();
        }

        private ObservableCollection<string> entryCollection;

        /// <summary>
        /// Gets or sets the items in the entry collection.
        /// </summary>
        public ObservableCollection<string> EntryCollection
        {
            get { return entryCollection; }
            set
            {
                if (Equals(value, entryCollection)) return;
                entryCollection = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}