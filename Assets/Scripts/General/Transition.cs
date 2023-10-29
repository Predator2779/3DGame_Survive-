using UnityEngine;

namespace General
{
    public class Transition
    {
        public void MoveObjects(GameObject[] objs, Vector3 position)
        {
            var length = objs.Length;

            for (int i = 0; i < length; i++)
                MoveObject(objs[i], position);
        }

        public void MoveObject(GameObject obj, Vector3 position) => obj.transform.position = position;
    }
}