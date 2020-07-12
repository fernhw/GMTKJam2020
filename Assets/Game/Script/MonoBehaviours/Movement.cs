

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement:MonoBehaviour {
    Animator anime;

    public SpriteRenderer penguinRenderer;

    public Sprite[] fpose;

    readonly string walk = "walk";
    readonly string forward = "point_forward";
    readonly string dforward = "point_diagonal";
    readonly string upward = "point_up";

    readonly string idle = "idle";
    //readonly string dback = "diagonal_back";
    //readonly string backward = "backward";

    bool disableWalkingAnim = false;

    [SerializeField] public float wandangle;

    IEnumerator forward_pose () {
        disableWalkingAnim = true;

        yield return new WaitForSeconds(1);
        //    int i = 0;
        //    while (i < 5)
        //   {
        //   penguinRenderer.sprite = fpose[i];
        //   i++;
        //    yield return new WaitForEndOfFrame();
        //yield return 0;
        //  }
        // StartCoroutine(forward_pose()); //stack overflow much?
        //anime.SetBool(forward, false);
        //anime.SetBool(dforward, false);
        //// anime.SetBool(upward, false);
        // anime.SetBool(walk, true);

        disableWalkingAnim = false;
    }

    private void Start () {
        anime = penguinRenderer.GetComponent<Animator>();
    }
    string animationCurrent = "";
    public void GameUpdate (PenguinData charData, InputsManager input, ref Data data, Settings settings) {



        wandangle = charData.wandAngle;

        //Debug.Log(input.click);
        if (input.actionButton) {
            //anime.StopPlayback();
            if (wandangle >= -30 && wandangle < 30) {
                penguinRenderer.flipX = false;
                //    if (animationCurrent != forward)
                anime.PlayInFixedTime(forward);
                animationCurrent = forward;
            } else if (wandangle >= 30 && wandangle < 60) {

                penguinRenderer.flipX = false;
                //   if (animationCurrent != dforward)

                anime.PlayInFixedTime(dforward);
                animationCurrent = dforward;
            } else if (wandangle >= 60 && wandangle < 120) {

                penguinRenderer.flipX = false;
                //   if (animationCurrent != upward)
                anime.PlayInFixedTime(upward);

                animationCurrent = upward;
            } else if (wandangle >= 120 && wandangle < 150) {

                penguinRenderer.flipX = true;
                //if (animationCurrent != dforward)
                anime.PlayInFixedTime(dforward);

                anime.playbackTime = 0;
                animationCurrent = dforward;
            } else if (wandangle >= 150 || wandangle < -150) {

                penguinRenderer.flipX = true;
                //   if (animationCurrent != forward)
                anime.PlayInFixedTime(forward);

                anime.playbackTime = 0;
                animationCurrent = forward;
            }
            data.disableWalk = true;
            disableWalkingAnim = true;
            StopAllCoroutines();
            StartCoroutine(forward_pose());
        }

        if (disableWalkingAnim)
            return;

        data.disableWalk = false;

        bool movingRight = ( input.movement.x > 0 );
        bool movingLeft = ( input.movement.x < 0 );

        if (movingRight) {
            penguinRenderer.flipX = false;
            if (animationCurrent != walk) {
                anime.Play(walk);
                animationCurrent = walk;
                Debug.Log("walllll");
            }
        } else if (movingLeft) {
            penguinRenderer.flipX = true;
            if (animationCurrent != walk) {
                anime.Play(walk);
                animationCurrent = walk;
                Debug.Log("walllll");
            }
        } else {
            if (animationCurrent != idle) {
                anime.Play(idle);
                animationCurrent = idle;
                Debug.Log("idl");
            }
        }


    }
}
