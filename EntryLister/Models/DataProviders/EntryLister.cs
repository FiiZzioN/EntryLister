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

using System.ComponentModel;
using System.Runtime.CompilerServices;
using EntryLister.Annotations;
using EntryLister.Models.DataControllers;

namespace EntryLister.Models.DataProviders
{
    public class EntryLister : INotifyPropertyChanged
    {
        public EntryLister()
        {
            this.EntryStorage = new EntryStorage();
            this.EntryTools = new EntryTools(EntryStorage);
        }

        private string directoryPath = "No path selected.";
        private EntryStorage entryStorage;
        private EntryTools entryTools;


        #region Properties

        /// <summary>
        /// Gets or sets the directory path.
        /// </summary>
        /// <value>The directory path.</value>
        public string DirectoryPath
        {
            get { return directoryPath; }
            set
            {
                if (value == directoryPath) return;
                directoryPath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the entry storage.
        /// </summary>
        public EntryStorage EntryStorage
        {
            get { return entryStorage; }
            set
            {
                if (Equals(value, entryStorage)) return;
                entryStorage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the entry tools.
        /// </summary>
        public EntryTools EntryTools
        {
            get { return entryTools; }
            set
            {
                if (Equals(value, entryTools)) return;
                entryTools = value;
                OnPropertyChanged();
            }
        }

        #endregion

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