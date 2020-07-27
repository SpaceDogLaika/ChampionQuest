using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized]
    public PlayerHolder[] allPlayers;
    public GameState currentState;
    public PlayerHolder currentPlayer;
    public CardHolders playerOneHolder;
    public CardHolders otherPlayersHolder;

    public GameObject cardPrefab;

    public Turn[] turns;
    public int turnIndex;
    public SO.GameEvent onTurnChanged;
    public SO.GameEvent onPhaseChanged;
    public SO.StringVariable turnText;

    public bool switchPlayer;

    public static GameManager gmSingleton;

    private void Awake()
    {
        gmSingleton = this;

        allPlayers = new PlayerHolder[turns.Length];

        for (int i = 0; i < turns.Length; i++)
        {
            allPlayers[i] = turns[i].player;
        }

        currentPlayer = turns[0].player;
    }

    private void Start()
    {
        Settings._gameManager = this;

        SetupPlayers();

        CreateStartingCards();
        turnText.value = turns[turnIndex].player.username;
        onTurnChanged.Raise();
    }

    public void SetupPlayers()
    {
        foreach (PlayerHolder p in allPlayers)
        {
            if (p.isHumanPlayer)
            {
                p.currentHolder = playerOneHolder;
            }
            else
            {
                p.currentHolder = otherPlayersHolder;
            }
        }
    }

    private void CreateStartingCards()
    {
        ResourcesManager resourcesManager = Settings.GetResourcesManager();

        for (int p = 0; p < allPlayers.Length; p++)
        {
            for (int i = 0; i < allPlayers[p].startingCards.Length; i++)
            {
                GameObject gameObject = Instantiate(cardPrefab) as GameObject;
                CardViz cardViz = gameObject.GetComponent<CardViz>();
                cardViz.LoadCard(resourcesManager.GetCardInstance(allPlayers[p].startingCards[i]));
                CardInstance cardInstance = gameObject.GetComponent<CardInstance>();
                cardInstance.currentLogic = allPlayers[p].handLogic;
                Settings.SetParentForCard(gameObject.transform, allPlayers[p].currentHolder.handGrid.value.transform);
                allPlayers[p].handCards.Add(cardInstance);
            }

            Settings.RegisterEvent("Created cards for player - " + allPlayers[p].username, allPlayers[p].playerColor);
        }


    }

    private void FixedUpdate()
    {
        if (switchPlayer)
        {
            switchPlayer = false;

            playerOneHolder.LoadPlayer(allPlayers[1]);
            otherPlayersHolder.LoadPlayer(allPlayers[0]);
        }

        bool isComplete = turns[turnIndex].Execute();

        if (isComplete)
        {
            turnIndex++;

            if (turnIndex > turns.Length - 1)
                turnIndex = 0;


            // Current player changes here
            currentPlayer = turns[turnIndex].player;
            turns[turnIndex].OnTurnStart();
            turnText.value = turns[turnIndex].player.username;
            onTurnChanged.Raise();
        }

        if (currentState)
            currentState.Tick(Time.deltaTime);
    }

    public void SetState(GameState state)
    {
        currentState = state;
    }

    public void EndCurrentPhase()
    {
        turns[turnIndex].EndCurrentPhase();

        Settings.RegisterEvent(turns[turnIndex].name + " finished", currentPlayer.playerColor);
    }
}
