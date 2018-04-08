using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeButtonController : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {

	    if (Input.GetKey(KeyCode.Escape))
	    {
	        var backButton = GameObject.Find("backbutton");

	        if (backButton != null)
	        {
	            var btn = backButton.GetComponent<Button>();
	            btn.onClick.Invoke();
	        }
        }
    }
}
