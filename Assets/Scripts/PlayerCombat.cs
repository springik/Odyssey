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
    [SerializeField]
    float invTime;
    float currInvTime;
    Collision2D collision_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CastRay();
        }
        if (currInvTime > 0 && collision_ != null)
        {
            ProcessCooldownE(collision_.collider);
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
                Debug.DrawRay(DrawPoint.transform.position, dir, Color.red);
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    //d�t dmg nepriteli
                    Debug.Log("To� jest de�osprecht");
                }
            }
            catch { }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision);
            EnemyBehaviour enemyBehaviour = collision.gameObject.GetComponent<EnemyBehaviour>();
            StatManager.Instance.takeDamage(enemyBehaviour.enemyObject.dmg.currVal);
            collision.collider.enabled = false;
            collision_ = collision;
            Debug.Log(StatManager.getStatOfType("HP").realVal);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision_ = collision;
        StartCoroutine(invCoroutine(collision.collider));
    }
    IEnumerator invCoroutine(Collider2D collider) //TODO: FIX COROUTINE
    {
        ProcessCooldownE(collider);
        yield return null;
    }

    private void ProcessCooldownE(Collider2D collider)
    {
        SetAttackCooldownE();
        Debug.Log(currInvTime);
        currInvTime -= Time.deltaTime;
        Debug.Log(currInvTime);
        if (!IsInvincible())
        {
            collider.enabled = true;
        }
    }

    private void SetAttackCooldownE()
    {
        if (currInvTime <= 0)
        {
            currInvTime = invTime;
        }
    }
    bool IsInvincible()
    {
        if (currInvTime > 0) 
        {
            return true;
        }
        return false;
    }
}
