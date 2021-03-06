﻿using System.Collections;
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
	private NetworkManager m_network;

	public override void OnStartClient() {
		CmdSetParameters();
	}

	void Start() {
		if (isLocalPlayer) {
			SetupDeck();
			SetupResources();
			m_abilityDeck.GetComponentInChildren<Inventory_Ingame>().m_owner = this;
		}
	}

	[Command]
	private void CmdSetParameters() {
		Vector3 spawnPos = transform.position;
		if (transform.position.x < 0) {
			gameObject.layer = LayerMask.NameToLayer("Player1");
			gameObject.tag = "Player1";
			spawnPos.x += 1;
		} else {
			transform.Rotate(new Vector2(0, 180));
			gameObject.layer = LayerMask.NameToLayer("Player2");
			gameObject.tag = "Player2";
			GameManager.Instance.hasClient = true;
			spawnPos.x -= 1;			
		}
		spawnPos.y += (float)0.1;
		m_spawnPoint.position = spawnPos;
	}

	[Command]
	public void CmdSpawnType(short type) {
		GameObject temp = Instantiate(m_spawnables[type]);
		Vector3 newPosition = m_spawnPoint.position;
		newPosition.z += z_layer;
		temp.transform.position = newPosition;
		temp.layer = gameObject.layer;
		z_layer--;
		NetworkServer.Spawn(temp);
		if (z_layer <= -5) {
			z_layer = 0;
		}
	}

	public bool Spawn(short type) {
		bool hasSpawned = false;
		if (isLocalPlayer) {
			if (type != 0 && m_energy.CanPurchase(type)) {
				CmdSpawnType(type);
				hasSpawned = true;
			}
		}
		return hasSpawned;
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
