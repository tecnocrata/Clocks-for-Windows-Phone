using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Modulo6.Actividad1
{
    public class Reloj: INotifyPropertyChanged
    {
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnProperyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private int segundos;

        public int Segundos
        {
            get { return segundos; }
            set
            {
                segundos = value;
                OnProperyChanged("Segundos");
            }
        }

        private int minutos;

        public int Minutos
        {
            get { return minutos; }
            set
            {
                minutos = value;
                OnProperyChanged("Minutos");
            }
        }

        private int horas;

        public int Horas
        {
            get { return horas; }
            set
            {
                horas = value;
                OnProperyChanged("Horas");
            }
        }

        private double anguloSegundos;

        public double AnguloSegundos
        {
            get { return anguloSegundos; }
            set
            {
                anguloSegundos = value;
                OnProperyChanged("AnguloSegundos");
            }
        }

        private double anguloMinutos;

        public double AnguloMinutos
        {
            get { return anguloMinutos; }
            set
            {
                anguloMinutos = value;
                OnProperyChanged("AnguloMinutos");
            }
        }

        private double anguloHoras;

        public double AnguloHoras
        {
            get { return anguloHoras; }
            set
            {
                anguloHoras = value;
                OnProperyChanged("AnguloHoras");
            }
        }

        private string meridiano;
        public string Meridiano
        {
            get { return meridiano; }
            set
            {
                meridiano = value;
                OnProperyChanged("Meridiano");
            }
        }

        #endregion

        private DispatcherTimer timer;

        public Reloj()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(TimerTick);
            GetDateTime();
        }

        void TimerTick(object sender, EventArgs e)
        {
            GetDateTime();
        }

        private void GetDateTime()
        {
            var date = DateTime.Now;
            Horas = date.Hour;
            Minutos = date.Minute;
            Segundos = date.Second;
            Meridiano = date.Hour > 12 || date.ToShortTimeString().ToUpper().Contains("PM") ? "PM" : "AM";
            AnguloHoras = (((float)Horas) / 12) * 360 + Minutos / 2;
            AnguloMinutos = (360/60)*Minutos;
            AnguloSegundos = (360 / 60) * (Segundos + 0);
        }

        public void Start()
        {
            if (!timer.IsEnabled)
                timer.Start();
        }

        public void Stop()
        {
            if (timer.IsEnabled)
                timer.Stop();
        }
    }
}
