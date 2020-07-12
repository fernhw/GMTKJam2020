

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public float speed = 1;


    public void GameUpdate(PenguinData charData, InputsManager input)
    {
        bool movingRight = ( input.movement.x > 0 );
        bool movingLeft = ( input.movement.x < 0 );

       // charData.wandAngle;

    }
}
