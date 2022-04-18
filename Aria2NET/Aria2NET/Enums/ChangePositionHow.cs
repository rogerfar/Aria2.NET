namespace Aria2NET;

public enum ChangePositionHow
{
    /// <summary>
    ///     Move the download to a position relative to the beginning of the queue.
    /// </summary>
    FromBeginning,

    /// <summary>
    ///     Move the download to a position relative to the current position.
    /// </summary>
    FromCurrent,
        
    /// <summary>
    ///     Move the download to a position relative to the end of the queue.
    /// </summary>
    FromEnd
}