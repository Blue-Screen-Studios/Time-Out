using UnityEngine;
using BetterDebug;
using System;
using UnityEngine.SceneManagement;

public class DebugTest : MonoBehaviour
{
    [SerializeField] private bool enableTests;

    private void Awake()
    {
        //SceneManager.LoadScene(1);
    }

    //A test of the BetterDebug plugin
    void Start()
    {
        if(enableTests)
        {
            AdvancedDebug.Log("Log test, should print 'this'! " + this);
            AdvancedDebug.LogWarning("Warning test");
            AdvancedDebug.LogError("Error test");
            AdvancedDebug.LogException(new NotImplementedException());
        }
    }
}
