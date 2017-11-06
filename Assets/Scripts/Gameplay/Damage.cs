using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Note - if attack taking too long, animation for attacking could be longer than attack rate,
// either speed up animation or increase attack rate
public class Damage : MonoBehaviour {

	// more than two types that deal damage do this --> public short m_type
	public short m_damage;
	public float m_attackRate;
	public bool m_isProjectile;
	public bool m_isAttacking = false;
	private float m_timer = 0;
	private Health m_target = null;
	private Movement m_movement;

	void Start() {
		m_movement = GetComponent<Movement>();
	}

	void Update() {
		if (m_target != null) {
			if (m_timer <= 0) {
				m_timer = m_attackRate;
				SetAttacking();
			} else {
				m_timer -= Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		m_target = other.gameObject.GetComponent<Health>();
	}

	void OnTriggerExit2D(Collider2D other) {
		m_target = null;
		m_isAttacking = false;
	}

	private void SetAttacking() {
		if (m_isProjectile) {
			DealDamage();
			// death particle here
			// GetComponent<ParticleSystem>().Play;
			Destroy(this);
		} else {
			m_isAttacking = true;
		}
	}

	public void DealDamage() {
		m_target.TakeDamage(m_damage);
	}
}
