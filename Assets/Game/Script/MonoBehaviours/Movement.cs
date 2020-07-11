using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public float speed = 1;


    public void GameUpdate(Deltas delta, InputsManager input)
    {

        // All postion will be given through the Game Runner class, this is an example.

        float x_translation = input.movement.x * speed * delta.actionDelta;
        float z_translation = input.movement.y * speed * delta.actionDelta;

        Vector3 translation = new Vector3(x_translation, 0, z_translation);
        transform.Translate(translation * (speed*Time.deltaTime));
    }
}
