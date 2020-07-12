

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator anime;

    public SpriteRenderer penguinRenderer;

    public Sprite[] fpose;

    readonly string walk = "walk";
    readonly string forward = "forward";
    readonly string dforward = "diagonal_forward";
    readonly string upward = "upward";
    readonly string dback = "diagonal_back";
    readonly string backward = "backward";

    [SerializeField] public float wandangle;

    IEnumerator forward_pose()
    {
        int i = 0;
        while (i < fpose.Length)
        {
            penguinRenderer.sprite = fpose[i];
            i++;
            yield return new WaitForSeconds(0.05f);
            yield return 0;
        }
        StartCoroutine(forward_pose());
    }

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
        Debug.Log(input.click);
        if (!input.actionButton)
        {
            if (wandangle >= -30 && wandangle < 30)
            {
                /*anime.SetBool(forward, true);
                anime.SetBool(dforward, false);
                anime.SetBool(upward, false);
                anime.SetBool(dback, false);
                anime.SetBool(backward, false);*/
                StopAllCoroutines();
                StartCoroutine(forward_pose());
            }
            else if (wandangle >= 30 && wandangle < 60)
            {
                anime.SetBool(forward, false);
                anime.SetBool(dforward, true);
                anime.SetBool(upward, false);
                anime.SetBool(dback, false);
                anime.SetBool(backward, false);
            }
            else if (wandangle >= 60 && wandangle < 120)
            {
                anime.SetBool(forward, false);
                anime.SetBool(dforward, false);
                anime.SetBool(upward, true);
                anime.SetBool(dback, false);
                anime.SetBool(backward, false);
            }
            else if (wandangle >= 120 && wandangle < 150)
            {

            }
            else if (wandangle >= 150 || wandangle < -150)
            {

            }
        }



    }
}
