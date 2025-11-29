using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaveManager))]
public class WaveManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        WaveManager script = (WaveManager)target;

        script.mode = (WaveManager.SpawnMode)EditorGUILayout.EnumPopup("Modo de Juego", script.mode);

        if (script.mode == WaveManager.SpawnMode.Automatic)
        {
            EditorGUILayout.HelpBox("Modo Automático Activado", MessageType.Info);
            base.OnInspectorGUI();
        }
        else
        {
            EditorGUILayout.HelpBox("Modo Manual/Debug", MessageType.Warning);
            script.spawnPoint = (Transform)EditorGUILayout.ObjectField("Spawn Point", script.spawnPoint, typeof(Transform), true);

            if (GUILayout.Button("Spawn Enemy Test") && Application.isPlaying)
            {
                Debug.Log("Spawn Manual Ejecutado");
            }
        }
    }
}