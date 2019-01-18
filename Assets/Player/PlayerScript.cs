using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {
	[SyncVar]
	public float PlayerObjectHealth = 100f;
	public GameObject PlayerObject;
	void Start () {
		if (!isLocalPlayer) {
			return;
		}
		CmdSpawnUnit ();
	}

	[Command]
	void CmdSpawnUnit () {
		GameObject PlayerUnit = Instantiate (PlayerObject);
		NetworkServer.SpawnWithClientAuthority (PlayerUnit, connectionToClient);
	}

	[ClientRpc]
	void RpcChangeHealth (float changeAmount) {
		PlayerObjectHealth += changeAmount;
	}
}