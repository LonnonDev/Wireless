using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using System;
using LogicWorld.Server.Circuitry;
using wireless.Server.Components;
using wireless.Server;

namespace wireless.Server.Components {
    public class receiver : LogicComponent {
        private int OldAddress = 1;
        protected override void DoLogicUpdate() {
            int Address = 0;
            for (int i = 0; i <= 3; i++) {
                int On = base.Inputs[i].On ? 1 : 0;
                Address += On * (int)Math.Pow(2, i);  
            }
            Logger.Info(Address.ToString());
            if (OldAddress != Address) {
                Connections.WirelessConnections[OldAddress][1] = null;
                Connections.WirelessConnections[Address][1] = this;
                OldAddress = Address;
            }
        }
    }
}