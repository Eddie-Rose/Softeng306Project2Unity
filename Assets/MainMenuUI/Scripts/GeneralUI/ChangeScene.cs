using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public CanvasGroup fadeOutImageCanvasGroup;
    public GameObject menuCanvasGroup;
    public GameObject menuObject;

    private int sceneNum;

    // Starts a change in scene
    public void GoToScene(int scene) {
        Invoke("LoadDelayed", 1);
        sceneNum = scene;

        // Carries out a fade duing a scene change
        StartCoroutine(FadeCanvasGroupAlpha(0f, 1f, fadeOutImageCanvasGroup));
    }

    // Launches the scene once the fade has completed
    public void LoadDelayed() {

        // Destroys the main-menu scene (index 0) if its being relaunched
        if (sceneNum == 0) {
            Destroy(GameObject.Find("Menu UI"));
        }

        //Load the selected scene, by scene index number in build settings
        SceneManager.LoadScene(sceneNum);
    }

    // Carries out a fade of the screen while removing currently visible canvas
    public IEnumerator FadeCanvasGroupAlpha(float startAlpha, float endAlpha, CanvasGroup canvasGroupToFadeAlpha)
    {

        float elapsedTime = 0f;
        float totalDuration = 1;

        // Fade
        while (elapsedTime < totalDuration)
        {
            elapsedTime += Time.deltaTime;
            float currentAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / totalDuration);
            canvasGroupToFadeAlpha.alpha = currentAlpha;
            yield return null;
        }

        // Remove current visible canvas
        menuCanvasGroup.SetActive(false);
    }
}
