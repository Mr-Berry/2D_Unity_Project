using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private bool m_isFacingRight = false;
	private Transform m_spawnPoint;
	private List<m_abilities> m_usedPool = new List<m_abilities>();
	private List<m_abilities> m_abilityPool = new List<m_abilities>();

	 void Start() {

	 }

	 public void LoadAbilityPool() {
		 //playerprefs stuff here
	 }
}
