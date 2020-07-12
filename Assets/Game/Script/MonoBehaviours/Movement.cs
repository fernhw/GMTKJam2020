

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public float speed = 1;
    Animator anime;

    public SpriteRenderer penguinRenderer;

    readonly string walk = "walk";

    private void Start () {
        anime = penguinRenderer.GetComponent<Animator>();
    }

    public void GameUpdate(PenguinData charData, InputsManager input)
    {
        

        bool movingRight = ( input.movement.x > 0 );
        bool movingLeft = ( input.movement.x < 0 );

        if (movingRight)
        {
            penguinRenderer.flipX = true;
            anime.SetBool(walk, true);
        }
        else
        {
            penguinRenderer.flipX = false;
            anime.SetBool(walk, false);
        }       

        // charData.wandAngle;

    }
}
