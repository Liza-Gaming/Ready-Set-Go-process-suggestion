using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BasketBehavior : MonoBehaviour
{
    int points = 0;
    public Text textToShow;

    public List<ClothingSpawner> spawners; // List to hold all your spawners

    void Start()
    {
        textToShow.text = "Collect all of the winter items";
    }

    private void OnCollisionEnter(Collision other)
    {
        string clothTag = other.gameObject.tag;
       // Destroy the clothing item that's collected
        Destroy(other.gameObject);

        if (clothTag == "Sweater" || clothTag == "Socks" || clothTag == "Winter Hat" || clothTag == "Jeans Pants" || clothTag == "UnderPants")
        {
            points++;
            textToShow.color = Color.green;
            textToShow.text = "Great!";
            if (points == 5)
            {
                SceneManager.LoadScene(0);
            }
            // Iterate over each spawner and remove the corresponding clothing
            foreach (var spawner in spawners)
            {
                GameObject clothToRemove = null;
                foreach (GameObject clothing in spawner.prefabToSpawn)
                {
                    if (clothing.CompareTag(clothTag))
                    {
                        clothToRemove = clothing;
                        break;
                    }
                }

                if (clothToRemove != null)
                {
                    spawner.prefabToSpawn.Remove(clothToRemove);
                }
            }
        }
        else
        {
            textToShow.color = Color.red;
            textToShow.text = "Summer Item collected";
        }
    }
}