using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SceneDB", menuName = "Create Scene DB")]
public class SceneData : ScriptableObject
{
    public List<string> SceneName = new List<string>();

    public List<string> Fetch()
    {
        return SceneName;
    }
}
