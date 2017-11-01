using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameMenu : GameState {

	public StateGameMenu(GameManager gm):base(gm) { }
	public override void Enter() {
		m_state.SetActive(true);
		m_state.GetComponent<MainMenuManager>().InitStates();
	 }
	 
	public override void Execute() { }

	public override void Exit() {
		m_state.SetActive(false);
	 }
}
