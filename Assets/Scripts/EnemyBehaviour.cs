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
    EnemyStats stats;
    SpriteRenderer childRenderer;
    [SerializeField]
    float attackSpeed;
    float currAttackSpeed;
    PlayerStats playerStats;
    private void Start()
    {
        childRenderer = GetComponentInChildren<SpriteRenderer>();
        //childRenderer.sprite = stats.enemyObject?.sprite;
    }
    // Update is called once per frame
    void Update()
    {
        followTarget();
        if (currAttackSpeed > 0)
        {
            ProcessCooldown();
        }
    }

    void followTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack())
        {
            //deal dmg
            playerStats = collision.gameObject.GetComponent<PlayerStats>();
            playerStats.takeDamage(stats.dmg.GetTotalValue());
            Debug.Log("took dmg");
        }
    }

    private void ProcessCooldown()
    {
        SetAttackCooldown();
        //Debug.Log(currattackSpeed);
        currAttackSpeed -= Time.deltaTime;
        //Debug.Log(currattackSpeed);
    }

    private void SetAttackCooldown()
    {
        if (currAttackSpeed <= 0)
        {
            currAttackSpeed = attackSpeed;
        }
    }
    bool canAttack()
    {
        if (currAttackSpeed > 0)
        {
            return false;
        }
        return true;
    }
}
