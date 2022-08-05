using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private Text lenghtText;
    [SerializeField] private Text lenghtButtonPrizeText;
    [SerializeField] private Text strengthText;
    [SerializeField] private Text strengthButtonPrizeText;
    [SerializeField] private Text offlineText;
    [SerializeField] private Text offlineButtonPrizeText;
    [SerializeField] private Text currentCurrencyText;

    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private HookController hook;
    [SerializeField] private FishCatcher fishCatcher;
    public Canvas onSurfaceCanvas;

    private void Start()
    {
        lenghtText.text = levelManager.currentDeptLenght + "m";
        strengthText.text = levelManager.currentStrength + "Fishes";
        currentCurrencyText.text = CurrencyManager.Instance.currentCurrency + "$";
    }

    public void ChangeMaxDept()
    {
        levelManager.CalculateDepthLenght();
        lenghtText.text = levelManager.currentDeptLenght + "m";
    }

    public void ChangeStrength()
    {
        levelManager.IncrementStrength();
        strengthText.text = levelManager.currentStrength + "Fishes";
    }

    public void TapToFish()
    {
        hook.StartCoroutine(hook.Hook());      
        fishCatcher.catchList.Clear();
    }

    public void UpdateCurrencyText()
    {
        currentCurrencyText.text = CurrencyManager.Instance.currentCurrency + "$";
    }

}
