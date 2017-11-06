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
		Vector3 tmpVec = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
		GameObject tmp = Instantiate(m_fireball, tmpVec, Quaternion.identity);
		NetworkServer.Spawn(tmp);
	}
}
