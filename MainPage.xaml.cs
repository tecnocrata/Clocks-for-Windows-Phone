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
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard1.Begin();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SelectClock();
            StartClock();
        }

        private void SelectClock()
        {
            var configuracion = ((Application.Current as App).Resources["myConfiguration"] as SettingsStore);
            if (!App.IsApplicationInstancePreserved)
                if (configuracion != null) configuracion.RecuperarFromIsolatedStorage();
            if (configuracion != null && configuracion.Analogo)
            {
                AnalogClock.Visibility = Visibility.Visible;
                DigitalClock.Visibility = Visibility.Collapsed;
            }
            else
            {
                AnalogClock.Visibility = Visibility.Collapsed;
                DigitalClock.Visibility = Visibility.Visible;
            }
        }

        private void StartClock()
        {
            var reloj = (this.Resources["myClock"] as Reloj);
            secondsTransformation.Angle = (360 / 60) * (reloj.Segundos + 0);
            segundosAnimation.From = secondsTransformation.Angle;
            segundosAnimation.To = secondsTransformation.Angle + 360;

            minutesTransformation.Angle = (360 / 60) * (reloj.Minutos);
            minutosAnimation.From = minutesTransformation.Angle;
            minutosAnimation.To = minutesTransformation.Angle + 360;

            hoursTransformation.Angle = (((float)reloj.Horas) / 12) * 360 + reloj.Minutos / 2;
            horasAnimation.From = hoursTransformation.Angle;
            horasAnimation.To = hoursTransformation.Angle + 360;
            reloj.Start();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }
    }
}