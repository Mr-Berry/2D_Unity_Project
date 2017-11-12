using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameLost : GameState {

	private float m_countDown = 5f;
	
	public StateGameLost(GameManager gm):base(gm) { }

	public override void Enter() {
		m_state.SetActive(true);
	}

	public override void Execute() {

	}

	public override void Exit() {
		m_state.SetActive(false);
	 }
}
