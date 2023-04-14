using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private bool _showWinScreen = false;
    private string _labelText = "Collect all 4 items and you will win the game";
    [SerializeField] private int _maxItems = 4;
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
            if (_itemCollected >= _maxItems)
            {
                _labelText = $"You win!";
                _showWinScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                _labelText = $"You need yet {_maxItems - _itemCollected} items";
            }


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

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 50), $"Player HP: {_playerHP}");
        GUI.Box(new Rect(20, 70, 150, 50), $"Items collected: {_itemCollected}");

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), _labelText);

        if (_showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 200, 200, 100), "You won!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1f;
            }
        }

    }


}
