﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour {

	public Inventory_UI m_inventory;

	public void InitInventory() {
		m_inventory.Initialize();
	}	
}
