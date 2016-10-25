
using DVDRenatal.Infrastructure.CommandProcessor;

namespace DVDRental.Fulfillment.ApplicationService.BusinessUseCases
{
    /// <summary>
    /// 选择分配租借请求
    /// </summary>
    public class AssignRentalAllocationsToPicker: ICommand
    {
        public string PickerName { get; set; }
    }
}