using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour {

	private List<Movement> m_targets = new List<Movement>();
	public float m_offset;

	void Start() {
		if (transform.position.x < 0) {
			transform.Rotate(new Vector2(0, 180));
			transform.position += new Vector3(m_offset, 0, 0);
		} else {
			transform.position -= new Vector3(m_offset, 0, 0);			
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!other.GetComponent<Damage>().m_isProjectile) {
			m_targets.Add(other.GetComponent<Movement>());
		}
	}

	public void KnockbackTargets() {
		for (int i = 0; i < m_targets.Count; i++) {
			m_targets[i].KnockBack();
		}
		Destroy(this.gameObject);
	}
}
