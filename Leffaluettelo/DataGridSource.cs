using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieList
{
    public class DataGridSource : INotifyPropertyChanged
    {
        public DataGridSource()
        {
            DGItemsSource = new ObservableCollection<MovieInfo>();
        }

        private ObservableCollection<MovieInfo> _ItemsSource;
        public ObservableCollection<MovieInfo> DGItemsSource
        {
            get { return _ItemsSource; }
            set { _ItemsSource = value; onPropertyChanged(this, "DGItemsSource"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
