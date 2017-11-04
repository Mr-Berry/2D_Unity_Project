using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public short m_maxHealth;
	public bool m_isPlayer;
	public string m_editorComment;
	private short m_currentHealth;
	public bool m_isDead { get; set; }

	void Start () {
		m_currentHealth = m_maxHealth;
		m_isDead = false;
	}

	public void TakeDamage(short damage) {
		m_currentHealth -= damage;
		CheckIsDead();
	}

	void Update() {

	}

	private void CheckIsDead() {
		if (m_currentHealth <= 0) {
			m_isDead = true;
			if(m_isPlayer) {
				// switch to lose state
			} else {

			}
		}
	}
}
