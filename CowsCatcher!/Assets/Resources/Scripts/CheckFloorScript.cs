using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloorScript : MonoBehaviour
{
	public Sprite czek;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.tag == "Player")
		{
			GetComponent<SpriteRenderer>().sprite = czek;
			transform.tag = "Checked";
			GetComponent<BoxCollider2D>().isTrigger = false;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.transform.tag == "Player")
		{
		}
	}
}
