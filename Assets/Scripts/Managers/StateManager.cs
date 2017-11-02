using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates_enum { INTRO, MENU, PLAY, WIN, LOSE, NUMSTATES};

public class StateManager : MonoBehaviour {
	public GameObject[] m_stateObjs;
	[HideInInspector]
    public GameState[] m_gameStates = new GameState[5];
    public static StateManager Instance {get { return m_instance; } }
    private static StateManager m_instance = null;	

	void Awake () {
		if (m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	public void PlayGame() {
	}

	public void InitStates() {
		m_gameStates[(int)GameStates_enum.INTRO] = new StateGameIntro(GameManager.Instance);
		m_gameStates[(int)GameStates_enum.MENU] = new StateGameMenu(GameManager.Instance);
		m_gameStates[(int)GameStates_enum.PLAY] = new StateGamePlay(GameManager.Instance);
		m_gameStates[(int)GameStates_enum.WIN] = new StateGameWon(GameManager.Instance);
		m_gameStates[(int)GameStates_enum.LOSE] = new StateGameLost(GameManager.Instance);
		for (int i = 0; i < (int)GameStates_enum.NUMSTATES; i++) {
			m_gameStates[i].m_state = m_stateObjs[i];
			m_stateObjs[i].SetActive(false);
		}
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void Test() {
		Debug.Log("Hello");
	}
}
