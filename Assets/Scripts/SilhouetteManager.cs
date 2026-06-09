using UnityEngine;
using UnityEngine.UI; 

public class SilhouetteManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image silhouetteDisplay; // Imagem na UI de criação de personagem

    [Header("Sprites")]
    public Sprite femaleSilhouette; 
    public Sprite maleSilhouette;   

    // 1 = Mulher, 0 = Homem (começa como mulher por padrão)
    private bool isFemale = true;

    void Start()
    {
        // Ao abrir a tela, carrega a opção salva (se não houver, o padrão é 1)
        isFemale = PlayerPrefs.GetInt("GeneroAvatar", 1) == 1;
        AtualizarImagem();
    }

    // Método chamado pelo botão de trocar personagem
    public void ToggleSilhouette()
    {
        isFemale = !isFemale;

        // Salva a escolha imediatamente
        PlayerPrefs.SetInt("GeneroAvatar", isFemale ? 1 : 0);
        PlayerPrefs.Save();

        AtualizarImagem();
    }

    private void AtualizarImagem()
    {
        if (silhouetteDisplay != null)
        {
            silhouetteDisplay.sprite = isFemale ? femaleSilhouette : maleSilhouette;
        }
    }
}