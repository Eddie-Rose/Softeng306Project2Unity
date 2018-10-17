using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections;

public class GeneralTest {

    [Test]
    //Ensure Hire panel active on startup or else errors occur on actual play time
    public void StartUp_Hire_IsActive() {
        // Use the Assert class to test conditions.
        Scene mainScene = EditorSceneManager.OpenScene("Assets/Scenes/Level1v2.unity");
        GameObject[] allGameObjects = mainScene.GetRootGameObjects();
        GameObject eventCanvas = null;
        foreach(GameObject obj in allGameObjects)
        {
            if (obj.name == "EventCanvas")
            {
                eventCanvas = obj;
            }
        }

        GameObject result = eventCanvas.transform.Find("HirePanel").gameObject;

        bool hirePanelIsActive = result.activeSelf;

        Assert.IsTrue(hirePanelIsActive);

    }

    [Test]
    //Ensure Transfer panel active on startup or else errors occur on actual play time
    public void StartUp_Transfer_IsActive()
    {
        // Use the Assert class to test conditions.
        Scene mainScene = EditorSceneManager.OpenScene("Assets/Scenes/Level1v2.unity");
        GameObject[] allGameObjects = mainScene.GetRootGameObjects();
        GameObject eventCanvas = null;
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.name == "EventCanvas")
            {
                eventCanvas = obj;
            }
        }

        GameObject result = eventCanvas.transform.Find("TransferPanel").gameObject;

        bool transferPanelIsActive = result.activeSelf;

        Assert.IsTrue(transferPanelIsActive);

    }

    [Test]
    //Ensure Current Task panel active on startup or else errors occur on actual play time
    public void StartUp_CurrentTask_IsActive()
    {
        // Use the Assert class to test conditions.
        Scene mainScene = EditorSceneManager.OpenScene("Assets/Scenes/Level1v2.unity");
        GameObject[] allGameObjects = mainScene.GetRootGameObjects();
        GameObject eventCanvas = null;
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.name == "EventCanvas")
            {
                eventCanvas = obj;
            }
        }

        GameObject result = eventCanvas.transform.Find("CurrentTaskPrefab").gameObject;

        bool currentTaskPanelIsActive = result.activeSelf;

        Assert.IsTrue(currentTaskPanelIsActive);

    }

    [Test]
    //Ensure Conflict prefab panel active on startup or else errors occur on actual play time
    public void StartUp_ConflictPrefab_IsActive()
    {
        // Use the Assert class to test conditions.
        Scene mainScene = EditorSceneManager.OpenScene("Assets/Scenes/Level1v2.unity");
        GameObject[] allGameObjects = mainScene.GetRootGameObjects();
        GameObject eventCanvas = null;
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.name == "EventCanvas")
            {
                eventCanvas = obj;
            }
        }

        GameObject result = eventCanvas.transform.Find("ConflictPrefab").gameObject;

        bool conflictPrefabPanelIsActive = result.activeSelf;

        Assert.IsTrue(conflictPrefabPanelIsActive);

    }

    [Test]
    //Ensure CEO (maincharacter) prefab panel available
    public void CheckForMainCharacter()
    {
        // Use the Assert class to test conditions.
        Scene mainScene = EditorSceneManager.OpenScene("Assets/Scenes/Level1v2.unity");
        GameObject[] allGameObjects = mainScene.GetRootGameObjects();
        bool isAvailable = false;
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.name == "CEO")
            {
                isAvailable = true;
            }
        }


        Assert.IsTrue(isAvailable);

    }

    [Test]
    //Ensure CEO (maincharacter) prefab panel available
    public void CheckForsMainCharacter()
    {
        // Use the Assert class to test conditions.
        Scene mainScene = EditorSceneManager.OpenScene("Assets/Scenes/Level1v2.unity");
        GameObject[] allGameObjects = mainScene.GetRootGameObjects();
        GameObject controller = null;
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.name == "ControllerObject")
            {
                controller = obj;
            }
        }

      

        

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator GeneralTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
