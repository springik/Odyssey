using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    public Enemy enemyObject;

    // Update is called once per frame
    void Update()
    {
        followTarget();
    }

    void followTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
}
