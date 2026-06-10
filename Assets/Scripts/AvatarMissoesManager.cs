using UnityEngine;
using UnityEngine.UI;

public class AvatarMissoesManager : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("Arraste aqui o componente Image que exibe o personagem nesta tela.")]
    public Image imagemPersonagemMissao; 

    [Header("Sprites do Avatar (Mesmos da criação)")]
    public Sprite femaleSprite;
    public Sprite maleSprite;

    // O OnEnable é executado toda vez que a tela de missão correspondente for ativada
    private void OnEnable()
    {
        AtualizarPersonagem();
    }

    private void AtualizarPersonagem()
    {
        if (imagemPersonagemMissao != null)
        {
            // Puxa a escolha salva no PlayerPrefs (1 = Mulher, 0 = Homem). Se não achar nada, o padrão é 1 (Mulher).
            bool isFemale = PlayerPrefs.GetInt("GeneroAvatar", 1) == 1;
            
            // Substitui dinamicamente o sprite com base no gênero salvo
            imagemPersonagemMissao.sprite = isFemale ? femaleSprite : maleSprite;
            
            Debug.Log($"[EntreFases] Sprite da tela de missões atualizado com sucesso. Gênero Feminino: {isFemale}");
        }
        else
        {
            Debug.LogWarning("[EntreFases] Referência de imagem vazia no componente AvatarMissoesManager.");
        }
    }
}