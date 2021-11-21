using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using System;
using LogicWorld.Server.Circuitry;
using wireless.Server.Components;
using wireless.Server;

namespace wireless.Server.Components {
    public class transmitter : LogicComponent {
        private int OldAddress = 1;
        protected override void DoLogicUpdate() {
            int Address = 0;
            for (int i = 0; i <= 3; i++) {
                int On = base.Inputs[i].On ? 1 : 0;
                Address += On * (int)Math.Pow(2, i);  
            }
            Logger.Info(Address.ToString());
            if (OldAddress != Address) {
                RemoveConnections();
                Connections.WirelessConnections[OldAddress][0] = null;
                Connections.WirelessConnections[Address][0] = this;
                OldAddress = Address;
            }
        }
        void RemoveConnections() {
            for (int k = 4; k < 8; k++) {
                base.Inputs[k].RemoveAllSecretLinks();
            }
        }
    }
}