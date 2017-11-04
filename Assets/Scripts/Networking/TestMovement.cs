using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestMovement : NetworkBehaviour {

	public int m_movementSpeed = 5;
	public Rigidbody2D m_rb;
	public GameObject m_fireball;
	private bool m_isLocal;

	void Start() {
		GetComponent<TestMovement>().enabled = true;
		m_rb = GetComponent<Rigidbody2D>();
	}
 
	void Update() {
		if(isLocalPlayer) {
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
		}
	}

	[Command]
	public void CmdSpawnFireball() {
		GameObject tmp = Instantiate(m_fireball, transform.position, Quaternion.identity);
		NetworkServer.Spawn(tmp);
	}
}
