using VanguardProtocol.Netcode.Transport.Messages;
using Xunit;

namespace VanguardProtocol.Netcode.Tests;

public class MessageCodecTests
{

    [Fact]
    public void HelloMessage_RoundTrip()
    {
        var original = new HelloMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[HelloMessage.Size];
        Assert.Equal(HelloMessage.Size, original.Write(buf));
        Assert.True(HelloMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void HelloAckMessage_RoundTrip()
    {
        var original = new HelloAckMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[HelloAckMessage.Size];
        Assert.Equal(HelloAckMessage.Size, original.Write(buf));
        Assert.True(HelloAckMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void InputBatchMessage_RoundTrip()
    {
        var original = new InputBatchMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[InputBatchMessage.Size];
        Assert.Equal(InputBatchMessage.Size, original.Write(buf));
        Assert.True(InputBatchMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void ChecksumMessage_RoundTrip()
    {
        var original = new ChecksumMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[ChecksumMessage.Size];
        Assert.Equal(ChecksumMessage.Size, original.Write(buf));
        Assert.True(ChecksumMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void PingMessage_RoundTrip()
    {
        var original = new PingMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[PingMessage.Size];
        Assert.Equal(PingMessage.Size, original.Write(buf));
        Assert.True(PingMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void PongMessage_RoundTrip()
    {
        var original = new PongMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[PongMessage.Size];
        Assert.Equal(PongMessage.Size, original.Write(buf));
        Assert.True(PongMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void DisconnectMessage_RoundTrip()
    {
        var original = new DisconnectMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[DisconnectMessage.Size];
        Assert.Equal(DisconnectMessage.Size, original.Write(buf));
        Assert.True(DisconnectMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void MatchOfferMessage_RoundTrip()
    {
        var original = new MatchOfferMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[MatchOfferMessage.Size];
        Assert.Equal(MatchOfferMessage.Size, original.Write(buf));
        Assert.True(MatchOfferMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void MatchAcceptMessage_RoundTrip()
    {
        var original = new MatchAcceptMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[MatchAcceptMessage.Size];
        Assert.Equal(MatchAcceptMessage.Size, original.Write(buf));
        Assert.True(MatchAcceptMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void NatProbeMessage_RoundTrip()
    {
        var original = new NatProbeMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[NatProbeMessage.Size];
        Assert.Equal(NatProbeMessage.Size, original.Write(buf));
        Assert.True(NatProbeMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void KeepAliveMessage_RoundTrip()
    {
        var original = new KeepAliveMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[KeepAliveMessage.Size];
        Assert.Equal(KeepAliveMessage.Size, original.Write(buf));
        Assert.True(KeepAliveMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void ChatMessage_RoundTrip()
    {
        var original = new ChatMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[ChatMessage.Size];
        Assert.Equal(ChatMessage.Size, original.Write(buf));
        Assert.True(ChatMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void ReadyMessage_RoundTrip()
    {
        var original = new ReadyMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[ReadyMessage.Size];
        Assert.Equal(ReadyMessage.Size, original.Write(buf));
        Assert.True(ReadyMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void PauseMessage_RoundTrip()
    {
        var original = new PauseMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[PauseMessage.Size];
        Assert.Equal(PauseMessage.Size, original.Write(buf));
        Assert.True(PauseMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void ResumeMessage_RoundTrip()
    {
        var original = new ResumeMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[ResumeMessage.Size];
        Assert.Equal(ResumeMessage.Size, original.Write(buf));
        Assert.True(ResumeMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }

    [Fact]
    public void MapVoteMessage_RoundTrip()
    {
        var original = new MapVoteMessage(42, 99, 7);
        Span<byte> buf = stackalloc byte[MapVoteMessage.Size];
        Assert.Equal(MapVoteMessage.Size, original.Write(buf));
        Assert.True(MapVoteMessage.TryRead(buf, out var copy));
        Assert.Equal(original.Frame, copy.Frame);
        Assert.Equal(original.Token, copy.Token);
        Assert.Equal(original.Payload, copy.Payload);
    }
}
