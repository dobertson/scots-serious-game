using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineData 
{
    public string originalText { get; set; }
    public string translatedText { get; set; }
    public string characterSpeaking { get; set; }

    public LineData(
        string originalText,
        string translatedText,
        string characterSpeaking)
    {
        this.originalText = originalText;
        this.translatedText = translatedText;
        this.characterSpeaking = characterSpeaking;
    }
}
