using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    private int _itemCollected = 0;
    public int Items 
    {
        get
        {
            return _itemCollected;
        }

        set
        {
            _itemCollected = value;
            Debug.LogFormat($"Items: {_itemCollected}");
        }

     }
    
    private int _playerHP = 10;
    public int HP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            _playerHP = value;
            Debug.LogFormat($"Lives: {_playerHP}");
        }
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
