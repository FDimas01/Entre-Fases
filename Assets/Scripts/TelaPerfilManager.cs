using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelaPerfilManager : MonoBehaviour
{
    [Header("Referências de Telas")]
    public GameObject telaPrincipal;     // tela principal (menu inicial do app)
    public GameObject telaPerfil;        // tela de perfil
    public GameObject telaReiniciar;     // tela de reiniciar personagem
    public GameObject telaInicio;        // primeira tela do app (cadastro inicial)

    [Header("Botões da Tela Principal")]
    public Button btnAbrirPerfil;        // botão na tela principal que abre a tela de perfil
    public Button btnAbrirReiniciar;     // botão na tela principal que abre a tela de reiniciar

    [Header("Botões da Tela de Perfil")]
    public Button btnVoltarPerfil;       // volta para tela principal
    public Button btnRefazerCadastro;    // apaga dados e volta ao início

    [Header("Botões da Tela de Reiniciar")]
    public Button btnVoltarReiniciar;    // volta para tela principal
    public Button btnReiniciar;          // apaga dados e volta ao início

    private void Start()
    {
        // Liga botões da tela principal
        if (btnAbrirPerfil)
            btnAbrirPerfil.onClick.AddListener(() => MostrarTela(telaPerfil));

        if (btnAbrirReiniciar)
            btnAbrirReiniciar.onClick.AddListener(() => MostrarTela(telaReiniciar));

        // Liga botões da tela de perfil
        if (btnVoltarPerfil)
            btnVoltarPerfil.onClick.AddListener(() => MostrarTela(telaPrincipal));

        if (btnRefazerCadastro)
            btnRefazerCadastro.onClick.AddListener(RefazerCadastro);

        // Liga botões da tela de reiniciar
        if (btnVoltarReiniciar)
            btnVoltarReiniciar.onClick.AddListener(() => MostrarTela(telaPrincipal));

        if (btnReiniciar)
            btnReiniciar.onClick.AddListener(RefazerCadastro);
    }

    private void MostrarTela(GameObject tela)
    {
        // Desativa todas as telas conhecidas
        telaPrincipal.SetActive(false);
        telaPerfil.SetActive(false);
        telaReiniciar.SetActive(false);
        telaInicio.SetActive(false);

        // Ativa a escolhida
        tela.SetActive(true);
    }

    private void RefazerCadastro()
    {
        // 🧹 Apaga todos os dados armazenados
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("🧹 Todos os dados foram apagados. Reiniciando o personagem...");

        // 🌀 (Opcional, mas mais confiável)
        // Recarrega a cena atual para reiniciar completamente os estados de scripts e objetos
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
