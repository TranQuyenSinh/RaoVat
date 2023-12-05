namespace App.RequestModels;

public class ApproveAdModel
{
    public int AdId { get; set; }
    public int ApproveStatus { get; set; }
    public string? RejectReason { get; set; }
}