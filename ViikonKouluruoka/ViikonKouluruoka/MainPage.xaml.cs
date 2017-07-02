using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ViikonKouluruoka
{
    /// <summary>
    /// Data of schools
    /// </summary>
    public class SchoolDataModel
    {
        public string Name { set; get; }

        public string City { set; get; }

        public string Id { set; get; }

        public static IList<SchoolDataModel> All { set; get; }

        public string Title => $"{Name}, {City}";

        public string HtmlUrl
            => $"https://api.theel0ja.info/viikon-kouluruoka/html/{Id}?theme=winuwp"; // TODO: make xamarin theme


        static SchoolDataModel()
        {
            All = new ObservableCollection<SchoolDataModel> {
                new SchoolDataModel {
                    Name = "Alakoulut",
                    City = "Turku",
                    Id = "turku_alakoulut",
                },
                new SchoolDataModel
                {
                    Name = "Yläkoulut ja lukiot",
                    City = "Turku",
                    Id = "turku_ylakoulut"
                }
            };
        }
    }

    public partial class MainPage : TabbedPage
    {
        public MainPage()
		{
			InitializeComponent();

            ItemsSource = SchoolDataModel.All;
        }
	}
}
