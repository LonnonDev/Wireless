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
            RemoveConnections();
            //PrintArray();
            Connections.OldWirelessConnections = Connections.WirelessConnections;
            base.QueueLogicUpdate();
        }
        void PrintArray() {
            for (int i = 0; i < Connections.WirelessConnections.Length; i++) { 
                Logger.Info(i.ToString() + "\n" + (Connections.WirelessConnections[i][0] == null ? true : false).ToString() + "\n" + (Connections.WirelessConnections[i][1] == null ? true : false).ToString());
            }
        }
        void RemoveConnections() {
            // Iterate through 1st layer
            for (int i = 0; i < Connections.WirelessConnections.Length; i++) {
                // Inputs
                for (int k = 4; k < 8; k++) {
                    try {
                        Connections.WirelessConnections[i][0].Inputs[k].RemovePhasicLinkWithUnsafe(Connections.WirelessConnections[i][1].Inputs[k]);
                    } catch {}
                }
            }
        }
        void AddConnections() {
            // Iterate through 1st layer
            for (int i = 0; i < Connections.WirelessConnections.Length; i++) {
                for (int k = 4; k < 8; k++) {
                    try {
                        Connections.WirelessConnections[i][0].Inputs[k].AddPhasicLinkWithUnsafe(Connections.WirelessConnections[i][1].Inputs[k]);
                    } catch {
                        Logger.Info(i.ToString() + "\n" + (Connections.WirelessConnections[i][0] == null ? true : false).ToString() + "\n" + (Connections.WirelessConnections[i][1] == null ? true : false).ToString());
                    }
                }
            }
        }
    }
}