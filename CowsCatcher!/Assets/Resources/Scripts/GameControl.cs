using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
	public GameObject endLevelPanel;
	public static GameObject endingPanel;

	public static bool gameOver;

	public static bool gameWon;
    // Start is called before the first frame update
    void Start()
    {
		endingPanel = endLevelPanel;
		endingPanel.SetActive(false);

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
		endingPanel.SetActive(true);
	}

	public static void LostTheGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
