using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour {

	private AudioSource _myAudioSource;

	void Start (){
		_myAudioSource = GetComponent<AudioSource>();
	}

	public void ChangeScene (string sceneName){

		_myAudioSource.Play ();
		SceneManager.LoadScene (sceneName);
	}

	public void ExitGame (){
		_myAudioSource.Play ();
		Application.Quit ();
	}
}
