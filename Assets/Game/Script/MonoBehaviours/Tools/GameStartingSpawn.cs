


using UnityEngine;

/// <summary>
/// Identifier monobehaviour to set spawn
/// </summary>

public class GameStartingSpawn :MonoBehaviour
{

    private void OnDrawGizmos () {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.localPosition, 0.2f);
        Gizmos.DrawCube(transform.localPosition,new Vector3(0.1f,0.1f,0.1f));
    }

}
