using System.Linq;
using UnityEngine;

public class FirstPersonAudio : MonoBehaviour
{
    private Player player;
    public GroundCheck groundCheck;

    [Header("Step")]
    public AudioSource stepAudio;
    public AudioSource runningAudio;
    [Tooltip("Minimum velocity for moving audio to play")]
    /// <summary> "Minimum velocity for moving audio to play" </summary>
    public float velocityThreshold = .01f;
    Vector2 lastCharacterPosition;
    Vector2 CurrentCharacterPosition => new Vector2(player.transform.position.x, player.transform.position.z);

    [Header("Landing")]
    public AudioSource landingAudio;
    public AudioClip[] landingSFX;

    [Header("Jump")]

    public AudioSource jumpAudio;
    public AudioClip[] jumpSFX;

    [Header("Crouch")]
    //public Crouch crouch;
    public AudioSource crouchStartAudio, crouchedAudio, crouchEndAudio;
    public AudioClip[] crouchStartSFX, crouchEndSFX;

    AudioSource[] MovingAudios => new AudioSource[] { stepAudio, runningAudio, crouchedAudio };

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    void Reset()
    {
        // Setup stuff.

        groundCheck = (transform.parent ?? transform).GetComponentInChildren<GroundCheck>();
        stepAudio = GetOrCreateAudioSource("Step Audio");
        runningAudio = GetOrCreateAudioSource("Running Audio");
        landingAudio = GetOrCreateAudioSource("Landing Audio");

        // Setup jump audio.
        jumpAudio = GetOrCreateAudioSource("Jump audio");
        crouchStartAudio = GetOrCreateAudioSource("Crouch Start Audio");
        crouchStartAudio = GetOrCreateAudioSource("Crouched Audio");
        crouchStartAudio = GetOrCreateAudioSource("Crouch End Audio");

    }



    void FixedUpdate()
    {
        // Play moving audio if the character is moving and on the ground.
        float velocity = Vector3.Distance(CurrentCharacterPosition, lastCharacterPosition);
        if (velocity >= velocityThreshold && groundCheck && groundCheck.isGrounded)
        {

            if (player.IsRunning())
            {
                SetPlayingMovingAudio(runningAudio);
            }
            else if (player.IsJumping())
            {
                SetPlayingMovingAudio(jumpAudio);
            }
            else
            {
                SetPlayingMovingAudio(stepAudio);
            }
        }
        else
        {
            SetPlayingMovingAudio(null);
        }

        // Remember lastCharacterPosition.
        lastCharacterPosition = CurrentCharacterPosition;
    }


    /// <summary>
    /// Pause all MovingAudios and enforce play on audioToPlay.
    /// </summary>
    /// <param name="audioToPlay">Audio that should be playing.</param>
    void SetPlayingMovingAudio(AudioSource audioToPlay)
    {
        // Pause all MovingAudios.
        foreach (var audio in MovingAudios.Where(audio => audio != audioToPlay && audio != null))
        {
            audio.Pause();
        }

        // Play audioToPlay if it was not playing.
        if (audioToPlay && !audioToPlay.isPlaying)
        {

            audioToPlay.Play();
        }
    }

    /// <summary>
    /// Get an existing AudioSource from a name or create one if it was not found.
    /// </summary>
    /// <param name="name">Name of the AudioSource to search for.</param>
    /// <returns>The created AudioSource.</returns>
    AudioSource GetOrCreateAudioSource(string name)
    {
        // Try to get the audiosource.
        AudioSource result = System.Array.Find(GetComponentsInChildren<AudioSource>(), a => a.name == name);
        if (result)
            return result;

        // Audiosource does not exist, create it.
        result = new GameObject(name).AddComponent<AudioSource>();
        result.spatialBlend = 1;
        result.playOnAwake = false;
        result.transform.SetParent(transform, false);
        return result;
    }

}