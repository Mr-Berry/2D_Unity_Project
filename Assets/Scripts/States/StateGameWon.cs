using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameWon : GameState {

	private float m_countDown = 5f;
	
	public StateGameWon(GameManager gm):base(gm) { }

	public override void Enter() {
		m_countDown = 5f;
	}

	public override void Execute() {
		if (m_countDown <= 0 ) {

		} else {
			m_countDown -= Time.deltaTime;
		}
	}

	public override void Exit() { }
}
