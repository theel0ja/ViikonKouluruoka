using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ViikonKouluruoka
{
    /// <summary>
    /// List of schools
    /// </summary>
    public class SchoolDataModel
    {
        /// <summary>
        /// Get coefficient for font, for optimal size
        /// </summary>
        private static double FontCoefficient
        {
            get
            {
                // Font coefficient
                double fontCoefficient;
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        fontCoefficient = 1.5; // "Yläkoulut ja lukiot, Turku" is too big.
                        break;
                    default:
                        fontCoefficient = 1.0;
                        break;
                }

                return fontCoefficient;
            }
        }

        /// <summary>
        /// Get theme name, for sending to data server
        /// </summary>
        private static string ThemeName
        {
            get
            {
                string themeName;
                
                switch(Device.RuntimePlatform)
                {
                    case Device.Android:
                        themeName = "xamarin-android"; // TODO: make theme
                        break;
                    case Device.Windows:
                        themeName = "winuwp";
                        break;
                    default:
                        themeName = "xamarin-other";
                        break;
                }

                return themeName;
            }
        }

        /// <summary>
        /// Name of the restaurant.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// City where the restaurant is located.
        /// </summary>
        public string City { set; get; }

        /// <summary>
        /// Id of the school in the data server.
        /// </summary>
        public string Id { set; get; }


        /// <summary>
        /// Returns list of all schools.
        /// </summary>
        public static IList<SchoolDataModel> All { set; get; }

        /// <summary>
        /// Title for the restaurant
        /// </summary>
        public string Title => $"{Name}, {City}";

        /// <summary>
        /// Url of the data server, showing data in HTML format
        /// </summary>
        //public Uri HtmlUrl
        //    => new Uri($"https://api.theel0ja.info/viikon-kouluruoka/html/{Id}?theme={ThemeName}");

        /// <summary>
        /// Url of the data server, showing data in HTML format (DEV!!!!)
        /// </summary>
        public Uri HtmlUrl
            => new Uri($"http://82.128.255.83:8080/html/{Id}.php?theme={ThemeName}");

        /// <summary>
        /// Font size of the title (Xamarin.Forms.Label)    
        /// </summary>
        public double FontSize => Device.GetNamedSize(NamedSize.Large, typeof(Label)) * FontCoefficient;


        static SchoolDataModel()
        {
            //var loader = new ResourceLoader();

            All = new ObservableCollection<SchoolDataModel> {
                new SchoolDataModel {
                    Name = "Alakoulut",
                    City = "Turku",
                    Id = "turku_alakoulut"
                },
                new SchoolDataModel
                {
                    Name = "Yläkoulut ja lukiot",
                    City = "Turku",
                    Id = "turku_ylakoulut"
                },
                /* Espoo isn't done yet on the data server. */
                //new SchoolDataModel
                //{
                //    Name = "Koulut",
                //    City = "Espoo",
                //    Id = "espoo_koulut"
                //}
            };
        }
    }
}
