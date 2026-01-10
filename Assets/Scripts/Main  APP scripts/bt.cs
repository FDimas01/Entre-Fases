using UnityEngine;

public class BotaoTrocarTela : MonoBehaviour
{
    public ScreenManager screenManager;
    public GameObject telaDesejada;

    public void TrocarTela()
    {
        screenManager.AtivarSomente(telaDesejada);
    }
}
