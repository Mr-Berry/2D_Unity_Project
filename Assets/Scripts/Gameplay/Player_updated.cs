using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_updated : NetworkBehaviour {

	public GameObject m_abilityDeckPrefab;
	public GameObject[] m_spawnables;
	private GameObject m_abilityDeck;
	public Transform m_spawnPoint;
	private int z_layer = 0;

	void Awake() {
		Debug.Log("hello");
		// if (GameManager.Instance.m_players[0] == null) {
		// 	GameManager.Instance.m_players[0] = this;				
		// } else {
		// 	GameManager.Instance.m_players[1] = this;
		// }

	}
	
	void Start() {
		if (isLocalPlayer){
			SetupDeck();
			SetParameters();
		}
		m_abilityDeck.GetComponentInChildren<Inventory_Ingame>().m_owner = this;
	}

	private void SetParameters() {
		Vector3 spawnPos = transform.position;
		if (transform.position.x < 0) {
			gameObject.layer = LayerMask.NameToLayer("Player1");
			spawnPos.x += 1;
		} else {
			transform.Rotate(new Vector2(0, 180));
			gameObject.layer = LayerMask.NameToLayer("Player2");
			spawnPos.x -= 1;			
		}
		spawnPos.y += (float)0.1;
		m_spawnPoint.position = spawnPos;
	}

	[Command]
	public void CmdSpawnType(short type) {
		if (type != 0) {
			GameObject temp = Instantiate(m_spawnables[type]);
			NetworkServer.Spawn(temp);
			Vector3 newPosition = m_spawnPoint.position;
			newPosition.z += z_layer;
			temp.transform.position = newPosition;
			temp.layer = gameObject.layer;
			z_layer--;
			if (z_layer <= -5) {
				z_layer = 0;
			}
		} else {
			Debug.Log("type = 0");
		}
	}

	private void SetupDeck() {
		m_abilityDeck = Instantiate(m_abilityDeckPrefab);
		Vector3 newPos = m_abilityDeck.transform.position;
		newPos.x = 0;
		newPos.y = 3;
		m_abilityDeck.transform.position = newPos;
		m_abilityDeck.transform.localScale /= transform.localScale.x;
		Debug.Log(m_abilityDeck == null);
	}

	void Update() {
		if (GameManager.Instance.m_isGameOver) {

		}
	}

	public void SetGameOver() {
		GameManager.Instance.m_isGameOver = true;
	}
}
