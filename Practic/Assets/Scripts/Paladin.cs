using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Character
{
    public Weapon Weapon { get; set; }
    
    public Paladin(string name, Weapon weapon) : base(name) 
    {
        this.Weapon = weapon;
    }

    public override void PrintStatsInfo()
    {
        Debug.LogFormat($"Привет, {Name}, возьми свой {Weapon.Name}");
    }

}
