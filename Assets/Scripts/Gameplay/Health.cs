using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public short m_maxHealth;
	private short m_currentHealth;
	private bool m_isDead { get; set; }

	void Start () {
		m_currentHealth = m_maxHealth;
		m_isDead = false;
	}

	public void TakeDamage(short damage) {
		m_currentHealth -= damage;
		CheckIsDead();
	}

	void Update() {
		Debug.Log(name + " " + m_currentHealth);
	}

	private void CheckIsDead() {
		if (m_currentHealth <= 0) {
			m_isDead = true;
			Destroy(this.gameObject);
		}
	}
}
