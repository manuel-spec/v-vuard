using VanguardProtocol.Animation;

namespace VanguardProtocol.Animation.Tests;

public class AnimationStateMachineTests
{
    private static AnimationClip Clip(string name, int frames, float duration, bool loop, int? eventFrame = null) =>
        new(name, Enumerable.Range(0, frames).Select(i =>
            new SpriteFrame(i * 16, 0, 16, 16, duration, eventFrame == i ? "fire" : null)).ToArray(), loop);

    [Fact]
    public void Update_AdvancesFramesAndLoops()
    {
        var sm = new AnimationStateMachine([Clip("run", 3, 0.1f, loop: true)], "run");
        Assert.Equal(0, sm.FrameIndex);
        sm.Update(0.1f);
        Assert.Equal(1, sm.FrameIndex);
        sm.Update(0.2f);
        Assert.Equal(0, sm.FrameIndex); // wrapped
        Assert.False(sm.Finished);
    }

    [Fact]
    public void NonLooping_FinishesAndEmitsEvent()
    {
        var sm = new AnimationStateMachine([Clip("shoot", 2, 0.1f, loop: false, eventFrame: 0)], "shoot");
        var events = sm.Update(0.1f);
        Assert.Contains("fire", events);
        sm.Update(0.1f);
        Assert.True(sm.Finished);
    }

    [Fact]
    public void Play_RestartsOnlyWhenRequested()
    {
        var sm = new AnimationStateMachine(
            [Clip("idle", 2, 0.1f, true), Clip("run", 2, 0.1f, true)],
            "idle");
        sm.Update(0.1f);
        sm.Play("idle");
        Assert.Equal(1, sm.FrameIndex);
        sm.Play("idle", restart: true);
        Assert.Equal(0, sm.FrameIndex);
    }
}
