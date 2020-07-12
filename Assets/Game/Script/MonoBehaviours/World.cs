using UnityEngine;

/// <summary>
/// Receive all objects, doesn't manipulate them only for access
/// </summary>
public class World : MonoBehaviour
{
    [HideInInspector]
    public Movement penguinObj;

    [HideInInspector]
    public MainCamera cam;

    // main spawn objects
    [HideInInspector]
    public GameStartingSpawn gameStartingSpawn;

    [HideInInspector]
    public EndGameSpawn endGameSpawn;




}
