



using UnityEngine;



public class CharacterLaunching
{

    public static void Parse(ref Data data, ref World world, Deltas delta, InputsManager controls, Settings settings)
    {


        Vector3 characterPos = world.penguinObj.transform.localPosition;

        characterPos.x += data.xPush * delta.actionDelta * 2;

        data.gravity += ( -4 - data.gravity ) * delta.actionDelta * 1;
        characterPos.y += data.gravity * delta.actionDelta * 2;
        Debug.Log(data.gravity);
        if (characterPos.y < 0) {
            characterPos.y = 0;
            data.gravity = 0;
        }
        if(characterPos.y == 0) {
            data.xPush += ( 0 - data.xPush ) * delta.actionDelta * 10;
            data.gravity = 0;
        }

        if (characterPos.y > 2.9f)
            characterPos.y = 2.9f;

        if (characterPos.x < -1.4f)
            characterPos.x = -1.4f;

        world.penguinObj.transform.localPosition = characterPos;

    }

}
