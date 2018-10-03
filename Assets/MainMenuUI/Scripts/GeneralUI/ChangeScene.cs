using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public CanvasGroup fadeOutImageCanvasGroup;
    public GameObject menuCanvasGroup;

    private int sceneNum;

    void Awake()
    {

        //Get a reference to the CanvasGroup attached to the main menu so that we can fade it's alpha
        //menuCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void GoToScene(int scene) {
        Invoke("LoadDelayed", 1);
        sceneNum = scene;

        StartCoroutine(FadeCanvasGroupAlpha(0f, 1f, fadeOutImageCanvasGroup));
    }

    public void LoadDelayed()
    {

        //Load the selected scene, by scene index number in build settings
        SceneManager.LoadScene(sceneNum);
    }

    public IEnumerator FadeCanvasGroupAlpha(float startAlpha, float endAlpha, CanvasGroup canvasGroupToFadeAlpha)
    {

        float elapsedTime = 0f;
        float totalDuration = 1;

        while (elapsedTime < totalDuration)
        {
            elapsedTime += Time.deltaTime;
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / totalDuration);
            canvasGroupToFadeAlpha.alpha = currentAlpha;
            yield return null;
        }
        menuCanvasGroup.SetActive(false);

        Debug.Log("Coroutine done. Game started in same scene! Put your game starting stuff here.");
    }
}
