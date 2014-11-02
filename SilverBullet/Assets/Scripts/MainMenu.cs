using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width/2-75, Screen.height-150, 150, 75), "Play"))
        {
            Application.LoadLevel("Main");
        }
    }
}
