using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AnimationController : NetworkBehaviour {

	private Damage m_damage;
	private Health m_health;
	private Rigidbody2D m_rb;
	private Animator m_anim;
	private int m_deathHash = Animator.StringToHash("isDead");
	private int m_movingHash = Animator.StringToHash("isMoving");
	private int m_attackingHash = Animator.StringToHash("isAttacking");
	
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
		if (m_damage.m_isAttacking) {
			m_anim.SetBool(m_attackingHash, true);
			m_damage.m_isAttacking = false;
		}
	}

	private void HandleDeathAnim() {
		if (m_health.m_isDead) {
			m_anim.SetBool(m_deathHash, true);
		}
	}

	private void HandleMovementAnim() {
		if (Mathf.Abs(m_rb.velocity.x) > 0) {
			m_anim.SetBool(m_movingHash, true);
		} else {
			m_anim.SetBool(m_movingHash, false);
		}
	}

	[Command]
	public void CmdStopAttacking() {
		m_anim.SetBool(m_attackingHash, false);		
	}
}
