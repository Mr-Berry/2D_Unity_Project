using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetPlayerScripts : NetworkBehaviour{

	void Start() {
		if (isLocalPlayer) {
			GetComponent<Player_updated>().enabled = true;
		}
	}
}
