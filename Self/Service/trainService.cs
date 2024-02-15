using Self.Database;
using Self.Entity;

namespace Self.Service
{
    public class trainService : ITrainService
    {
        private readonly MyContext _context;

        public trainService(MyContext context)
        {
            _context = context;
        }

        public void CreateTrain(Train train)
        {
            _context.Trains1.Add(train);
            _context.SaveChanges();
        }

         public void UpdateTrain(Train train)
        {
            _context.Trains1.Update(train);
            _context.SaveChanges();
        }

        public void DeleteTrain(int trainNo)
        {
            var train = _context.Trains1.Find(trainNo);

            if (train != null)
            {
                _context.Trains1.Remove(train);
                _context.SaveChanges();
            }
        }

        public Train GetTrainByTrainNo(int walletId)
        {
            return _context.Trains1.Find(walletId);
        }

        public List<Train> GetAllTrains()
        {
            return _context.Trains1.ToList();
        }

    }
}
