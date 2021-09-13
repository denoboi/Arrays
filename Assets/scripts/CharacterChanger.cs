﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes character on left mouse button
/// </summary>
public class CharacterChanger : MonoBehaviour
{
    
    GameObject [] prefabCharacters = new GameObject[4];
   

    // need for location of new character
    GameObject currentCharacter;

    // first frame input support
    bool previousFrameChangeCharacterInput = false;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        prefabCharacters[0] = (GameObject)Resources.Load("Character0");
        prefabCharacters[1] = (GameObject)Resources.Load("Character1");
        prefabCharacters[2] = (GameObject)Resources.Load("Character2");
        prefabCharacters[3] = (GameObject)Resources.Load("Character3");

        currentCharacter = Instantiate<GameObject>(
            prefabCharacters[0], Vector3.zero,
            Quaternion.identity);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // change character on left mouse button
        if (Input.GetAxis("ChangeCharacter") > 0)
        {
            // only change character on first input frame
            if (!previousFrameChangeCharacterInput)
            {
                previousFrameChangeCharacterInput = true;

                // save current position and destroy current character
                Vector3 position = currentCharacter.transform.position;
                Destroy(currentCharacter);

                // instantiate a new random character

                currentCharacter = Instantiate(prefabCharacters[Random.Range(0, 4)],
                    position, Quaternion.identity);
            }   
               
        }
        else
        {
            // no change character input
            previousFrameChangeCharacterInput = false;
        }
    }
}
