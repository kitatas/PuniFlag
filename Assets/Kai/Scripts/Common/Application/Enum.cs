namespace Kai.Common.Application
{
    public enum BgmType
    {
        Title = 0,
        Main = 1,
        Result = 2,
    }

    public enum SeType
    {
        Decision = 0,
        Cancel = 1,
        Transition = 2,
        StageClear = 3,
        LevelUp = 4,
        GameClear = 5,
    }

    public enum ButtonType
    {
        Decision,
        Cancel,
    }

    public enum LoadType
    {
        Direct,
        Next,
        Reload,
    }

    public enum SceneName
    {
        Title,
        Main,
        Ranking,
    }

    public enum GameType
    {
        None,
        ScoreAttack,
        FreePlay,
    }

    public enum LanguageType
    {
        Japanese,
        English,
    }

    public enum ExplainType
    {
        None,
        Gravity,
        Rotate,
        Move,
        Reset,
        Step,
        Flag,
    }
}