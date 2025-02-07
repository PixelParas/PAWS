using System.Collections;
using UnityEngine;

public class CloudData : MonoBehaviour
{
    public Material cloudMaterial;
    public Color startColor;
    public float moisture;
    public SpriteRenderer sr; // Assign this in the Inspector

    public float checkMoisture(float duration)
    {
        StartCoroutine(FlashYellow(duration));
        return moisture;
    }

    public void isSeedable()
    {
        sr.color = Color.green; // Cloud turns green
    }

    public void isNotSeedable()
    {
        sr.color = Color.red; // Cloud turns red
    }

    private IEnumerator FlashYellow(float duration)
    {
        sr.color = Color.yellow; // Turn yellow while checking moisture
        yield return new WaitForSeconds(duration);
    }
}
