using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_updated : MonoBehaviour {

	public GameObject m_abilityDeckPrefab;
	public GameObject[] m_spawnables;
	private GameObject m_abilityDeck;
	public Transform m_spawnPoint;

	void Awake() {
		SetupDeck();
		SetParameters();
	}
	
	void Start() {
		m_abilityDeck.GetComponent<Inventory_Ingame>().m_owner = this;
	}

	private void SetParameters() {
		Vector2 spawnPos = transform.position;
		if (transform.position.x < 0) {
			gameObject.layer = LayerMask.NameToLayer("Player1");
			spawnPos.x += 5;
		} else {
			transform.Rotate(new Vector2(0, 180));
			gameObject.layer = LayerMask.NameToLayer("Player2");
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
		m_abilityDeck = Instantiate(m_abilityDeckPrefab, transform);
		Vector3 newPos = m_abilityDeck.transform.position;
		newPos.x = 0;
		newPos.y = 0;
		m_abilityDeck.transform.position = newPos;
		m_abilityDeck.transform.localScale /= transform.localScale.x;
	}
}
