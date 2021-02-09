using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {

        StartCoroutine(FadeScene());

    }

    IEnumerator FadeScene()
    {
        float time = GameObject.Find("FadeScreen").GetComponent<Fade>().BeginFade(1);
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }    

}
