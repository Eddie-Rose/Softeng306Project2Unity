using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class GeneralTest {

    [Test]
    public void GeneralTestSimplePasses() {
        // Use the Assert class to test conditions.
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
