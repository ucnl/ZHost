using System;
using System.Text;
using UCNLDrivers;
using ZLibrary;

namespace ZHost
{
    [Serializable]
    public class SettingsContainer : SimpleSettingsContainer
    {
        #region Properties

        public string ZPortName;
        public BaudRate ZPortBaudrate;

        public bool IsUseOutputPort;
        public string OutputPortName;
        public BaudRate OutputPortBaudrate;
        public ZAddress OutputPortResponderAddress;
        public bool IsOutputSave;

        public bool IsAUX1;
        public string AUX1PortName;
        public BaudRate AUX1PortBaudrate;

        public bool IsAUX2;
        public string AUX2PortName;
        public BaudRate AUX2PortBaudrate;

        public ZAddress[] RespondersInUseAddresses;

        public int DataObsoleteThreshold_sec;
        public int MaxDistance_m;

        public double Salinity_PSU;

        public bool IsAutoSoundSpeed;
        public double SoundSpeed;

        public bool IsRedPhoneCompatibilityMode;
        public bool IsCoarseDepth;

        public double AntennaDy;
        public double AntennaDx;
        public double AntennaAdjustAngle;

        public bool IsUseVTGAsHeadingSource;

        #endregion
        
        #region Methods

        public override void SetDefaults()
        {
            ZPortName = "COM1";
            ZPortBaudrate = BaudRate.baudRate9600;

            IsUseOutputPort = false;
            OutputPortName = "COM1";
            OutputPortBaudrate = BaudRate.baudRate9600;
            OutputPortResponderAddress = ZAddress.Responder_1;
            IsOutputSave = false;

            IsAUX1 = false;
            AUX1PortName = "COM1";
            AUX1PortBaudrate = BaudRate.baudRate9600;

            IsAUX2 = false;
            AUX2PortName = "COM1";
            AUX2PortBaudrate = BaudRate.baudRate9600;

            RespondersInUseAddresses = new ZAddress[] { ZAddress.Responder_1 };

            MaxDistance_m = 1000;
            Salinity_PSU = 0;

            IsAutoSoundSpeed = true;
            SoundSpeed = 1500;

            IsRedPhoneCompatibilityMode = false;
            IsCoarseDepth = true;

            AntennaDy = 0.0;
            AntennaDx = 0.0;
            AntennaAdjustAngle = 0.0;
            IsUseVTGAsHeadingSource = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n");

            var fields = this.GetType().GetFields();

            foreach (var item in fields)
            {                
                
                if (item.FieldType.IsArray)
                {
                    sb.AppendFormat("-- {0}: ", item.Name);
                    foreach (var aItem in (Array)item.GetValue(this))
                    {
                        sb.AppendFormat("{0}, ", aItem);
                    }
                    sb.Append("\r\n");
                }
                else
                    sb.AppendFormat("-- {0}: {1}\r\n", item.Name, item.GetValue(this));
            }

            return sb.ToString();
        }

        #endregion
    }
}
