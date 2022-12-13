using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    GameObject DrawPoint;
    [SerializeField]
    float range;
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
                    //dát dmg nepriteli
                    Debug.Log("Tož jest dežosprecht");
                }
            }
            catch { }
    }
}
