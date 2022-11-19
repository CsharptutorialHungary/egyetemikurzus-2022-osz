using System.Collections.Concurrent;
using System.Data.SqlTypes;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public sealed class CounterBuff : IStatusAilment
{
    public string Name => "Counter";
    public int DurationMillisec => 1000;
    public int? MaxTicks => 1;
    public int CurrentTicks { get; set; }
    public int CounterValue { get; }
    public bool IsHarmful => false;
    public bool IsDisplayed => true;
    public StatusAilmentTypes[] Types => new[] { StatusAilmentTypes.OnSkillUse };
    public DateTime TimeOfAcquisition { get; init; }


    CounterBuff(int blockedValue)
    {
        CurrentTicks = 1;
        TimeOfAcquisition = new DateTime();
        TimeOfAcquisition = DateTime.Now;
        CounterValue = blockedValue * 3;
    }
    public void RequestAction(ConcurrentQueue<StatusAilmentQue> statusAilmentQues, Creature self, Creature target)
    {
        StatusAilmentQue ailmentQue = new StatusAilmentQue(this, self, target);
        statusAilmentQues.Enqueue(ailmentQue);
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