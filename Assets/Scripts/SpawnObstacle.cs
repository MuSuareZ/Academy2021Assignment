using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    private System.Random _random = new System.Random();

    public List<GameObject> obstacles;
    public GameObject colorSwitch;

    public void Spawn(int position)
    {
        int r = _random.Next(obstacles.Count);
        Instantiate(colorSwitch, new Vector3(0, position + 6, 0), Quaternion.identity);
        Instantiate(obstacles[r], new Vector3(0, position + 8, 0), Quaternion.identity);
    }
}
