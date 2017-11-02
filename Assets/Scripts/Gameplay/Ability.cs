using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

	public Sprite[] m_sprites;
	private Image m_img;
	protected short m_type { get; set; }

	void Start() {
		m_img = GetComponent<Image>();
		m_img.sprite = m_sprites[(int)m_abilities.NONE];
	}

	public void ChangeSprite(short index) {
		m_type = index;
		m_img.sprite = m_sprites[m_type];
	}

	public void Activate() {
		//click it and it does this
		switch (m_type) {
			case 0:
				Debug.Log("Default type of nothing");
			break;
			case 1:
				//Fireballs here
			break;
			case 2:
				//Summon here
			break;
			case 3:
				//Shield here
			break;
			default:
				Debug.Log("Unknown type");
			break;
		}
	}


	
}
