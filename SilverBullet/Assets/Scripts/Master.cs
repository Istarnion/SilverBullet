using UnityEngine;
using System.Collections;

public class Master : MonoBehaviour {

    public GUITexture fader;
    public float fadeSpeed = .2f;
    public GUIText hudText;

    void Awake()
    {
        hudText.text = "";
        fader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        fader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        fader.color = Color.clear;
        hudText.color = Color.clear;
        while(fader.color.a <= 0.95)
        {
            hudText.color = Color.Lerp(hudText.color, Color.white, 0.1f);
            fader.color = Color.Lerp(fader.color, Color.black, 0.005f);
            yield return new WaitForSeconds(0.016f);
        }
        hudText.color = Color.white;
        fader.color = Color.black;
    }

    public IEnumerator FadeIn()
    {
        fader.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        fader.color = Color.black;
        while (fader.color.a >= 0.05)
        {
            fader.color = Color.Lerp(fader.color, Color.clear, fadeSpeed);
            yield return new WaitForSeconds(0.016f);
        }
        fader.color = Color.clear;
    }

    public void EndGame(bool victory)
    {
        GameObject player = GameObject.FindWithTag("Player");
        foreach(MonoBehaviour mb in player.GetComponents<MonoBehaviour>())
        {
            mb.enabled = false;
        }
        foreach (MonoBehaviour mb in player.GetComponentsInChildren<MonoBehaviour>())
        {
            mb.enabled = false;
        }
        Screen.lockCursor = false;
        if(victory)
        {
            hudText.text = "You survived!";
            StartCoroutine(FadeOut());
        }
        else
        {
            hudText.text = "You are delicious!";
            StartCoroutine(FadeOut());
        }
    }
}
