using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    public class MarkRentalAllocationAsDispatched: ICommand
    {
        public string PickerName { get; set; }
        public int DvdId { get; set; }
        public string FulfilmentRequestId { get; set; }
    }
}