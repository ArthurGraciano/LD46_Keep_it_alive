using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{  
    public static gameManager _inst;

    public State activeChar;

    public enum State
    {
        astronaut,
        cannons,
        tutorial
    };

    public void Awake()
    {
        if (_inst == null)
        {
            _inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(gameObject);

        activeChar = State.tutorial;
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyUp("mouse 1") && activeChar != State.tutorial) { 
            switch (activeChar)
        {
            case State.astronaut:
                    activeChar = State.cannons;
                break;

            case State.cannons:
                    activeChar = State.astronaut;
                break;
            }
        }
    }

}

