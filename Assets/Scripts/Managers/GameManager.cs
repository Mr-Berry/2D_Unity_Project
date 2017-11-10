using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public enum m_abilities{NONE, FIREBALL, DRAGONWAR, TROLL, YETI, KNOCKBACK, SHIELD, NUM_ABILITIES}
public enum m_costs{NONE = 0, FIREBALL = 1, DRAGONWAR = 2, TROLL = 5, YETI = 3, SHIELD = 2, KNOCKBACK = 2}

public class GameManager : NetworkBehaviour {
	public StateManager m_sm;
	public bool m_isGameOver = false;
	public bool hasClient = false;
	private GameState m_currentState;
	public static GameManager Instance {get { return m_instance; } }
	private static GameManager m_instance = null;
	public Player_updated[] m_players = new Player_updated[2]; 

	void Awake () {
		PlayerPrefs.DeleteKey("GameWon");
//		PlayerPrefs.DeleteAll();
		if (m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		if (m_sm != null) {
			m_sm.InitStates();
		}
	}

	void Start() {
		if(PlayerPrefs.HasKey("GameWon")) {
			if (PlayerPrefs.GetInt("GameWon") == 1) {
				ChangeStates(m_sm.m_gameStates[(int)GameStates_enum.WIN]);				
			} else {
				ChangeStates(m_sm.m_gameStates[(int)GameStates_enum.LOSE]);
			}
			PlayerPrefs.DeleteKey("GameWon");
		} else {
			if (m_sm != null) {
				ChangeStates(m_sm.m_gameStates[(int)GameStates_enum.INTRO]);
			}
		}
	}

	private void Update () {
		if (m_currentState != null) {
			m_currentState.Execute();
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("MainMenu");
		}
	}

	public void ChangeStates (GameState newState) {
		if (m_currentState != null)	{
			m_currentState.Exit();
		}
		m_currentState = newState;
		m_currentState.Enter();
	}

	public void StartGame() {
		SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
	}

	public void SetGameOver() {
		m_isGameOver = true;
	}

	public void LoadMenu() {
		SceneManager.LoadSceneAsync(0,LoadSceneMode.Additive);
	}
}
