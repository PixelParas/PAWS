using System;
using TMPro;
using UnityEngine;

public class SyntaxHighlighter : MonoBehaviour
{
    public TMP_Text input;
    public TMP_InputField inputField;

    public RectTransform inpRectTransform;
    public RectTransform outRectTransform;
    public string finalText;

    void Update()
    {
        outRectTransform.offsetMin = inpRectTransform.offsetMin;
        outRectTransform.offsetMax = inpRectTransform.offsetMax;
    }

    void LateUpdate()
    {
        finalText = "";
        string word = "";
        foreach(char c in inputField.text)
        {
            if (c == ' ' || c == '\n' || c == '\t' || c == '.' || c == '<' || c == '>')
            {
                Color(word);
                finalText += c;
                word = "";
            }
            else 
            {
                word += c;
            }
        }
        input.text = finalText;
    }
    void Color(string word)
    {
        if (word == "")
            return;
        if (word == "public" || word == "void" || word == "class" || word == "using" || word == "static" || word == "new")
        {
            finalText += ("<color=#569cd6>" + word);
        }
        else if (word  == "for" || word == "foreach" || word == "if" || word == "else")
        {
            finalText += ("<color=#d8a0df>" + word);
        }
        else if (word == "Turrent" || word == "Transform" || word == "GameObject" || word == "MeshRenderer")
        {
            finalText += ("<color=#41c4b0>" + word);
        }
        else if (word == "aimTowards")
        {
            finalText += ("<color=#DBDCAA>" + word);
        }
        else if (word == "turrent" || word == "_t" || word == "aimTarget")
        {
            finalText += ("<color=#9CCFD8>" + word);
        }
        else
        {
            finalText += ("<color=#B6B6B6>"+ word);
        }
    }
}