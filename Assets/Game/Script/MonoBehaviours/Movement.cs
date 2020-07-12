

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public float speed = 1;
    Animator anime;
    readonly string walk = "walk";


    public void GameUpdate(PenguinData charData, InputsManager input)
    {
        anime = GetComponent<Animator>();

        bool movingRight = ( input.movement.x > 0 );
        bool movingLeft = ( input.movement.x < 0 );

        if (movingRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            anime.SetBool(walk, true);
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            anime.SetBool(walk, false);
        }       

        // charData.wandAngle;

    }
}
