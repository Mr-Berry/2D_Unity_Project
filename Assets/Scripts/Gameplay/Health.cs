using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public short m_maxHealth;
	public bool m_hasDeathAnimation;
	public bool m_isPlayer;
	public string m_editorComment;

	private short m_currentHealth;
	private Animation m_deathAnimation;
	private bool m_isDead { get; set; }

	void Start () {
		m_currentHealth = m_maxHealth;
		m_isDead = false;
		if(m_hasDeathAnimation) {
			// get the death animation here
			//m_deathAnimation = GetComponent<>();
		}
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
			if(m_isPlayer) {
				// switch to lose state
			} else {
				Destroy(this.gameObject);
			}
		}
	}
}
