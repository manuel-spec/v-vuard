namespace VanguardProtocol.Animation;

public readonly struct SpriteFrame
{
    public SpriteFrame(int x, int y, int width, int height, float durationSeconds, string? eventId = null)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        DurationSeconds = durationSeconds;
        EventId = eventId;
    }

    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }
    public float DurationSeconds { get; }
    public string? EventId { get; }
}

public sealed class AnimationClip
{
    public AnimationClip(string name, SpriteFrame[] frames, bool loop = true)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (frames.Length == 0)
            throw new ArgumentException("Clip requires at least one frame.", nameof(frames));

        Name = name;
        Frames = frames;
        Loop = loop;
        DurationSeconds = 0f;
        for (var i = 0; i < frames.Length; i++)
            DurationSeconds += frames[i].DurationSeconds;
    }

    public string Name { get; }
    public SpriteFrame[] Frames { get; }
    public bool Loop { get; }
    public float DurationSeconds { get; }
}

public sealed class SpriteSheet
{
    public SpriteSheet(string textureId, int frameWidth, int frameHeight)
    {
        TextureId = textureId;
        FrameWidth = frameWidth;
        FrameHeight = frameHeight;
        Clips = new Dictionary<string, AnimationClip>(StringComparer.OrdinalIgnoreCase);
    }

    public string TextureId { get; }
    public int FrameWidth { get; }
    public int FrameHeight { get; }
    public Dictionary<string, AnimationClip> Clips { get; }

    public AnimationClip AddClip(string name, int startFrame, int frameCount, float frameDuration, bool loop = true, int? eventFrame = null, string? eventId = null)
    {
        var frames = new SpriteFrame[frameCount];
        for (var i = 0; i < frameCount; i++)
        {
            var index = startFrame + i;
            var x = (index * FrameWidth);
            var evt = eventFrame == i ? eventId : null;
            frames[i] = new SpriteFrame(x, 0, FrameWidth, FrameHeight, frameDuration, evt);
        }

        var clip = new AnimationClip(name, frames, loop);
        Clips[name] = clip;
        return clip;
    }
}
