using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    /// <summary>
    /// 标记租借请求的Dvd已派送
    /// </summary>
    public class MarkRentalAllocationAsDispatched: ICommand
    {
        public string PickerName { get; set; }
        public int DvdId { get; set; }
        public string FulfilmentRequestId { get; set; }
    }
}