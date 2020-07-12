using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : MonoBehaviour
{
    [SerializeField] GameObject ArmSprite;
    [SerializeField] float angle = 0;

    Vector3 pivot;

    // Start is called before the first frame update
    void Start()
    {
        pivot = transform.forward;        
    }

    // Update is called once per frame
    void Update()
    {
        ArmSprite.transform.RotateAround(transform.position, pivot, angle * Time.deltaTime);   
    }

    public void GameUpdate(Deltas delta, InputsManager input)
    {
        //GameRunner shall call this to rotate arm to angle         
    }
}
