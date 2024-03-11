using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    public Camera Camera;

    public List<Transform> targets = new List<Transform>();
    public Player player;
    public Level level;

    public List<NavMeshData> navMeshDatas = new List<NavMeshData>();

    public void LoadLevel()
    {
        OnInit();
        for (int i = 0; i < level.spawnPos.Count; i++)
        {
            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot, level.spawnPos[i].position, Quaternion.identity);
        }
    }

    public void OnInit()
    {
        player.transform.position = level.startPoint.position;
        player.OnInit();
        NavMesh.AddNavMeshData(navMeshDatas[0]);
    }

}
