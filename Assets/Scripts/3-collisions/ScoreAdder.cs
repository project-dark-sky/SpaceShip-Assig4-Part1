using UnityEngine;

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField]
    string triggeringTag;

    [SerializeField]
    NumberField scoreField;

    [SerializeField]
    int pointsToAdd;

    [SerializeField]
    private Playerlife playerLifeScript;

    [SerializeField]
    private int amoutForLife = 50;
    private static int trackAmountForLife = 0;

    public void Start()
    {
        playerLifeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playerlife>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && scoreField != null)
        {
            scoreField.AddNumber(pointsToAdd);
            trackAmountForLife += pointsToAdd;

            //each times reaches certain amout of point he will be gifted with a life.
            if (trackAmountForLife >= amoutForLife)
            {
                playerLifeScript.RewardALife(5);
                trackAmountForLife = 0;
            }
        }
    }

    public void SetScoreField(NumberField newTextField)
    {
        this.scoreField = newTextField;
    }
}
