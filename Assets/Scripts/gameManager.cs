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
        cannons
    };

    public void Awake()
    {
        if (_inst == null)
        {
            _inst = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(gameObject);

        activeChar = State.astronaut;
    }

    private void Update()
    {
        if (Input.GetKeyUp("mouse 1")) { 
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

