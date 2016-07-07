using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour {
	// 移动速度
	public float m_speed = 1;
	// 旋转速度
	public float m_rotSpeed = 30;
	// 生命值
	public float m_life = 10;

	protected Transform m_transform;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateMove();
	}

	protected virtual void UpdateMove () {
		// 左右移动
		float rx = Mathf.Sin(Time.time) * Time.deltaTime;
		// 前进
		m_transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log("Enemy trigger");
		if (other.tag.CompareTo ("PlayerRocket") == 0) {
			Rocket rocket = other.GetComponent<Rocket> ();
			if (rocket != null) {
				m_life -= rocket.m_power;
				if (m_life <= 0) {
					Destroy (this.gameObject);
				}
			}
			Debug.Log ("Enemy trigger rocket");
		} else if (other.tag.CompareTo ("Player") == 0) {
			m_life = 0;
			Destroy (this.gameObject);
			Debug.Log ("Enemy trigger player");
		} else if (other.tag.CompareTo("bound") == 0) {
			m_life = 0;
			Destroy (this.gameObject);
			Debug.Log ("Enemy trigger bound");
		}
	}
}
