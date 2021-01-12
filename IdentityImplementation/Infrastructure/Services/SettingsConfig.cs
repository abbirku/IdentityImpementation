using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class SettingsConfig
    {
        public string WebAddress { get; }
        public int Delay { get; }

        public SettingsConfig(string webAddress, int delay)
        {
            WebAddress = webAddress;
            Delay = delay;
        }
    }
}
