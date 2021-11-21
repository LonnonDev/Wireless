using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using System;
using LogicWorld.Server.Circuitry;
using wireless.Server.Components;
using wireless.Server;


namespace wireless.Server
{
    public class Loader : ServerMod {
        protected override void Initialize() {
            Logger.Info("wireless initialized");
        }
    }
    public static class Connections {
        public static LogicComponent[][] WirelessConnections = new LogicComponent[16][];
    }
}