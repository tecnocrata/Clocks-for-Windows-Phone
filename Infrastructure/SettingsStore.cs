using System;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Modulo6.Actividad1
{
    public class SettingsStore: INotifyPropertyChanged
    {
        //private readonly IsolatedStorageSettings isolatedStore;
        //private UTF8Encoding encoding;

        private string fileName = "Settings.txt";

        public SettingsStore()
        {
            //isolatedStore = IsolatedStorageSettings.ApplicationSettings;
            //encoding = new UTF8Encoding();
            //if (!DesignerProperties.IsInDesignTool)
            //    RecuperarFromIsolatedStorage();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnProperyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private bool analogo;

        public bool Analogo
        {
            get { return analogo; }
            set
            {
                analogo = value;
                OnProperyChanged("Analogo");
            }
        }

        private bool digital;

        public bool Digital
        {
            get { return digital; }
            set
            {
                digital = value;
                OnProperyChanged("Digital");
            }
        }

        public void GuardarToIsolatedStorage()
        {
            var isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isoStore.FileExists(fileName))
                isoStore.DeleteFile(fileName);
            Stream sw = isoStore.CreateFile(fileName);
            DataContractSerializer serializer = new DataContractSerializer(typeof(SettingsStore));
            serializer.WriteObject(sw, this);
            sw.Close();
            IsolatedStorageSettings.ApplicationSettings["DataLastSaveTime"] = DateTime.Now;
        }

        public void RecuperarFromIsolatedStorage()
        {
            //var resultado = "Analogo";
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (isoStore.FileExists(fileName))
            {
                Stream sr = isoStore.OpenFile(fileName, FileMode.Open);
                DataContractSerializer serializer = new DataContractSerializer(typeof(SettingsStore));
                var resultado = serializer.ReadObject(sr) as SettingsStore;
                Analogo = resultado != null && resultado.Analogo;
                Digital = resultado == null || resultado.Digital;
                sr.Close();
                return;
            }
            Analogo = false;
            Digital = true;
        }
    }
}
