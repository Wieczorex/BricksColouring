using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
	
	public Animator transitionAnimator;
    // Start is called before the first frame update
    void Start()
    {
		transitionAnimator.SetBool("SceneEnds", false);
    }

	public void HeadToNextLevel()
	{
		StartCoroutine("LoadScene");
	}

	IEnumerator LoadScene()
	{
		transitionAnimator.SetBool("SceneEnds", true);
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
