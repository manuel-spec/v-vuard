using VanguardProtocol.Levels.Content;
using VanguardProtocol.Levels.Content.Arenas;
using VanguardProtocol.Physics;
using Xunit;

namespace VanguardProtocol.Levels.Tests;

public class ContentCoverageTests
{

    [Fact]
    public void Chapter01_Stage1_Has_Solid_Floor()
    {
        var level = Chapter01Levels.Stage1();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter01_Stage2_Has_Solid_Floor()
    {
        var level = Chapter01Levels.Stage2();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter01_Stage3_Has_Solid_Floor()
    {
        var level = Chapter01Levels.Stage3();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter01_Stage4_Has_Solid_Floor()
    {
        var level = Chapter01Levels.Stage4();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter02_Stage1_Has_Solid_Floor()
    {
        var level = Chapter02Levels.Stage1();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter02_Stage2_Has_Solid_Floor()
    {
        var level = Chapter02Levels.Stage2();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter02_Stage3_Has_Solid_Floor()
    {
        var level = Chapter02Levels.Stage3();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter02_Stage4_Has_Solid_Floor()
    {
        var level = Chapter02Levels.Stage4();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter03_Stage1_Has_Solid_Floor()
    {
        var level = Chapter03Levels.Stage1();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter03_Stage2_Has_Solid_Floor()
    {
        var level = Chapter03Levels.Stage2();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter03_Stage3_Has_Solid_Floor()
    {
        var level = Chapter03Levels.Stage3();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter03_Stage4_Has_Solid_Floor()
    {
        var level = Chapter03Levels.Stage4();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter04_Stage1_Has_Solid_Floor()
    {
        var level = Chapter04Levels.Stage1();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter04_Stage2_Has_Solid_Floor()
    {
        var level = Chapter04Levels.Stage2();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter04_Stage3_Has_Solid_Floor()
    {
        var level = Chapter04Levels.Stage3();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter04_Stage4_Has_Solid_Floor()
    {
        var level = Chapter04Levels.Stage4();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter05_Stage1_Has_Solid_Floor()
    {
        var level = Chapter05Levels.Stage1();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter05_Stage2_Has_Solid_Floor()
    {
        var level = Chapter05Levels.Stage2();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter05_Stage3_Has_Solid_Floor()
    {
        var level = Chapter05Levels.Stage3();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter05_Stage4_Has_Solid_Floor()
    {
        var level = Chapter05Levels.Stage4();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter06_Stage1_Has_Solid_Floor()
    {
        var level = Chapter06Levels.Stage1();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter06_Stage2_Has_Solid_Floor()
    {
        var level = Chapter06Levels.Stage2();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter06_Stage3_Has_Solid_Floor()
    {
        var level = Chapter06Levels.Stage3();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter06_Stage4_Has_Solid_Floor()
    {
        var level = Chapter06Levels.Stage4();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter07_Stage1_Has_Solid_Floor()
    {
        var level = Chapter07Levels.Stage1();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter07_Stage2_Has_Solid_Floor()
    {
        var level = Chapter07Levels.Stage2();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter07_Stage3_Has_Solid_Floor()
    {
        var level = Chapter07Levels.Stage3();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter07_Stage4_Has_Solid_Floor()
    {
        var level = Chapter07Levels.Stage4();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter08_Stage1_Has_Solid_Floor()
    {
        var level = Chapter08Levels.Stage1();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter08_Stage2_Has_Solid_Floor()
    {
        var level = Chapter08Levels.Stage2();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter08_Stage3_Has_Solid_Floor()
    {
        var level = Chapter08Levels.Stage3();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Chapter08_Stage4_Has_Solid_Floor()
    {
        var level = Chapter08Levels.Stage4();
        Assert.True(level.Tiles.Any(t => (t & TileFlags.Solid) != 0));
        Assert.NotEmpty(level.Spawns);
        Assert.NotEmpty(level.Triggers);
    }

    [Fact]
    public void Arena01_Builds()
    {
        var level = Arena01.Build();
        Assert.Equal("arena_01", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena02_Builds()
    {
        var level = Arena02.Build();
        Assert.Equal("arena_02", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena03_Builds()
    {
        var level = Arena03.Build();
        Assert.Equal("arena_03", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena04_Builds()
    {
        var level = Arena04.Build();
        Assert.Equal("arena_04", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena05_Builds()
    {
        var level = Arena05.Build();
        Assert.Equal("arena_05", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena06_Builds()
    {
        var level = Arena06.Build();
        Assert.Equal("arena_06", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena07_Builds()
    {
        var level = Arena07.Build();
        Assert.Equal("arena_07", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena08_Builds()
    {
        var level = Arena08.Build();
        Assert.Equal("arena_08", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena09_Builds()
    {
        var level = Arena09.Build();
        Assert.Equal("arena_09", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena10_Builds()
    {
        var level = Arena10.Build();
        Assert.Equal("arena_10", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena11_Builds()
    {
        var level = Arena11.Build();
        Assert.Equal("arena_11", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena12_Builds()
    {
        var level = Arena12.Build();
        Assert.Equal("arena_12", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena13_Builds()
    {
        var level = Arena13.Build();
        Assert.Equal("arena_13", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena14_Builds()
    {
        var level = Arena14.Build();
        Assert.Equal("arena_14", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena15_Builds()
    {
        var level = Arena15.Build();
        Assert.Equal("arena_15", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena16_Builds()
    {
        var level = Arena16.Build();
        Assert.Equal("arena_16", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena17_Builds()
    {
        var level = Arena17.Build();
        Assert.Equal("arena_17", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena18_Builds()
    {
        var level = Arena18.Build();
        Assert.Equal("arena_18", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena19_Builds()
    {
        var level = Arena19.Build();
        Assert.Equal("arena_19", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }

    [Fact]
    public void Arena20_Builds()
    {
        var level = Arena20.Build();
        Assert.Equal("arena_20", level.Name);
        Assert.Equal(level.Width * level.Height, level.Tiles.Length);
    }
}
