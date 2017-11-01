using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameIntro : GameState {

	private float m_countDown = 1f;
	
	public StateGameIntro(GameManager gm):base(gm) { }

	public override void Enter() { 
		m_state.SetActive(true);
	}

	public override void Execute() {
		if (m_countDown <= 0 ) {
			m_gm.ChangeStates(m_gm.m_sm.m_gameStates[(int)GameStates_enum.MENU]);
		} else {
			m_countDown -= Time.deltaTime;
		}
	}

	public override void Exit() {
		m_state.SetActive(false);
	 }
}
