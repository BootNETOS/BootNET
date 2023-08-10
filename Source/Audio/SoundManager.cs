using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio;
using Cosmos.System.Audio.IO;

namespace BootNET.Audio;

/// <summary>
///     A very basic sound manager using CAI (Cosmos Audio Infrastructure)
/// </summary>
public static class SoundManager
{
    #region Methods

    /// <summary>
    ///     Initialize Sound Manager.
    /// </summary>
    public static void Initialize()
    {
        driver = AC97.Initialize(4096);
        manager = new AudioManager
        {
            Stream = mixer,
            Output = driver
        };

        manager.Enable();
    }

    /// <summary>
    ///     Disable Sound Manager.
    /// </summary>
    public static void Disable()
    {
        manager.Disable();
    }

    /// <summary>
    ///     Play audio from bytes.
    /// </summary>
    /// <param name="audio">Bytes of a wave (.wav) file.</param>
    public static void PlayAudio(byte[] audio)
    {
        var audioStream = MemoryAudioStream.FromWave(audio);
        mixer.Streams.Add(audioStream);
    }

    #endregion

    #region Fields

    public static AudioMixer mixer;
    public static AudioStream stream;
    public static AudioDriver driver;
    public static AudioManager manager;

    #endregion
}