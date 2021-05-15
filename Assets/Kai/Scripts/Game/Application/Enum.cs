namespace Kai.Game.Application
{
    public enum StageObjectType
    {
        None = 0,
        Player = 1,
        Flag = 2,
        Block = 3,
    }

    public enum ColorType
    {
        None = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
    }

    public enum InputType
    {
        None = 0,
        MoveLeft = 1,
        MoveRight = 2,
        RotateLeft = 3,
        RotateRight = 4,
    }

    public enum GameState
    {
        None,
        Input,
        Move,
        Clear,
    }
}