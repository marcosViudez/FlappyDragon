using UnityEngine;
using System.Collections;

public class DragonManager : MonoBehaviour {

	//Variable para acceder al componente Animator
	private Animator _myAnimator;

	//Velocidad de Player
	private Vector3 velocity;
	//Gravedad que afecta al Player
	public Vector3 gravity;
	//Velocidad de salto
	public Vector3 jumpVelocity;
	//Comprobar si player está haciendo un salto
	private bool isJumping;
	//Variable para gestionar la velocidad máxima de rotación
	public float topRotationSpeed;


	void Start () {
	
		_myAnimator = GetComponent<Animator>();
	}

	void GameStart (){
		//Establecemos en true, el parámetro de cambiar a animación de movimiento
		_myAnimator.SetBool ("DragonMov", true);
	}

	void GameOver (){
		_myAnimator.SetBool ("DragonMov", false);
	}

	void Update (){

		if (GameManager.gameStart){
			
			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)){
				isJumping = true;	
			}
		}

	}


	void FixedUpdate (){

		//Si el juego ya ha iniciado
		if (GameManager.gameStart){

			//Aplicar una fuerza a Player, dada por la gravedad
			velocity += gravity * Time.deltaTime;

			//Detecta orden de salto dada desde el Update
			if (isJumping){
				isJumping = false;
				//Aplicarle una fuerza en Y, seteando el valor de Y de velocity, con el el valor establecido para jumpVelocity
				velocity.y = jumpVelocity.y;
			}

			//Establece la posición de Player
			transform.position += velocity * Time.deltaTime;

			//Gestion de rotación de player
			float angle = 0;

			if (velocity.y >= 0){
				angle = Mathf.Lerp (0, 25, velocity.y/topRotationSpeed);
			}else {
				angle = Mathf.Lerp (0, -25, -velocity.y/topRotationSpeed);
			}

			//Establemos la rotación del player
			transform.rotation = Quaternion.Euler (0, 0, angle);
		}
	}

}
