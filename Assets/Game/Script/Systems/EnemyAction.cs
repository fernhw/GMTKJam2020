




using UnityEngine;



public class EnemyAction {

    public static void Parse (ref Data data, ref World world, Deltas delta, InputsManager controls, Settings settings) {

        bool createAlien = false;
        data.alienTimer += delta.actionDelta * settings.alienAppearance;

        if(data.alienTimer > 1) {
            createAlien = true;
            data.alienTimer = 0;
        }

        Vector3 cameraPosition = world.cam.transform.localPosition;
        Vector3 characterPos = world.penguinObj.transform.localPosition;

        float cameraUpperBound = cameraPosition.y + settings.cameraBounds.y;
        float cameraLowerBound = cameraPosition.y - settings.cameraBounds.y;
        float cameraRightBound = cameraPosition.x + settings.cameraBounds.x;
        float cameraLeftBound = cameraPosition.x - settings.cameraBounds.x;

        characterPos.y += settings.penguinYUpPivotFix;

        int alienPoolLen = world.alienPool.Count;
        int bulletPoolLen = world.bulletPool.Count;

        int activeAlienIndex = 0;
        bool areThereActiveAlien = false;
        // pick innactive alien
        for (int i = 0; i < alienPoolLen; i++) {
            Alien indexAlien = world.alienPool[i];
            if (!indexAlien.active) {
                activeAlienIndex = i;
                areThereActiveAlien = true;
                break;
            }
        }


        // ACTIVATE first inactive alien
        if (createAlien && areThereActiveAlien) {

            Vector3 positionSpawn = new Vector3();

            int quadrant = Mathf.RoundToInt(Random.value * 2) + 1;

            float randomizer = Random.value * 16 - 8;

            if (quadrant == 1) {

                positionSpawn.x = cameraLeftBound;
                positionSpawn.y = Mathf.Abs(randomizer - 1) + 1;
            } else {

                positionSpawn.x = cameraRightBound;
                positionSpawn.y = Mathf.Abs(randomizer - 1) + 1;
            }

            positionSpawn.z = world.gameStartingSpawn.transform.localPosition.z;

            world.alienPool[activeAlienIndex].gameObject.SetActive(true);
            world.alienPool[activeAlienIndex].active = true;
            world.alienPool[activeAlienIndex].transform.localPosition = positionSpawn;
            world.alienPool[activeAlienIndex].transform.localEulerAngles = new Vector3(0, 0, 0);

        }


        // animate aliens
        for (int i = 0; i < alienPoolLen; i++) {

            Alien movingAlien = world.alienPool[i];

            if (!movingAlien.active)
                continue;

            Vector3 alienPosition = movingAlien.transform.localPosition;
            Vector3 alienAngle = movingAlien.transform.localEulerAngles;

            Vector3 anglePosToChar = alienPosition - characterPos;

            float angle = Mathf.Atan2(-anglePosToChar.y, -anglePosToChar.x);

            Vector3 alienMovement = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0); ;

            Vector3 newAlienPosition = alienPosition + alienMovement * delta.actionDelta * settings.alienSpeed;

            movingAlien.transform.localPosition = newAlienPosition;
            alienPosition = movingAlien.transform.localPosition;

            for (int j = 0; j < bulletPoolLen; j++) {
                Bullet bullet = world.bulletPool[j];
                float xDist = ( alienPosition.x - bullet.transform.localPosition.x );
                float yDist = ( alienPosition.y - bullet.transform.localPosition.y );
                float distance = xDist* xDist + yDist*yDist;

                if(distance < .1f) {
                    movingAlien.active = false;
                    movingAlien.gameObject.SetActive(false);
                }

            }
        }
    }
}
