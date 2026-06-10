using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class TelaPrincipalManager : MonoBehaviour
{
    [Header("Tela Principal")]
    public GameObject telaPrincipal;

    [Header("Botões da Tela Principal")]
    public Button btnAbrirHumor;
    public Button btnAbrirMedicacao;
    public Button btnAbrirRotina;
    public Button btnAbrirRegistro;
    public Button btnAbrirMissoes;

    // ================= HUMOR =================
    [Header("Humor")]
    public GameObject telaHumor;
    public List<Toggle> botoesHumores;
    public TMP_Text textoHumoresSelecionados;
    public Button btnVoltarHumor;
    private List<string> humoresSelecionados = new List<string>();

    // === ADIÇÃO HUMOR ===
    [Header("Botão Continuar Humor")]
    public Button btnContinuarHumor; // botão na tela de humor que confirma seleção e volta para principal
    // =====================

    // ================= MEDICAÇÃO =================
    [Header("Medicação")]
    public GameObject telaMedicacao;
    public TMP_InputField inputNomeRemedio;
    public TMP_InputField inputDose;
    public TMP_InputField inputHorario;
    public Button btnVoltarMedicacao;

    public Button btnAddHorario;
    public Toggle toggleAlarme; // botão de sino virou toggle

    private List<Medicamento> medicamentos = new List<Medicamento>();
    private List<string> horariosTemp = new List<string>();

    // ================= ROTINA =================
    [Header("Rotina")]
    public GameObject telaRotina;
    public GameObject telaRotinaDiaria;
    public GameObject telaRotinaSemanal;
    public GameObject telaRotinaMensal;
    public Button btnVoltarRotina;

    public Button btnAbrirRotinaDiaria;
    public Button btnAbrirRotinaSemanal;
    public Button btnAbrirRotinaMensal;

    public Button btnVoltarRotinaDiaria;
    public Button btnVoltarRotinaSemanal;
    public Button btnVoltarRotinaMensal;

    [Header("Rotina Diária")]
    public TMP_InputField[] inputManhaAtividade;
    public TMP_InputField[] inputManhaHorario;
    public TMP_InputField[] inputTardeAtividade;
    public TMP_InputField[] inputTardeHorario;
    public TMP_InputField[] inputNoiteAtividade;
    public TMP_InputField[] inputNoiteHorario;
    private List<RotinaDiaria> rotinasDiarias = new List<RotinaDiaria>();

    [Header("Rotina Semanal")]
    public List<Button> botoesDiasSemana;

    [Header("Tela de Registro da Rotina Semanal")]
    public GameObject telaRegistroSemanal;
    public TMP_InputField inputNomeRotinaSemanal;
    public TMP_InputField inputHorarioRotinaSemanal;
    public Toggle btnAlarmeSemanal; // <-- alterado para Toggle (sino vira toggle)
    public Button btnSalvarRotinaSemanal;
    public Button btnVoltarRotinaSemanalRegistro;
    public TMP_Text textoDiaSemana; // novo TMP para exibir a semana/dia selecionado
    private string diaSelecionadoSemanal = "";

    private List<RotinaSemanal> rotinasSemanais = new List<RotinaSemanal>();

    [System.Serializable]
    public class RotinaSemanal
    {
        public string Dia;
        public string Nome;
        public string Horario;
    }

    // === ADIÇÃO PARA ROTINA MENSAL ===
    [Header("Rotina Mensal")]
    public TMP_Text textoMes;
    public Button btnMesAnterior;
    public Button btnProximoMes;
    public List<Button> botoesDiasMes; // Botões de 1 a 31
    public GameObject telaRegistroMensal;
    public TMP_InputField inputNomeRotinaMensal;
    public TMP_InputField inputHorarioRotinaMensal;
    public Button btnSalvarRotinaMensal;
    public Button btnVoltarRotinaMensalRegistro;

    // NOVOS CAMPOS ADICIONADOS
    [Header("Elementos Extras da Tela de Registro Mensal")]
    public TMP_Text textoAtividadesDoDia; // Exibe "Atividades do dia (número)"
    public Toggle toggleAlarmeMensal;     // Toggle para ativar/desativar o alarme

    private int mesAtual;
    private string diaSelecionadoMensal = "";
    private List<RotinaMensal> rotinasMensais = new List<RotinaMensal>();

    [System.Serializable]
    public class RotinaMensal
    {
        public int Mes;
        public string Dia;
        public string Nome;
        public string Horario;
    }
    // ==================================

    // ================= REGISTRO =================
    [Header("Registro")]
    public GameObject telaRegistro;
    public TMP_InputField inputNomeTarefa;
    public TMP_InputField inputHorarioTarefa;
    public Button btnVoltarRegistro;
    private List<Tarefa> tarefas = new List<Tarefa>();

    // ================= MISSÕES =================
    [Header("Missões")]
    public GameObject telaMissoes;
    public TMP_InputField inputMissao1;
    public TMP_InputField inputMissao2;
    public TMP_InputField inputMissao3;
    public Button btnVoltarMissoes;
    public Button btnVoltarMissoesSemanal;
    private List<Missoes> missoes = new List<Missoes>();

    // ================= CLASSES =================
    [System.Serializable]
    public class Medicamento
    {
        public string Nome;
        public string Dose;
        public List<string> Horarios;
    }

    [System.Serializable]
    public class RotinaDiaria
    {
        public string Atividade;
        public string Horario;
        public string Periodo;
    }

    [System.Serializable]
    public class Tarefa
    {
        public string Nome;
        public string Horario;
    }

    [System.Serializable]
    public class Missoes
    {
        public string Missao1;
        public string Missao2;
        public string Missao3;
    }

    private void Start()
    {
        // Botões de voltar principais
        if (btnVoltarHumor) btnVoltarHumor.onClick.AddListener(() => MostrarTela(telaPrincipal));
        if (btnVoltarMedicacao) btnVoltarMedicacao.onClick.AddListener(() => MostrarTela(telaPrincipal));
        if (btnVoltarRotina) btnVoltarRotina.onClick.AddListener(() => MostrarTela(telaPrincipal));
        if (btnVoltarRegistro) btnVoltarRegistro.onClick.AddListener(() => MostrarTela(telaPrincipal));
        if (btnVoltarMissoes) btnVoltarMissoes.onClick.AddListener(() => MostrarTela(telaPrincipal));
        if (btnVoltarMissoesSemanal) btnVoltarMissoesSemanal.onClick.AddListener(() => MostrarTela(telaPrincipal));

        // Botões da tela principal
        if (btnAbrirHumor) btnAbrirHumor.onClick.AddListener(() => MostrarTela(telaHumor));
        if (btnAbrirMedicacao) btnAbrirMedicacao.onClick.AddListener(() => MostrarTela(telaMedicacao));
        if (btnAbrirRotina) btnAbrirRotina.onClick.AddListener(() => MostrarTela(telaRotina));
        if (btnAbrirRegistro) btnAbrirRegistro.onClick.AddListener(() => MostrarTela(telaRegistro));
        if (btnAbrirMissoes) btnAbrirMissoes.onClick.AddListener(() => MostrarTela(telaMissoes));

        // === ADIÇÃO HUMOR ===
        if (btnContinuarHumor)
            btnContinuarHumor.onClick.AddListener(ConfirmarHumoresSelecionados);
        // =====================

        // Botões de abrir rotinas
        if (btnAbrirRotinaDiaria) btnAbrirRotinaDiaria.onClick.AddListener(() => MostrarTela(telaRotinaDiaria));
        if (btnAbrirRotinaSemanal) btnAbrirRotinaSemanal.onClick.AddListener(() => MostrarTela(telaRotinaSemanal));
        if (btnAbrirRotinaMensal) btnAbrirRotinaMensal.onClick.AddListener(() => MostrarTela(telaRotinaMensal));

        // Botões de voltar dentro das rotinas
        if (btnVoltarRotinaDiaria) btnVoltarRotinaDiaria.onClick.AddListener(() => LimparCamposDiariosERetornar());
        if (btnVoltarRotinaSemanal) btnVoltarRotinaSemanal.onClick.AddListener(() => MostrarTela(telaRotina));
        if (btnVoltarRotinaMensal) btnVoltarRotinaMensal.onClick.AddListener(() => MostrarTela(telaRotina));

        // === MEDICAÇÃO ===
        if (btnAddHorario)
            btnAddHorario.onClick.AddListener(AdicionarHorarioMedicacao);

        if (toggleAlarme)
            toggleAlarme.onValueChanged.AddListener(AtivarOuDesativarAlarmeMedicacao);

        if (btnVoltarMedicacao)
            btnVoltarMedicacao.onClick.AddListener(() => MostrarTela(telaPrincipal));

        // Botão "Incluir novo medicamento" (adicione no inspetor o botão correspondente)
        Button btnIncluirMedicamento = telaMedicacao.GetComponentInChildren<Button>(true);
        if (btnIncluirMedicamento)
            btnIncluirMedicamento.onClick.AddListener(SalvarMedicamento);


        // === ROTINA SEMANAL ===
        if (botoesDiasSemana != null && botoesDiasSemana.Count == 7)
        {
            string[] dias = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            for (int i = 0; i < botoesDiasSemana.Count; i++)
            {
                int index = i;
                botoesDiasSemana[i].onClick.AddListener(() => AbrirTelaRegistroSemanal(dias[index]));
            }
        }

        if (btnVoltarRotinaSemanalRegistro)
            btnVoltarRotinaSemanalRegistro.onClick.AddListener(() => MostrarTela(telaRotinaSemanal));

        // substitui o botão de alarme por toggle: adiciona listener de mudança
        if (btnAlarmeSemanal)
            btnAlarmeSemanal.onValueChanged.AddListener(AtivarOuDesativarAlarmeSemanal);

        if (btnSalvarRotinaSemanal)
            btnSalvarRotinaSemanal.onClick.AddListener(SalvarRotinaSemanal);

        // === ROTINA MENSAL ===
        if (btnMesAnterior) btnMesAnterior.onClick.AddListener(() => MudarMes(-1));
        if (btnProximoMes) btnProximoMes.onClick.AddListener(() => MudarMes(1));

        if (botoesDiasMes != null && botoesDiasMes.Count == 31)
        {
            for (int i = 0; i < botoesDiasMes.Count; i++)
            {
                int dia = i + 1;
                botoesDiasMes[i].onClick.AddListener(() => AbrirTelaRegistroMensal(dia));
            }
        }

        if (btnVoltarRotinaMensalRegistro)
            btnVoltarRotinaMensalRegistro.onClick.AddListener(() => MostrarTela(telaRotinaMensal));

        if (btnSalvarRotinaMensal)
            btnSalvarRotinaMensal.onClick.AddListener(SalvarRotinaMensal);

        // Novo: listener do toggle do alarme mensal
        if (toggleAlarmeMensal)
            toggleAlarmeMensal.onValueChanged.AddListener(AtivarOuDesativarAlarmeMensal);

        // 🗓️ Novo: inicia com o mês atual do sistema
        mesAtual = DateTime.Now.Month;

        AtualizarTextoMes();

        // === ROTINA DIÁRIA ===
        InicializarRotinaDiaria();
    }

    // === ADIÇÃO: ROTINA DIÁRIA ===
    [Header("Botões e Toggles da Rotina Diária")]
    public Button btnAddManha;
    public Toggle toggleAlarmeManha;

    public Button btnAddTarde;
    public Toggle toggleAlarmeTarde;

    public Button btnAddNoite;
    public Toggle toggleAlarmeNoite;

    private void InicializarRotinaDiaria()
    {
        if (btnAddManha) btnAddManha.onClick.AddListener(() => SalvarAtividadeDiaria("manhã"));
        if (btnAddTarde) btnAddTarde.onClick.AddListener(() => SalvarAtividadeDiaria("tarde"));
        if (btnAddNoite) btnAddNoite.onClick.AddListener(() => SalvarAtividadeDiaria("noite"));
    }

    private void SalvarAtividadeDiaria(string periodo)
    {
        TMP_InputField nome = null;
        TMP_InputField horario = null;
        Toggle alarme = null;

        switch (periodo)
        {
            case "manhã":
                nome = inputManhaAtividade[0];
                horario = inputManhaHorario[0];
                alarme = toggleAlarmeManha;
                break;
            case "tarde":
                nome = inputTardeAtividade[0];
                horario = inputTardeHorario[0];
                alarme = toggleAlarmeTarde;
                break;
            case "noite":
                nome = inputNoiteAtividade[0];
                horario = inputNoiteHorario[0];
                alarme = toggleAlarmeNoite;
                break;
        }

        if (nome == null || horario == null) return;

        string horarioValidado = ValidarHorario(horario.text);
        if (string.IsNullOrEmpty(nome.text) || string.IsNullOrEmpty(horarioValidado))
        {
            Debug.LogWarning("⚠️ Preencha o nome e o horário corretamente!");
            return;
        }

        rotinasDiarias.Add(new RotinaDiaria
        {
            Atividade = nome.text,
            Horario = horarioValidado,
            Periodo = periodo
        });

        Debug.Log($"✅ {periodo.ToUpper()}: {nome.text} às {horarioValidado}");

        // Limpa campos e reseta toggle
        nome.text = "";
        horario.text = "";
        if (alarme != null) alarme.isOn = false;
    }

    private void LimparCamposDiariosERetornar()
    {
        foreach (var campo in inputManhaAtividade) campo.text = "";
        foreach (var campo in inputManhaHorario) campo.text = "";
        foreach (var campo in inputTardeAtividade) campo.text = "";
        foreach (var campo in inputTardeHorario) campo.text = "";
        foreach (var campo in inputNoiteAtividade) campo.text = "";
        foreach (var campo in inputNoiteHorario) campo.text = "";

        if (toggleAlarmeManha) toggleAlarmeManha.isOn = false;
        if (toggleAlarmeTarde) toggleAlarmeTarde.isOn = false;
        if (toggleAlarmeNoite) toggleAlarmeNoite.isOn = false;

        MostrarTela(telaRotina);
    }

    // --- MENSAL, SEMANAL E UTILITÁRIOS (mantidos iguais) ---
    private void MudarMes(int direcao)
    {
        mesAtual += direcao;
        if (mesAtual < 1) mesAtual = 12;
        if (mesAtual > 12) mesAtual = 1;
        AtualizarTextoMes();
    }

    private void AtualizarTextoMes()
    {
    string nomeMes = System.Globalization.CultureInfo
                        .GetCultureInfo("en-US")
                        .DateTimeFormat
                        .GetMonthName(mesAtual);

    // Primeira letra maiúscula
    nomeMes = char.ToUpper(nomeMes[0]) + nomeMes.Substring(1);

    textoMes.text = nomeMes;
    }

    private void AbrirTelaRegistroMensal(int dia)
    {
        diaSelecionadoMensal = dia.ToString();
        inputNomeRotinaMensal.text = "";
        inputHorarioRotinaMensal.text = "";
        MostrarTela(telaRegistroMensal);

        // Atualiza o texto "Atividades do dia"
        if (textoAtividadesDoDia)
            textoAtividadesDoDia.text = $"Activities of the day {diaSelecionadoMensal}";

        // Reseta o toggle do alarme
        if (toggleAlarmeMensal)
            toggleAlarmeMensal.isOn = false;

        Debug.Log($"📅 Abrindo registro da rotina mensal - Dia {dia}");
    }

    private void SalvarRotinaMensal()
    {
        string nome = inputNomeRotinaMensal.text;
        string horario = ValidarHorario(inputHorarioRotinaMensal.text);

        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(horario))
        {
            Debug.LogWarning("⚠️ Preencha o nome e o horário corretamente!");
            return;
        }

        RotinaMensal nova = new RotinaMensal
        {
            Mes = mesAtual,
            Dia = diaSelecionadoMensal,
            Nome = nome,
            Horario = horario
        };

        rotinasMensais.Add(nova);
        Debug.Log($"✅ Rotina mensal salva: {nome} - Dia {diaSelecionadoMensal}/{mesAtual} às {horario}");

        // 🔹 NOVO: limpar campos após inserir
        inputNomeRotinaMensal.text = "";
        inputHorarioRotinaMensal.text = "";
        if (toggleAlarmeMensal)
            toggleAlarmeMensal.isOn = false;

        Debug.Log("🧹 Campos da rotina mensal limpos após salvar.");
    }


    private void AtivarOuDesativarAlarmeMensal(bool ativado)
    {
        if (ativado)
            Debug.Log($"🔔 Alarme ativado para o dia {diaSelecionadoMensal}");
        else
            Debug.Log($"🔕 Alarme desativado para o dia {diaSelecionadoMensal}");
    }

    // === ROTINA SEMANAL ===
    private void AbrirTelaRegistroSemanal(string dia)
    {
        diaSelecionadoSemanal = dia;
        inputNomeRotinaSemanal.text = "";
        inputHorarioRotinaSemanal.text = "";
        MostrarTela(telaRegistroSemanal);

        // exibe a semana/dia selecionado no topo (mesma ideia do textoAtividadesDoDia)
        if (textoDiaSemana)
            textoDiaSemana.text = $"Activities of {diaSelecionadoSemanal}";

        // reseta o toggle do alarme semanal
        if (btnAlarmeSemanal)
            btnAlarmeSemanal.isOn = false;

        Debug.Log($"📅 Abrindo registro da rotina semanal - {dia}");
    }

    // antigo AtivarAlarmeSemanal removido (substituído pelo Toggle listener)

    private void SalvarRotinaSemanal()
    {
        string nome = inputNomeRotinaSemanal.text;
        string horarioDigitado = inputHorarioRotinaSemanal.text;
        string horarioValidado = ValidarHorario(horarioDigitado);

        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(horarioValidado))
        {
            Debug.LogWarning("⚠️ Preencha o nome e o horário corretamente!");
            return;
        }

        RotinaSemanal nova = new RotinaSemanal
        {
            Dia = diaSelecionadoSemanal,
            Nome = nome,
            Horario = horarioValidado
        };

        rotinasSemanais.Add(nova);
        Debug.Log($"✅ Rotina semanal salva: {diaSelecionadoSemanal} - {nome} às {horarioValidado}");

        // limpar campos e resetar toggle (comportamento igual ao registro mensal)
        inputNomeRotinaSemanal.text = "";
        inputHorarioRotinaSemanal.text = "";
        if (btnAlarmeSemanal)
            btnAlarmeSemanal.isOn = false;
    }

    private void AtivarOuDesativarAlarmeSemanal(bool ativado)
    {
        if (ativado)
            Debug.Log($"🔔 Alarme ativado para {diaSelecionadoSemanal}");
        else
            Debug.Log($"🔕 Alarme desativado para {diaSelecionadoSemanal}");
    }

    // ---------- UTILITÁRIOS ----------
    private string ValidarHorario(string input)
    {
        if (TimeSpan.TryParseExact(input, "hh\\:mm", null, out TimeSpan horario))
            return horario.ToString(@"hh\:mm");
        else
        {
            Debug.LogWarning("⚠️ Horário inválido: " + input + " | Use o formato HH:mm (ex: 08:30)");
            return null;
        }
    }

    private void ConfirmarHumoresSelecionados()
{
    // Limpa lista de humores anteriores
    humoresSelecionados.Clear();

    // Coleta os toggles marcados
    foreach (var toggle in botoesHumores)
    {
        if (toggle.isOn)
            humoresSelecionados.Add(toggle.GetComponentInChildren<TMP_Text>().text);
    }

    if (humoresSelecionados.Count > 0)
    {
        // Salva o primeiro humor selecionado como o gancho para atualizar o algoritmo de missões
        PlayerPrefs.SetString("UltimoHumorRegistrado", humoresSelecionados[0]);
        PlayerPrefs.Save();

        // Se o objeto de missões existir na cena, força a reconfiguração dinâmica do ecossistema de tarefas
        MissionGenerationSystem algorithm = FindObjectOfType<MissionGenerationSystem>();
        if (algorithm != null)
        {
            algorithm.ResetAndRegenerateMissions();
        }
    }


    // Atualiza o texto exibindo os humores selecionados (se houver)
    if (textoHumoresSelecionados)
    {
        if (humoresSelecionados.Count > 0)
            textoHumoresSelecionados.text = "" + string.Join("\n\n", humoresSelecionados);
        else
            textoHumoresSelecionados.text = "No feeling selected";
    }

    // Desmarca todos os toggles após confirmar
    foreach (var toggle in botoesHumores)
        toggle.isOn = false;

    Debug.Log("✅ Humores confirmados e toggles desativados.");

    // Retorna para a tela principal
    MostrarTela(telaPrincipal);
}

// ==================== MÉTODOS DE MEDICAÇÃO ====================

private void AdicionarHorarioMedicacao()
{
    string horarioDigitado = inputHorario.text;
    string horarioValidado = ValidarHorario(horarioDigitado);

    if (string.IsNullOrEmpty(horarioValidado))
    {
        Debug.LogWarning("⚠️ Horário inválido. Use o formato HH:mm (ex: 08:30)");
        return;
    }

    horariosTemp.Add(horarioValidado);
    Debug.Log($"🕒 Horário adicionado: {horarioValidado}");

    // Limpa apenas o campo de horário
    inputHorario.text = "";
}

private void SalvarMedicamento()
{
    string nome = inputNomeRemedio.text;
    string dose = inputDose.text;

    if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(dose) || horariosTemp.Count == 0)
    {
        Debug.LogWarning("⚠️ Preencha nome, dose e pelo menos um horário.");
        return;
    }

    Medicamento novo = new Medicamento
    {
        Nome = nome,
        Dose = dose,
        Horarios = new List<string>(horariosTemp)
    };

    medicamentos.Add(novo);
    Debug.Log($"💊 Medicamento salvo: {nome} - {dose}mg - Horários: {string.Join(", ", horariosTemp)}");

    // Limpa os campos e lista temporária
    inputNomeRemedio.text = "";
    inputDose.text = "";
    inputHorario.text = "";
    horariosTemp.Clear();

    // Reseta toggle do alarme
    if (toggleAlarme)
        toggleAlarme.isOn = false;
}

private void AtivarOuDesativarAlarmeMedicacao(bool ativado)
{
    if (ativado)
        Debug.Log("🔔 Alarme de medicação ativado.");
    else
        Debug.Log("🔕 Alarme de medicação desativado.");
}


    private void MostrarTela(GameObject tela)
    {
        telaPrincipal.SetActive(false);
        telaHumor.SetActive(false);
        telaMedicacao.SetActive(false);
        telaRotina.SetActive(false);
        telaRotinaDiaria.SetActive(false);
        telaRotinaSemanal.SetActive(false);
        telaRotinaMensal.SetActive(false);
        telaRegistro.SetActive(false);
        telaMissoes.SetActive(false);
        if (telaRegistroSemanal) telaRegistroSemanal.SetActive(false);
        if (telaRegistroMensal) telaRegistroMensal.SetActive(false);

        tela.SetActive(true);
    }
}
