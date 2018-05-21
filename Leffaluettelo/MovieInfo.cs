using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieList
{
    [DataContract]
    public class MovieInfo : INotifyPropertyChanged
    {
        private string name;
        private string director;
        private string releaseYear;
        private string genre;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; onPropertyChanged(this, "Name"); }
        }

        [DataMember]
        public string Director
        {
            get { return director; }
            set { director = value; onPropertyChanged(this, "Director"); }
        }

        [DataMember]
        public string ReleaseYear
        {
            get { return releaseYear; }
            set { releaseYear = value; onPropertyChanged(this, "ReleaseYear"); }
        }

        [DataMember]
        public string Genre
        {
            get { return genre; }
            set { genre = value; onPropertyChanged(this, "Genre"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MovieInfo() { }

        public MovieInfo(string name, string director, string releaseYear, string genre)
        {
            this.name = Name;
            this.director = Director;
            this.releaseYear = ReleaseYear;
            this.genre = Genre;
        }

    }
}
