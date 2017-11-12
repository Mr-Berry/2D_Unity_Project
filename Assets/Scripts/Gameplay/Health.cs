using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Health : NetworkBehaviour {

	public short m_maxHealth;
	public bool m_isPlayer;
	public string m_editorComment;
	public bool m_hasDeathAnim;
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

	void Update() {
		if(GameManager.Instance.m_isGameOver) {
			if (!PlayerPrefs.HasKey("GameWon")) {
				PlayerPrefs.SetInt("GameWon",1);
			}
			if (gameObject.tag == "Player2") {
				GameManager.Instance.CmdSetClientLeft();				
			} else if (gameObject.tag == "Player1" && !GameManager.Instance.hasClient) {
				GameManager.Instance.m_isGameOver = false;
				NetworkManager.Shutdown();
			}
		}
	}

	private void CheckIsDead() {
		if (m_currentHealth <= 0) {
			m_isDead = true;
			if(m_isPlayer) {
				GameManager.Instance.CmdSetGameOver();
				if (gameObject.tag == "Player2") {
					GameManager.Instance.CmdSetClientLeft();					
				}
				if (isLocalPlayer) {
					PlayerPrefs.SetInt("GameWon",0);
				}
			}
			if (m_movement == null) {
				Destroy(this.gameObject);
			} else {
				m_movement.StopMovement();
			}
		}	
	}

	public void DestroySelf() {
		Destroy(this.gameObject);
	}
}
