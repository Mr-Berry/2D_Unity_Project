using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public StateManager m_sm;
	private GameState m_currentState;
	public static GameManager Instance {get { return m_instance; } }
	private static GameManager m_instance = null;

	void Awake () {
		if (m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		m_sm.InitStates();
		ChangeStates(m_sm.m_gameStates[(int)GameStates_enum.INTRO]);
	}

	private void Update () {
		if (m_currentState != null) {
			m_currentState.Execute();
		}
	}

	public void ChangeStates (GameState newState) {
		if (m_currentState != null)	{
			m_currentState.Exit();
		}
		m_currentState = newState;
		m_currentState.Enter();
	}
}
