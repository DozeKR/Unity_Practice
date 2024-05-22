using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int stageIndex;

    [SerializeField] private int playerHealth;


    public void NextStage()
    {
        stageIndex++;
    }

    public void HealthDown(int damage)
    {
        playerHealth -= damage;
    }
}
