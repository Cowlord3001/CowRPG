using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public TextAsset TextFile;
    public string[] TextLines;
    public Text CurrentText;
    int Line;
    int Character;
    public float TextSpeed;

	// Use this for initialization
	void OnEnable() {
		if(TextFile != null)
        {
            Debug.Log("awake");
            CurrentText.text = "";
            Line = 0;
            Character = 0;
            TextLines = TextFile.text.Split('\n');
            InvokeRepeating("UpdateText", 0, 1/TextSpeed);
        }
	}

    void OnDisable()
    {
        CancelInvoke();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void UpdateText()
    {
        if(Character > TextLines[Line].Length-1)
        {
            Line = Line + 1;
            Character = 0;
            CurrentText.text = CurrentText.text + '\n';
        }
        if (Line > TextLines.Length-1)
        {
            CancelInvoke();
        }
        else if(Line == TextLines.Length-1 && TextLines[Line].Length - 1 <= 0)
        {
            CancelInvoke();
        }
        else
        {
            CurrentText.text = CurrentText.text + TextLines[Line][Character];
            Character = Character + 1;
        }
    }
}
