using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceGen : MonoBehaviour {

	public short m_initialResources;
	public float m_resourcesPerSecond;
	public string m_baseText;
	public Text m_text;
	private short m_resource { get; set; }
	private float m_timer;

	void Start () {
		m_resource = m_initialResources;
		m_resourcesPerSecond = 1/m_resourcesPerSecond;
		SetText();
	}
	
	// Update is called once per frame
	void Update () {
		m_timer += Time.deltaTime;
		if (m_timer >= m_resourcesPerSecond) {
			m_resource++;
			SetText();
			m_timer = 0;
		}
	}

	private void PurchaseItem(short cost) {
		m_resource -= cost;
		SetText();
	}

	public bool CanPurchase(short type) {
		bool retVal = false;
		short cost = 0;
		switch (type) {
			case (short)m_abilities.NONE:
				Debug.Log("Type == 0");
			break;
			case (short)m_abilities.FIREBALL:
				cost = (short)m_costs.FIREBALL;	
			break;
			case (short)m_abilities.DRAGONWAR:
				cost = (short)m_costs.DRAGONWAR;	
			break;
			case (short)m_abilities.TROLL:
				cost = (short)m_costs.TROLL;	
			break;
			case (short)m_abilities.YETI:
				cost = (short)m_costs.YETI;	
			break;
			case (short)m_abilities.SHIELD:
				cost = (short)m_costs.SHIELD;	
			break;
			case (short)m_abilities.KNOCKBACK:
				cost = (short)m_costs.KNOCKBACK;	
			break;
			default:
				Debug.Log("type does not match enum");
			break;
		}
		if(m_resource >= cost) {
			retVal = true;
			PurchaseItem(cost);
		} else {

		}

		return retVal;
	}

	private void SetText() {
		m_text.text = m_baseText + " " + m_resource;
	}

	private void FlashRed() {
		
	}
}
