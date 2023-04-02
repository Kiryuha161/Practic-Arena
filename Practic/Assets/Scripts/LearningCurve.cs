using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Weapon huntingBow = new Weapon("ќхотничий лук", 105);
        Weapon sword = new Weapon("ƒвуручный меч", 125);
        Character hero = new Character("Ёльза"); 
        hero.PrintStatsInfo();
        Paladin knight = new Paladin("јртур", sword);
        knight.PrintStatsInfo();

        huntingBow.PrintWeaponStats();
        
    }

    

   
}
