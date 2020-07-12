

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator anime;

    public SpriteRenderer penguinRenderer;

    readonly string walk = "walk";

    [SerializeField] public float wandangle;

    private void Start () {
        anime = penguinRenderer.GetComponent<Animator>();
    }

    public void GameUpdate(PenguinData charData, InputsManager input)
    {        

        bool movingRight = ( input.movement.x > 0 );
        bool movingLeft = ( input.movement.x < 0 );

        if (movingRight)
        {
            penguinRenderer.flipX = false;
            anime.SetBool(walk, true);
        }
        else if (movingLeft)
        {
            penguinRenderer.flipX = true;
            anime.SetBool(walk, true);
        }
        else
        {
            anime.SetBool(walk, false);
        }

        wandangle = charData.wandAngle;
        //Debug.Log(input.click);
        if (input.actionButton)
        {
            Debug.Log("CLICKED");
            Debug.Log(wandangle);
        }



    }
}
