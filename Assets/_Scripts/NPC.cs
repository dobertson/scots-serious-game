/*

The MIT License (MIT)

Copyright (c) 2015-2017 Secret Lab Pty. Ltd. and Yarn Spinner contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using UnityEngine;
using Yarn.Unity;


/*
 *  This is based off the NPC script that comes with YarnSpinner example project.
 *  It is attached to NPC characters that you can have dialogue with
 */

public class NPC : MonoBehaviour 
{
    public string talkToNode = ""; // yarn node to start conversation with if player clicks on npc

    [Header("Optional")]
    public YarnProgram scriptToLoad; // the script to load

    private DialogueRunner dialogueRunner;
    private DialogueTranslated dialogueTranslated;

    void Start () {
        if (scriptToLoad != null) {
            // add script to dialgoue runner
            dialogueRunner = FindObjectOfType<DialogueRunner>();
            dialogueRunner.Add(scriptToLoad);

            // add translated script to dialgue 
            dialogueTranslated = FindObjectOfType<DialogueTranslated>();
            dialogueTranslated.Add(scriptToLoad.localizations[0].text);
            }
    }

    private void OnMouseDown()
    {
        // if player is close enough to talk
        if (GameManager.IsPlayerCloseEnough(transform.position))
        {  
            // and there is a node to talk to
            if (!string.IsNullOrEmpty(talkToNode))
            {   
                //talk
                dialogueRunner.StartDialogue(talkToNode);
            }
        }
    }
}