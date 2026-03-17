using UnityEngine;

namespace Utils
{
    public class CirclePlacer : MonoBehaviour
    {
        public GameObject prefab;
        public int count = 8;
        public float radius = 2f;
        public float angleOffset = 0f;
        public bool lookAtCenter = true;

        public void Place()
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

            for (var i = 0; i < count; i++)
            {
                var angle = i * Mathf.PI * 2f / count + angleOffset * Mathf.Deg2Rad;

                var pos = new Vector3(
                    Mathf.Cos(angle) * radius,
                    0,
                    Mathf.Sin(angle) * radius
                );

                var obj = Instantiate(prefab, transform);
                obj.transform.localPosition = pos;

                if (lookAtCenter)
                    obj.transform.LookAt(transform.position);
            }
        }
    }
}