
using MyProjectBackend.DTO;


namespace MyProjectBackend.Tests.AdditionalLogic.EqualityComparers;

internal class MatchEqualityComparer : BaseEqualityComparer<Match>
{
    public override bool Equals(Match? x, Match? y) 
        => base.Equals(x, y) && x!.User1Id == y!.User1Id && x.User2Id == y.User2Id && x.Id == y.Id && x.StartDate == y.StartDate;
}
