using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private const int MaxItems = 1;

    [SerializeField] private bool _showWinScreen = false;
    [SerializeField] private bool _showLoseScreen = false;
    private string _labelText = "Collect all 4 items and you will win the game";
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
            if (_itemCollected >= MaxItems)
            {
                SetWinLoseScreen(ref _showWinScreen, "You win!");
            }
            else
            {
                _labelText = $"You need yet {MaxItems - _itemCollected} items";
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

            if (_playerHP <= 0)
            {
                SetWinLoseScreen(ref _showLoseScreen, "Do you want play again?");
            }
            else
            {
                _labelText = "Ouch...It was hurt!";
                Debug.LogFormat($"Lives: {_playerHP}");
            }
        }
    }

    private void SetWinLoseScreen(ref bool showScreen, string text)
    {
        showScreen = true;
        _labelText = text;
        Time.timeScale = 0;
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
                Utilities.RestartLevel(0);
            }
        }

        if (_showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height - 200, 200, 100), "You lose..."))
            {
                Utilities.RestartLevel();
            }
        }

    }


}
