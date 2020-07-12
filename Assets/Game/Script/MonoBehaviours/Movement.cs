

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
    readonly string die = "die";
    //readonly string dback = "diagonal_back";
    //readonly string backward = "backward";

    bool disableWalkingAnim = false;

    [SerializeField] public float wandangle;

    IEnumerator forward_pose () {
        disableWalkingAnim = true;

        yield return new WaitForSeconds(1);

        disableWalkingAnim = false;
    }

    private void Start () {
        anime = penguinRenderer.GetComponent<Animator>();
    }
    string animationCurrent = "";
    public void GameUpdate (PenguinData charData, InputsManager input, ref Data data, Settings settings, World world) {
        wandangle = charData.wandAngle;

        bool movingRight = ( data.xPush < -0.001f );
        bool movingLeft = ( data.xPush > 0.001f );

        if (movingRight) {
            penguinRenderer.flipX = false;            
        } else if (movingLeft) {
            penguinRenderer.flipX = true;
        }

        if (input.quak) {
            anime.PlayInFixedTime("quack");
            world.quack.Play();
        }


        if (input.actionButton) {
            if (wandangle >= -30 && wandangle < 30) {
                penguinRenderer.flipX = false;
                anime.PlayInFixedTime(forward);
                animationCurrent = forward;
            } else if (wandangle >= 30 && wandangle < 60) {
                penguinRenderer.flipX = false;
                anime.PlayInFixedTime(dforward);
                animationCurrent = dforward;
            } else if (wandangle >= 60 && wandangle < 120) {
                penguinRenderer.flipX = false;
                anime.PlayInFixedTime(upward);
                animationCurrent = upward;
            } else if ((wandangle >= 120 && wandangle < 150)) {
                penguinRenderer.flipX = true;
                anime.PlayInFixedTime(dforward);
                animationCurrent = dforward;
            } else if (wandangle >= 150 || wandangle < -150) {
                penguinRenderer.flipX = true;
                anime.PlayInFixedTime(forward);
                animationCurrent = forward;
            }

            data.disableWalk = true;
            disableWalkingAnim = true;
            StopAllCoroutines();
            StartCoroutine(forward_pose());
        }


        // Enemy deaths

        int alienPoolLen = world.alienPool.Count;
        for (int i = 0; i < alienPoolLen; i++) {
            Alien movingAlien = world.alienPool[i];
            Vector3 alienPosition = movingAlien.transform.localPosition;

            float xDist = ( alienPosition.x - this.transform.localPosition.x );
            float yDist = ( alienPosition.y - this.transform.localPosition.y );
            float distance = xDist * xDist + yDist * yDist;

            if (distance < 0.8f) {

                world.gameOver.Play();
               // Debug.Log("dead");
                anime.PlayInFixedTime(die);
                data.gameStatus = GameState.GAME_OVER;
            } else {
                //Debug.Log("alive");
            }
        }




        if (disableWalkingAnim)
            return;

        data.disableWalk = false;

        movingRight = ( input.movement.x > 0 ) || ( data.xPush < -0.001f );
        movingLeft = ( input.movement.x < 0 ) || ( data.xPush > 0.001f );

        if (movingRight) {
            penguinRenderer.flipX = false;
            if (animationCurrent != walk) {
                anime.Play(walk);
                animationCurrent = walk;
               // Debug.Log("walllll");
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