using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int level = 1;

    private void Awake()
    {
        instance = this;
    }

    public void Restart()
    {
        level = 1;
        SceneManager.LoadScene(0);
    }

    public void LevelUp()
    {
        level++;
    }
}
