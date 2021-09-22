using UnityEngine;
using System.Collections;

public class PipesManager : MonoBehaviour {

	//Variable encargada de gestionar la velocidad con que se mueven los tubos
	public Vector3 velocity;

	//Variable de distancia entre tubos
	public Vector3 pipeDistance;

	//Referencia de GameManager
	private GameManager _gameManager;

	//Gestion de puntaje
	private bool addingScore = false;

	void Start (){
		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	void Update () {
	
		if (GameManager.gameStart){

			//Mueve los tubos en dirección de la velocidad que se indique, en este caso la vamos a setar en negativa en dirección X
			transform.position = transform.position += (velocity * Time.deltaTime);

			//Si la posición del tubo es menor que -5, cambiamos su posición más a la derecha
			if (transform.position.x < -5f){

				Vector3 tempPosition = transform.position + pipeDistance;
				//Posicion aleatoria de los tubos en Y
				tempPosition.y = Random.Range (-2f, -5f);
				//Setea la posición con los valores de tempPosition
				transform.position = tempPosition;
				addingScore = false;
			}

			//Gestión del puntaje
			if (transform.position.x <-3f && !addingScore){
				_gameManager.transform.SendMessage ("UpdateScore");
				addingScore = true;
			}
		}
	}
}
