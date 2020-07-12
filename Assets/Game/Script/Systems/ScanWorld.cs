

using UnityEngine;

public struct ScanWorld {

    public static void Parse (ref World world, MonoBehaviour[] monoBehaviours) {

        int sizeOfAll = monoBehaviours.Length;
        for (int i = 0; i < sizeOfAll; i++) {
            MonoBehaviour behaviour = monoBehaviours[i];

            //bullets
            var isBullet = behaviour.GetComponent(typeof(Bullet)) as Bullet;
            if (isBullet != null) {
                world.bulletPool.Add(isBullet);
                continue;
            }

            //Aliens
            var isAlien = behaviour.GetComponent(typeof(Bullet)) as Bullet;
            if (isAlien != null) {
                world.bulletPool.Add(isAlien);
                continue;
            }

        }

    }
}