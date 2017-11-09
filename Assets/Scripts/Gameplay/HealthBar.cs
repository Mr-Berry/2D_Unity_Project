using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	
	
	public float fillAmount;
	public Image contant;
	public GameObject m_Player;
	private Health m_health;

	void Start () 
	{
		m_health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_health = m_Player.m_currentHealth;
		HandleBar();
	}

	private void HandleBar()
	{
		contant.fillAmount = m_health;
	}

	
}
