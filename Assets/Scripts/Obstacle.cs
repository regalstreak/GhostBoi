using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private Shake shake;
	public int damage;
	public float speed;
	public GameObject effect;

	// Use this for initialization
	void Start () {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player")){
			Instantiate(effect, transform.position, Quaternion.identity);
			other.GetComponent<Player>().health -= damage;
            shake.CamShake();
			Destroy(gameObject);

		}
	}
}
