using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene("SampleScene");
	}
	
	public void Back()
	{
		SceneManager.LoadScene("Menu");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}    