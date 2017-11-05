using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_updated : MonoBehaviour {

	public GameObject m_abilityDeckPrefab;
	public LayerMask[] m_playerLayerMasks;
	public GameObject[] m_spawnables;
	private GameObject m_abilityDeck;
	private Transform m_spawnPoint;
	
	void Start() {
		SetupDeck();
		SetParameters();
	}

	private void SetParameters() {
		Vector2 spawnPos = transform.position;
		if (transform.position.x < 0) {
			gameObject.layer = m_playerLayerMasks[0];
			spawnPos.x += 5;
		} else {
			transform.Rotate(new Vector2(0, 180));
			gameObject.layer = m_playerLayerMasks[1];
			spawnPos.x -= 5;			
		}
		m_spawnPoint.position = spawnPos;
	}

	public void SpawnType(short type) {
		if (type != 0) {
			GameObject temp = Instantiate(m_spawnables[type]);
			temp.layer = gameObject.layer;
		} else {
			Debug.Log("type = 0");
		}
	}

	private void SetupDeck() {
		m_abilityDeck = Instantiate(m_abilityDeckPrefab);
		m_abilityDeck.GetComponent<Inventory_Ingame>().m_owner = this;
	}
}
