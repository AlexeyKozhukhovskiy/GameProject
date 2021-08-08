using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [Header("Скорость")]
    [Range(1,3)]
    public float speed = 2;
    public Transform fon1;
    public Transform fon2;
    public Transform obstacle1;
    public Transform obstacle2;
    void Update()
    {
        if (GameManager.isGamePaused == true)
        {
            return;
        }
        if (fon1.position.x <= -5.75f)
        {
            fon1.position = new Vector3(5.75f + fon2.position.x, 0, 0);
            obstacle1.position = new Vector3(obstacle1.position.x, Random.Range(-0.2f, 1.2f), obstacle1.position.z);
        }
        if (fon2.position.x <= -5.75f)
        {
            fon2.position = new Vector3(5.75f+ fon1.position.x, 0, 0);
            obstacle2.position = new Vector3(obstacle2.position.x, Random.Range(-0.2f, 1.2f), obstacle2.position.z);
        }
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
