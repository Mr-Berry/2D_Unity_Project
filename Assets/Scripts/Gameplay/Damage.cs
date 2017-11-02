using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	// more than two types that deal damage do this --> public short m_type
	public short m_damage;
	public float m_attackRate;
	public bool m_isProjectile;
	private float m_timer;
	private Collider m_clr;
	private Health m_target;

	void Start() {
		m_clr = GetComponent<Collider>();
		m_timer = m_attackRate;
	}

	void Update() {
		if (m_target != null) {
			if (m_timer <= 0) {
				m_target.TakeDamage(m_damage);
				m_timer = m_attackRate;
				if (m_isProjectile) {
					// death particle here
					// GetComponent<ParticleSystem>().Play;
					Destroy(this);
				}
			} else {
				m_timer -= Time.deltaTime;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		m_target = other.gameObject.GetComponent<Health>();
	}
}
