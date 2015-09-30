using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyCounter.Resources;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using Windows.Storage;
using System.Xml;
using Windows.Data.Xml.Dom;
using System.Runtime.Serialization;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;


namespace MyCounter
{
    public partial class MainPage : PhoneApplicationPage
    {
        //private ObservableCollection<CountItem> _countItems;
        //private CounterDataContext db;

        //public ObservableCollection<CountItem> CountItems
        //{
        //    get { return _countItems; }

        //    set 
        //    { 
        //        if(_countItems!=value)
        //        {
        //            _countItems = value;
        //            NotifyPropertyChanged("CountItems");
        //        }
        //    }
        //}

        int trenutniBroj;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            //db = new CounterDataContext(CounterDataContext.DBConnectionString);
            //this.DataContext = this;

            trenutniBroj = LoadValue();
            valueText.Text = trenutniBroj.ToString();

        }

        private void plusBttn_Click(object sender, RoutedEventArgs e)
        {
            trenutniBroj += 2;
            SaveValue();
            valueText.Text = trenutniBroj.ToString();
        }

        public int LoadValue()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (storage.FileExists("awesomefile.xml"))
                {
                    using (var file = storage.OpenFile("awesomefile.xml", System.IO.FileMode.Open))
                    {
                        try
                        {
                            var serializer = new XmlSerializer(typeof(int));
                            return (int)serializer.Deserialize(file);
                        }
                        catch (Exception)
                        {
                            //You'd better do something more clever here
                            return -1;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

            public void SaveValue()
            {
               //int br=606;

                using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (storage.FileExists("awesomefile.xml"))
                    {
                        storage.DeleteFile("awesomefile.xml");
                    }

                    using (var file = storage.CreateFile("awesomefile.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(int));
                        serializer.Serialize(file, trenutniBroj);
                    }
                }
            }

            private void undoImg_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
            {
                trenutniBroj -= 2;
                SaveValue();
                valueText.Text = trenutniBroj.ToString();
            }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    var itemsInDB = from CountItem item in db.items select item;

        //    _countItems = new ObservableCollection<CountItem>(itemsInDB);

        //    base.OnNavigatedTo(e);
        //}

       
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged(string p)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(p));
        //}
    }
}