namespace Utils
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(CirclePlacer))]
    public class CirclePlacerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var placer = (CirclePlacer)target;

            GUILayout.Space(10);

            if (GUILayout.Button("Place Objects In Circle"))
            {
                placer.Place();
            }
        }
    }
}