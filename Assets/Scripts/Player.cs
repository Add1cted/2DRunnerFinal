using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private Vector2 targetPos;
	public float yIncrement;

	public float speed;
	public float maxHeight;
	public float minHeight;

	public GameObject gameOver;
	public GameObject effect;
	private Shake shake;
	public Text healthDisplay;
	public GameObject popSound;

	public int health;

	void Start(){
		shake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponent<Shake>();
	}

	void Update ()
	{
		healthDisplay.text = "HP: " + health.ToString ();

		if (health <= 0) {
			gameOver.SetActive (true);
			Destroy (GameObject.FindWithTag("Player"));
			Time.timeScale = 0;
		}
		transform.position = Vector2.MoveTowards (transform.position, targetPos, speed*Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.W) && transform.position.y<maxHeight){
			Instantiate (effect, transform.position, Quaternion.identity);
			shake.CamShake ();
			Instantiate (popSound, transform.position, Quaternion.identity);
			targetPos	= new Vector2(0, transform.position.y + yIncrement);
		}
		else if(Input.GetKeyDown(KeyCode.S) && transform.position.y>minHeight){
			Instantiate (effect, transform.position, Quaternion.identity);
			shake.CamShake ();
			Instantiate (popSound, transform.position, Quaternion.identity);
			targetPos	= new Vector2(0, transform.position.y - yIncrement);
		}
	}
}
