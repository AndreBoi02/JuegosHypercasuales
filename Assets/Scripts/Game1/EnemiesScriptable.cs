using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesStats", menuName = "ScriptableObjects/EnemiesStats", order = 0)]
public class EnemiesScriptable : ScriptableObject
{
    public float speed;
    public float size;
    public float points;
    public Sprite sprite;
    public Color color;
}
