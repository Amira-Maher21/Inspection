namespace Inspection.Domain.Event
{
    public interface IPostingLineEntity
    {
        long Id { get; }
        long? OperationId { get; }
        long? WBSId { get; }
        long? CostCodeId { get; }
        long? ActivityId { get; }
        long? BOQLineId { get; }
        long? SubcontractBOQId { get; }
        long? ProductionOrderId { get; }

    }
}
