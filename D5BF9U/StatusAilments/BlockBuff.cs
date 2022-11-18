using System.Collections.Concurrent;
using System.Data;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public sealed class BlockBuff : IStatusAilment
{
    public string Name => "Block";
    public int DurationMillisec => 200;
    public int MaxTicks => 1;
    public int CurrentTicks { get; set; }
    public bool IsHarmful => false;
    public bool IsDisplayed => true;
    public StatusAilmentTypes[] Types = new[] { StatusAilmentTypes.WhenStruck, StatusAilmentTypes.Immune };

    public DateTime TimeOfAcquisition { get; init; }
    public void RequestAction(ConcurrentQueue<StatusAilmentQue> statusAilmentQues, Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void Activate(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void Deactivate(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }
}