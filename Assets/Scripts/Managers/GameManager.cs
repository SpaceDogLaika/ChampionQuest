using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState currentState;
    public PlayerHolder currentPlayer;
    public GameObject cardPrefab;

    public Turn[] turns;
    public int turnIndex;
    public SO.GameEvent onTurnChanged;
    public SO.GameEvent onPhaseChanged;
    public SO.StringVariable turnText;

    private void Start()
    {
        Settings._gameManager = this;
        CreateStartingCards();
        turnText.value = turns[turnIndex].turnName;
        onTurnChanged.Raise();
    }

    private void CreateStartingCards()
    {
        ResourcesManager resourcesManager = Settings.GetResourcesManager();

        for (int i = 0; i < currentPlayer.startingCards.Length; i++)
        {
            GameObject gameObject = Instantiate(cardPrefab) as GameObject;
            CardViz cardViz = gameObject.GetComponent<CardViz>();
            cardViz.LoadCard(resourcesManager.GetCardInstance(currentPlayer.startingCards[i]));
            CardInstance cardInstance = gameObject.GetComponent<CardInstance>();
            cardInstance.currentLogic = currentPlayer.handLogic;
            Settings.SetParentForCard(gameObject.transform, currentPlayer.handGrid.value.transform);
        }
    }

    private void FixedUpdate()
    {
        bool isComplete = turns[turnIndex].Execute();

        if (isComplete)
        {
            turnIndex++;

            if (turnIndex > turns.Length - 1)
                turnIndex = 0;

            turnText.value = turns[turnIndex].turnName;
            onTurnChanged.Raise();
        }

        if (currentState)
            currentState.Tick(Time.deltaTime);
    }

    public void SetState(GameState state)
    {
        currentState = state;
    }
}
