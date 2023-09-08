using System;
using System.Collections.Generic;

namespace OpenDOS.Config
{
    public class Config
    {
        public string configName;
        public string configValue;

        public Config(string configValue, string configName)
        {
            this.configName = configName;
            this.configValue = configValue;
        }

    }
}
