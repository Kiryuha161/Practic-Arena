using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Weapon huntingBow = new Weapon("��������� ���", 105);
        Weapon sword = new Weapon("��������� ���", 125);
        Character hero = new Character("�����"); 
        hero.PrintStatsInfo();
        Paladin knight = new Paladin("�����", sword);
        knight.PrintStatsInfo();

        huntingBow.PrintWeaponStats();
        
    }

    

   
}
