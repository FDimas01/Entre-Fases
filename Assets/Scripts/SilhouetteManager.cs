using UnityEngine;
using UnityEngine.UI; // Necessário para acessar os componentes de UI

public class SilhouetteManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image silhouetteDisplay; // A imagem na UI que vai mostrar a silhueta

    [Header("Sprites")]
    public Sprite femaleSilhouette; // Arraste a imagem da mulher aqui no Inspector
    public Sprite maleSilhouette;   // Arraste a imagem do homem aqui no Inspector

    // Variável para controlar o estado atual (começa como true para a mulher)
    private bool isFemale = true;

    void Start()
    {
        // Garante que a aplicação inicie com a silhueta da mulher
        if (silhouetteDisplay != null && femaleSilhouette != null)
        {
            silhouetteDisplay.sprite = femaleSilhouette;
        }
    }

    // Método que será chamado pelo botão
    public void ToggleSilhouette()
    {
        // Inverte o valor da variável (se era true vira false, e vice-versa)
        isFemale = !isFemale;

        // Atualiza a imagem com base no novo estado
        if (isFemale)
        {
            silhouetteDisplay.sprite = femaleSilhouette;
        }
        else
        {
            silhouetteDisplay.sprite = maleSilhouette;
        }
    }
}