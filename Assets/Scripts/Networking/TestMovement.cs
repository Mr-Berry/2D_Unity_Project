using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestMovement : NetworkBehaviour {

	public int m_movementSpeed = 5;
	public Rigidbody2D m_rb;
	public GameObject m_fireball;
	private bool m_isLocal;
	private bool m_hitOnce = false;
	private bool m_knockback = false;
	private float m_timer = 0;

	void Start() {
		GetComponent<TestMovement>().enabled = true;
		m_rb = GetComponent<Rigidbody2D>();
	}
 
	void Update() {
		if(isLocalPlayer) {
			if(!m_knockback) {
				if(Input.GetKey(KeyCode.A)) {
					m_rb.velocity = Vector3.left * m_movementSpeed;
				}
				if(Input.GetKeyUp(KeyCode.A)) {
					m_rb.velocity = Vector3.zero;
				}
				if(Input.GetKey(KeyCode.D)) {
					m_rb.velocity = Vector3.right * m_movementSpeed;
				}
				if(Input.GetKeyUp(KeyCode.D)) {
					m_rb.velocity = Vector3.zero;
				}
				if(Input.GetKeyDown(KeyCode.Space)) {
					CmdSpawnFireball();
				}
			} else {
				m_rb.AddForce(transform.right * 10);
				m_hitOnce = true;
				m_timer += Time.deltaTime;
				if(m_timer > 1f) {
					m_knockback = false;
					m_hitOnce = false;
					m_timer = 0f;
				}
			}
		}
	}

	[Command]
	public void CmdSpawnFireball() {
		Vector3 tmpVec = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
		GameObject tmp = Instantiate(m_fireball, tmpVec, Quaternion.identity);
		NetworkServer.Spawn(tmp);
	}

	public void KnockBack() {
		if(!m_hitOnce) {
			m_knockback = true;
		}
	}
}
