using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelector : Ability {

	public void IncrementType() {
		m_type++;
		m_type %= (int)m_abilities.NUM_ABILITIES;
		ChangeSprite(m_type);
	}

	public void DecrementType() {
		if (m_type <= 0) {
			m_type = (int)m_abilities.NUM_ABILITIES;
		}
		m_type--;
		ChangeSprite(m_type);
	}
}
