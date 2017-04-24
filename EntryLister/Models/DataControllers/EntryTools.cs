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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using EntryLister.Annotations;

namespace EntryLister.Models.DataControllers
{
    /// <summary>
    /// <see cref="EntryTools"/> is dedicated to grouping all helpful methods that allow the user to modify a given <see cref="EntryStorage"/>.
    /// </summary>
    public class EntryTools : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryTools"/> class.
        /// </summary>
        /// <param name="entryStorage">The entry storage.</param>
        public EntryTools(EntryStorage entryStorage)
        {
            this.EntryCollection = entryStorage.EntryCollection;
        }

        private ObservableCollection<string> entryCollection;
        private List<string> allowedExtensions = new List<string> { ".dat", ".dll", ".cfg" };

        /// <summary>
        /// Gets or sets the entry collection.
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

        /// <summary>
        /// Adds any directory or file that was found in the given path specified.
        /// </summary>
        /// <param name="path">The path that will be iterated over.</param>
        public void AddToEntryCollection(string path)
        {
            var directories = Directory.GetDirectories(path);

            // Search through the specified path and add all directories, PLUS any entries with an allowed extension. (Specified in the "allowedExtensions" field.)
            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => allowedExtensions.Contains(Path.GetExtension(s)));

            // Adds the directories to the collection first.
            foreach (var entries in directories)
            {
                entryCollection.Add(Path.GetFileName(entries));
            }

            // And then add any files to the collection second.
            foreach (var entries in files)
            {
                entryCollection.Add(Path.GetFileName(entries));
            }
        }

        /// <summary>
        /// Clears the entry collection.
        /// </summary>
        public void ClearEntryCollection()
        {
            entryCollection.Clear();
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