using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Inventory_Ingame : MonoBehaviour {

	public Player_updated m_owner;
	public GameObject m_abilityBox;
	public Transform[] m_startPositions;
	public Transform m_creationPoint;
	private short NUMBOXES = 5;
	private short NUMABILITIES = 15;
	private GameObject[] m_boxes;
	private Ability[] m_abilities;
	private List<short> m_types = new List<short>();
	private List<short> m_usedTypes = new List<short>();

	void Start() {
		m_boxes = new GameObject[NUMBOXES];
		m_abilities = new Ability[NUMBOXES];
		LoadPlayerPrefs();
		InitializeArray();
	}

	private void InitializeArray() {
		for (int i = 0; i < NUMBOXES; i++) {
			GameObject temp = Instantiate(m_abilityBox, m_startPositions[i]);
			temp.transform.SetParent(m_creationPoint);
			m_abilities[i] = temp.GetComponent<Ability>();
			m_abilities[i].m_IngameInventory = this;
			ChangeBoxType(m_abilities[i]);
			m_boxes[i] = temp;
		}
	}

	private void LoadPlayerPrefs() {
		for (int i = 0; i < NUMABILITIES; i++) {
			m_types.Add((short)PlayerPrefs.GetInt("Inventory_"+i));
		}
	}

	private void ChangeBoxType(Ability ability) {
		ability.ChangeType(GetRandomType());
	}

	private short GetRandomType() {
		if (m_types.Count <= 0) {
			m_types = m_usedTypes;
		}
		int index = Random.Range(0, m_types.Count);
		short type = m_types[index];
		m_types.RemoveAt(index);
		m_usedTypes.Add(type);
		return type;
	}

	private void RespawnBox(Ability ability) {
		ability.gameObject.transform.position = m_creationPoint.position;
		ChangeBoxType(ability);
	}

	public void ActivateAbility(Ability ability) {
		m_owner.Spawn(ability.m_type);
		RespawnBox(ability);
	}
}
