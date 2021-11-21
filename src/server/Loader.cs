using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;

namespace wireless.Server
{
    public class Loader : ServerMod {
        protected override void Initialize() {
            Logger.Info("wireless initialized");
        }
    }
    public static class Connections {
        public static LogicComponent[][] WirelessConnections = new LogicComponent[16][];
        public static LogicComponent[][] OldWirelessConnections = new LogicComponent[16][];
    }
}