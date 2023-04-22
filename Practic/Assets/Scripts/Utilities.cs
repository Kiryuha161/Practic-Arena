using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities 
{
    public static int playerDeath = 0;// Start is called before the first frame update

    public static void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

        Debug.LogFormat($"Player died: {playerDeath} time");
        string message = UpdateDeathCount(ref playerDeath);
        Debug.LogFormat($"Player died: {playerDeath} time");
    }

    public static bool RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;

        return true;
    }

    public static string UpdateDeathCount(ref int countDeath)
    {
        countDeath++;
       
        return "Next time you will be number" + countDeath;
    }

}
