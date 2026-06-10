using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MissionGenerationSystem : MonoBehaviour
{
    [Header("UI Elements - Missões Diárias (Today)")]
    public TMP_Text txtDailyMission1;
    public TMP_Text txtDailyMission2;
    public TMP_Text txtDailyMission3;

    [Header("UI Elements - Missões Mensais (Month)")]
    public TMP_Text txtMonthlyMission1;
    public TMP_Text txtMonthlyMission2;
    public TMP_Text txtMonthlyMission3;

    // Bancos de dados de missões (Variedade baseada no Fogg Behavior Model e Octalysis)
    private readonly string[] dailyLowEnergyMissions = {
        "Drink a full glass of water right now.",
        "Open the curtains to let natural light in for 5 min.",
        "Send an emoji to a trusted friend or support network.",
        "Sit comfortably and take 5 deep, slow breaths.",
        "List 2 small things you are grateful for today.",
        "Listen to one song that brings you calm or comfort.",
        "Wash 3 pieces of dishes or organize one single drawer."
    };

    private readonly string[] monthlyLowEnergyMissions = {
        "Maintain a steady wake-up time for 7 consecutive days.",
        "Log your mood using emojis at least 15 times this month.",
        "Have one voice/video call with your support avatar person.",
        "Complete 8 daily low-effort behavioral activation tasks.",
        "Go outside for a short, quiet walk 3 times this week."
    };

    private readonly string[] dailyHighEnergyMissions = {
        "Write down your current ideas on paper to clear your mind.",
        "Avoid screens (phone/TV) for 30 minutes before bed.",
        "Sit quietly for 5 minutes without multitasking.",
        "Listen to a relaxing, low-tempo instrumental track.",
        "Postpone any major unexpected purchase for 48 hours.",
        "Drink a warm, caffeine-free tea to help stabilize.",
        "Focus on eating a meal slowly, without checking notifications."
    };

    private readonly string[] monthlyHighEnergyMissions = {
        "Establish and follow a strict 'lights out' routine for 2 weeks.",
        "Keep a daily log of expenditures to monitor impulsivity.",
        "Practice a 15-minute stabilization mindfulness routine weekly.",
        "Successfully take your prescribed medication on time for 20 days.",
        "Discuss your energy tracking logs with your healthcare provider."
    };

    private void OnEnable()
    {
        LoadOrGenerateMissions();
    }

    public void LoadOrGenerateMissions()
    {
        // Verifica se as missões já foram geradas através do registro de humor
        if (PlayerPrefs.HasKey("DailyMission1"))
        {
            DisplaySavedMissions();
        }
        else
        {
            // Se não houver missões salvas, exibe uma mensagem pedindo para registrar o humor
            DisplayPlaceholderMissions();
        }
    }

    private void DisplayPlaceholderMissions()
    {
        string placeholderMsg = "Log your mood today to receive missions!";

        if (txtDailyMission1 != null) txtDailyMission1.text = placeholderMsg;
        if (txtDailyMission2 != null) txtDailyMission2.text = placeholderMsg;
        if (txtDailyMission3 != null) txtDailyMission3.text = placeholderMsg;

        if (txtMonthlyMission1 != null) txtMonthlyMission1.text = placeholderMsg;
        if (txtMonthlyMission2 != null) txtMonthlyMission2.text = placeholderMsg;
        if (txtMonthlyMission3 != null) txtMonthlyMission3.text = placeholderMsg;
    }

    // Este método agora só é chamado quando o usuário confirma o humor na tela do Mood Tracker
    private void GenerateNewMissionsBasedOnMood()
    {
        string ultimoHumor = PlayerPrefs.GetString("UltimoHumorRegistrado", "Calm");

        bool isHighEnergyPhase = CheckIfHighEnergy(ultimoHumor);

        string[] currentDailyPool = isHighEnergyPhase ? dailyHighEnergyMissions : dailyLowEnergyMissions;
        string[] currentMonthlyPool = isHighEnergyPhase ? monthlyHighEnergyMissions : monthlyLowEnergyMissions;

        List<string> dailyChosen = GetRandomUniqueMissions(currentDailyPool, 3);
        List<string> monthlyChosen = GetRandomUniqueMissions(currentMonthlyPool, 3);

        PlayerPrefs.SetString("DailyMission1", dailyChosen[0]);
        PlayerPrefs.SetString("DailyMission2", dailyChosen[1]);
        PlayerPrefs.SetString("DailyMission3", dailyChosen[2]);

        PlayerPrefs.SetString("MonthlyMission1", monthlyChosen[0]);
        PlayerPrefs.SetString("MonthlyMission2", monthlyChosen[1]);
        PlayerPrefs.SetString("MonthlyMission3", monthlyChosen[2]);
        PlayerPrefs.Save();

        DisplaySavedMissions();
    }

    private bool CheckIfHighEnergy(string mood)
    {
        string moodLower = mood.ToLower();
        if (moodLower.Contains("mania") || moodLower.Contains("excited") || 
            moodLower.Contains("euphoric") || moodLower.Contains("irritable") || moodLower.Contains("agitated"))
        {
            return true; 
        }
        return false; 
    }

    private List<string> GetRandomUniqueMissions(string[] pool, int count)
    {
        List<string> tempPool = new List<string>(pool);
        List<string> chosen = new List<string>();

        for (int i = 0; i < count; i++)
        {
            if (tempPool.Count == 0) break;
            int randomIndex = Random.Range(0, tempPool.Count);
            chosen.Add(tempPool[randomIndex]);
            tempPool.RemoveAt(randomIndex); 
        }

        while (chosen.Count < count) chosen.Add("Complete a health routine activity.");

        return chosen;
    }

    private void DisplaySavedMissions()
    {
        if (txtDailyMission1 != null) txtDailyMission1.text = PlayerPrefs.GetString("DailyMission1");
        if (txtDailyMission2 != null) txtDailyMission2.text = PlayerPrefs.GetString("DailyMission2");
        if (txtDailyMission3 != null) txtDailyMission3.text = PlayerPrefs.GetString("DailyMission3");

        if (txtMonthlyMission1 != null) txtMonthlyMission1.text = PlayerPrefs.GetString("MonthlyMission1");
        if (txtMonthlyMission2 != null) txtMonthlyMission2.text = PlayerPrefs.GetString("MonthlyMission2");
        if (txtMonthlyMission3 != null) txtMonthlyMission3.text = PlayerPrefs.GetString("MonthlyMission3");
    }

    // Método que você chama lá no seu TelaPrincipalManager após confirmar o humor
    public void ResetAndRegenerateMissions()
    {
        // Deleta as chaves antigas para garantir que o sistema crie novas
        PlayerPrefs.DeleteKey("DailyMission1");
        PlayerPrefs.DeleteKey("DailyMission2");
        PlayerPrefs.DeleteKey("DailyMission3");
        PlayerPrefs.DeleteKey("MonthlyMission1");
        PlayerPrefs.DeleteKey("MonthlyMission2");
        PlayerPrefs.DeleteKey("MonthlyMission3");
        
        // Agora, em vez de LoadOrGenerateMissions, chamamos diretamente a geração
        GenerateNewMissionsBasedOnMood();
    }
}