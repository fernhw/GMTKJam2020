

using UnityEngine;

public class EndGameSpawn : MonoBehaviour {


    private void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.localPosition, 0.2f);
        Gizmos.DrawCube(transform.localPosition, new Vector3(0.1f, 60f, 0.1f));
        Gizmos.DrawCube(transform.localPosition, new Vector3(0.1f, 0.1f, 60f));
    }

}

