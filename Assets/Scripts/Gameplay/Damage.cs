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
	private List<Health> m_target = new List<Health>();
	private AnimationController m_anim;
	private Movement m_movement;

	void Start() {
		m_movement = GetComponent<Movement>();
		m_anim = GetComponent<AnimationController>();
	}

	void Update() {
		if (m_target.Count != 0) {
			if (m_timer <= 0) {
				m_timer = m_attackRate;
				SetAttacking();
			} else {
				m_timer -= Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<Health>() != null) {
			m_target.Add(other.gameObject.GetComponent<Health>());
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		m_target.Remove(other.gameObject.GetComponent<Health>());
		Debug.Log("object exit");
		if (m_target.Count == 0){
			m_isAttacking = false;
			if (m_anim != null)	{
				m_anim.CmdStopAttacking();
			}
		}
	}

	private void SetAttacking() {
		if (m_isProjectile) {
			DealDamage();
			// death particle here
			// GetComponent<ParticleSystem>().Play;
			Destroy(this.gameObject);
		} else {
			m_isAttacking = true;
		}
	}

	public void DealDamage() {
		m_target[0].TakeDamage(m_damage);
	}
}
