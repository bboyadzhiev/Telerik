using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _02.Number_of_clicks
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int Counter { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.Counter = 0;

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void clickHereButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (this.Counter < 99)
            {
                this.Counter++;
                clicksCounterTextBox.Text = Counter.ToString();
                if (this.Counter > clicksCounterTextBox.FontSize)
                {
                    clicksCounterTextBox.FontSize = Counter;
                }
            }
            else
            {
                clicksCounterTextBox.FontSize = 50;
                clicksCounterTextBox.Text = "No luck today ;)";
            }
        }
    }
}
