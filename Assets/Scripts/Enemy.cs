using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "NPCs/Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    Stat hp;
    [SerializeField]
    Stat dmg;
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    public string enemyName;
    public static List<Enemy> enemyList { get; private set; } = new List<Enemy>();
    [SerializeField]
    List<Item> lootTable;

    private void Awake()
    {
        enemyList.Add(this);
        hp.type = "HP";
        dmg.type = "DMG";
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
