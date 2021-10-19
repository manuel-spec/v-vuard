using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Animation;

public delegate void FrameEventHandler(Entity entity, string eventId);

public sealed class AnimationStateMachine
{
    private readonly Dictionary<string, AnimationClip> _clips;
    private string _current = string.Empty;
    private int _frameIndex;
    private float _frameTime;
    private bool _finished;

    public AnimationStateMachine(IEnumerable<AnimationClip> clips, string initial)
    {
        _clips = clips.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);
        if (!_clips.ContainsKey(initial))
            throw new ArgumentException($"Unknown initial clip '{initial}'.", nameof(initial));
        Play(initial, restart: true);
    }

    public string CurrentClip => _current;
    public int FrameIndex => _frameIndex;
    public bool Finished => _finished;
    public SpriteFrame CurrentFrame => _clips[_current].Frames[_frameIndex];

    public void Play(string clipName, bool restart = false)
    {
        if (!_clips.TryGetValue(clipName, out _))
            throw new KeyNotFoundException($"Clip '{clipName}' not found.");

        if (!restart && string.Equals(_current, clipName, StringComparison.OrdinalIgnoreCase))
            return;

        _current = clipName;
        _frameIndex = 0;
        _frameTime = 0f;
        _finished = false;
    }

    public List<string> Update(float deltaSeconds)
    {
        var events = new List<string>();
        if (_finished)
            return events;

        var clip = _clips[_current];
        _frameTime += deltaSeconds;

        while (_frameTime >= clip.Frames[_frameIndex].DurationSeconds)
        {
            _frameTime -= clip.Frames[_frameIndex].DurationSeconds;
            var evt = clip.Frames[_frameIndex].EventId;
            if (!string.IsNullOrEmpty(evt))
                events.Add(evt!);

            if (_frameIndex + 1 >= clip.Frames.Length)
            {
                if (clip.Loop)
                {
                    _frameIndex = 0;
                }
                else
                {
                    _finished = true;
                    break;
                }
            }
            else
            {
                _frameIndex++;
            }
        }

        return events;
    }
}

public struct AnimationComponent : IComponent
{
    public AnimationStateMachine? StateMachine;
    public bool FacingRight;
}
