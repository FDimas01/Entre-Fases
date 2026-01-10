using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [Tooltip("Adicione aqui todas as telas que deseja controlar.")]
    public List<GameObject> telas;

    /// <summary>
    /// Ativa apenas a tela desejada e desativa todas as outras.
    /// </summary>
    /// <param name="telaParaAtivar">GameObject da tela que deve ficar ativa.</param>
    public void AtivarSomente(GameObject telaParaAtivar)
    {
        foreach (GameObject tela in telas)
        {
            tela.SetActive(false);
        }

        telaParaAtivar.SetActive(true);
    }
}