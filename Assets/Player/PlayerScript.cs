using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {

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
}