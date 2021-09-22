using UnityEngine;
using System.Collections;

public class ColliderManager : MonoBehaviour {


	//Referencia de GameManager
	private GameManager _gameManager;

	void Start (){
		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.tag == "Player"){
			Debug.Log ("Game Over!!!");
			//Envia mensaje de Game Over a Dragon Manager
			other.transform.SendMessage ("GameOver");
			other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
			//Comunicaicion con Game Manager
			GameManager.gameStart = false;
			_gameManager.transform.SendMessage ("GameOver");
		}
	}

}
