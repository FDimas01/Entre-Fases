using UnityEngine;
using TMPro;

public class ChangeUIInicio : MonoBehaviour
{
    [Header("Telas")]
    public GameObject telaInicio;
    public GameObject telaProfissionais;
    public GameObject telaAtendimentoMedico;
    public GameObject telaAtendimentoPsicologa;
    public GameObject telaAtendimentoAssistenteSocial;
    public GameObject telaAtendimentoEnfermeira;
    public GameObject telaCriacaoPersonagem;
    public GameObject telaSuporte;
    public GameObject telaCriacaoSuporte;
    public GameObject telaAnimalSuporte;
    public GameObject telaTrofeu;
    public GameObject telaPrincipal;

    [Header("Inputs Atendimento Médico")]
    public TMP_InputField inputNomeMedico;
    public TMP_InputField inputIdadeMedico;

    [Header("Inputs Atendimento Psicóloga")]
    public TMP_InputField inputNomePsicologa;
    public TMP_InputField inputIdadePsicologa;

    [Header("Inputs Atendimento Assistente Social")]
    public TMP_InputField inputNomeAssistente;
    public TMP_InputField inputIdadeAssistente;

    [Header("Inputs Atendimento Enfermeira")]
    public TMP_InputField inputNomeEnfermeira;
    public TMP_InputField inputIdadeEnfermeira;

    [Header("Texto Criação Personagem")]
    public TMP_Text textoCriacaoPersonagem;

    [Header("Inputs Criação Suporte")]
    public TMP_InputField inputParentesco; // Pai, mãe, amigo etc.
    public TMP_InputField inputNomeSuporte;

    [Header("Texto Tela Principal")]
    public TMP_Text textoTelaPrincipal;

    // Dados salvos em memória
    private string nomeUsuario;
    private int idadeUsuario;
    private string parentescoSuporte;
    private string nomeSuporte;
    private string tipoSuporte; // pessoa ou animal

    private void Start()
    {
        // 🔹 Verifica se já existem dados salvos
        if (PlayerPrefs.HasKey("NomeUsuario"))
        {
            CarregarDados();
            MostrarTela(telaPrincipal);
        }
        else
        {
            MostrarTela(telaInicio);
        }
    }

    // ------------------- Sistema de Telas -------------------
    private void MostrarTela(GameObject tela)
    {
        telaInicio.SetActive(false);
        telaProfissionais.SetActive(false);
        telaAtendimentoMedico.SetActive(false);
        telaAtendimentoPsicologa.SetActive(false);
        telaAtendimentoAssistenteSocial.SetActive(false);
        telaAtendimentoEnfermeira.SetActive(false);
        telaCriacaoPersonagem.SetActive(false);
        telaSuporte.SetActive(false);
        telaCriacaoSuporte.SetActive(false);
        telaAnimalSuporte.SetActive(false);
        telaTrofeu.SetActive(false);
        telaPrincipal.SetActive(false);

        tela.SetActive(true);
    }

    // ------------------- Fluxo -------------------
    public void IniciarApp()
    {
        MostrarTela(telaProfissionais);
    }

    public void EscolherProfissional(string profissional)
    {
        switch (profissional)
        {
            case "medico": MostrarTela(telaAtendimentoMedico); break;
            case "psicologa": MostrarTela(telaAtendimentoPsicologa); break;
            case "assistente": MostrarTela(telaAtendimentoAssistenteSocial); break;
            case "enfermeira": MostrarTela(telaAtendimentoEnfermeira); break;
        }
    }

    public void ContinuarAtendimento(string profissional)
    {
    switch (profissional)
    {
        case "medico":
            nomeUsuario = inputNomeMedico.text;
            int.TryParse(inputIdadeMedico.text, out idadeUsuario);
            break;
        case "psicologa":
            nomeUsuario = inputNomePsicologa.text;
            int.TryParse(inputIdadePsicologa.text, out idadeUsuario);
            break;
        case "assistente":
            nomeUsuario = inputNomeAssistente.text;
            int.TryParse(inputIdadeAssistente.text, out idadeUsuario);
            break;
        case "enfermeira":
            nomeUsuario = inputNomeEnfermeira.text;
            int.TryParse(inputIdadeEnfermeira.text, out idadeUsuario);
            break;
    }

    // 🔹 Deixa a primeira letra maiúscula e o restante minúsculo
    if (!string.IsNullOrEmpty(nomeUsuario))
    {
        nomeUsuario = char.ToUpper(nomeUsuario[0]) + nomeUsuario.Substring(1).ToLower();
    }

    textoCriacaoPersonagem.text = $"It's great to be able to help you, {nomeUsuario}!\nNow, choose the characteristics of your avatar.";
    MostrarTela(telaCriacaoPersonagem);
    }


    public void ContinuarCriacaoPersonagem()
    {
        MostrarTela(telaSuporte);
    }

    public void EscolherSuporte(string suporte)
    {
        tipoSuporte = suporte;

        if (suporte == "pessoa")
            MostrarTela(telaCriacaoSuporte);
        else if (suporte == "animal")
            MostrarTela(telaAnimalSuporte);
    }

    public void ContinuarCriacaoSuporte()
    {
        parentescoSuporte = inputParentesco.text;
        nomeSuporte = inputNomeSuporte.text;

        MostrarTela(telaTrofeu);
    }

    public void EscolherAnimal(string animal)
    {
        tipoSuporte = "animal";
        nomeSuporte = animal; // aqui salva o animal escolhido
        MostrarTela(telaTrofeu);
    }

    public void ContinuarTrofeu()
    {
        textoTelaPrincipal.text = $"Hello, {nomeUsuario}!";

        // 🔹 Salvar os dados para uso futuro
        SalvarDados();

        MostrarTela(telaPrincipal);
    }

    // ------------------- Salvamento -------------------
    private void SalvarDados()
    {
        PlayerPrefs.SetString("NomeUsuario", nomeUsuario);
        PlayerPrefs.SetInt("IdadeUsuario", idadeUsuario);
        PlayerPrefs.SetString("TipoSuporte", tipoSuporte);
        PlayerPrefs.SetString("NomeSuporte", nomeSuporte);
        PlayerPrefs.SetString("ParentescoSuporte", parentescoSuporte);
        PlayerPrefs.Save();
    }

    private void CarregarDados()
    {
        nomeUsuario = PlayerPrefs.GetString("NomeUsuario");
        idadeUsuario = PlayerPrefs.GetInt("IdadeUsuario");
        tipoSuporte = PlayerPrefs.GetString("TipoSuporte");
        nomeSuporte = PlayerPrefs.GetString("NomeSuporte");
        parentescoSuporte = PlayerPrefs.GetString("ParentescoSuporte");

        textoTelaPrincipal.text = $"Hello, {nomeUsuario}!";
    }
}
