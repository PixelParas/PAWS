using UnityEngine;
using UnityEngine.SceneManagement;


public class Mainmenu : MonoBehaviour
{
    public GameObject menuPanel; // The main menu panel
    public GameObject learnMorePanel; // The Learn More panel

    public AudioClip backgroundMusic; // Background music for the menu

    private AudioSource audioSource; // AudioSource component
    void Start()
    {
        // Ensure the correct panels are active
        menuPanel.SetActive(true);
        learnMorePanel.SetActive(false);


        // Add and configure AudioSource component for background music
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 0.5f; // Adjust volume as needed

        // Play background music
        if (backgroundMusic != null)
        {
            audioSource.Play();
        }
    }

    // Function to load the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("TurrentTest"); // Replace "GameScene" with your actual game scene name
    }

    // Function to show the Learn More panel
    public void OpenLearnMore()
    {
        menuPanel.SetActive(false);
        learnMorePanel.SetActive(true);
    }

    // Function to go back to the main menu panel
    public void BackToMenu()
    {
        learnMorePanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
