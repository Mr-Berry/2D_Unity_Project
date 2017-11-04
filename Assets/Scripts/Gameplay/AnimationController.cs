using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

	private Damage m_damage;
	private Health m_health;
	private Rigidbody2D m_rb;
	private Animator m_anim;
	void Start () {
		m_anim = GetComponent<Animator>();
		m_damage = GetComponent<Damage>();
		m_health = GetComponent<Health>();
		m_rb = GetComponent<Rigidbody2D>();
	}	
	
	void Update () {
		HandleDeathAnim();
		HandleAttackAnim();
		HandleMovementAnim();
	}

	private void HandleAttackAnim() {

	}

	private void HandleDeathAnim() {
		if (m_health.m_isDead) {
			m_anim.SetBool("isDead", true);
		}
	}

	private void HandleMovementAnim() {
		if (Mathf.Abs(m_rb.velocity.x) > 0) {
			m_anim.SetBool("isMoving", true);
		} else {
			m_anim.SetBool("isMoving", false);
		}
	}
}
