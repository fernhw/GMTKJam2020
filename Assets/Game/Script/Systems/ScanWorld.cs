

using UnityEngine;

public struct ScanWorld {

    public static void Parse (ref World world, MonoBehaviour[] monoBehaviours) {

        int sizeOfAll = monoBehaviours.Length;
        for (int i = 0; i < sizeOfAll; i++) {
            MonoBehaviour behaviour = monoBehaviours[i];

            //bullets
            var isBullet = behaviour.GetComponent(typeof(Bullet)) as Bullet;
            if (isBullet != null) {
                isBullet.gameObject.SetActive(false);
                world.bulletPool.Add(isBullet);
                continue;
            }

            //Aliens
            var isAlien = behaviour.GetComponent(typeof(Alien)) as Alien;
            if (isAlien != null) {
                isAlien.gameObject.SetActive(false);
                world.alienPool.Add(isAlien);
                continue;
            }

        }

    }
}