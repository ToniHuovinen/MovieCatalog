using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Data;
using System.Collections.ObjectModel;

namespace MovieList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<MovieInfo> movieInformation = new ObservableCollection<MovieInfo>();

        public MainWindow()
        {
            InitializeComponent();      
            dgSimple.DataContext = new DataGridSource();

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(ObservableCollection<MovieInfo>));
            string xmlFile = "catalog.xml";
            FileStream xmlStream = new FileStream(xmlFile, FileMode.OpenOrCreate);

            var readInfo = ser.ReadObject(xmlStream);
            dgSimple.ItemsSource = readInfo as ObservableCollection<MovieInfo>;
            movieInformation = dgSimple.ItemsSource as ObservableCollection<MovieInfo>;

            xmlStream.Close();

        }


        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {

            movieInformation.Add(new MovieInfo()
            {
                Name = nameText.Text,
                Director = directorText.Text,
                ReleaseYear = relYearText.Text,
                Genre = genreText.Text
            });

            
            dgSimple.ItemsSource = movieInformation;
            

            ClearTyped();

            
        }


        private void dgSimple_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object chosenTarget = dgSimple.SelectedItem;
            // Takes first cell from chosen line and stores it's content as string
            string content = (dgSimple.SelectedCells[0].Column.GetCellContent(chosenTarget) as TextBlock).Text;
            
            // Form the address that's been used in search. In the end there is an OMDB API Key
            string url = "http://www.omdbapi.com/?t=" + content.Trim() + "&apikey=7acf8da1";
            using (WebClient browser = new WebClient())
            {
                // Change the address into JSON format
                var json = browser.DownloadString(url);
                JavaScriptSerializer oJavaSer = new JavaScriptSerializer();
                MovieDatabase target = new MovieDatabase();
                target = oJavaSer.Deserialize<MovieDatabase>(json);

                if (target.Response == "True")
                {
                    moviePlot.Text = target.Plot;
                    string address = target.Poster;
                    moviePoster.Source = new BitmapImage(new Uri(address));
                    imdbRating.Text = target.imdbRating + "/10";
                    
                }
                else
                {
                    MessageBox.Show("No movie information found, check for errors in name.");
                }
            }
        }

        public void ClearTyped()
        {
            nameText.Text = string.Empty;
            directorText.Text = string.Empty;
            relYearText.Text = string.Empty;
            genreText.Text = string.Empty;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            DataContractSerializer ser = new DataContractSerializer(typeof(List<MovieInfo>));
            var information = movieInformation;

            string xmlFile = "catalog.xml";
            FileStream xmlStream = File.Create(xmlFile);

            ser.WriteObject(xmlStream, information);

            xmlStream.Dispose();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
