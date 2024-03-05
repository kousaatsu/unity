using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/New Audio Settings", fileName = "AudioSettings")]

    public class AudioSettingsSO : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float loudness;


        [Space(30)]
        [SerializeField] private AudioTypes audioTypes;
        [SerializeField] private List<AudioData> audioDangerous;
        [SerializeField] private List<AudioData> audioFriendly;
        [SerializeField] private List<AudioData> audioNeutral;

        [SerializeField] private string text;
        [SerializeField] private string id;

    }


    [Serializable]
    public class AudioData
    {
        [field: SerializeField] public AudioClip AudioClip { get; private set; }
        [field: SerializeField] public float Volume { get; private set; }
    }

    [CustomEditor(typeof(AudioSettingsSO))]
    [CanEditMultipleObjects]
    public class AudioEditor : Editor
    {
        private SerializedProperty speed;
        private SerializedProperty loudness;
        private SerializedProperty text;
        private SerializedProperty audioTypes;
        private SerializedProperty audioList;
        private SerializedProperty GUIid;
        private bool showText;
        private bool showList;
        private void OnEnable()
        {
            showText = false;
            showList = false;
            audioTypes = serializedObject.FindProperty("audioTypes");
            speed = serializedObject.FindProperty("speed");
            loudness = serializedObject.FindProperty("loudness");
            text = serializedObject.FindProperty("text");
            GUIid = serializedObject.FindProperty("id");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(speed);
            EditorGUILayout.PropertyField(audioTypes);
            switch (audioTypes.enumValueFlag)
            {
                case 0:
                    audioList = serializedObject.FindProperty("audioDangerous");
                    break;
                case 1:
                    audioList = serializedObject.FindProperty("audioFriendly");
                    break;
                case 2:
                    audioList = serializedObject.FindProperty("audioNeutral");
                    break;
            }
            EditorGUILayout.Slider(loudness, 0, 100);

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Show List"))
            {
                showList = true;
            }
            if (GUILayout.Button("Show Text"))
            {
                showText = true;
            }
            if (GUILayout.Button("Hide All"))
            {
                showText = false;
                showList = false;
            }
            EditorGUILayout.EndHorizontal();
            if (showText)
            {
                EditorGUILayout.PropertyField(text);
            }
            if (showList)
            {
                EditorGUILayout.PropertyField(audioList);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
