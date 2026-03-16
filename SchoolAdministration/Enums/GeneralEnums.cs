internal enum ClassScheduleStatus : byte
{
    Planned = 1,
    Ongoing = 2,
    Completed = 3,
    Cancelled = 4
}

internal enum ParentRelationship : byte
{
    Father = 1,
    Mother = 2,
    Guardian = 3,
    Grandfather = 4,
    Grandmother = 5,
    Other = 6
}

internal enum MessageType : byte
{
    SMS = 0,
    Email = 1
}
internal enum MessageWeight : byte
{
    Normal = 0,
    Important = 1,
    Urgent = 2
}