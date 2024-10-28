using eHnue.Shared.Models;

namespace eHnue.Server.Interfaces
{
    public interface IPurpose
    {
        public List<Purpose> GetPurposeDetails();
        public void AddPurpose(Purpose purpose);
        public void UpdatePurposeDetails(Purpose purpose);
        public Purpose GetPurposeData(int id);
        public void DeletePurpose(int id);
        
    }
}
