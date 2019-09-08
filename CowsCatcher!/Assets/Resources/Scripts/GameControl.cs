using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
	public static bool gameOver;

	public static bool gameWon;
    // Start is called before the first frame update
    void Start()
    {
		gameOver = false;

		gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (gameWon)
		{
			WonTheGame();
		}
		if (gameOver)
		{
			LostTheGame();
		}
    }

	public static void WonTheGame()
	{
		Debug.Log("Congratulations! You Won The Game!");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public static void LostTheGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
