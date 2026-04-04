using UnityEngine;

namespace KinghtAdventure.Utils 
{
    public static class Utils
    {
        public static Vector3 GetRandomDirection() => new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
