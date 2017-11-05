using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelector : Ability {

	public Inventory_UI m_Inventory;
	public void IncrementType() {
		m_type++;
		m_type %= (int)m_abilities.NUM_ABILITIES;
		ChangeType(m_type);
	}

	public void DecrementType() {
		if (m_type <= 0) {
			m_type = (int)m_abilities.NUM_ABILITIES;
		}
		m_type--;
		ChangeType(m_type);
	}

	public void SetAbility() {
		if (m_Inventory.CanPlaceMore(m_type)) {
			for (int i = 0; i < m_Inventory.m_abilityPool.Count; i++) {
				if (m_Inventory.m_abilityPool[i].m_type == 0) {
					m_Inventory.m_abilityPool[i].ChangeType(m_type);
					m_Inventory.Sort( (short)i, m_type);
					break;	
				}
			}
		}
	}
}
