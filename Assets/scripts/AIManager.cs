using UnityEngine;
using TMPro; // Pour le texte
using System.Collections;

public class AIManager : MonoBehaviour
{
    public TextMeshPro infoText; // Glisse ton texte AR ici
    public GameObject loadingIcon; // Optionnel : un petit cercle qui tourne

    public void StartAnalysis()
    {
        StartCoroutine(SimulateAIProcess());
    }

    IEnumerator SimulateAIProcess()
    {
        // 1. On affiche que l'IA travaille
        infoText.text = "Analyse IA en cours...";
        if (loadingIcon) loadingIcon.SetActive(true);

        // 2. On attend 2 secondes (simule le temps de réponse API)
        yield return new WaitForSeconds(2f);

        // 3. Résultat dynamique (Tu peux personnaliser selon ton objet)
        infoText.text = "OBJET : Moteur Industriel\nÉTAT : 85% Optimisé\nACTION : Maintenance requise";

        if (loadingIcon) loadingIcon.SetActive(false);
        Debug.Log("L'IA a terminé l'analyse.");
    }
}