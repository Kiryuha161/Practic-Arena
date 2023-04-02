using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Character
{
    public string Name;
    public int ExpPoints = 0;

    public Character()
    {
        Name = "�������";
    }

    public Character(string name)
    {
        //Name = name;
        this.Name = name;
    }

    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("�����: " + Name + ", ����: " + ExpPoints);
    }

    private void Reset()
    {
        this.Name = "�� ���������";
        this.ExpPoints = 0;
    }
}

public struct Weapon
{
    public string Name;
    public int Damage;

    public Weapon(string name, int damage)
    {
        this.Name = name;
        this.Damage = damage;
    }

    public void PrintWeaponStats()
    {
        Debug.LogFormat($"������: {Name},����: {Damage}");
    }

}
