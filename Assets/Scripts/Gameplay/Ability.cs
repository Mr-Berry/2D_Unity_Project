﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

	public Sprite[] m_sprites;
	private Image m_img;
	public bool m_inPlayMode = true;
	[HideInInspector]
	public short m_type;
	public Inventory m_Inventory { get; set; }

	void Start() {
		m_img = GetComponent<Image>();
		m_img.sprite = m_sprites[(int)m_abilities.NONE];
	}

	public void ChangeType(short index) {
		m_type = index;
		m_img.sprite = m_sprites[m_type];
	}

	public void Activate() {
		if (m_inPlayMode) {
			//click it and it does this
			switch (m_type) {
				case 0:
					Debug.Log("Default type of nothing");
				break;
				case 1:
					//Fireballs here
				break;
				case 2:
					//Summon here
				break;
				case 3:
					//Shield here
				break;
				default:
					Debug.Log("Unknown type");
				break;
			}
		} else {
			m_Inventory.RemoveAndSort(this);
		}
	}
}
