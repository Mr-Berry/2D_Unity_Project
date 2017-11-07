using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

	public bool m_isFlying;
	public float m_speed;
	public short m_knockbackMultiplier = 150;
	public bool m_isMoving = true;
	public bool m_facingRight = false;
	private Rigidbody2D m_rb;
	
	void Start () {
		m_rb = GetComponent<Rigidbody2D>();
		if (transform.position.x < 0) {
			m_facingRight = true;
		} else {
			m_speed *= -1;
		}
		if (!m_facingRight) {
			transform.Rotate(new Vector2(0,180));
		}
		if (transform.position.x == 0) {
			Debug.Log("object at zeroed X position");
		}
	}
	
	void Update () {
		if (m_isMoving) {
			if ((m_facingRight && m_rb.velocity.x < m_speed) || (!m_facingRight && m_rb.velocity.x > m_speed)) {
				m_rb.velocity += Vector2.right * m_speed * Time.deltaTime;
			}
		}
	}

	public void StopMovement() {
		m_rb.velocity = Vector2.zero;
		m_isMoving = false;
	}

	public void StartMovement() {
		m_isMoving = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		StopMovement();
	}

	void OnTriggerExit2D(Collider2D other) {
		StartMovement();
	}

	public void KnockBack() {
		if (m_facingRight) {
			m_rb.AddForce(m_knockbackMultiplier*m_speed*Vector2.right);			
		} else {
			m_rb.AddForce(m_knockbackMultiplier*m_speed*Vector2.left);				
		}
	}
}
