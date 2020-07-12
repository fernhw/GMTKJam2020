

using UnityEngine;

/// <summary>
/// Class to identify main camera
/// </summary>
public class MainCamera : MonoBehaviour
{
    [HideInInspector]
    public Camera camera;
    
    void Start () {
        camera = gameObject.GetComponent(typeof(Camera)) as Camera;
    }
}
