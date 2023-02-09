﻿using System.ComponentModel;
using System.IO;

namespace DwmLutGUI
{
    public class MonitorData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _sdrLutPath;
        private string _hdrLutPath;

        public MonitorData(string devicePath, uint sourceId, string name, string connector, string position,
            string sdrLutPath, string hdrLutPath)
        {
            DevicePath = devicePath;
            SourceId = sourceId;
            Name = name;
            Connector = connector;
            Position = position;
            SdrLutPath = sdrLutPath;
            HdrLutPath = hdrLutPath;
        }

        public MonitorData(string devicePath, string sdrLutPath, string hdrLutPath)
        {
            DevicePath = devicePath;
            SdrLutPath = sdrLutPath;
            HdrLutPath = hdrLutPath;
        }

        public string DevicePath { get; }
        public uint SourceId { get; }
        public string Name { get; }
        public string Connector { get; }
        public string Position { get; }

        public string SdrLutPath
        {
            set
            {
                if (value == _sdrLutPath) return;
                _sdrLutPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SdrLutFilename)));
            }
            get => _sdrLutPath;
        }

        public string HdrLutPath
        {
            set
            {
                if (value == _hdrLutPath) return;
                _hdrLutPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HdrLutFilename)));
            }
            get => _hdrLutPath;
        }

        public string SdrLutFilename => Path.GetFileName(SdrLutPath) ?? "None";

        public string HdrLutFilename => Path.GetFileName(HdrLutPath) ?? "None";
    }
}