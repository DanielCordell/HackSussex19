using System.Collections;

using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
    private int currentHealth;
    ArrayList healthBoxes;
    public Color noHealth;
    private Color startColor;


    public GameObject healthBoxPrefab;
    // Start is called before the first frame update
    void Start()
    {
        startColor = healthBoxPrefab.transform.Find("Image").GetComponent<Image>().color;
        healthBoxes = new ArrayList();
        currentHealth = PlayerStats.health;
        Debug.Log(PlayerStats.health);
        for(int i = 0; i< currentHealth; i++)
        {
            healthBoxes.Add(Instantiate(healthBoxPrefab, transform));
            Debug.Log("test:" + healthBoxes.Count);
        }
    }

    public void UpdateDisplay()
    {
        currentHealth = PlayerStats.health;
        int i = currentHealth-1;
        foreach (GameObject boxTochange in healthBoxes)
        {
            if(i< 0)
            {
                boxTochange.transform.Find("Image").GetComponent<Image>().color = noHealth;
            }
            else
            {
                boxTochange.transform.Find("Image").GetComponent<Image>().color = startColor;
                i--;
            }

        }
    }
}
