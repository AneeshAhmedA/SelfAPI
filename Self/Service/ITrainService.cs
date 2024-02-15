using Self.Entity;

namespace Self.Service
{
    public interface ITrainService
    {
        void CreateTrain(Train Train);
        void UpdateTrain(Train train);
        void DeleteTrain(int trainNo);
        Train GetTrainByTrainNo(int trainNo);
        List<Train> GetAllTrains();
    }
}
