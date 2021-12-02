namespace VanguardProtocol.Audio;

public interface IAudioClipPlayer
{
    void PlaySfx(string cueId, float volume);
    void PlayMusic(string trackId, bool loop);
    void StopMusic();
    void SetMusicVolume(float volume);
}

public sealed class NullAudioClipPlayer : IAudioClipPlayer
{
    public int SfxCount { get; private set; }
    public string? CurrentMusic { get; private set; }
    public void PlaySfx(string cueId, float volume) => SfxCount++;
    public void PlayMusic(string trackId, bool loop) => CurrentMusic = trackId;
    public void StopMusic() => CurrentMusic = null;
    public void SetMusicVolume(float volume) { }
}

public sealed class SfxManager
{
    private readonly IAudioClipPlayer _player;
    private readonly Dictionary<string, float> _cooldowns = new();
    public SfxManager(IAudioClipPlayer player) => _player = player;

    public void Play(string cueId, float volume = 1f, float minInterval = 0.05f)
    {
        if (_cooldowns.TryGetValue(cueId, out var cd) && cd > 0f)
            return;
        _player.PlaySfx(cueId, Math.Clamp(volume, 0f, 1f));
        _cooldowns[cueId] = minInterval;
    }

    public void Tick(float dt)
    {
        foreach (var key in _cooldowns.Keys.ToArray())
        {
            var v = _cooldowns[key] - dt;
            if (v <= 0)
                _cooldowns.Remove(key);
            else
                _cooldowns[key] = v;
        }
    }
}

public sealed class MusicManager
{
    private readonly IAudioClipPlayer _player;
    private float _volume = 1f;
    private float _duck = 1f;
    public MusicManager(IAudioClipPlayer player) => _player = player;
    public void Play(string trackId, bool loop = true) => _player.PlayMusic(trackId, loop);
    public void Stop() => _player.StopMusic();
    public void SetVolume(float volume) { _volume = Math.Clamp(volume, 0f, 1f); Apply(); }
    public void Duck(float factor) { _duck = Math.Clamp(factor, 0f, 1f); Apply(); }
    private void Apply() => _player.SetMusicVolume(_volume * _duck);
}
