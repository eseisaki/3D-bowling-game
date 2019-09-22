using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class MainMenu : MonoBehaviour {

public void NewGameBtn(string NewGameLevel)
	{
		SceneManager.LoadScene (NewGameLevel);
	}

public void ExitGameBtn(){
		Application.Quit();
	}
}

