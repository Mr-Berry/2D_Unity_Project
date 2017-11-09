using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum m_abilities{NONE, FIREBALL, DRAGONWAR, TROLL, YETI, KNOCKBACK, SHIELD, NUM_ABILITIES}
public enum m_costs{NONE = 0, FIREBALL = 1, DRAGONWAR = 2, TROLL = 5, YETI = 3, SHIELD = 2, KNOCKBACK = 2}

public class GameManager : MonoBehaviour {
	public StateManager m_sm;
	public bool m_isGameOver = false;
	private GameState m_currentState;
	public static GameManager Instance {get { return m_instance; } }
	private static GameManager m_instance = null;
	public Player_updated[] m_players = new Player_updated[2]; 

	void Awake () {
//		PlayerPrefs.DeleteKey("GameWon");
//		PlayerPrefs.DeleteAll();
		if (m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
		m_sm.InitStates();
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
			ChangeStates(m_sm.m_gameStates[(int)GameStates_enum.INTRO]);
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
		SceneManager.LoadScene("Jason'sNetworkScene", LoadSceneMode.Single);
	}
}
