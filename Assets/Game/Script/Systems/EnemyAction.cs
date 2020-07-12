




using UnityEngine;

public class EnemyAction {

    public static void Parse (ref Data data, ref World world, Deltas delta, InputsManager controls, Settings settings) {

        Vector3 cameraPosition = world.cam.transform.localPosition;
        Vector3 characterPos = world.penguinObj.transform.localPosition;

        float cameraUpperBound = cameraPosition.y + settings.cameraBounds.y;
        float cameraLowerBound = cameraPosition.y - settings.cameraBounds.y;
        float cameraRightBound = cameraPosition.x + settings.cameraBounds.x;
        float cameraLeftBound = cameraPosition.x - settings.cameraBounds.x;

        characterPos.y += settings.penguinYUpPivotFix;

        int alienPoolLen = world.alienPool.Count;

        int activeAlienIndex = 0;

        // pick innactive alien
        for (int i = 0; i < alienPoolLen; i++) {
            Alien indexAlien = world.alienPool[i];
            if (!indexAlien.active) {
                activeAlienIndex = i;
                break;
            }
        }


        // ACTIVATE first inactive alien
        if (controls.actionButton) {
            world.alienPool[activeAlienIndex].gameObject.SetActive(true);
            world.alienPool[activeAlienIndex].active = true;
            world.alienPool[activeAlienIndex].transform.localPosition = characterPos;
            world.alienPool[activeAlienIndex].transform.localEulerAngles = new Vector3(0, 0, data.angleToMouse);
        }


        // animate aliens
        for (int i = 0; i < alienPoolLen; i++) {

            Alien movingAlien = world.alienPool[i];

            if (!movingAlien.active)
                continue;

            Vector3 alienPosition = movingAlien.transform.localPosition;
            Vector3 alienAngle = movingAlien.transform.localEulerAngles;

            Vector3 alienMovement = new Vector3(Mathf.Cos(alienAngle.z * Mathf.Deg2Rad), Mathf.Sin(alienAngle.z * Mathf.Deg2Rad), 0); ;

            Vector3 newAlienPosition = alienPosition + alienMovement * delta.actionDelta * settings.alienSpeed;

            movingAlien.transform.localPosition = newAlienPosition;
            alienPosition = movingAlien.transform.localPosition;

            if (alienPosition.x > cameraRightBound ||
                alienPosition.x < cameraLeftBound ||
                alienPosition.y > cameraUpperBound ||
                alienPosition.y < cameraLowerBound) {
                movingAlien.gameObject.SetActive(false);
                movingAlien.active = false;
            }

        }

    }

}
