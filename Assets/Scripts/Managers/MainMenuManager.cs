using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour {

	private enum m_menuStates { MENU, BANK_EDITOR, NUM_STATES };
	public GameObject[] m_menuObjs;
	private m_menuStates m_currentState = m_menuStates.MENU;
	private List<m_abilities> m_playerBank = new List<m_abilities>();
	private int m_counter = 0;

	public void InitStates() {
		for (int i = 0; i < (int)m_menuStates.NUM_STATES; i++) {
			m_menuObjs[i].SetActive(false);
		}
		m_currentState = m_menuStates.MENU;
		m_menuObjs[(int)m_currentState].SetActive(true);
	}

	public void BankEditorState() {
		m_menuObjs[(int)m_currentState].SetActive(false);
		m_currentState = m_menuStates.BANK_EDITOR;
		m_menuObjs[(int)m_currentState].SetActive(true);
		m_menuObjs[(int)m_currentState].GetComponent<BankManager>().InitInventory();
	}

	public void MainMenuState() {
		m_menuObjs[(int)m_currentState].SetActive(false);
		m_currentState = m_menuStates.MENU;
		m_menuObjs[(int)m_currentState].SetActive(true);		
	}

	public void SaveInventory() {
		
	}

	public void InitAbilityBank() {

	}
}
