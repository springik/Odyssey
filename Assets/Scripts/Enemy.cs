using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "NPCs/Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField]
    public Sprite sprite;
    [SerializeField]
    public string enemyName;
    public static List<Enemy> enemyList { get; private set; } = new List<Enemy>();
    [SerializeField]
    List<Item> lootTable;
}
