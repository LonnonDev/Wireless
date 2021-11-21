using LogicAPI.Server.Components;
using LogicAPI.Server;
using LogicLog;
using LogicWorld.Server.Circuitry;
using wireless.Server;
using UnityEngine;

namespace wireless.Server.Components {
    public class clock : LogicComponent {
        protected override void Initialize() {
            for (int i = 0; i <= 15; i++) {
                Logger.Info(i.ToString());
                Connections.WirelessConnections[i] = new LogicComponent[] {null, null};
            }
        }

        protected override void DoLogicUpdate() {
            AddConnections();
            if (base.Inputs[0].On) {
                PrintArray();
            }

            base.QueueLogicUpdate();
        }
        void PrintArray() {
            for (int i = 0; i < Connections.WirelessConnections.Length; i++) { 
                Logger.Info(i.ToString() + " : " + (Connections.WirelessConnections[i][0] == null ? true : false).ToString() + " : " + (Connections.WirelessConnections[i][1] == null ? true : false).ToString());
            }
        }
        void AddConnections() {
            // Iterate through 1st layer
            for (int i = 0; i < Connections.WirelessConnections.Length; i++) {
                for (int k = 4; k < 8; k++) {
                    try {
                        Connections.WirelessConnections[i][0].Inputs[k].AddSecretLinkWith(Connections.WirelessConnections[i][1].Inputs[k]);
                        if (base.Inputs[1].On) {
                            Logger.Info("added: " + i.ToString());
                        }
                    } catch {
                         if (base.Inputs[1].On) {
                            Logger.Info("failed: " + i.ToString());
                        }
                    }
                }
            }
        }
    }
}