using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections;

public class GeneralTest {

    [Test]
    public void StartUp_HireAndTransfer_Inactive() {
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
        GameObject result1 = eventCanvas.transform.Find("TransferPanel").gameObject;
        bool hirePanelIsActive = result.activeSelf;
        bool transferPanelIsActive = result1.activeSelf;



        Assert.IsTrue(transferPanelIsActive);
        Assert.IsTrue(hirePanelIsActive);

    }

    [Test]
    public void TestProposalGeneration()
    {
        


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
