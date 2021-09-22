using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Consultar desde cualquier clae, el estado del juego
	public static bool gameStart = false;

	//Referencia de GameObject del jugador
	public GameObject dragonPlayer;

	//Variable de puntaje
	private int score = 0;
	public Text textScore;

	//Gestion de Game Over
	public GameObject panelGameOver;
	public Text textScoreGameOver;
	public Text textTopScore;

	//Gestion de Top Score
	private int topScore;

	void Start () {
		gameStart = false;

		textScore.text = "";

		//Leer el valor almacenado en PlayerPref
		topScore = PlayerPrefs.GetInt ("TopScore");
	}

	void Update () {
	
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)){
			gameStart = true;
			dragonPlayer.SendMessage ("GameStart");
			textScore.text = score.ToString();
		}

	}

	void UpdateScore (){
		score++;
//		Debug.Log ("Score= "+score);
		textScore.text = score.ToString();
	}

	void GameOver (){
		//Si el puntaje es mayor que Top Score, se almacena
		if (score > topScore){
			PlayerPrefs.SetInt ("TopScore", score);
			topScore = score;
		}
		panelGameOver.SetActive (true);
		//Seteamos el texto con el puntaje actual
		textScoreGameOver.text = "Score   "+score.ToString();
		//Seteamos el texto con el puntaje maximo
		textTopScore.text = "Top Score   "+topScore.ToString();
	}
}
