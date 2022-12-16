using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    GameObject DrawPoint;
    [SerializeField]
    float range;
    EnemyStats enemyStats;
    PlayerStats playerStats;
    [SerializeField]
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CastRay();
        }
    }
    void CastRay()
    {
        try
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 dir = mousePos - DrawPoint.transform.position;
            dir.Normalize();
            RaycastHit2D hit = Physics2D.Raycast(DrawPoint.transform.position, dir, range);
            //Debug.DrawRay(DrawPoint.transform.position, dir, Color.red);
            animator.SetTrigger("Attack");
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                //deal dmg
                Debug.Log("To je enemák");
                enemyStats = hit.collider.gameObject.GetComponent<EnemyStats>();
                enemyStats.takeDamage(playerStats.dmg.GetTotalValue());
            }
        }
        catch { }
    }
}
