using UnityEngine;
using UnityEngine.UI;

public class AvatarMenuPrincipal : MonoBehaviour
{
    [Header("UI Elements")]
    public Image imagemAvatarPrincipal; // Arraste a imagem do avatar da Tela Principal aqui

    [Header("Sprites (Os mesmos da tela de criação)")]
    public Sprite femaleSilhouette;
    public Sprite maleSilhouette;

    // O OnEnable é chamado toda vez que a Tela Principal for ativada (mostrada)
    private void OnEnable()
    {
        AtualizarAvatar();
    }

    private void AtualizarAvatar()
    {
        if (imagemAvatarPrincipal != null)
        {
            // Puxa a escolha salva (1 = Mulher, 0 = Homem). Se não existir, padrão é 1
            bool isFemale = PlayerPrefs.GetInt("GeneroAvatar", 1) == 1;
            
            // Aplica o sprite correto na Tela Principal
            imagemAvatarPrincipal.sprite = isFemale ? femaleSilhouette : maleSilhouette;
        }
    }
}