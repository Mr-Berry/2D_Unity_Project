using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public short m_maxHealth;
	public bool m_isPlayer;
	public string m_editorComment;
	public short m_currentHealth;
	private Movement m_movement;
	public bool m_isDead { get; set; }

	public short m_healthToAdd;

	void Start () {
		m_currentHealth = m_maxHealth;
		m_movement = GetComponent<Movement>();
		m_isDead = false;
	}

	public void TakeDamage(short damage) {
		m_currentHealth -= damage;
		CheckIsDead();
	}

	void Update() 
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			m_currentHealth += m_healthToAdd;
			Debug.Log(m_currentHealth);
		}
	}

	private void CheckIsDead() {
		if (m_currentHealth <= 0) {
			m_isDead = true;
			m_movement.StopMovement();
			if(m_isPlayer) {
				// switch to lose state
			} else {

			}
		}

		
	}

	public void DestroySelf() {
		Destroy(this.gameObject);
	}

	
}
