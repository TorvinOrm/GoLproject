using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void MainMenuAction(int actionNr){
		switch (actionNr){
		case 0:
			Application.Quit();
			break;

		case 1:
			SceneManager.LoadScene ("DrawCard");
			break;
		}
	}
}
