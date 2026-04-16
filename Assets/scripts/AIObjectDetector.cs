using UnityEngine;
using TMPro;

public class AIObjectDetector : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    // Cette variable permet de lier ton SelectionFrame vert
    public GameObject greenFrame;

    public void OnTargetDetected()
    {
        // On affiche le message d'analyse
        if (debugText != null) debugText.text = "IA : Analyse du flux vidéo...";

        // L'IA "verrouille" la cible : on affiche le cadre vert
        if (greenFrame != null) greenFrame.SetActive(true);

        Invoke("ShowResult", 1.5f); // Simule le temps de calcul
    }

    void ShowResult()
    {
        if (debugText != null) debugText.text = "IA : Astronaute identifié (98%)";
    }

    public void OnTargetLost()
    {
        if (debugText != null) debugText.text = "";

        // On cache le cadre dès que l'astronaute n'est plus vu
        if (greenFrame != null) greenFrame.SetActive(false);
    }
}