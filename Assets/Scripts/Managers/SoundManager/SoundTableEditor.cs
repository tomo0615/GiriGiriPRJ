using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

#if UNITY_EDITOR
[CustomEditor(typeof(SoundTable))]
public class SoundTableCreator : Editor
{
    const string soundEnumName = "SoundType";

    public override void OnInspectorGUI()
    {
        var soundTable = target as SoundTable;

        DrawDefaultInspector();

        if (GUILayout.Button("Create SoundType"))
        {   
            CreateSoundType(soundTable);
        }
    }

    public static void CreateSoundType(SoundTable soundTable)
    {
        List<string> names = new List<string>();

        foreach (var effect in soundTable.audioClipList)
        {
            names.Add(effect.name);
        }

        //Enum作成
        EnumCreator.Create(
            enumName: soundEnumName,            //enumの名前
            itemNameList: names,                //enumの項目
                                                //作成したファイルのパスをAssetsから拡張子まで指定
            exportPath: "Assets/Scripts/Managers/SoundManager/" + soundEnumName + ".cs"
        );
    }
}
#endif