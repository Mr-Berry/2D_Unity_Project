﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

	public Sprite[] m_sprites;
	private Image m_img;
	public bool m_inPlayMode = true;
	[HideInInspector]
	public short m_type = 0;
	public Inventory_UI m_Inventory;
	public Inventory_Ingame m_IngameInventory;

	void Awake() {
		m_img = GetComponent<Image>();
		m_img.sprite = m_sprites[(int)m_abilities.NONE];
	}

	void Start() {

	}

	public void ChangeType(short index) {
		m_type = index;
		m_img.sprite = m_sprites[m_type];
	}

	public void Activate() {
		if (m_inPlayMode) {
			m_IngameInventory.ActivateAbility(this);
		} else {
			m_Inventory.RemoveAndSort(this);
		}
	}
}
