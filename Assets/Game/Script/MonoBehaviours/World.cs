using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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


    [HideInInspector]
    public List<Alien> alienPool;

    [HideInInspector]
    public List<Bullet> bulletPool;


    public AudioSource spell2;

    public AudioSource quack;

    public AudioSource enemydeath;



}
