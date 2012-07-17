using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Modulo6.Actividad1
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            ((Application.Current as App).Resources["myConfiguration"] as SettingsStore).GuardarToIsolatedStorage();
            NavigationService.GoBack();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ((Application.Current as App).Resources["myConfiguration"] as SettingsStore).RecuperarFromIsolatedStorage();
        }
    }
}