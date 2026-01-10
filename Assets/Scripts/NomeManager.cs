using UnityEngine;
using TMPro;

public class MensagemPersonalizada : MonoBehaviour
{
    public TMP_Text textoMensagem;

    // Esse método você chama quando quiser atualizar a mensagem
    public void AtualizarMensagem(string nomeUsuario)
    {
        textoMensagem.text = $"Que bom poder te ajudar, {nomeUsuario}!\nAgora escolha as características do seu avatar.";
    }
}
