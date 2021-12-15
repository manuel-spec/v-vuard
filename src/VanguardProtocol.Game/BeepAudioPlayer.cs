using Microsoft.Xna.Framework.Audio;
using VanguardProtocol.Audio;

namespace VanguardProtocol.Game;

/// <summary>Procedural square-wave SFX so the game has audio without Content Pipeline assets.</summary>
public sealed class BeepAudioPlayer : IAudioClipPlayer, IDisposable
{
    private readonly Dictionary<string, DynamicSoundEffectInstance> _tones = new();
    private bool _disposed;

    public void PlaySfx(string cueId, float volume)
    {
        EnsureTone(cueId);
        if (!_tones.TryGetValue(cueId, out var tone))
            return;
        tone.Volume = Math.Clamp(volume, 0f, 1f);
        if (tone.State == SoundState.Playing)
            tone.Stop();
        tone.Play();
    }

    public void PlayMusic(string trackId, bool loop) { }
    public void StopMusic() { }
    public void SetMusicVolume(float volume) { }

    private void EnsureTone(string cueId)
    {
        if (_tones.ContainsKey(cueId))
            return;

        var (freq, ms) = cueId switch
        {
            "shoot" => (880, 40),
            "hit" => (220, 70),
            "hurt" => (140, 120),
            "pickup" => (660, 80),
            "jump" => (520, 50),
            "clear" => (523, 220),
            "ui" => (400, 40),
            _ => (330, 50),
        };

        var sampleRate = 22050;
        var samples = sampleRate * ms / 1000;
        var data = new byte[samples * 2];
        for (var i = 0; i < samples; i++)
        {
            var t = i / (double)sampleRate;
            var amp = (short)(((i / (sampleRate / freq)) % 2 == 0 ? 1 : -1) * 8000);
            // Fade out
            var fade = 1.0 - (i / (double)samples);
            amp = (short)(amp * fade);
            data[i * 2] = (byte)(amp & 0xFF);
            data[i * 2 + 1] = (byte)((amp >> 8) & 0xFF);
        }

        var tone = new DynamicSoundEffectInstance(sampleRate, AudioChannels.Mono);
        tone.SubmitBuffer(data);
        _tones[cueId] = tone;
    }

    public void Dispose()
    {
        if (_disposed)
            return;
        _disposed = true;
        foreach (var tone in _tones.Values)
            tone.Dispose();
        _tones.Clear();
    }
}
