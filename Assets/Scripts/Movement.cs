using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool m_isFlying;
	public short m_speed;
	private bool m_facingRight = false;
	private Rigidbody2D m_rb;
	
	void Start () {
		m_rb = GetComponent<Rigidbody2D>();
		if (transform.position.x < 0) {
			m_facingRight = true;
		}
		if (transform.position.x == 0) {
			Debug.Log("object at zeroed X position");
		}
	}
	

	void Update () {
		if (m_facingRight) {
			m_rb.velocity = Vector2.right * m_speed;
		} else {
			m_rb.velocity = Vector2.left * m_speed;
		}
	}
}
