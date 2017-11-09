using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_updated : NetworkBehaviour {
	public GameObject[] m_spawnables;
	public GameObject m_abilityDeckPrefab;
	public GameObject m_resourceGenPrefab;
	private ResourceGen m_energy;
	public Transform m_spawnPoint;
	private GameObject m_abilityDeck;
	private int z_layer = 0;
	private int WON = 1;
	private int LOST = 0;
	
	void Start() {
		if (isLocalPlayer){
			SetupDeck();
			HandleParameters();
			SetupResources();
			m_abilityDeck.GetComponentInChildren<Inventory_Ingame>().m_owner = this;
		}
	}

	private void HandleParameters() {
		CmdSetParameters();
		SetParameters();
	}

	[Command]
	private void CmdSetParameters() {
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
			if (m_energy.CanPurchase(type)) {
				GameObject temp = Instantiate(m_spawnables[type]);
				Vector3 newPosition = m_spawnPoint.position;
				newPosition.z += z_layer;
				temp.transform.position = newPosition;
				temp.layer = gameObject.layer;
				z_layer--;
				if (z_layer <= -5) {
					z_layer = 0;
				}
			}
		} else {
			Debug.Log("type = 0");
		}
	}

	public void SpawnType(short type) {
		if (type != 0) {
			if (m_energy.CanPurchase(type)) {
				GameObject temp = Instantiate(m_spawnables[type]);
				Vector3 newPosition = m_spawnPoint.position;
				newPosition.z += z_layer;
				temp.transform.position = newPosition;
				temp.layer = gameObject.layer;
				z_layer--;
				if (z_layer <= -5) {
					z_layer = 0;
				}
			}
		} else {
			Debug.Log("type = 0");
		}
	}

	public void Spawn(short type) {
		if (isLocalPlayer) {
//			SpawnType(type);
			CmdSpawnType(type);
		}
	}

	private void SetupDeck() {
		m_abilityDeck = Instantiate(m_abilityDeckPrefab);
		Vector3 newPos = m_abilityDeck.transform.position;
		newPos.x = 0;
		newPos.y = 3;
		newPos.z = 0;
		m_abilityDeck.transform.position = newPos;
		m_abilityDeck.transform.localScale /= transform.localScale.x;
	}

	void Update() {
		// if (GameManager.Instance.m_isGameOver) {
		// 	PlayerPrefs.SetInt("GameWon", WON);
		// }
	}

	public void SetGameOver() {
		GameManager.Instance.m_isGameOver = true;
	}

	private void SetupResources() {
		GameObject temp = Instantiate(m_resourceGenPrefab);
		Vector3 newPos = m_abilityDeck.transform.position; 
		newPos.x = transform.position.x;
		newPos.y -= 2;
		newPos.z = 0;
		temp.transform.position = newPos;
		temp.transform.localScale /= transform.localScale.x;
		m_energy = temp.GetComponent<ResourceGen>();		
	}
}
