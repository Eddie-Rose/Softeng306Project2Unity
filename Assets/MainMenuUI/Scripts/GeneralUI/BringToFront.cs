using UnityEngine;
using System.Collections;

public class BringToFront : MonoBehaviour
{

    // Ensures a UI object is set to the front of the screen.
    void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}
