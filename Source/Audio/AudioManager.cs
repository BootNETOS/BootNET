using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio;
using Cosmos.System.Audio.IO;

namespace BootNET.Audio
{
    /// <summary>
    /// Simple Audio Manager, using CAI (Cosmos Audio Infrastructure)
    /// </summary>
    public static class AudioManager
    {
        public static AC97 AudioDriver;
        public static AudioMixer Mixer;
        /// <summary>
        /// Initialize driver and mixer.
        /// </summary>
        /// <param name="bufferSize"></param>
        public static void Initialize(ushort bufferSize = 4096)
        {
            AudioDriver = AC97.Initialize(bufferSize);
            Mixer = new();
        }
        /// <summary>
        /// Play a wav file.
        /// </summary>
        /// <param name="audioBytes">Wav file audio bytes.</param>
        public static void PlayAudio(byte[] audioBytes)
        {
            var audioStream = MemoryAudioStream.FromWave(audioBytes);
            Mixer.Streams.Add(audioStream);

            var audioManager = new Cosmos.System.Audio.AudioManager()
            {
                Stream = Mixer,
                Output = AudioDriver
            };
            audioManager.Enable();
        }
    }
}
