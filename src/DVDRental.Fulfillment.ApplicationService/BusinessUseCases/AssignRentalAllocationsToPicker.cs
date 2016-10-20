
using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    public class AssignRentalAllocationsToPicker: ICommand
    {
        public string PickerName { get; set; }
    }
}