using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

[CreateAssetMenu(fileName = "Platform",menuName = "Data/Platform")]
public class PlatformData : ScriptableObject
{
    public List<EcsEntity> Entityes;
    public GameObject Platform;
}
