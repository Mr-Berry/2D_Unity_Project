﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour {
	private List<Ability> m_usedPool = new List<Ability>();
	public List<Ability> m_abilityPool = new List<Ability>();
	public GameObject abilityBox;
	private List<GameObject> m_abilityBoxes = new List<GameObject>();
	private const short NUMABILITIES = 15;

	void Awake() {
		for (int i = 0; i < NUMABILITIES; i++) {
			m_abilityPool[i].m_Inventory = this;
		}
	}

	public bool CanPlaceMore(short type) {
		bool retVal = true;
		short count = 0;
		for (int i = 0; i < NUMABILITIES; i++) {
			if (m_abilityPool[i].m_type == type) {
				count++;
				if (count == 3) {
					retVal = false;
					break;
				}
			}
		}
		return retVal;
	}

	public void Sort(short index, short type) {
		for (int i = 0; i < index; i++) {
			if (m_abilityPool[i].m_type == type) {
				for (int j = index; j > i; j--) {
					m_abilityPool[j].ChangeType(m_abilityPool[j-1].m_type);
				}
				break;			
			}
		}
	}

	public void RemoveAndSort(Ability abilityToRemove) {
		for (int i = 0; i < NUMABILITIES; i++) {
			if (m_abilityPool[i] == abilityToRemove) {
				for (int j = i; j < NUMABILITIES; j++) {
					if (j == 14 || m_abilityPool[j].m_type == 0) {
						m_abilityPool[j].ChangeType((int)m_abilities.NONE);
						break;
					}
					m_abilityPool[j].ChangeType(m_abilityPool[j+1].m_type);
				}
			}
		}
	}

	public void Initialize() {
		if (PlayerPrefs.HasKey("Inventory_0")) {
			Debug.Log("loading");
			LoadInventory();	
		} else {
			Debug.Log("Saving");
			SaveInventory();
		}
	}

	private void LoadInventory() {
		for (int i = 0; i < NUMABILITIES; i++) {
			m_abilityPool[i].ChangeType((short)PlayerPrefs.GetInt("Inventory_"+i));
			Debug.Log(PlayerPrefs.GetInt("Inventory_"+i));
		}
	}

	public void SaveInventory() {
		for (int i = 0; i < NUMABILITIES; i++) {
			PlayerPrefs.SetInt( "Inventory_"+i, m_abilityPool[i].m_type);
		}
	} 

	public void CreateInventory() {
		for (int i = 0; i < NUMABILITIES; i++) {
			m_abilityBoxes[i] = Instantiate(abilityBox);
			m_abilityPool[i] = m_abilityBoxes[i].GetComponent<Ability>();
		}
		LoadInventory();
	}
}
